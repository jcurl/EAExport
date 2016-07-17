using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using HtmlAgilityPack;

namespace EAExport.Model
{
    /// <summary>
    /// Class to export the EATree objects in a CSV file for DOORs import.
    /// </summary>
    public class CsvDoorsTreePlainExport : ITreeExport
    {
        private readonly StreamWriter m_Writer;

        /// <summary>
        /// Initializes a new instance of the <see cref="CsvDoorsTreeExport"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file to export to.</param>
        public CsvDoorsTreePlainExport(string fileName)
        {
            m_Writer = new StreamWriter(fileName);
            m_Writer.WriteLine("EAID;EAParent;Heading;Text");
        }

        /// <summary>
        /// Exports the tree.
        /// </summary>
        /// <param name="root">The root element.</param>
        /// <param name="includeRoot">if set to <c>true</c> the also export the root element, else
        /// if set to <c>false</c>, then the children are exported.</param>
        public void ExportTree(EATree root, bool includeRoot)
        {
            ExportElement(root, includeRoot, root.Id);
        }

        private void ExportElement(EATree element, bool includeElement, string parentId)
        {
            if (includeElement) {
                string heading = (element.Heading == null) ? string.Empty : element.Heading.Trim();
                string text = (element.Text == null) ? string.Empty : element.Text.Trim();

                if (text != null) {
                    // Parse the text as HTML and strip all formatting
                    string convertedText = ConvertHtmlToPlainText(text);
                    m_Writer.WriteLine("{0};{1};\"{2}\";\"{3}\"",
                        element.Id,
                        includeElement ? parentId : string.Empty,
                        heading != null ? heading : string.Empty,
                        convertedText != null ? convertedText : string.Empty);
                }
            }

            foreach (EATree child in element.Children) {
                ExportElement(child, true, includeElement ? element.Id : string.Empty);
            }
        }

        private string ConvertHtmlToPlainText(string text)
        {
            StringBuilder sb = new StringBuilder();
            HtmlDocument html = new HtmlDocument();

            html.LoadHtml(text);
            ParseHtml(html.DocumentNode, sb);

            return sb.ToString();
        }

        private void ParseHtml(HtmlNode node, StringBuilder sb)
        {
            string html;
            switch (node.NodeType) {
            case HtmlNodeType.Comment:
                // Don't output comments
                break;
            case HtmlNodeType.Document:
                ParseHtmlChildren(node, sb);
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
                
                sb.Append(HtmlEntity.DeEntitize(html));
                break;
            case HtmlNodeType.Element:
                switch (node.Name) {
                case "p":
                    sb.Append(Environment.NewLine);
                    break;
                }
                if (node.HasChildNodes) {
                    ParseHtmlChildren(node, sb);
                }
                break;
            }
        }

        private void ParseHtmlChildren(HtmlNode node, StringBuilder sb)
        {
            foreach (HtmlNode child in node.ChildNodes) {
                ParseHtml(child, sb);
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
                m_Writer.Dispose();
            }
        }
    }
}
