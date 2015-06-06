using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace EAExport.Model
{
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
            using (XmlReader xmlReader = XmlReader.Create(fileName, ReadXmlSettings())) {
                model.LoadXmi(xmlReader);
                model.BuildTree();
                return model;
            }
        }

        /// <summary>
        /// The default XML settings when reading the local configuration.
        /// </summary>
        /// <returns>The settings for reading.</returns>
        private static XmlReaderSettings ReadXmlSettings()
        {
            XmlReaderSettings xmlSettings = new XmlReaderSettings();
            xmlSettings.IgnoreComments = true;
            xmlSettings.ConformanceLevel = ConformanceLevel.Document;
            xmlSettings.ValidationType = ValidationType.None;
            xmlSettings.ValidationFlags = XmlSchemaValidationFlags.ReportValidationWarnings;
            xmlSettings.ValidationEventHandler += xmlSettings_ValidationEventHandler;
            return xmlSettings;
        }

        private static void xmlSettings_ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            throw new InvalidDataException("Can't parse this XMI file");
        }

        private void LoadXmi(XmlReader xmlReader)
        {
            while (xmlReader.Read()) {
                switch (xmlReader.NodeType) {
                case XmlNodeType.Element:
                    if (xmlReader.Name.Equals("XMI")) {
                        LoadXmiRoot(xmlReader);
                    } else {
                        ReadIgnoreSubElements(xmlReader);
                    }
                    break;
                case XmlNodeType.EndElement:
                    break;
                default:
                    break;
                }
            }
        }

        private void LoadXmiRoot(XmlReader xmlReader)
        {
            Console.WriteLine("{0}", xmlReader.Name);

            if (!xmlReader["xmi.version"].Equals("1.1")) {
                throw new FileFormatException("Unexpected version. Got " + xmlReader["xmi.version"] + "; expected 1.1");
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
                        ReadIgnoreSubElements(xmlReader);
                        break;
                    }
                    break;
                case XmlNodeType.EndElement:
                    if (xmlReader.Name.Equals(endElement)) return;
                    throw new FileFormatException("Invalid configuration XML format (expected </" + endElement + ">)");
                }
            }

            throw new FileFormatException("Unexpected end of stream");
        }

        private void LoadXmiContent(XmlReader xmlReader)
        {
            Console.WriteLine("{0}", xmlReader.Name);

            if (xmlReader.IsEmptyElement) return;
            string endElement = xmlReader.Name;

            while (xmlReader.Read()) {
                switch (xmlReader.NodeType) {
                case XmlNodeType.Element:
                    // This is where you would add support for more fields in the configuration file
                    if (xmlReader.Name.Equals("UML:Model")) {
                        LoadUmlModel(xmlReader);
                    } else {
                        ReadIgnoreSubElements(xmlReader);
                        break;
                    }
                    break;
                case XmlNodeType.EndElement:
                    if (xmlReader.Name.Equals(endElement)) return;
                    throw new FileFormatException("Invalid configuration XML format (expected </" + endElement + ">)");
                }
            }

            throw new FileFormatException("Unexpected end of stream");
        }

        private void LoadUmlModel(XmlReader xmlReader)
        {
            Console.WriteLine("{0}", xmlReader.Name);

            EATree element;
            if (Root == null) {
                element = new EATree(xmlReader["xmi.id"], xmlReader["name"], string.Empty, 0);
                Root = element;
                AddElement(element);
            } else {
                // We only support a single model in our XMI for now.
                ReadIgnoreSubElements(xmlReader);
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
                        ReadIgnoreSubElements(xmlReader);
                        break;
                    }
                    break;
                case XmlNodeType.EndElement:
                    if (xmlReader.Name.Equals(endElement)) return;
                    throw new FileFormatException("Invalid configuration XML format (expected </" + endElement + ">)");
                }
            }

            throw new FileFormatException("Unexpected end of stream");
        }

        private void LoadUmlNamespaceOwnedElement(XmlReader xmlReader, EATree parent)
        {
            Console.WriteLine("{0}", xmlReader.Name);

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
                        LoadUmlClassifierRole(xmlReader, parent);
                    } else {
                        ReadIgnoreSubElements(xmlReader);
                        break;
                    }
                    break;
                case XmlNodeType.EndElement:
                    if (xmlReader.Name.Equals(endElement)) return;
                    throw new FileFormatException("Invalid configuration XML format (expected </" + endElement + ">)");
                }
            }

            throw new FileFormatException("Unexpected end of stream");
        }

        private void LoadUmlPackage(XmlReader xmlReader, EATree parent)
        {
            Console.WriteLine("{0}", xmlReader.Name);

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
                    } else if (xmlReader.Name.Equals("UML:Namespace.ownedElement")) {
                        LoadUmlNamespaceOwnedElement(xmlReader, package);
                    } else {
                        ReadIgnoreSubElements(xmlReader);
                        break;
                    }
                    break;
                case XmlNodeType.EndElement:
                    if (xmlReader.Name.Equals(endElement)) return;
                    throw new FileFormatException("Invalid configuration XML format (expected </" + endElement + ">)");
                }
            }

            throw new FileFormatException("Unexpected end of stream");
        }

        private void LoadUmlCollaboration(XmlReader xmlReader, EATree parent)
        {
            Console.WriteLine("{0}", xmlReader.Name);

            if (xmlReader.IsEmptyElement) return;
            string endElement = xmlReader.Name;

            while (xmlReader.Read()) {
                switch (xmlReader.NodeType) {
                case XmlNodeType.Element:
                    // This is where you would add support for more fields in the configuration file
                    if (xmlReader.Name.Equals("UML:Namespace.ownedElement")) {
                        LoadUmlNamespaceOwnedElement(xmlReader, parent);
                    } else {
                        ReadIgnoreSubElements(xmlReader);
                        break;
                    }
                    break;
                case XmlNodeType.EndElement:
                    if (xmlReader.Name.Equals(endElement)) return;
                    throw new FileFormatException("Invalid configuration XML format (expected </" + endElement + ">)");
                }
            }

            throw new FileFormatException("Unexpected end of stream");
        }

        private void LoadUmlClassifierRole(XmlReader xmlReader, EATree parent)
        {
            Console.WriteLine("{0}", xmlReader.Name);

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
                    } else {
                        ReadIgnoreSubElements(xmlReader);
                        break;
                    }
                    break;
                case XmlNodeType.EndElement:
                    if (xmlReader.Name.Equals(endElement)) return;
                    throw new FileFormatException("Invalid configuration XML format (expected </" + endElement + ">)");
                }
            }

            throw new FileFormatException("Unexpected end of stream");
        }

        private void LoadUmlModelElementTaggedValue(XmlReader xmlReader, EATree parent)
        {
            Console.WriteLine("{0}", xmlReader.Name);

            if (xmlReader.IsEmptyElement) return;
            string endElement = xmlReader.Name;

            string owner = null;
            string package = null;
            string package2 = null;
            string parentElement = null;
            string tpos = null;
            string text = null;

            while (xmlReader.Read()) {
                switch (xmlReader.NodeType) {
                case XmlNodeType.Element:
                    if (xmlReader.Name.Equals("UML:TaggedValue")) {
                        if (xmlReader["tag"].Equals("owner")) {
                            owner = xmlReader["value"];
                        } else if (xmlReader["tag"].Equals("package")) {
                            package = xmlReader["value"];
                        } else if (xmlReader["tag"].Equals("tpos")) {
                            tpos = xmlReader["value"];
                        } else if (xmlReader["tag"].Equals("documentation")) {
                            text = xmlReader["value"];
                        } else if (xmlReader["tag"].Equals("package2")) {
                            package2 = xmlReader["value"];
                        } else if (xmlReader["tag"].Equals("parent")) {
                            parentElement = xmlReader["value"];
                        }

                        if (!xmlReader.IsEmptyElement) {
                            ReadIgnoreSubElements(xmlReader);
                        }
                    } else {
                        ReadIgnoreSubElements(xmlReader);
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
                        parent.Text = text;
                        return;
                    }
                    throw new FileFormatException("Invalid configuration XML format (expected </" + endElement + ">)");
                }
            }

            throw new FileFormatException("Unexpected end of stream");
        }

        /// <summary>
        /// Ignore all nodes under the current XML node in the XML stream.
        /// </summary>
        /// <param name="xmlReader">The stream to parse.</param>
        /// <remarks>
        /// This function is normally called when a NodeType.Element is found and
        /// the name is not supported, to parse through the tree and ignore all
        /// information found. This allows for loading XML files that are similar
        /// by different classes (upgrades, downgrades, etc.).
        /// <para>It will read through the stream until the end element is found
        /// which is the same as the current node element.</para>
        /// </remarks>
        private void ReadIgnoreSubElements(XmlReader xmlReader)
        {
            if (xmlReader == null) return;

            if (xmlReader.NodeType != XmlNodeType.Element) {
                throw new FileFormatException("Expected NodeType of Element");
            }
            if (xmlReader.IsEmptyElement) return;
            string endElement = xmlReader.Name;
            Stack<string> subElements = new Stack<string>();

            while (xmlReader.Read()) {
                switch (xmlReader.NodeType) {
                case XmlNodeType.Element:
                    if (!xmlReader.IsEmptyElement) {
                        // We have a sub-element in XML that isn't understood by this
                        // object
                        subElements.Push(xmlReader.Name);
                    }
                    break;
                case XmlNodeType.EndElement:
                    if (subElements.Count == 0) {
                        if (xmlReader.Name.Equals(endElement)) return;
                        throw new FileFormatException("Invalid tag " + xmlReader.Name + ", expecting " + endElement);
                    } else {
                        if (xmlReader.Name.Equals(subElements.Peek())) {
                            subElements.Pop();
                        } else {
                            throw new FileFormatException("Invalid tag " + xmlReader.Name + ", expecting " + subElements.Peek());
                        }
                    }
                    break;
                }
            }
        }

        private Dictionary<string, EATree> m_Elements = new Dictionary<string, EATree>();

        private Dictionary<string, EATree> m_PackageElements = new Dictionary<string, EATree>();

        private void AddElement(EATree element)
        {
            if (m_Elements.ContainsKey(element.Id))
                throw new FileFormatException("XMI malformed, XMI.ID " + element.Id + " occurs multiple times");
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
                    EATree parent = m_Elements[element.ParentId];
                    parent.AddChild(element);
                }
            }
        }

        /// <summary>
        /// Gets the root tree of the model.
        /// </summary>
        /// <value>The root tree of the model.</value>
        public EATree Root { get; private set; }
    }
}
