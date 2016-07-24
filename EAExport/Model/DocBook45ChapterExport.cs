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

        /// <summary>
        /// Exports the tree.
        /// </summary>
        /// <param name="root">The root element.</param>
        /// <param name="includeRoot">if set to <c>true</c> the also export the root element, else
        /// if set to <c>false</c>, then the children are exported.</param>
        public void ExportTree(EATree root, bool includeRoot)
        {
            ExportElement(root, includeRoot, new DocBookFormat());
        }

        private void ExportElement(EATree element, bool includeElement, DocBookFormat format)
        {
            if (includeElement) {
                string heading = (element.Heading == null) ? string.Empty : element.Heading.Trim();
                string text = (element.Text == null) ? string.Empty : element.Text.Trim();

                // Parse the text as HTML and strip all formatting
                string convertedTitle = HtmlEntity.DeEntitize(heading);

                // Write the section and the title for the section
                if (format.SectionDepth == 0) {
                    m_XmlWriter.WriteStartElement("chapter");
                } else {
                    m_XmlWriter.WriteStartElement("section");
                }
                format.SectionDepth++;

                m_XmlWriter.WriteStartElement("title");
                m_XmlWriter.WriteValue(convertedTitle);
                m_XmlWriter.WriteEndElement();

                ConvertHtmlToDocBook45(format, text);
            }

            foreach (EATree child in element.Children) {
                ExportElement(child, true, format);
            }

            if (includeElement) {
                format.SectionDepth--;
                m_XmlWriter.WriteEndElement();
            }
        }

        private void ConvertHtmlToDocBook45(DocBookFormat format, string text)
        {
            if (!string.IsNullOrWhiteSpace(text)) {
                m_XmlWriter.WriteStartElement("para");

                HtmlDocument html = new HtmlDocument();
                html.LoadHtml(text);
                ParseHtml(format, html.DocumentNode);

                m_XmlWriter.WriteEndElement();
            }
        }

        private void ParseHtml(DocBookFormat format, HtmlNode node)
        {
            string html;
            switch (node.NodeType) {
            case HtmlNodeType.Comment:
                // Don't output comments
                break;
            case HtmlNodeType.Document:
                ParseHtmlChildren(format, node);
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

                m_XmlWriter.WriteValue(html);
                break;
            case HtmlNodeType.Element:
                DocBookFormat nextFormat = format;

                switch (node.Name) {
                case "p":
                    //sb.Append(Environment.NewLine);

                    // End all elements, until we get to the paragraph
                    // Then end the paragraph and start a new one.
                    m_XmlWriter.WriteComment("p");
                    break;
                case "ol":
                    //nextFormat = new DocBookFormat(HtmlFormatMode.OrderedList);
                    //nextFormat.Indent = format.Indent + 1;
                    m_XmlWriter.WriteComment("ol");
                    break;
                case "ul":
                    //nextFormat = new DocBookFormat(HtmlFormatMode.UnorderedList);
                    //nextFormat.Indent = format.Indent + 1;
                    m_XmlWriter.WriteComment("ul");
                    break;
                case "li":
                    //nextFormat.Counter = nextFormat.Counter + 1;
                    //sb.Append(' ', nextFormat.Indent);
                    //switch (nextFormat.Mode) {
                    //case HtmlFormatMode.OrderedList:
                    //    sb.Append(string.Format("{0}. ", nextFormat.Counter));
                    //    break;
                    //case HtmlFormatMode.UnorderedList:
                    //    sb.Append("* ");
                    //    break;
                    //}
                    m_XmlWriter.WriteComment("li");
                    break;
                }

                if (node.HasChildNodes) {
                    ParseHtmlChildren(nextFormat, node);
                }
                break;
            }
        }

        private void ParseHtmlChildren(DocBookFormat format, HtmlNode node)
        {
            foreach (HtmlNode child in node.ChildNodes) {
                ParseHtml(format, child);
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
