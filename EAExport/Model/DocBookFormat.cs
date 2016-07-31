namespace EAExport.Model
{
    using System;

    /// <summary>
    /// State while parsing HTML for DocBook 4.5 conversion.
    /// </summary>
    public class DocBookFormat
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocBookFormat"/> class.
        /// </summary>
        public DocBookFormat()
        {
            SectionDepth = 0;
            Mode = HtmlFormatMode.None;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocBookFormat"/> class.
        /// </summary>
        /// <param name="sectionDepth">The section depth.</param>
        /// <param name="mode">The mode.</param>
        public DocBookFormat(int sectionDepth, HtmlFormatMode mode)
        {
            SectionDepth = sectionDepth;
            Mode = mode;
        }

        /// <summary>
        /// The current section level depth.
        /// </summary>
        /// <value>The section depth. A value of 0 indicates top level.</value>
        public int SectionDepth { get; set; }

        /// <summary>
        /// Gets or sets the current formatting mode.
        /// </summary>
        /// <value>The mode.</value>
        public HtmlFormatMode Mode { get; set; }
    }
}
