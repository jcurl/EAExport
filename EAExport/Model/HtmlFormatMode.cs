﻿namespace EAExport.Model
{
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
        UnorderedList,

        /// <summary>
        /// The current formatting is for a list item
        /// </summary>
        ListItem
    }
}
