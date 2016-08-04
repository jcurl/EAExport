namespace EAExport.Model
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// Enterprise Architect Model.
    /// </summary>
    public class EAModel
    {
        private EAModel() { }

        /// <summary>
        /// Loads the EA Model from an XMI file.
        /// </summary>
        /// <param name="fileName">Name of the file to import.</param>
        /// <returns>An EA Model object.</returns>
        public static EAModel LoadXmi(string fileName)
        {
            EAModel model = new EAModel();

            EATrace.XmiImport(TraceEventType.Information, "Time: {0}", DateTime.Now.ToString("G"));
            EATrace.XmiImport(TraceEventType.Information, "Loading file {0}", fileName);
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            using (XmlTextReader xmlReader = new XmlTextReader(fs)) {
                model.LoadXmi(xmlReader);
                model.BuildTree();
                return model;
            }
        }

        #region Load the XMI file
        private void FileFormatException(string format, params object[] args)
        {
            FileFormatException(null, format, args);
        }

        private void FileFormatException(XmlReader xmlReader, string format, params object[] args)
        {
            string message = EATrace.XmiImport(xmlReader, TraceEventType.Warning, format, args);
            throw new FileFormatException(message);
        }

        private void LoadXmi(XmlReader xmlReader)
        {
            while (xmlReader.Read()) {
                switch (xmlReader.NodeType) {
                case XmlNodeType.Element:
                    if (xmlReader.Name.Equals("XMI")) {
                        LoadXmiRoot(xmlReader);
                    } else {
                        xmlReader.Skip();
                    }
                    break;
                case XmlNodeType.EndElement:
                    break;
                }
            }
        }

        private void LoadXmiRoot(XmlReader xmlReader)
        {
            EATrace.XmiImport(xmlReader, TraceEventType.Verbose, "{0}", xmlReader.Name);

            if (!xmlReader["xmi.version"].Equals("1.1")) {
                FileFormatException(xmlReader, "Unexpected version. Got {0}; Expected 1.1", xmlReader["xmi.version"]);
                return;
            }

            if (xmlReader.IsEmptyElement) return;
            string endElement = xmlReader.Name;

            while (xmlReader.Read()) {
                switch (xmlReader.NodeType) {
                case XmlNodeType.Element:
                    // This is where you would add support for more fields in the configuration file
                    if (xmlReader.Name.Equals("XMI.content")) {
                        LoadXmiContent(xmlReader);
                    } else {
                        xmlReader.Skip();
                        break;
                    }
                    break;
                case XmlNodeType.EndElement:
                    if (xmlReader.Name.Equals(endElement)) return;
                    FileFormatException(xmlReader, "Invalid XML format (expected </{0}>)", endElement);
                    return;
                }
            }

            FileFormatException(xmlReader, "Unexpected end of stream");
        }

        private void LoadXmiContent(XmlReader xmlReader)
        {
            EATrace.XmiImport(xmlReader, TraceEventType.Verbose, "{0}", xmlReader.Name);

            if (xmlReader.IsEmptyElement) return;
            string endElement = xmlReader.Name;

            while (xmlReader.Read()) {
                switch (xmlReader.NodeType) {
                case XmlNodeType.Element:
                    // This is where you would add support for more fields in the configuration file
                    if (xmlReader.Name.Equals("UML:Model")) {
                        LoadUmlModel(xmlReader);
                    } else {
                        xmlReader.Skip();
                        break;
                    }
                    break;
                case XmlNodeType.EndElement:
                    if (xmlReader.Name.Equals(endElement)) return;
                    FileFormatException(xmlReader, "Invalid XML format (expected </{0}>)", endElement);
                    return;
                }
            }

            FileFormatException(xmlReader, "Unexpected end of stream");
        }

        private void LoadUmlModel(XmlReader xmlReader)
        {
            EATrace.XmiImport(xmlReader, TraceEventType.Verbose, "{0}", xmlReader.Name);

            EATree element;
            if (Root == null) {
                element = new EATree(xmlReader["xmi.id"], xmlReader["name"], string.Empty, 0);
                Root = element;
                AddElement(element);
            } else {
                // We only support a single model in our XMI for now.
                xmlReader.Skip();
                return;
            }

            if (xmlReader.IsEmptyElement) return;
            string endElement = xmlReader.Name;

            while (xmlReader.Read()) {
                switch (xmlReader.NodeType) {
                case XmlNodeType.Element:
                    // This is where you would add support for more fields in the configuration file
                    if (xmlReader.Name.Equals("UML:Namespace.ownedElement")) {
                        LoadUmlNamespaceOwnedElement(xmlReader, element);
                    } else {
                        xmlReader.Skip();
                        break;
                    }
                    break;
                case XmlNodeType.EndElement:
                    if (xmlReader.Name.Equals(endElement)) return;
                    FileFormatException(xmlReader, "Invalid XML format (expected </{0}>)", endElement);
                    return;
                }
            }

            FileFormatException(xmlReader, "Unexpected end of stream");
        }

        private void LoadUmlNamespaceOwnedElement(XmlReader xmlReader, EATree parent)
        {
            EATrace.XmiImport(xmlReader, TraceEventType.Verbose, "{0}", xmlReader.Name);

            if (xmlReader.IsEmptyElement) return;
            string endElement = xmlReader.Name;

            while (xmlReader.Read()) {
                switch (xmlReader.NodeType) {
                case XmlNodeType.Element:
                    // This is where you would add support for more fields in the configuration file
                    if (xmlReader.Name.Equals("UML:Package")) {
                        LoadUmlPackage(xmlReader, parent);
                    } else if (xmlReader.Name.Equals("UML:Collaboration")) {
                        LoadUmlCollaboration(xmlReader, parent);
                    } else if (xmlReader.Name.Equals("UML:ClassifierRole")) {
                        LoadUmlClassifierRole(xmlReader);
                    } else {
                        xmlReader.Skip();
                        break;
                    }
                    break;
                case XmlNodeType.EndElement:
                    if (xmlReader.Name.Equals(endElement)) return;
                    FileFormatException(xmlReader, "Invalid configuration XML format (expected </{0}>)", endElement);
                    return;
                }
            }

            FileFormatException(xmlReader, "Unexpected end of stream");
        }

        private void LoadUmlPackage(XmlReader xmlReader, EATree parent)
        {
            EATrace.XmiImport(xmlReader, TraceEventType.Verbose, "{0}", xmlReader.Name);

            EATree package = new EATree(parent.Id, xmlReader["xmi.id"], xmlReader["name"], string.Empty, 0);
            AddElement(package);

            if (xmlReader.IsEmptyElement) return;
            string endElement = xmlReader.Name;

            while (xmlReader.Read()) {
                switch (xmlReader.NodeType) {
                case XmlNodeType.Element:
                    // This is where you would add support for more fields in the configuration file
                    if (xmlReader.Name.Equals("UML:ModelElement.taggedValue")) {
                        LoadUmlModelElementTaggedValue(xmlReader, package);
                    } else if (xmlReader.Name.Equals("UML:ModelElement.stereotype")) {
                        LoadUmlModelElementStereotype(xmlReader, package);
                    } else if (xmlReader.Name.Equals("UML:Namespace.ownedElement")) {
                        LoadUmlNamespaceOwnedElement(xmlReader, package);
                    } else {
                        xmlReader.Skip();
                        break;
                    }
                    break;
                case XmlNodeType.EndElement:
                    if (xmlReader.Name.Equals(endElement)) return;
                    FileFormatException(xmlReader, "Invalid configuration XML format (expected </{0}>)", endElement);
                    return;
                }
            }

            FileFormatException(xmlReader, "Unexpected end of stream");
        }

        private void LoadUmlCollaboration(XmlReader xmlReader, EATree parent)
        {
            EATrace.XmiImport(xmlReader, TraceEventType.Verbose, "{0}", xmlReader.Name);

            if (xmlReader.IsEmptyElement) return;
            string endElement = xmlReader.Name;

            while (xmlReader.Read()) {
                switch (xmlReader.NodeType) {
                case XmlNodeType.Element:
                    // This is where you would add support for more fields in the configuration file
                    if (xmlReader.Name.Equals("UML:Namespace.ownedElement")) {
                        LoadUmlNamespaceOwnedElement(xmlReader, parent);
                    } else {
                        xmlReader.Skip();
                        break;
                    }
                    break;
                case XmlNodeType.EndElement:
                    if (xmlReader.Name.Equals(endElement)) return;
                    FileFormatException(xmlReader, "Invalid configuration XML format (expected </{0}>)", endElement);
                    return;
                }
            }

            FileFormatException(xmlReader, "Unexpected end of stream");
        }

        private void LoadUmlClassifierRole(XmlReader xmlReader)
        {
            EATrace.XmiImport(xmlReader, TraceEventType.Verbose, "{0}", xmlReader.Name);

            // We can only tell the parent after parsing the tagged values.
            EATree element = new EATree(xmlReader["xmi.id"], xmlReader["name"], string.Empty, 0);
            AddElement(element);

            if (xmlReader.IsEmptyElement) return;
            string endElement = xmlReader.Name;

            while (xmlReader.Read()) {
                switch (xmlReader.NodeType) {
                case XmlNodeType.Element:
                    // This is where you would add support for more fields in the configuration file
                    if (xmlReader.Name.Equals("UML:ModelElement.taggedValue")) {
                        LoadUmlModelElementTaggedValue(xmlReader, element);
                    } else if (xmlReader.Name.Equals("UML:ModelElement.stereotype")) {
                        LoadUmlModelElementStereotype(xmlReader, element);
                    } else {
                        xmlReader.Skip();
                        break;
                    }
                    break;
                case XmlNodeType.EndElement:
                    if (xmlReader.Name.Equals(endElement)) return;
                    FileFormatException(xmlReader, "Invalid configuration XML format (expected </{0}>)", endElement);
                    return;
                }
            }

            FileFormatException(xmlReader, "Unexpected end of stream");
        }

        private void LoadUmlModelElementTaggedValue(XmlReader xmlReader, EATree parent)
        {
            EATrace.XmiImport(xmlReader, TraceEventType.Verbose, "{0}", xmlReader.Name);

            if (xmlReader.IsEmptyElement) return;
            string endElement = xmlReader.Name;

            string owner = null;
            string package = null;
            string package2 = null;
            string tpos = null;

            while (xmlReader.Read()) {
                switch (xmlReader.NodeType) {
                case XmlNodeType.Element:
                    if (xmlReader.Name.Equals("UML:TaggedValue")) {
                        EATrace.XmiImport(xmlReader, TraceEventType.Verbose, "Tagged Value: {0} = {1}", xmlReader["tag"], xmlReader["value"]);
                        if (xmlReader["tag"].Equals("owner")) {
                            owner = xmlReader["value"];
                        } else if (xmlReader["tag"].Equals("package")) {
                            package = xmlReader["value"];
                        } else if (xmlReader["tag"].Equals("tpos")) {
                            tpos = xmlReader["value"];
                        } else if (xmlReader["tag"].Equals("documentation")) {
                            parent.Text = xmlReader["value"];
                        } else if (xmlReader["tag"].Equals("package2")) {
                            package2 = xmlReader["value"];
                        } else if (xmlReader["tag"].Equals("alias")) {
                            parent.Alias = xmlReader["value"];
                        } else if (xmlReader["tag"].Equals("version")) {
                            parent.Version = xmlReader["value"];
                        } else if (xmlReader["tag"].Equals("author")) {
                            parent.Author = xmlReader["value"];
                        } else if (xmlReader["tag"].Equals("status")) {
                            parent.Status = xmlReader["value"];
                        } else if (xmlReader["tag"].Equals("date_created")) {
                            parent.CreateTime = ConvertDateTime(xmlReader["value"]);
                        } else if (xmlReader["tag"].Equals("date_modified")) {
                            parent.ModifiedTime = ConvertDateTime(xmlReader["value"]);
                        }

                        if (!xmlReader.IsEmptyElement) {
                            xmlReader.Skip();
                        }
                    } else {
                        xmlReader.Skip();
                        break;
                    }
                    break;
                case XmlNodeType.EndElement:
                    if (xmlReader.Name.Equals(endElement)) {
                        if (parent.ParentId == null) {
                            if (owner != null) {
                                parent.ParentId = owner;
                            } else if (package != null) {
                                parent.ParentId = package;
                            }
                        }
                        
                        if (package2 != null) {
                            // In EA, we see a package contains a ClassifierRole object as well as a Package.
                            // We need to filter these ClassifierRole objects out, else they occur twice in
                            // the tree. We assume that 'package2' is the same as the element ID.
                            m_PackageElements.Add(parent.Id, parent);
                        }

                        if (tpos != null) parent.Pos = int.Parse(tpos);
                        return;
                    }
                    FileFormatException(xmlReader, "Invalid configuration XML format (expected </{0}>)", endElement);
                    return;
                }
            }

            FileFormatException(xmlReader, "Unexpected end of stream");
        }

        private DateTime ConvertDateTime(string datetime)
        {
            // 2016-07-25 20:38:16, assumed to be UTC

            if (string.IsNullOrWhiteSpace(datetime)) return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            try {
                int year = int.Parse(datetime.Substring(0, 4));
                int month = int.Parse(datetime.Substring(5, 2));
                int day = int.Parse(datetime.Substring(8, 2));
                int hour = int.Parse(datetime.Substring(11, 2));
                int min = int.Parse(datetime.Substring(14, 2));
                int sec = int.Parse(datetime.Substring(17, 2));
                return new DateTime(year, month, day, hour, min, sec, DateTimeKind.Utc);
            } catch (FormatException) {
                return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            }
        }

        private void LoadUmlModelElementStereotype(XmlReader xmlReader, EATree parent)
        {
            EATrace.XmiImport(xmlReader, TraceEventType.Verbose, "{0}", xmlReader.Name);

            if (xmlReader.IsEmptyElement) return;
            string endElement = xmlReader.Name;

            while (xmlReader.Read()) {
                switch (xmlReader.NodeType) {
                case XmlNodeType.Element:
                    if (xmlReader.Name.Equals("UML:Stereotype")) {
                        parent.Stereotype = xmlReader["name"];
                    } else {
                        xmlReader.Skip();
                        break;
                    }
                    break;
                case XmlNodeType.EndElement:
                    if (xmlReader.Name.Equals(endElement)) return;
                    FileFormatException(xmlReader, "Invalid configuration XML format (expected </{0}>)", endElement);
                    return;
                }
            }

            FileFormatException(xmlReader, "Unexpected end of stream");
        }

        private Dictionary<string, EATree> m_Elements = new Dictionary<string, EATree>();

        private Dictionary<string, EATree> m_PackageElements = new Dictionary<string, EATree>();

        private void AddElement(EATree element)
        {
            if (m_Elements.ContainsKey(element.Id)) {
                FileFormatException("XMI malformed, XMI.ID {0} occurs multiple times", element.Id);
                return;
            }
            m_Elements.Add(element.Id, element);
        }

        private void BuildTree()
        {
            foreach (EATree element in m_PackageElements.Values) {
                string package = "EAPK" + element.Id.Substring(4);
                EATree packageElement;
                if (m_Elements.TryGetValue(package, out packageElement)) {
                    packageElement.Text = element.Text;
                    m_Elements.Remove(element.Id);
                }
            }

            foreach (EATree element in m_Elements.Values) {
                if (element.ParentId != null) {
                    EATree parent;
                    if (!m_Elements.TryGetValue(element.ParentId, out parent)) {
                        EATrace.XmiImport(TraceEventType.Warning, "Element: {0} disassociated with parent {1}. Object Heading is {2}.",
                            element.Id, element.ParentId, element.Heading);
                    } else {
                        parent.AddChild(element);
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// Gets the root tree of the model.
        /// </summary>
        /// <value>The root tree of the model.</value>
        public EATree Root { get; private set; }

        public EATree FindGuid(string guid)
        {
            return FindGuid(Root, guid);
        }

        public EATree FindGuid(EATree node, string guid)
        {
            if (node == null) return null;
            if (node.Id.Equals(guid)) return node;
            foreach (EATree child in node.Children) {
                EATree found = FindGuid(child, guid);
                if (found != null) return found;
            }
            return null;
        }
    }
}
