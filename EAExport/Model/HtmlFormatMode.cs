namespace EAExport.Model
{
    using System;

    /// <summary>
    /// HtmlFormatMode.
    /// </summary>
    public enum HtmlFormatMode
    {
        /// <summary>
        /// No special formatting required.
        /// </summary>
        None,

        /// <summary>
        /// The current formatting is for an ordered list.
        /// </summary>
        OrderedList,

        /// <summary>
        /// The current formatting is for an unordered list
        /// </summary>
        UnorderedList
    }
}
