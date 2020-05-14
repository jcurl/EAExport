namespace EAExport
{
    using System.Diagnostics;
    using System.Xml;

    public static class EATrace
    {
        private static TraceSource s_XmiImport = new TraceSource("EAExport.XmiImport");

        public static string XmiImport(TraceEventType eventType, string message)
        {
            return XmiImport(null, eventType, message);
        }

        public static string XmiImport(XmlReader xmlReader, TraceEventType eventType, string message)
        {
            return XmiImport(xmlReader, eventType, "{0}", message);
        }

        public static string XmiImport(TraceEventType eventType, string format, params object[] args)
        {
            return XmiImport(null, eventType, format, args);
        }

        public static string XmiImport(XmlReader xmlReader, TraceEventType eventType, string format, params object[] args)
        {
            string message = string.Format(format, args);
            if (xmlReader is XmlTextReader xmlTextReader) {
                s_XmiImport.TraceEvent(eventType, 0, "XML ({0},{1}) {2}", xmlTextReader.LineNumber, xmlTextReader.LinePosition, message);
            } else {
                s_XmiImport.TraceEvent(eventType, 0, message);
            }
            return message;
        }
    }
}
