namespace EAExport.Model
{
    using System;

    /// <summary>
    /// The output Format Type.
    /// </summary>
    public enum FormatType
    {
        /// <summary>
        /// Convert to Comma Separated Values format with HTML content.
        /// </summary>
        CsvHtml,

        /// <summary>
        /// Convert to Comma Separated values format with Plain Text.
        /// </summary>
        CsvText,

        /// <summary>
        /// Convert to DocBook 4.5 fragment with Chapters.
        /// </summary>
        DB45Chapters
    }
}
