namespace EAExport.Model
{
    using System;
    using System.IO;
    using System.Text;
    using HtmlAgilityPack;

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
            m_Writer = new StreamWriter(fileName, false, Encoding.GetEncoding("iso-8859-15"), 4096);
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
                    string convertedTitle = ConvertHtmlToPlainText(new HtmlFormat(HtmlFormatMode.None), heading);
                    string convertedText = ConvertHtmlToPlainText(new HtmlFormat(HtmlFormatMode.None), text);
                    m_Writer.WriteLine("{0};{1};\"{2}\";\"{3}\"",
                        element.Id, parentId,
                        heading != null ? EscapeCsvText(heading) : string.Empty,
                        convertedText != null ? EscapeCsvText(convertedText) : string.Empty);
                }
            }

            foreach (EATree child in element.Children) {
                ExportElement(child, true, includeElement ? element.Id : string.Empty);
            }
        }

        private string ConvertHtmlToPlainText(HtmlFormat format, string text)
        {
            StringBuilder sb = new StringBuilder();
            HtmlDocument html = new HtmlDocument();

            html.LoadHtml(text);
            ParseHtml(format, html.DocumentNode, sb);

            return sb.ToString();
        }

        private void ParseHtml(HtmlFormat format, HtmlNode node, StringBuilder sb)
        {
            string html;
            switch (node.NodeType) {
            case HtmlNodeType.Comment:
                // Don't output comments
                break;
            case HtmlNodeType.Document:
                ParseHtmlChildren(format, node, sb);
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
                HtmlFormat nextFormat = format;

                switch (node.Name) {
                case "p":
                    sb.Append(Environment.NewLine);
                    break;
                case "ol":
                    nextFormat = new HtmlFormat(HtmlFormatMode.OrderedList);
                    nextFormat.Indent = format.Indent + 1;
                    break;
                case "ul":
                    nextFormat = new HtmlFormat(HtmlFormatMode.UnorderedList);
                    nextFormat.Indent = format.Indent + 1;
                    break;
                case "li":
                    nextFormat.Counter = nextFormat.Counter + 1;
                    sb.Append(' ', nextFormat.Indent);
                    switch(nextFormat.Mode) {
                    case HtmlFormatMode.OrderedList:
                        sb.Append(string.Format("{0}. ", nextFormat.Counter));
                        break;
                    case HtmlFormatMode.UnorderedList:
                        sb.Append("* ");
                        break;
                    }
                    break;
                }

                if (node.HasChildNodes) {
                    ParseHtmlChildren(nextFormat, node, sb);
                }
                break;
            }
        }

        private void ParseHtmlChildren(HtmlFormat format, HtmlNode node, StringBuilder sb)
        {
            foreach (HtmlNode child in node.ChildNodes) {
                ParseHtml(format, child, sb);
            }
        }

        private static string EscapeCsvText(string text)
        {
            StringBuilder sb = null;
            int l = text.Length;
            int p = 0;
            while (p < l) {
                int cp = text.IndexOf('"', p);
                if (p == 0 && cp == -1) return text;
                if (sb == null) sb = new StringBuilder();

                if (cp == -1) {
                    sb.Append(text.Substring(p, l - p));
                    p = l;
                } else {
                    sb.Append(text.Substring(p, cp + 1 - p)).Append('"');
                    p = cp + 1;
                }
            }
            return sb == null ? text : sb.ToString();
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
