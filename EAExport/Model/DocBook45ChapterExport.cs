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
            if (textNode == null) {
                if (element.Children.Count == 0) {
                    textNode = m_XmlDocument.CreateElement("para");
                }
            }
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
            XmlNode xmlParent;

            switch (node.NodeType) {
            case HtmlNodeType.Document:
                ParseHtmlChildren(node, format, xmlNode);
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

                xmlParent = GetParent(xmlNode, "para", "orderedlist", "itemizedlist");
                if (xmlParent == null) {
                    // We're not in an ordered list and we don't have a paragraph set up. So make a new element.
                    XmlElement xmlPara = m_XmlDocument.CreateElement("para");
                    xmlNode.AppendChild(xmlPara);
                    xmlNode = xmlPara;
                    xmlParent = xmlPara;
                }

                if (xmlParent.Name.Equals("para")) {
                    // Only add the the text if we're in a paragraph.
                    xmlNode = ParseHtmlText(html, xmlNode);
                }
                break;

            case HtmlNodeType.Element:
                DocBookFormat nextFormat = format;
                XmlNode nextNode = xmlNode;

                switch (node.Name) {
                case "ol":
                    // Add the ordered list after the previous paragraph if there is one.
                    xmlParent = GetParent(xmlNode, "para");
                    if (xmlParent != null) xmlNode = xmlParent.ParentNode;
                    nextFormat = new DocBookFormat(format.SectionDepth, HtmlFormatMode.OrderedList);
                    nextNode = m_XmlDocument.CreateElement("orderedlist");
                    xmlNode.AppendChild(nextNode);
                    break;
                case "ul":
                    xmlParent = GetParent(xmlNode, "para");
                    if (xmlParent != null) xmlNode = xmlParent.ParentNode;
                    nextFormat = new DocBookFormat(format.SectionDepth, HtmlFormatMode.UnorderedList);
                    nextNode = m_XmlDocument.CreateElement("itemizedlist");
                    xmlNode.AppendChild(nextNode);
                    break;
                case "li":
                    nextFormat = new DocBookFormat(format.SectionDepth, HtmlFormatMode.ListItem);
                    XmlElement xmlListItem = m_XmlDocument.CreateElement("listitem");
                    XmlElement xmlPara = m_XmlDocument.CreateElement("para");
                    xmlListItem.AppendChild(xmlPara);
                    xmlNode.AppendChild(xmlListItem);
                    nextNode = xmlPara;
                    break;
                case "u":
                    XmlElement xmlUnderline = m_XmlDocument.CreateElement("emphasis");
                    XmlAttribute xmlUnderlineAttr = m_XmlDocument.CreateAttribute("role");
                    xmlUnderlineAttr.Value = "underline";
                    xmlUnderline.Attributes.Append(xmlUnderlineAttr);
                    xmlNode.AppendChild(xmlUnderline);
                    nextNode = xmlUnderline;
                    break;
                case "i":
                    XmlElement xmlItalic = m_XmlDocument.CreateElement("emphasis");
                    xmlNode.AppendChild(xmlItalic);
                    nextNode = xmlItalic;
                    break;
                case "b":
                    XmlElement xmlBold = m_XmlDocument.CreateElement("emphasis");
                    XmlAttribute xmlBoldAttr = m_XmlDocument.CreateAttribute("role");
                    xmlBoldAttr.Value = "bold";
                    xmlBold.Attributes.Append(xmlBoldAttr);
                    xmlNode.AppendChild(xmlBold);
                    nextNode = xmlBold;
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

        private XmlNode GetParent(XmlNode node, string element)
        {
            while (node != null) {
                if (node.NodeType == XmlNodeType.Element && node.Name.Equals(element)) return node;
                node = node.ParentNode;
            }
            return null;
        }

        private XmlNode GetParent(XmlNode node, params string[] elements)
        {
            while (node != null) {
                if (node.NodeType == XmlNodeType.Element) {
                    foreach (string element in elements) {
                        if (node.Name.Equals(element)) return node;
                    }
                }
                node = node.ParentNode;
            }
            return null;
        }

        private XmlNode ParseHtmlText(string htmlText, XmlNode node)
        {
            string[] paragraphs = htmlText.Split('\n', '\r');
            if (paragraphs.Length == 0) return node;

            XmlNode xmlTopPara = GetParent(node, "para");
            if (xmlTopPara == null) throw new ApplicationException("Not in a paragraph");

            bool inParagraph = true;
            XmlNode origNode = node;
            foreach (string paragraph in paragraphs) {
                string normalizedParagraph = paragraph.Trim();
                if (normalizedParagraph.Length > 0) {
                    if (!inParagraph) {
                        // Here we construct a new paragraph and reset the formatting based on origNode
                        XmlNode xmlCursor = origNode;
                        XmlNode xmlPara = null;
                        while (xmlCursor != null) {
                            XmlNode xmlSubElement = m_XmlDocument.CreateElement(xmlCursor.Name);
                            if (xmlPara == null) {
                                xmlPara = xmlSubElement;
                                node = xmlSubElement;
                            } else {
                                xmlSubElement.AppendChild(xmlPara);
                                xmlPara = xmlSubElement;
                            }
                            if (xmlCursor.Name.Equals("para")) {
                                xmlCursor = null;
                            } else {
                                xmlCursor = xmlCursor.ParentNode;
                            }
                        }
                        xmlTopPara.ParentNode.AppendChild(xmlPara);
                    }
                    XmlText xmlText = m_XmlDocument.CreateTextNode(paragraph);
                    node.AppendChild(xmlText);
                    inParagraph = false;
                }
            }
            return node;
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
