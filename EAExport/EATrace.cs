namespace EAExport
{
    using System;
    using System.Diagnostics;
    using System.Text;
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
            XmlTextReader xmlTextReader = xmlReader as XmlTextReader;
            string message = string.Format(format, args);
            if (xmlTextReader != null) {
                s_XmiImport.TraceEvent(eventType, 0, "XML ({0},{1}) {2}", xmlTextReader.LineNumber, xmlTextReader.LinePosition, message);
            } else {
                s_XmiImport.TraceEvent(eventType, 0, message);
            }
            return message;
        }
    }
}
