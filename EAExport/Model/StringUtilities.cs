namespace EAExport.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Linq;

    public static class StringUtilities
    {
        public static string SearchAndReplace(string text, Dictionary<string, string> conversions)
        {
            if (string.IsNullOrEmpty(text)) return text;
            if (conversions == null) throw new ArgumentNullException("conversions");

            //return conversions.Aggregate(text, (current, replacement) => current.Replace(replacement.Key, replacement.Value));

            Regex regex = new Regex(String.Join("|", conversions.Keys.Select(k => Regex.Escape(k))));
            return regex.Replace(text, m => conversions[m.Value]);
        }
    }
}
