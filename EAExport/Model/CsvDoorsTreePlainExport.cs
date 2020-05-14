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
        private Stream m_WriteStream;
        private bool m_OwnsStream;
        private Encoding m_Encoding = Encoding.GetEncoding("iso-8859-15");
        private byte[] m_NewLine;

        /// <summary>
        /// Initializes a new instance of the <see cref="CsvDoorsTreePlainExport"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file to export to.</param>
        public CsvDoorsTreePlainExport(string fileName)
        {
            m_WriteStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
            m_OwnsStream = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CsvDoorsTreePlainExport"/> class.
        /// </summary>
        /// <param name="writer">The writer.</param>
        public CsvDoorsTreePlainExport(Stream stream)
        {
            m_WriteStream = stream;
        }

        private void Write(string text)
        {
            byte[] buffer = m_Encoding.GetBytes(text);
            m_WriteStream.Write(buffer, 0, buffer.Length);
        }

        private void Write(string format, params object[] args)
        {
            string text = string.Format(format, args);
            Write(text);
        }

        private void WriteLine(string text)
        {
            Write(text);
            if (m_NewLine == null) {
                m_NewLine = m_Encoding.GetBytes(Environment.NewLine);
            }
            m_WriteStream.Write(m_NewLine, 0, m_NewLine.Length);
        }

        private void WriteEscaped(string text)
        {
            byte[] buffer = m_Encoding.GetBytes(text);
            int p = 0;
            for (int i = 0; i < buffer.Length; i++) {
                if (buffer[i] == (byte)'"') {
                    m_WriteStream.Write(buffer, p, i - p + 1);
                    m_WriteStream.Write(buffer, i, 1);
                    p = i + 1;
                }
            }
            if (p < buffer.Length) {
                m_WriteStream.Write(buffer, p, buffer.Length - p);
            }
        }

        /// <summary>
        /// Exports the tree.
        /// </summary>
        /// <param name="root">The root element.</param>
        /// <param name="includeRoot">if set to <c>true</c> the also export the root element, else
        /// if set to <c>false</c>, then the children are exported.</param>
        public void ExportTree(EATree root, bool includeRoot)
        {
            WriteLine("EAID;EAParent;Heading;Text");
            ExportElement(root, includeRoot, root.Id);
        }

        private void ExportElement(EATree element, bool includeElement, string parentId)
        {
            if (includeElement) {
                string heading = (element.Heading == null) ? string.Empty : element.Heading.Trim();
                string text = (element.Text == null) ? string.Empty : element.Text.Trim();

                if (text != null) {
                    // Parse the text as HTML and strip all formatting
                    string convertedTitle = ConvertHtmlToPlainText(new HtmlFormatPlainText(HtmlFormatMode.None), heading);
                    string convertedText = ConvertHtmlToPlainText(new HtmlFormatPlainText(HtmlFormatMode.None), text);
                    Write("{0};{1};", element.Id, parentId);
                    Write("\"");
                    if (convertedTitle != null) WriteEscaped(convertedTitle);
                    Write("\";\"");
                    if (convertedText != null) WriteEscaped(convertedText);
                    WriteLine("\"");
                }
            }

            foreach (EATree child in element.Children) {
                ExportElement(child, true, includeElement ? element.Id : string.Empty);
            }
        }

        private string ConvertHtmlToPlainText(HtmlFormatPlainText format, string text)
        {
            StringBuilder sb = new StringBuilder();
            HtmlDocument html = new HtmlDocument();

            html.LoadHtml(text);
            ParseHtml(format, html.DocumentNode, sb);

            return TrimLines(sb.ToString());
        }

        private string TrimLines(string text)
        {
            string[] lines = text.Split(new char[] { '\n' });

            StringBuilder sb = new StringBuilder();
            bool firstLine = true;
            foreach (string line in lines) {
                if (!firstLine) sb.Append('\n');
                sb.Append(line.TrimEnd());
                firstLine = false;
            }
            return sb.ToString();
        }

        private void ParseHtml(HtmlFormatPlainText format, HtmlNode node, StringBuilder sb)
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
                HtmlFormatPlainText nextFormat = format;

                switch (node.Name) {
                case "p":
                    sb.Append(Environment.NewLine);
                    break;
                case "ol":
                    nextFormat = new HtmlFormatPlainText(HtmlFormatMode.OrderedList) {
                        Indent = format.Indent + 1
                    };
                    break;
                case "ul":
                    nextFormat = new HtmlFormatPlainText(HtmlFormatMode.UnorderedList) {
                        Indent = format.Indent + 1
                    };
                    break;
                case "li":
                    nextFormat.Counter += 1;
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

        private void ParseHtmlChildren(HtmlFormatPlainText format, HtmlNode node, StringBuilder sb)
        {
            foreach (HtmlNode child in node.ChildNodes) {
                ParseHtml(format, child, sb);
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
                if (m_OwnsStream) m_WriteStream.Close();
            }
        }
    }
}
