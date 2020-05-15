namespace EAExport.Model
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;
    using HtmlAgilityPack;

    /// <summary>
    /// Converts the text to a DocBook 4.5 fragment with the base element of "chapter" and then "section".
    /// </summary>
    /// <seealso cref="EAExport.Model.ITreeExport" />
    public class DocBook45ChapterExport : ITreeExport
    {
        private readonly bool m_OwnWriter;
        private readonly XmlWriter m_XmlWriter;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocBook45ChapterExport"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public DocBook45ChapterExport(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            XmlWriterSettings xmlSettings = new XmlWriterSettings {
                ConformanceLevel = ConformanceLevel.Fragment,
                CloseOutput = true,
                Indent = true,
                NewLineHandling = NewLineHandling.Entitize
            };

            m_XmlWriter = XmlWriter.Create(fs, xmlSettings);
            m_OwnWriter = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocBook45ChapterExport"/> class.
        /// </summary>
        /// <param name="xmlWriter">The XML writer.</param>
        public DocBook45ChapterExport(XmlWriter xmlWriter)
        {
            m_XmlWriter = xmlWriter;
        }

        private XmlDocument m_XmlDocument;

        /// <summary>
        /// Exports the tree.
        /// </summary>
        /// <param name="root">The root element.</param>
        /// <param name="includeRoot">if set to <c>true</c> the also export the root element, else
        /// if set to <c>false</c>, then the children are exported.</param>
        public void ExportTree(EATree root, bool includeRoot)
        {
            m_XmlDocument = new XmlDocument() {
                XmlResolver = null
            };
            XmlDocumentFragment xmlFragment = m_XmlDocument.CreateDocumentFragment();

            DocBookFormat format = new DocBookFormat();
            if (includeRoot) {
                XmlNode xnode = ExportElement(root, format);
                xmlFragment.AppendChild(xnode);
            } else {
                foreach (EATree child in root.Children) {
                    XmlNode xnode = ExportElement(child, format);
                    xmlFragment.AppendChild(xnode);
                }
            }
            xmlFragment.WriteContentTo(m_XmlWriter);
        }

        private XmlNode ExportElement(EATree element, DocBookFormat format)
        {
            XmlElement xmlSectionElement;
            if (format.SectionDepth == 0) {
                xmlSectionElement = m_XmlDocument.CreateElement("chapter");
            } else {
                xmlSectionElement = m_XmlDocument.CreateElement("section");
            }

            format.SectionDepth++;
            string heading = (element.Heading == null) ? string.Empty : element.Heading.Trim();
            XmlElement xmlTitleElement = m_XmlDocument.CreateElement("title");
            XmlText xmlTitleText = m_XmlDocument.CreateTextNode(HtmlEntity.DeEntitize(heading));
            xmlTitleElement.AppendChild(xmlTitleText);
            xmlSectionElement.AppendChild(xmlTitleElement);

            string text = (element.Text == null) ? string.Empty : element.Text.Trim();
            XmlNode infoNode = CreateInfoNode(element);
            if (infoNode != null) xmlSectionElement.AppendChild(infoNode);
            XmlNode textNode = ConvertHtmlToDocBook45(text, format);
            if (textNode != null) xmlSectionElement.AppendChild(textNode);

            if (textNode == null && infoNode == null) {
                if (element.Children.Count == 0) {
                    xmlSectionElement.AppendChild(m_XmlDocument.CreateElement("para"));
                }
            }

            foreach (EATree child in element.Children) {
                XmlNode xmlChild = ExportElement(child, format);
                xmlSectionElement.AppendChild(xmlChild);
            }

            format.SectionDepth--;
            return xmlSectionElement;
        }

        private XmlNode ConvertHtmlToDocBook45(string text, DocBookFormat format)
        {
            if (!string.IsNullOrWhiteSpace(text)) {
                HtmlDocument html = new HtmlDocument();
                html.LoadHtml(text);
                XmlDocumentFragment xmlFragment = m_XmlDocument.CreateDocumentFragment();
                return ParseHtml(html.DocumentNode, format, xmlFragment);
            }
            return null;
        }

        private XmlNode ParseHtml(HtmlNode node, DocBookFormat format, XmlNode xmlNode)
        {
            string html;
            XmlNode xmlParent;

            switch (node.NodeType) {
            case HtmlNodeType.Document:
                ParseHtmlChildren(node, format, xmlNode);
                break;
            case HtmlNodeType.Comment:
                // Don't output comments
                break;
            case HtmlNodeType.Text:
                string parentName = node.ParentNode.Name;
                if (parentName.Equals("script") || parentName.Equals("style")) {
                    // Ignore scripts and styles
                    break;
                }

                html = ((HtmlTextNode)node).Text;

                if (HtmlNode.IsOverlappedClosingElement(html)) {
                    // Is it in fact a special closing node output as text?
                    break;
                }

                xmlNode = ParseHtmlText(HtmlEntity.DeEntitize(html), xmlNode);
                break;

            case HtmlNodeType.Element:
                DocBookFormat nextFormat = format;
                XmlNode nextNode = xmlNode;

                switch (node.Name) {
                case "ol":
                    // Add the ordered list after the previous paragraph if there is one.
                    xmlParent = GetParent(xmlNode, "para");
                    if (xmlParent != null) xmlNode = xmlParent.ParentNode;
                    nextFormat = new DocBookFormat(format.SectionDepth, HtmlFormatMode.OrderedList);
                    nextNode = m_XmlDocument.CreateElement("orderedlist");
                    xmlNode.AppendChild(nextNode);
                    break;
                case "ul":
                    xmlParent = GetParent(xmlNode, "para");
                    if (xmlParent != null) xmlNode = xmlParent.ParentNode;
                    nextFormat = new DocBookFormat(format.SectionDepth, HtmlFormatMode.UnorderedList);
                    nextNode = m_XmlDocument.CreateElement("itemizedlist");
                    xmlNode.AppendChild(nextNode);
                    break;
                case "li":
                    nextFormat = new DocBookFormat(format.SectionDepth, HtmlFormatMode.ListItem);
                    XmlElement xmlListItem = m_XmlDocument.CreateElement("listitem");
                    XmlElement xmlPara = m_XmlDocument.CreateElement("para");
                    xmlListItem.AppendChild(xmlPara);
                    xmlNode.AppendChild(xmlListItem);
                    nextNode = xmlPara;
                    break;
                case "u":
                    xmlParent = GetParent(xmlNode, "para", "screen");
                    if (xmlParent == null) {
                        XmlElement xmlNewPara = m_XmlDocument.CreateElement("para");
                        xmlNode.AppendChild(xmlNewPara);
                        xmlNode = xmlNewPara;
                    }
                    XmlElement xmlUnderline = m_XmlDocument.CreateElement("emphasis");
                    XmlAttribute xmlUnderlineAttr = m_XmlDocument.CreateAttribute("role");
                    xmlUnderlineAttr.Value = "underline";
                    xmlUnderline.Attributes.Append(xmlUnderlineAttr);
                    xmlNode.AppendChild(xmlUnderline);
                    nextNode = xmlUnderline;
                    break;
                case "i":
                    xmlParent = GetParent(xmlNode, "para", "screen");
                    if (xmlParent == null) {
                        XmlElement xmlNewPara = m_XmlDocument.CreateElement("para");
                        xmlNode.AppendChild(xmlNewPara);
                        xmlNode = xmlNewPara;
                    }
                    XmlElement xmlItalic = m_XmlDocument.CreateElement("emphasis");
                    xmlNode.AppendChild(xmlItalic);
                    nextNode = xmlItalic;
                    break;
                case "b":
                    xmlParent = GetParent(xmlNode, "para", "screen");
                    if (xmlParent == null) {
                        XmlElement xmlNewPara = m_XmlDocument.CreateElement("para");
                        xmlNode.AppendChild(xmlNewPara);
                        xmlNode = xmlNewPara;
                    }
                    XmlElement xmlBold = m_XmlDocument.CreateElement("emphasis");
                    XmlAttribute xmlBoldAttr = m_XmlDocument.CreateAttribute("role");
                    xmlBoldAttr.Value = "bold";
                    xmlBold.Attributes.Append(xmlBoldAttr);
                    xmlNode.AppendChild(xmlBold);
                    nextNode = xmlBold;
                    break;
                case "sub":
                    xmlParent = GetParent(xmlNode, "para", "screen");
                    if (xmlParent == null) {
                        XmlElement xmlNewPara = m_XmlDocument.CreateElement("para");
                        xmlNode.AppendChild(xmlNewPara);
                        xmlNode = xmlNewPara;
                    }
                    XmlElement xmlSub = m_XmlDocument.CreateElement("subscript");
                    xmlNode.AppendChild(xmlSub);
                    nextNode = xmlSub;
                    break;
                case "sup":
                    xmlParent = GetParent(xmlNode, "para", "screen");
                    if (xmlParent == null) {
                        XmlElement xmlNewPara = m_XmlDocument.CreateElement("para");
                        xmlNode.AppendChild(xmlNewPara);
                        xmlNode = xmlNewPara;
                    }
                    XmlElement xmlSup = m_XmlDocument.CreateElement("superscript");
                    xmlNode.AppendChild(xmlSup);
                    nextNode = xmlSup;
                    break;
                }

                if (node.HasChildNodes) {
                    ParseHtmlChildren(node, nextFormat, nextNode);
                }
                break;
            }

            return xmlNode;
        }

        private void ParseHtmlChildren(HtmlNode node, DocBookFormat format, XmlNode xmlNode)
        {
            foreach (HtmlNode child in node.ChildNodes) {
                xmlNode = ParseHtml(child, format, xmlNode);
            }
        }

        private XmlNode GetParent(XmlNode node, string element)
        {
            while (node != null) {
                if (node.NodeType == XmlNodeType.Element && node.Name.Equals(element)) return node;
                node = node.ParentNode;
            }
            return null;
        }

        private XmlNode GetParent(XmlNode node, params string[] elements)
        {
            while (node != null) {
                if (node.NodeType == XmlNodeType.Element) {
                    foreach (string element in elements) {
                        if (node.Name.Equals(element)) return node;
                    }
                }
                node = node.ParentNode;
            }
            return null;
        }

        private enum TextMode
        {
            None,
            Paragraph,
            Screen
        }

        private XmlNode ParseHtmlText(string htmlText, XmlNode node)
        {
            XmlNode xmlFormatNode = null;
            XmlNode rootNode;
            TextMode textMode;
            XmlNode xmlParent = GetParent(node, "para", "screen", "orderedlist", "itemizedlist");

            if (xmlParent == null) {
                // We're not in a list, or a paragraph. We create a new node based on the next
                // that will be parsed.
                textMode = TextMode.None;
                rootNode = node;
            } else if (xmlParent.Name.Equals("para")) {
                // We're in a paragraph. The current node defines the formatting when a newline
                // is observed.
                xmlFormatNode = node;
                rootNode = xmlParent.ParentNode;
                textMode = TextMode.Paragraph;
            } else if (xmlParent.Name.Equals("screen")) {
                // We're in a literal block. Keep parsing it and we don't need to remember the
                // formatting.
                rootNode = xmlParent.ParentNode;
                textMode = TextMode.Screen;
            } else {
                // We're in a list, which case we throw away the text as it's not allowed here.
                return node;
            }

            string[] paragraphs = htmlText.Split('\n', '\r');
            if (paragraphs.Length == 0) return node;
            bool emptyParagraph = false;

            foreach (string paragraph in paragraphs) {
                TextMode nextMode;
                switch (textMode) {
                case TextMode.Paragraph:
                    nextMode = TextMode.Paragraph;
                    break;
                default:
                    if (paragraph.Length < 2) {
                        nextMode = TextMode.Paragraph;
                    } else {
                        // Anything that starts with a space is considered code, like in mediawiki
                        if (paragraph.Substring(0, 2).Equals("  ")) {
                            nextMode = TextMode.Screen;
                        } else {
                            nextMode = TextMode.Paragraph;
                        }
                    }
                    break;
                }

                switch (nextMode) {
                case TextMode.Paragraph:
                    if (paragraph.Trim().Length > 0) {
                        // Only create paragraphs for non-empty lines
                        if (textMode != TextMode.Paragraph) {
                            // Previously not in a paragraph, so we need to create a new one
                            // and copy the formatting from the previous paragraph.
                            XmlNode xmlPara = null;
                            if (xmlFormatNode == null) {
                                xmlPara = m_XmlDocument.CreateElement("para");
                            } else {
                                XmlNode xmlCursor = xmlFormatNode;
                                while (xmlCursor != null) {
                                    XmlNode xmlSubElement = m_XmlDocument.CreateElement(xmlCursor.Name);
                                    if (xmlPara == null) {
                                        xmlPara = xmlSubElement;
                                    } else {
                                        xmlSubElement.AppendChild(xmlPara);
                                        xmlPara = xmlSubElement;
                                    }
                                    if (xmlCursor.Name.Equals("para")) {
                                        xmlCursor = null;
                                    } else {
                                        xmlCursor = xmlCursor.ParentNode;
                                    }
                                }
                            }
                            rootNode.AppendChild(xmlPara);
                            node = xmlPara;
                        }
                        XmlText xmlText = m_XmlDocument.CreateTextNode(paragraph);
                        node.AppendChild(xmlText);
                        emptyParagraph = false;
                    } else {
                        emptyParagraph = true;
                    }
                    textMode = TextMode.None;
                    break;
                case TextMode.Screen:
                    if (textMode != TextMode.Screen) {
                        // Create a new screen element, but only for non-empty lines
                        if (paragraph.Trim().Length == 0) break;

                        XmlNode xmlScreen = m_XmlDocument.CreateElement("screen");
                        rootNode.AppendChild(xmlScreen);
                        node = xmlScreen;
                        textMode = TextMode.Screen;
                    } else {
                        // End the previous screen line and start a new one
                        XmlText xmlNewLine = m_XmlDocument.CreateTextNode("\n");
                        node.AppendChild(xmlNewLine);
                    }
                    XmlText xmlScreenText = m_XmlDocument.CreateTextNode(paragraph.Substring(2));
                    node.AppendChild(xmlScreenText);
                    break;
                }
            }
            if (emptyParagraph && node != null && node.ParentNode != null) {
                node = node.ParentNode;
            }
            return node;
        }

        private XmlNode CreateInfoNode(EATree node)
        {
            bool hasField = false;
            StringBuilder infoText = new StringBuilder();

            AddField("Requirement", node.Alias, infoText, ref hasField);
            AddField("Author", node.Author, infoText, ref hasField);
            AddField("Stereotype", node.Stereotype, infoText, ref hasField);
            AddField("Status", node.Status, infoText, ref hasField);
            AddField("Version", node.Version, infoText, ref hasField);
            if (node.CreateTime.Ticks != 0) AddField("Created", node.CreateTime.ToString("u"), infoText, ref hasField);
            if (node.ModifiedTime.Ticks != 0) AddField("Modified", node.ModifiedTime.ToString("u"), infoText, ref hasField);
            if (!hasField) return null;
            infoText.Append(".");

            XmlElement xmlPara = m_XmlDocument.CreateElement("para");
            XmlElement xmlSuper = m_XmlDocument.CreateElement("superscript");
            XmlElement xmlItalic = m_XmlDocument.CreateElement("emphasis");
            XmlText xmlInfoText = m_XmlDocument.CreateTextNode(infoText.ToString());

            xmlPara.AppendChild(xmlSuper);
            xmlSuper.AppendChild(xmlItalic);
            xmlItalic.AppendChild(xmlInfoText);
            return xmlPara;
        }

        private void AddField(string field, string text, StringBuilder infoText, ref bool hasField)
        {
            if (string.IsNullOrWhiteSpace(text)) return;
            if (hasField) infoText.Append("; ");
            infoText.Append(field).Append(": ").Append(text.Trim());
            hasField = true;
        }

        private bool m_IsDisposed;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources;
        /// <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !m_IsDisposed) {
                if (m_XmlWriter != null && m_OwnWriter) m_XmlWriter.Close();
                m_IsDisposed = true;
            }
        }
    }
}
