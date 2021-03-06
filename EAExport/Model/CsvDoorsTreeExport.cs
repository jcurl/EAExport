﻿namespace EAExport.Model
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Class to export the EATree objects in a CSV file for DOORs import.
    /// </summary>
    public class CsvDoorsTreeExport : ITreeExport
    {
        private readonly StreamWriter m_Writer;
        private readonly Dictionary<string, string> m_Conversions = new Dictionary<string, string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CsvDoorsTreeExport"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file to export to.</param>
        public CsvDoorsTreeExport(string fileName)
        {
            m_Writer = new StreamWriter(fileName, false, Encoding.GetEncoding("iso-8859-15"), 4096);
            m_Writer.WriteLine("EAID;EAParent;Heading;Text");

            m_Conversions.Add("\"", "\"\"");
            m_Conversions.Add("&gt;", ">");
            m_Conversions.Add("&lt;", "<");
            m_Conversions.Add("&amp;", "&");
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
                m_Writer.WriteLine("{0};{1};\"{2}\";\"{3}\"",
                    element.Id, parentId,
                    StringUtilities.SearchAndReplace(heading, m_Conversions),
                    StringUtilities.SearchAndReplace(text, m_Conversions));
            }

            foreach (EATree child in element.Children) {
                ExportElement(child, true, includeElement ? element.Id : string.Empty);
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
