namespace EAExport.Model
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;
    using HtmlAgilityPack;

    /// <summary>
    /// Converts the text to a DocBook 4.5 fragment with the base element of "chapter" and then "section".
    /// </summary>
    /// <seealso cref="EAExport.Model.ITreeExport" />
    public class DocBook45ChapterExport : ITreeExport
    {
        private bool m_OwnWriter;
        private XmlWriter m_XmlWriter;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocBook45ChapterExport"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public DocBook45ChapterExport(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.ConformanceLevel = ConformanceLevel.Fragment;
            xmlSettings.CloseOutput = true;
            xmlSettings.Indent = true;
            xmlSettings.NewLineHandling = NewLineHandling.Entitize;
            xmlSettings.Indent = true;

            m_XmlWriter = XmlWriter.Create(fs, xmlSettings);
            m_OwnWriter = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocBook45ChapterExport"/> class.
        /// </summary>
        /// <param name="xmlWriter">The XML writer.</param>
        public DocBook45ChapterExport(XmlWriter xmlWriter)
        {
            m_XmlWriter = xmlWriter;
        }

        XmlDocument m_XmlDocument;

        /// <summary>
        /// Exports the tree.
        /// </summary>
        /// <param name="root">The root element.</param>
        /// <param name="includeRoot">if set to <c>true</c> the also export the root element, else
        /// if set to <c>false</c>, then the children are exported.</param>
        public void ExportTree(EATree root, bool includeRoot)
        {
            m_XmlDocument = new XmlDocument();
            XmlDocumentFragment xmlFragment = m_XmlDocument.CreateDocumentFragment();

            DocBookFormat format = new DocBookFormat();
            if (includeRoot) {
                XmlNode xnode = ExportElement(root, format);
                xmlFragment.AppendChild(xnode);
            } else {
                foreach (EATree child in root.Children) {
                    XmlNode xnode = ExportElement(child, format);
                    xmlFragment.AppendChild(xnode);
                }
            }
            xmlFragment.WriteContentTo(m_XmlWriter);
        }

        private XmlNode ExportElement(EATree element, DocBookFormat format)
        {
            XmlElement xmlSectionElement;
            if (format.SectionDepth == 0) {
                xmlSectionElement = m_XmlDocument.CreateElement("chapter");
            } else {
                xmlSectionElement = m_XmlDocument.CreateElement("section");
            }

            format.SectionDepth++;
            string heading = (element.Heading == null) ? string.Empty : element.Heading.Trim();
            XmlElement xmlTitleElement = m_XmlDocument.CreateElement("title");
            XmlText xmlTitleText = m_XmlDocument.CreateTextNode(HtmlEntity.DeEntitize(heading));
            xmlTitleElement.AppendChild(xmlTitleText);
            xmlSectionElement.AppendChild(xmlTitleElement);

            string text = (element.Text == null) ? string.Empty : element.Text.Trim();
            XmlNode textNode = ConvertHtmlToDocBook45(text, format);
            if (textNode != null) xmlSectionElement.AppendChild(textNode);

            foreach (EATree child in element.Children) {
                XmlNode xmlChild = ExportElement(child, format);
                xmlSectionElement.AppendChild(xmlChild);
            }

            format.SectionDepth--;
            return xmlSectionElement;
        }

        private XmlNode ConvertHtmlToDocBook45(string text, DocBookFormat format)
        {
            if (!string.IsNullOrWhiteSpace(text)) {

                HtmlDocument html = new HtmlDocument();
                html.LoadHtml(text);
                XmlDocumentFragment xmlFragment = m_XmlDocument.CreateDocumentFragment();
                return ParseHtml(html.DocumentNode, format, xmlFragment);
            }
            return null;
        }

        private XmlNode ParseHtml(HtmlNode node, DocBookFormat format, XmlNode xmlNode)
        {
            string html;
            switch (node.NodeType) {
            case HtmlNodeType.Document:
                ParseHtmlChildren(node, format, xmlNode);
                format.InParagraph = false;
                break;
            case HtmlNodeType.Comment:
                // Don't output comments
                break;
            case HtmlNodeType.Text:
                string parentName = node.ParentNode.Name;
                if (parentName.Equals("script") || parentName.Equals("style")) {
                    // Ignore scripts and styles
                    break;
                }

                html = ((HtmlTextNode)node).Text;

                if (HtmlNode.IsOverlappedClosingElement(html)) {
                    // Is it in fact a special closing node output as text?
                    break;
                }

                if (!format.InParagraph && 
                    format.Mode != HtmlFormatMode.OrderedList && format.Mode != HtmlFormatMode.UnorderedList) {
                    format.InParagraph = true;
                    XmlElement xmlPara = m_XmlDocument.CreateElement("para");
                    xmlNode.AppendChild(xmlPara);
                    xmlNode = xmlPara;
                }

                if (format.Mode != HtmlFormatMode.OrderedList && format.Mode != HtmlFormatMode.UnorderedList) {
                    // Only add the text if we're not in an ordered list without a list element.
                    XmlText xmlParaText = m_XmlDocument.CreateTextNode(html);
                    xmlNode.AppendChild(xmlParaText);
                }
                break;

            case HtmlNodeType.Element:
                DocBookFormat nextFormat = format;
                XmlNode nextNode = xmlNode;

                switch (node.Name) {
                case "p":
                    // TODO
                    break;

                case "ol":
                    // Close the previous paragraph
                    if (format.InParagraph) {
                        while (xmlNode != null &&
                            (xmlNode.NodeType != XmlNodeType.Element || !xmlNode.Name.Equals("para"))) {
                            xmlNode = xmlNode.ParentNode;
                        }
                        xmlNode = xmlNode.ParentNode;
                    }

                    nextFormat = new DocBookFormat(format.SectionDepth, HtmlFormatMode.OrderedList);
                    nextFormat.InParagraph = false;
                    nextNode = m_XmlDocument.CreateElement("orderedlist");
                    xmlNode.AppendChild(nextNode);
                    format.InParagraph = false;
                    break;
                case "ul":
                    // Close the previous paragraph
                    if (format.InParagraph) {
                        while (xmlNode != null &&
                            (xmlNode.NodeType != XmlNodeType.Element || !xmlNode.Name.Equals("para"))) {
                            xmlNode = xmlNode.ParentNode;
                        }
                        xmlNode = xmlNode.ParentNode;
                    }

                    nextFormat = new DocBookFormat(format.SectionDepth, HtmlFormatMode.UnorderedList);
                    nextFormat.InParagraph = false;
                    nextNode = m_XmlDocument.CreateElement("itemizedlist");
                    xmlNode.AppendChild(nextNode);
                    format.InParagraph = false;
                    break;
                case "li":
                    nextFormat = new DocBookFormat(format.SectionDepth, HtmlFormatMode.ListItem);
                    XmlElement xmlListItem = m_XmlDocument.CreateElement("listitem");
                    XmlElement xmlPara = m_XmlDocument.CreateElement("para");
                    nextFormat.InParagraph = true;
                    xmlListItem.AppendChild(xmlPara);
                    xmlNode.AppendChild(xmlListItem);
                    nextNode = xmlPara;
                    break;
                }

                if (node.HasChildNodes) {
                    ParseHtmlChildren(node, nextFormat, nextNode);
                }
                break;
            }

            return xmlNode;
        }

        private void ParseHtmlChildren(HtmlNode node, DocBookFormat format, XmlNode xmlNode)
        {
            foreach (HtmlNode child in node.ChildNodes) {
                xmlNode = ParseHtml(child, format, xmlNode);
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources;
        /// <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing) {
                if (m_XmlWriter != null && m_OwnWriter) m_XmlWriter.Close();
                m_XmlWriter = null;
            }
        }
    }
}
