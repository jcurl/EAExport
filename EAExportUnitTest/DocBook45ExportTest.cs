﻿namespace EAExport.Model
{
    using System;
    using System.IO;
    using System.Xml;
    using NUnit.Framework;

    public class DocBook45ExportTest
    {
        private XmlWriter GetWriter(Stream stream)
        {
            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.ConformanceLevel = ConformanceLevel.Fragment;
            xmlSettings.CloseOutput = false;
            xmlSettings.Indent = true;
            xmlSettings.NewLineHandling = NewLineHandling.Entitize;

            return XmlWriter.Create(stream, xmlSettings);
        }

        private XmlDocumentFragment LoadDocumentFragment(Stream stream)
        {
            XmlDocument xmlDoc = new XmlDocument();

            stream.Flush();
            stream.Seek(0, SeekOrigin.Begin);
            XmlDocumentFragment fragment = xmlDoc.CreateDocumentFragment();

            XmlReaderSettings xrs = new XmlReaderSettings();
            xrs.ConformanceLevel = ConformanceLevel.Fragment;
            using (XmlReader xr = XmlReader.Create(stream, xrs)) {
                XmlNode node;
                do {
                    node = xmlDoc.ReadNode(xr);
                    if (node != null) fragment.AppendChild(node);
                } while (node != null);
            }
            return fragment;
        }

        [Test]
        [Category("DocBook45")]
        [DeploymentItem(@"XMI\TC01-TitleOnly.xml")]
        public void TitleOnly()
        {
            EAModel model = EAModel.LoadXmi("TC01-TitleOnly.xml");
            MemoryStream ms = new MemoryStream();
            using (XmlWriter wr = GetWriter(ms))
            using (DocBook45ChapterExport export = new DocBook45ChapterExport(wr)) {
                export.ExportTree(model.Root, false);
            }

            XmlDocumentFragment xml = LoadDocumentFragment(ms);
            Assert.That(xml.SelectSingleNode("/chapter/title").InnerXml, Is.EqualTo("TC01-TitleOnly"));
            Assert.That(xml.SelectSingleNode("/chapter/section/title").InnerXml, Is.EqualTo("Requirement1"));
        }

        [Test]
        [Category("DocBook45")]
        [DeploymentItem(@"XMI\TC02-TitleWithBody.xml")]
        public void TitleWithBody()
        {
            EAModel model = EAModel.LoadXmi("TC02-TitleWithBody.xml");
            MemoryStream ms = new MemoryStream();
            using (XmlWriter wr = GetWriter(ms))
            using (DocBook45ChapterExport export = new DocBook45ChapterExport(wr)) {
                export.ExportTree(model.Root, false);
            }

            XmlDocumentFragment xml = LoadDocumentFragment(ms);
            Assert.That(xml.SelectSingleNode("/chapter/title").InnerXml, Is.EqualTo("TC02-TitleWithBody"));
            Assert.That(xml.SelectSingleNode("/chapter/section/title").InnerXml, Is.EqualTo("Requirement1"));
            Assert.That(xml.SelectSingleNode("/chapter/section/para[2]").InnerXml, Is.EqualTo("This is some text body."));
        }

        [Test]
        [Category("DocBook45")]
        [DeploymentItem(@"XMI\TC03-TitleWithBodyParagraphs.xml")]
        public void TitleWithBodyParagraphs()
        {
            EAModel model = EAModel.LoadXmi("TC03-TitleWithBodyParagraphs.xml");
            MemoryStream ms = new MemoryStream();
            using (XmlWriter wr = GetWriter(ms))
            using (DocBook45ChapterExport export = new DocBook45ChapterExport(wr)) {
                export.ExportTree(model.Root, false);
            }

            XmlDocumentFragment xml = LoadDocumentFragment(ms);
            Assert.That(xml.SelectSingleNode("/chapter/title").InnerXml, Is.EqualTo("TC03-TitleWithBodyParagraphs"));
            Assert.That(xml.SelectSingleNode("/chapter/section/title").InnerXml, Is.EqualTo("Requirement1"));
            Assert.That(xml.SelectSingleNode("/chapter/section/para[2]").InnerXml, Is.EqualTo("This text has two paragraphs"));
            Assert.That(xml.SelectSingleNode("/chapter/section/para[3]").InnerXml, Is.EqualTo("This is paragraph 2."));
        }

        [Test]
        [Category("DocBook45")]
        [DeploymentItem(@"XMI\TC04-MultipleRequirements.xml")]
        public void MultipleRequirements()
        {
            EAModel model = EAModel.LoadXmi("TC04-MultipleRequirements.xml");
            MemoryStream ms = new MemoryStream();
            using (XmlWriter wr = GetWriter(ms))
            using (DocBook45ChapterExport export = new DocBook45ChapterExport(wr)) {
                export.ExportTree(model.Root, false);
            }

            XmlDocumentFragment xml = LoadDocumentFragment(ms);
            Assert.That(xml.SelectSingleNode("/chapter/title").InnerXml, Is.EqualTo("TC04-MultipleRequirements"));
            Assert.That(xml.SelectSingleNode("/chapter/section[1]/title").InnerXml, Is.EqualTo("Requirement1"));
            Assert.That(xml.SelectSingleNode("/chapter/section[1]/para[2]").InnerXml, Is.EqualTo("This is requirement 1"));
            Assert.That(xml.SelectSingleNode("/chapter/section[2]/title").InnerXml, Is.EqualTo("Requirement2"));
            Assert.That(xml.SelectSingleNode("/chapter/section[2]/para[2]").InnerXml, Is.EqualTo("This is requirement 2"));
        }

        [Test]
        [Category("DocBook45")]
        [DeploymentItem(@"XMI\TC05-NestedRequirements1.xml")]
        public void NestedRequirements1()
        {
            EAModel model = EAModel.LoadXmi("TC05-NestedRequirements1.xml");
            MemoryStream ms = new MemoryStream();
            using (XmlWriter wr = GetWriter(ms))
            using (DocBook45ChapterExport export = new DocBook45ChapterExport(wr)) {
                export.ExportTree(model.Root, false);
            }

            XmlDocumentFragment xml = LoadDocumentFragment(ms);
            Assert.That(xml.SelectSingleNode("/chapter/title").InnerXml, Is.EqualTo("TC05-NestedRequirements1"));
            Assert.That(xml.SelectSingleNode("/chapter/section/title").InnerXml, Is.EqualTo("Requirement1"));
            Assert.That(xml.SelectSingleNode("/chapter/section/para[2]").InnerXml, Is.EqualTo("This is requirement 1"));
            Assert.That(xml.SelectSingleNode("/chapter/section/section/title").InnerXml, Is.EqualTo("Subrequirement1"));
            Assert.That(xml.SelectSingleNode("/chapter/section/section/para[2]").InnerXml, Is.EqualTo("This is requirement 1.1"));
        }

        [Test]
        [Category("DocBook45")]
        [DeploymentItem(@"XMI\TC06-NestedRequirements2.xml")]
        public void NestedRequirements2()
        {
            EAModel model = EAModel.LoadXmi("TC06-NestedRequirements2.xml");
            MemoryStream ms = new MemoryStream();
            using (XmlWriter wr = GetWriter(ms))
            using (DocBook45ChapterExport export = new DocBook45ChapterExport(wr)) {
                export.ExportTree(model.Root, false);
            }

            XmlDocumentFragment xml = LoadDocumentFragment(ms);
            Assert.That(xml.SelectSingleNode("/chapter/title").InnerXml, Is.EqualTo("TC06-NestedRequirements2"));
            Assert.That(xml.SelectSingleNode("/chapter/section[1]/title").InnerXml, Is.EqualTo("Requirement1"));
            Assert.That(xml.SelectSingleNode("/chapter/section[1]/para[2]").InnerXml, Is.EqualTo("Requirement 1"));
            Assert.That(xml.SelectSingleNode("/chapter/section[1]/section/title").InnerXml, Is.EqualTo("Requirement3"));
            Assert.That(xml.SelectSingleNode("/chapter/section[1]/section/para[2]").InnerXml, Is.EqualTo("Requirement 1.1"));
            Assert.That(xml.SelectSingleNode("/chapter/section[2]/title").InnerXml, Is.EqualTo("Requirement2"));
            Assert.That(xml.SelectSingleNode("/chapter/section[2]/para[2]").InnerXml, Is.EqualTo("Requirement 2"));
        }

        [Test]
        [Category("DocBook45")]
        [DeploymentItem(@"XMI\TC07-SpecialQuotes.xml")]
        public void SpecialQuotes()
        {
            EAModel model = EAModel.LoadXmi("TC07-SpecialQuotes.xml");
            MemoryStream ms = new MemoryStream();
            using (XmlWriter wr = GetWriter(ms))
            using (DocBook45ChapterExport export = new DocBook45ChapterExport(wr)) {
                export.ExportTree(model.Root, false);
            }

            XmlDocumentFragment xml = LoadDocumentFragment(ms);
            Assert.That(xml.SelectSingleNode("/chapter/title").InnerXml, Is.EqualTo("TC07-SpecialQuotes"));
            Assert.That(xml.SelectSingleNode("/chapter/section/title").InnerXml, Is.EqualTo("Requirement1"));
            Assert.That(xml.SelectSingleNode("/chapter/section/para[2]").InnerXml, Is.EqualTo("Special Quotes “HIGH”"));
        }

        [Test]
        [Category("DocBook45")]
        [DeploymentItem(@"XMI\TC20-FormattingBold1.xml")]
        public void FormattingBold1()
        {
            EAModel model = EAModel.LoadXmi("TC20-FormattingBold1.xml");
            MemoryStream ms = new MemoryStream();
            using (XmlWriter wr = GetWriter(ms))
            using (DocBook45ChapterExport export = new DocBook45ChapterExport(wr)) {
                export.ExportTree(model.Root, false);
            }

            XmlDocumentFragment xml = LoadDocumentFragment(ms);
            Assert.That(xml.SelectSingleNode("/chapter/title").InnerXml, Is.EqualTo("TC20-FormattingBold1"));
            Assert.That(xml.SelectSingleNode("/chapter/section/title").InnerXml, Is.EqualTo("Requirement1"));
            Assert.That(xml.SelectSingleNode("/chapter/section/para[2]").InnerXml, Is.EqualTo(@"This is some sample <emphasis role=""bold"">bold </emphasis>text."));
        }

        [Test]
        [Category("DocBook45")]
        [DeploymentItem(@"XMI\TC21-FormattingBold2.xml")]
        public void FormattingBold2()
        {
            EAModel model = EAModel.LoadXmi("TC21-FormattingBold2.xml");
            MemoryStream ms = new MemoryStream();
            using (XmlWriter wr = GetWriter(ms))
            using (DocBook45ChapterExport export = new DocBook45ChapterExport(wr)) {
                export.ExportTree(model.Root, false);
            }

            XmlDocumentFragment xml = LoadDocumentFragment(ms);
            Assert.That(xml.SelectSingleNode("/chapter/title").InnerXml, Is.EqualTo("TC21-FormattingBold2"));
            Assert.That(xml.SelectSingleNode("/chapter/section/title").InnerXml, Is.EqualTo("Requirement1"));
            Assert.That(xml.SelectSingleNode("/chapter/section/para[2]").InnerXml, Is.EqualTo(@"This <emphasis role=""bold"">text </emphasis>contains two <emphasis role=""bold"">bold </emphasis>elements."));
        }

        [Test]
        [Category("DocBook45")]
        [DeploymentItem(@"XMI\TC22-FormattingItalics.xml")]
        public void FormattingItalics()
        {
            EAModel model = EAModel.LoadXmi("TC22-FormattingItalics.xml");
            MemoryStream ms = new MemoryStream();
            using (XmlWriter wr = GetWriter(ms))
            using (DocBook45ChapterExport export = new DocBook45ChapterExport(wr)) {
                export.ExportTree(model.Root, false);
            }

            XmlDocumentFragment xml = LoadDocumentFragment(ms);
            Assert.That(xml.SelectSingleNode("/chapter/title").InnerXml, Is.EqualTo("TC22-FormattingItalics"));
            Assert.That(xml.SelectSingleNode("/chapter/section/title").InnerXml, Is.EqualTo("Requirement1"));
            Assert.That(xml.SelectSingleNode("/chapter/section/para[2]").InnerXml, Is.EqualTo(@"This contains some <emphasis>italic </emphasis>text."));
        }

        [Test]
        [Category("DocBook45")]
        [DeploymentItem(@"XMI\TC23-FormattingUnderline.xml")]
        public void FormattingUnderline()
        {
            EAModel model = EAModel.LoadXmi("TC23-FormattingUnderline.xml");
            MemoryStream ms = new MemoryStream();
            using (XmlWriter wr = GetWriter(ms))
            using (DocBook45ChapterExport export = new DocBook45ChapterExport(wr)) {
                export.ExportTree(model.Root, false);
            }

            XmlDocumentFragment xml = LoadDocumentFragment(ms);
            Assert.That(xml.SelectSingleNode("/chapter/title").InnerXml, Is.EqualTo("TC23-FormattingUnderline"));
            Assert.That(xml.SelectSingleNode("/chapter/section/title").InnerXml, Is.EqualTo("Requirement1"));
            Assert.That(xml.SelectSingleNode("/chapter/section/para[2]").InnerXml, Is.EqualTo(@"This contains some <emphasis role=""underline"">underline </emphasis>text."));
        }

        [Test]
        [Category("DocBook45")]
        [DeploymentItem(@"XMI\TC24-FormattingSuperscript.xml")]
        public void FormattingSuperscript()
        {
            EAModel model = EAModel.LoadXmi("TC24-FormattingSuperscript.xml");
            MemoryStream ms = new MemoryStream();
            using (XmlWriter wr = GetWriter(ms))
            using (DocBook45ChapterExport export = new DocBook45ChapterExport(wr)) {
                export.ExportTree(model.Root, false);
            }

            XmlDocumentFragment xml = LoadDocumentFragment(ms);
            Assert.That(xml.SelectSingleNode("/chapter/title").InnerXml, Is.EqualTo("TC24-FormattingSuperscript"));
            Assert.That(xml.SelectSingleNode("/chapter/section/title").InnerXml, Is.EqualTo("Requirement1"));
            Assert.That(xml.SelectSingleNode("/chapter/section/para[2]").InnerXml, Is.EqualTo(@"This contains superscript x<superscript>2</superscript>."));
        }

        [Test]
        [Category("DocBook45")]
        [DeploymentItem(@"XMI\TC25-FormattingSubscript.xml")]
        public void FormattingSubscript()
        {
            EAModel model = EAModel.LoadXmi("TC25-FormattingSubscript.xml");
            MemoryStream ms = new MemoryStream();
            using (XmlWriter wr = GetWriter(ms))
            using (DocBook45ChapterExport export = new DocBook45ChapterExport(wr)) {
                export.ExportTree(model.Root, false);
            }

            XmlDocumentFragment xml = LoadDocumentFragment(ms);
            Assert.That(xml.SelectSingleNode("/chapter/title").InnerXml, Is.EqualTo("TC25-FormattingSubscript"));
            Assert.That(xml.SelectSingleNode("/chapter/section/title").InnerXml, Is.EqualTo("Requirement1"));
            Assert.That(xml.SelectSingleNode("/chapter/section/para[2]").InnerXml, Is.EqualTo(@"This contains a subscript v<subscript>t</subscript>."));
        }

        [Test]
        [Category("DocBook45")]
        [DeploymentItem(@"XMI\TC26-FormattingMultiple.xml")]
        public void FormattingMultiple()
        {
            EAModel model = EAModel.LoadXmi("TC26-FormattingMultiple.xml");
            MemoryStream ms = new MemoryStream();
            using (XmlWriter wr = GetWriter(ms))
            using (DocBook45ChapterExport export = new DocBook45ChapterExport(wr)) {
                export.ExportTree(model.Root, false);
            }

            XmlDocumentFragment xml = LoadDocumentFragment(ms);
            Assert.That(xml.SelectSingleNode("/chapter/title").InnerXml, Is.EqualTo("TC26-FormattingMultiple"));
            Assert.That(xml.SelectSingleNode("/chapter/section/title").InnerXml, Is.EqualTo("Requirement1"));

            // This <b>contains </b><i>multiple </i><u>elements</u>. <i>E</i><i><sub>t</sub></i><i> = mc</i><i><sup>2</sup></i>.
            Assert.That(xml.SelectSingleNode("/chapter/section/para[2]").InnerXml,
                Is.EqualTo(@"This <emphasis role=""bold"">contains </emphasis><emphasis>multiple </emphasis><emphasis role=""underline"">elements</emphasis>. " +
                @"<emphasis>E</emphasis><emphasis><subscript>t</subscript></emphasis><emphasis> = mc</emphasis><emphasis><superscript>2</superscript></emphasis>."));
        }

        [Test]
        [Category("DocBook45")]
        [DeploymentItem(@"XMI\TC27-QuotesInTitle.xml")]
        public void QuotesInTitle()
        {
            EAModel model = EAModel.LoadXmi("TC27-QuotesInTitle.xml");
            MemoryStream ms = new MemoryStream();
            using (XmlWriter wr = GetWriter(ms))
            using (DocBook45ChapterExport export = new DocBook45ChapterExport(wr)) {
                export.ExportTree(model.Root, false);
            }

            XmlDocumentFragment xml = LoadDocumentFragment(ms);
            Assert.That(xml.SelectSingleNode("/chapter/title").InnerXml, Is.EqualTo("TC27-QuotesInTitle"));
            Assert.That(xml.SelectSingleNode("/chapter/section/title").InnerXml, Is.EqualTo(@"Requirement1 ""X"""));
            Assert.That(xml.SelectSingleNode("/chapter/section/para[2]").InnerXml, Is.EqualTo("This is a requirement."));
        }

        [Test]
        [Category("DocBook45")]
        [DeploymentItem(@"XMI\TC40-OrderedList1.xml")]
        public void OrderedList1()
        {
            EAModel model = EAModel.LoadXmi("TC40-OrderedList1.xml");
            MemoryStream ms = new MemoryStream();
            using (XmlWriter wr = GetWriter(ms))
            using (DocBook45ChapterExport export = new DocBook45ChapterExport(wr)) {
                export.ExportTree(model.Root, false);
            }

            XmlDocumentFragment xml = LoadDocumentFragment(ms);
            Assert.That(xml.SelectSingleNode("/chapter/title").InnerXml, Is.EqualTo("TC40-OrderedList1"));
            Assert.That(xml.SelectSingleNode("/chapter/section/title").InnerXml, Is.EqualTo("Requirement1"));
            Assert.That(xml.SelectSingleNode("/chapter/section/orderedlist/listitem/para").InnerXml, Is.EqualTo("Ordered List"));
        }

        [Test]
        [Category("DocBook45")]
        [DeploymentItem(@"XMI\TC41-OrderedList2.xml")]
        public void OrderedList2()
        {
            EAModel model = EAModel.LoadXmi("TC41-OrderedList2.xml");
            MemoryStream ms = new MemoryStream();
            using (XmlWriter wr = GetWriter(ms))
            using (DocBook45ChapterExport export = new DocBook45ChapterExport(wr)) {
                export.ExportTree(model.Root, false);
            }

            XmlDocumentFragment xml = LoadDocumentFragment(ms);
            Assert.That(xml.SelectSingleNode("/chapter/title").InnerXml, Is.EqualTo("TC41-OrderedList2"));
            Assert.That(xml.SelectSingleNode("/chapter/section/title").InnerXml, Is.EqualTo("Requirement1"));
            Assert.That(xml.SelectSingleNode("/chapter/section/orderedlist/listitem[1]/para").InnerXml, Is.EqualTo("Ordered List 1"));
            Assert.That(xml.SelectSingleNode("/chapter/section/orderedlist/listitem[2]/para").InnerXml, Is.EqualTo("Ordered List 2"));
        }

        [Test]
        [Category("DocBook45")]
        [DeploymentItem(@"XMI\TC42-ItemizedList1.xml")]
        public void ItemizedList1()
        {
            EAModel model = EAModel.LoadXmi("TC42-ItemizedList1.xml");
            MemoryStream ms = new MemoryStream();
            using (XmlWriter wr = GetWriter(ms))
            using (DocBook45ChapterExport export = new DocBook45ChapterExport(wr)) {
                export.ExportTree(model.Root, false);
            }

            XmlDocumentFragment xml = LoadDocumentFragment(ms);
            Assert.That(xml.SelectSingleNode("/chapter/title").InnerXml, Is.EqualTo("TC42-ItemizedList1"));
            Assert.That(xml.SelectSingleNode("/chapter/section/title").InnerXml, Is.EqualTo("Requirement1"));
            Assert.That(xml.SelectSingleNode("/chapter/section/itemizedlist/listitem/para").InnerXml, Is.EqualTo("ItemizedList1"));
        }

        [Test]
        [Category("DocBook45")]
        [DeploymentItem(@"XMI\TC43-ItemizedList2.xml")]
        public void ItemizedList2()
        {
            EAModel model = EAModel.LoadXmi("TC43-ItemizedList2.xml");
            MemoryStream ms = new MemoryStream();
            using (XmlWriter wr = GetWriter(ms))
            using (DocBook45ChapterExport export = new DocBook45ChapterExport(wr)) {
                export.ExportTree(model.Root, false);
            }

            XmlDocumentFragment xml = LoadDocumentFragment(ms);
            Assert.That(xml.SelectSingleNode("/chapter/title").InnerXml, Is.EqualTo("TC43-ItemizedList2"));
            Assert.That(xml.SelectSingleNode("/chapter/section/title").InnerXml, Is.EqualTo("Requirement1"));
            Assert.That(xml.SelectSingleNode("/chapter/section/itemizedlist/listitem[1]/para").InnerXml, Is.EqualTo("ItemizedList1"));
            Assert.That(xml.SelectSingleNode("/chapter/section/itemizedlist/listitem[2]/para").InnerXml, Is.EqualTo("ItemizedList2"));
        }

        [Test]
        [Category("DocBook45")]
        [DeploymentItem(@"XMI\TC44-BothLists1.xml")]
        public void BothLists1()
        {
            EAModel model = EAModel.LoadXmi("TC44-BothLists1.xml");
            MemoryStream ms = new MemoryStream();
            using (XmlWriter wr = GetWriter(ms))
            using (DocBook45ChapterExport export = new DocBook45ChapterExport(wr)) {
                export.ExportTree(model.Root, false);
            }

            XmlDocumentFragment xml = LoadDocumentFragment(ms);
            Assert.That(xml.SelectSingleNode("/chapter/title").InnerXml, Is.EqualTo("TC44-BothLists1"));
            Assert.That(xml.SelectSingleNode("/chapter/section/title").InnerXml, Is.EqualTo("Requirement1"));
            Assert.That(xml.SelectSingleNode("/chapter/section/orderedlist[1]/listitem/para").InnerXml, Is.EqualTo("Ordered List"));
            Assert.That(xml.SelectSingleNode("/chapter/section/orderedlist[1]/listitem/orderedlist/listitem/para").InnerXml, Is.EqualTo("Itemized List"));
            Assert.That(xml.SelectSingleNode("/chapter/section/orderedlist[2]/listitem/para").InnerXml, Is.EqualTo("Ordered List "));
        }

        [Test]
        [Category("DocBook45")]
        [DeploymentItem(@"XMI\TC45-BothLists2.xml")]
        public void BothLists2()
        {
            EAModel model = EAModel.LoadXmi("TC45-BothLists2.xml");
            MemoryStream ms = new MemoryStream();
            using (XmlWriter wr = GetWriter(ms))
            using (DocBook45ChapterExport export = new DocBook45ChapterExport(wr)) {
                export.ExportTree(model.Root, false);
            }

            XmlDocumentFragment xml = LoadDocumentFragment(ms);
            Assert.That(xml.SelectSingleNode("/chapter/title").InnerXml, Is.EqualTo("TC45-BothLists2"));
            Assert.That(xml.SelectSingleNode("/chapter/section/title").InnerXml, Is.EqualTo("Requirement1"));
            Assert.That(xml.SelectSingleNode("/chapter/section/itemizedlist/listitem/para").InnerXml, Is.EqualTo("Itemized List 1"));
            Assert.That(xml.SelectSingleNode("/chapter/section/itemizedlist/listitem/itemizedlist/listitem/itemizedlist/listitem/itemizedlist/listitem[1]/para").InnerXml, Is.EqualTo("Itemized List 2"));
            Assert.That(xml.SelectSingleNode("/chapter/section/itemizedlist/listitem/itemizedlist/listitem/itemizedlist/listitem/itemizedlist/listitem[2]/para").InnerXml, Is.EqualTo("Itemized List 3"));
            Assert.That(xml.SelectSingleNode("/chapter/section/para[2]").InnerXml, Is.EqualTo("(Note we really wanted nested lists, but EA doesn't seem to let this happen)"));
        }
    }
}
