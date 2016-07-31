namespace EAExport.Model
{
    using System;


    /// <summary>
    /// Formatting State Object.
    /// </summary>
    public class HtmlFormatPlainText
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlFormatPlainText"/> class.
        /// </summary>
        /// <param name="mode">The mode.</param>
        public HtmlFormatPlainText(HtmlFormatMode mode)
        {
            Mode = mode;
        }

        public HtmlFormatMode Mode { get; private set; }

        /// <summary>
        /// Gets or sets the indent in number of tabs.
        /// </summary>
        /// <value>The indent as the number of tabs.</value>
        /// <remarks>
        /// The indent is the amount of indenting from the left
        /// at the beginning of each block, based on the elements
        /// previous.
        /// </remarks>
        public int Indent { get; set; }

        /// <summary>
        /// Gets or sets the counter for list items.
        /// </summary>
        /// <value>The counter for list items.</value>
        /// <remarks>
        /// The current counter for list items, when parsing ordered lists.
        /// </remarks>
        public int Counter { get; set; }
    }
}
