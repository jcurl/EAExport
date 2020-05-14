namespace EAExport.Model
{
    using System;
    using System.IO;
    using NUnit.Framework;

    [TestFixture(Category = "CsvPlainText")]
    public class CsvDoorsTreePlainExportTest
    {
        [Test]
        [DeploymentItem(@"XMI\TC01-TitleOnly.xml")]
        public void TitleOnly()
        {
            EAModel model = EAModel.LoadXmi("TC01-TitleOnly.xml");
            MemoryStream ms = new MemoryStream();
            using (CsvDoorsTreePlainExport export = new CsvDoorsTreePlainExport(ms)) {
                export.ExportTree(model.Root, false);
            }
            ms.Flush(); ms.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(ms);

            Assert.That(sr.ReadLine(), Is.EqualTo("EAID;EAParent;Heading;Text"));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAPK_6ABD8C60_320C_47c8_BB82_C7FF08351B76;;\"TC01-TitleOnly\";\"\""));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAID_B3877A96_36AA_41e4_B2A6_4CDEAF253D0E;EAPK_6ABD8C60_320C_47c8_BB82_C7FF08351B76;\"Requirement1\";\"\""));
            Assert.That(sr.ReadLine(), Is.Null);
        }

        [Test]
        [DeploymentItem(@"XMI\TC02-TitleWithBody.xml")]
        public void TitleWithBody()
        {
            EAModel model = EAModel.LoadXmi("TC02-TitleWithBody.xml");
            MemoryStream ms = new MemoryStream();
            using (CsvDoorsTreePlainExport export = new CsvDoorsTreePlainExport(ms)) {
                export.ExportTree(model.Root, false);
            }
            ms.Flush(); ms.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(ms);

            Assert.That(sr.ReadLine(), Is.EqualTo("EAID;EAParent;Heading;Text"));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAPK_48E77672_45B7_470b_BBE8_50A356C5FD44;;\"TC02-TitleWithBody\";\"\""));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAID_FDA2A455_5C72_4587_BC87_E2A16E44D259;EAPK_48E77672_45B7_470b_BBE8_50A356C5FD44;\"Requirement1\";\"This is some text body.\""));
            Assert.That(sr.ReadLine(), Is.Null);
        }

        [Test]
        [DeploymentItem(@"XMI\TC03-TitleWithBodyParagraphs.xml")]
        public void TitleWithBodyParagraphs()
        {
            EAModel model = EAModel.LoadXmi("TC03-TitleWithBodyParagraphs.xml");
            MemoryStream ms = new MemoryStream();
            using (CsvDoorsTreePlainExport export = new CsvDoorsTreePlainExport(ms)) {
                export.ExportTree(model.Root, false);
            }
            ms.Flush(); ms.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(ms);

            Assert.That(sr.ReadLine(), Is.EqualTo("EAID;EAParent;Heading;Text"));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAPK_0A139DBA_388E_43c4_8E5B_00EEF2E95737;;\"TC03-TitleWithBodyParagraphs\";\"\""));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAID_6F371BD5_916A_4eb1_83B1_C900F8D71DE7;EAPK_0A139DBA_388E_43c4_8E5B_00EEF2E95737;\"Requirement1\";\"This text has two paragraphs"));
            Assert.That(sr.ReadLine(), Is.EqualTo("This is paragraph 2.\""));
            Assert.That(sr.ReadLine(), Is.Null);
        }

        [Test]
        [DeploymentItem(@"XMI\TC04-MultipleRequirements.xml")]
        public void MultipleRequirements()
        {
            EAModel model = EAModel.LoadXmi("TC04-MultipleRequirements.xml");
            MemoryStream ms = new MemoryStream();
            using (CsvDoorsTreePlainExport export = new CsvDoorsTreePlainExport(ms)) {
                export.ExportTree(model.Root, false);
            }
            ms.Flush(); ms.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(ms);

            Assert.That(sr.ReadLine(), Is.EqualTo("EAID;EAParent;Heading;Text"));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAPK_65253614_1604_49a0_B742_5111B4809D61;;\"TC04-MultipleRequirements\";\"\""));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAID_ACDBCAFA_E76C_44a5_B3DB_9559ACC8871C;EAPK_65253614_1604_49a0_B742_5111B4809D61;\"Requirement1\";\"This is requirement 1\""));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAID_7DC3505B_C2C1_4f88_9D71_BA0835BE59C1;EAPK_65253614_1604_49a0_B742_5111B4809D61;\"Requirement2\";\"This is requirement 2\""));
            Assert.That(sr.ReadLine(), Is.Null);
        }

        [Test]
        [DeploymentItem(@"XMI\TC05-NestedRequirements1.xml")]
        public void NestedRequirements1()
        {
            EAModel model = EAModel.LoadXmi("TC05-NestedRequirements1.xml");
            MemoryStream ms = new MemoryStream();
            using (CsvDoorsTreePlainExport export = new CsvDoorsTreePlainExport(ms)) {
                export.ExportTree(model.Root, false);
            }
            ms.Flush(); ms.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(ms);

            Assert.That(sr.ReadLine(), Is.EqualTo("EAID;EAParent;Heading;Text"));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAPK_14C7EE49_72F4_4d52_99CF_F70CBDAF8E0D;;\"TC05-NestedRequirements1\";\"\""));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAID_BD08AEA4_D3AE_408d_AD21_F33D7BE1ECF9;EAPK_14C7EE49_72F4_4d52_99CF_F70CBDAF8E0D;\"Requirement1\";\"This is requirement 1\""));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAID_6039BC38_AC5E_41f8_9E49_706341E6E5D7;EAID_BD08AEA4_D3AE_408d_AD21_F33D7BE1ECF9;\"Subrequirement1\";\"This is requirement 1.1\""));
            Assert.That(sr.ReadLine(), Is.Null);
        }

        [Test]
        [DeploymentItem(@"XMI\TC06-NestedRequirements2.xml")]
        public void NestedRequirements2()
        {
            EAModel model = EAModel.LoadXmi("TC06-NestedRequirements2.xml");
            MemoryStream ms = new MemoryStream();
            using (CsvDoorsTreePlainExport export = new CsvDoorsTreePlainExport(ms)) {
                export.ExportTree(model.Root, false);
            }
            ms.Flush(); ms.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(ms);

            Assert.That(sr.ReadLine(), Is.EqualTo("EAID;EAParent;Heading;Text"));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAPK_B89ABDD0_2387_4403_AA6A_AF9EBA69E32A;;\"TC06-NestedRequirements2\";\"\""));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAID_20A64D23_90F9_4e89_9062_70448865753E;EAPK_B89ABDD0_2387_4403_AA6A_AF9EBA69E32A;\"Requirement1\";\"Requirement 1\""));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAID_B7DDDD41_3B22_4d01_BE02_2D73DBF3F8E4;EAID_20A64D23_90F9_4e89_9062_70448865753E;\"Requirement3\";\"Requirement 1.1\""));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAID_F0106B75_0E55_4b02_B186_F989F3980701;EAPK_B89ABDD0_2387_4403_AA6A_AF9EBA69E32A;\"Requirement2\";\"Requirement 2\""));
            Assert.That(sr.ReadLine(), Is.Null);
        }

        [Test]
        [DeploymentItem(@"XMI\TC07-SpecialQuotes.xml")]
        public void SpecialQuotes()
        {
            EAModel model = EAModel.LoadXmi("TC07-SpecialQuotes.xml");
            MemoryStream ms = new MemoryStream();
            using (CsvDoorsTreePlainExport export = new CsvDoorsTreePlainExport(ms)) {
                export.ExportTree(model.Root, false);
            }
            ms.Flush(); ms.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(ms);

            Assert.That(sr.ReadLine(), Is.EqualTo("EAID;EAParent;Heading;Text"));
            Assert.That(sr.ReadLine(), Is.EqualTo(@"EAPK_23973FF5_136F_4a00_B97F_72EA082C0115;;""TC07-SpecialQuotes"";"""""));
            Assert.That(sr.ReadLine(), Is.EqualTo(@"EAID_9F3ACCD1_28CE_4042_855E_B6947A78BC11;EAPK_23973FF5_136F_4a00_B97F_72EA082C0115;""Requirement1"";""Special Quotes """"HIGH"""""""));
            Assert.That(sr.ReadLine(), Is.Null);
        }

        [Test]
        [DeploymentItem(@"XMI\TC20-FormattingBold1.xml")]
        public void FormattingBold1()
        {
            EAModel model = EAModel.LoadXmi("TC20-FormattingBold1.xml");
            MemoryStream ms = new MemoryStream();
            using (CsvDoorsTreePlainExport export = new CsvDoorsTreePlainExport(ms)) {
                export.ExportTree(model.Root, false);
            }
            ms.Flush(); ms.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(ms);

            Assert.That(sr.ReadLine(), Is.EqualTo("EAID;EAParent;Heading;Text"));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAPK_A903EE99_F6D4_4e05_91FA_28A4C7417179;;\"TC20-FormattingBold1\";\"\""));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAID_B264707C_375B_451e_B3FB_12926119693B;EAPK_A903EE99_F6D4_4e05_91FA_28A4C7417179;\"Requirement1\";\"This is some sample bold text.\""));
            Assert.That(sr.ReadLine(), Is.Null);
        }

        [Test]
        [DeploymentItem(@"XMI\TC21-FormattingBold2.xml")]
        public void FormattingBold2()
        {
            EAModel model = EAModel.LoadXmi("TC21-FormattingBold2.xml");
            MemoryStream ms = new MemoryStream();
            using (CsvDoorsTreePlainExport export = new CsvDoorsTreePlainExport(ms)) {
                export.ExportTree(model.Root, false);
            }
            ms.Flush(); ms.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(ms);

            Assert.That(sr.ReadLine(), Is.EqualTo("EAID;EAParent;Heading;Text"));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAPK_BC71703F_84F5_479e_96C7_43D7210FACB8;;\"TC21-FormattingBold2\";\"\""));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAID_16E7C01E_1A21_41a6_BA91_CC1FD2F1E476;EAPK_BC71703F_84F5_479e_96C7_43D7210FACB8;\"Requirement1\";\"This text contains two bold elements.\""));
            Assert.That(sr.ReadLine(), Is.Null);
        }

        [Test]
        [DeploymentItem(@"XMI\TC22-FormattingItalics.xml")]
        public void FormattingItalics()
        {
            EAModel model = EAModel.LoadXmi("TC22-FormattingItalics.xml");
            MemoryStream ms = new MemoryStream();
            using (CsvDoorsTreePlainExport export = new CsvDoorsTreePlainExport(ms)) {
                export.ExportTree(model.Root, false);
            }
            ms.Flush(); ms.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(ms);

            Assert.That(sr.ReadLine(), Is.EqualTo("EAID;EAParent;Heading;Text"));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAPK_93C2DE62_DB08_4d03_8527_0C4475B86C29;;\"TC22-FormattingItalics\";\"\""));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAID_09D63387_3209_4947_8084_0F5AE6DA7631;EAPK_93C2DE62_DB08_4d03_8527_0C4475B86C29;\"Requirement1\";\"This contains some italic text.\""));
            Assert.That(sr.ReadLine(), Is.Null);
        }

        [Test]
        [DeploymentItem(@"XMI\TC23-FormattingUnderline.xml")]
        public void FormattingUnderline()
        {
            EAModel model = EAModel.LoadXmi("TC23-FormattingUnderline.xml");
            MemoryStream ms = new MemoryStream();
            using (CsvDoorsTreePlainExport export = new CsvDoorsTreePlainExport(ms)) {
                export.ExportTree(model.Root, false);
            }
            ms.Flush(); ms.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(ms);

            Assert.That(sr.ReadLine(), Is.EqualTo("EAID;EAParent;Heading;Text"));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAPK_440A4C0D_E350_4cca_B1ED_4963DD77D2B9;;\"TC23-FormattingUnderline\";\"\""));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAID_45B52CC7_6BEB_4457_BC1F_7D6670CAEA8E;EAPK_440A4C0D_E350_4cca_B1ED_4963DD77D2B9;\"Requirement1\";\"This contains some underline text.\""));
            Assert.That(sr.ReadLine(), Is.Null);
        }

        [Test]
        [DeploymentItem(@"XMI\TC24-FormattingSuperscript.xml")]
        public void FormattingSuperscript()
        {
            EAModel model = EAModel.LoadXmi("TC24-FormattingSuperscript.xml");
            MemoryStream ms = new MemoryStream();
            using (CsvDoorsTreePlainExport export = new CsvDoorsTreePlainExport(ms)) {
                export.ExportTree(model.Root, false);
            }
            ms.Flush(); ms.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(ms);

            Assert.That(sr.ReadLine(), Is.EqualTo("EAID;EAParent;Heading;Text"));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAPK_7199DB1C_9800_463e_AA88_6AC628487FA0;;\"TC24-FormattingSuperscript\";\"\""));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAID_D5930609_BFEB_4830_B1E8_FD38C2DA4DA5;EAPK_7199DB1C_9800_463e_AA88_6AC628487FA0;\"Requirement1\";\"This contains superscript x2.\""));
            Assert.That(sr.ReadLine(), Is.Null);
        }

        [Test]
        [DeploymentItem(@"XMI\TC25-FormattingSubscript.xml")]
        public void FormattingSubscript()
        {
            EAModel model = EAModel.LoadXmi("TC25-FormattingSubscript.xml");
            MemoryStream ms = new MemoryStream();
            using (CsvDoorsTreePlainExport export = new CsvDoorsTreePlainExport(ms)) {
                export.ExportTree(model.Root, false);
            }
            ms.Flush(); ms.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(ms);

            Assert.That(sr.ReadLine(), Is.EqualTo("EAID;EAParent;Heading;Text"));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAPK_D33B51E5_4791_4ec0_A1A4_A53F5FEC4B6F;;\"TC25-FormattingSubscript\";\"\""));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAID_DD2E50C5_3ADE_4b0f_B8F6_EF5D11F55923;EAPK_D33B51E5_4791_4ec0_A1A4_A53F5FEC4B6F;\"Requirement1\";\"This contains a subscript vt.\""));
            Assert.That(sr.ReadLine(), Is.Null);
        }

        [Test]
        [DeploymentItem(@"XMI\TC26-FormattingMultiple.xml")]
        public void FormattingMultiple()
        {
            EAModel model = EAModel.LoadXmi("TC26-FormattingMultiple.xml");
            MemoryStream ms = new MemoryStream();
            using (CsvDoorsTreePlainExport export = new CsvDoorsTreePlainExport(ms)) {
                export.ExportTree(model.Root, false);
            }
            ms.Flush(); ms.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(ms);

            Assert.That(sr.ReadLine(), Is.EqualTo("EAID;EAParent;Heading;Text"));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAPK_C22345A9_09D2_434a_BB36_4405BFA896BC;;\"TC26-FormattingMultiple\";\"\""));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAID_1300ADBC_FB4B_48e5_80B4_EE9AA5764193;EAPK_C22345A9_09D2_434a_BB36_4405BFA896BC;\"Requirement1\";\"This contains multiple elements. Et = mc2.\""));
            Assert.That(sr.ReadLine(), Is.Null);
        }

        [Test]
        [DeploymentItem(@"XMI\TC27-QuotesInTitle.xml")]
        public void QuotesInTitle()
        {
            EAModel model = EAModel.LoadXmi("TC27-QuotesInTitle.xml");
            MemoryStream ms = new MemoryStream();
            using (CsvDoorsTreePlainExport export = new CsvDoorsTreePlainExport(ms)) {
                export.ExportTree(model.Root, false);
            }
            ms.Flush(); ms.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(ms);

            Assert.That(sr.ReadLine(), Is.EqualTo("EAID;EAParent;Heading;Text"));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAPK_7EF083D6_24DD_4d45_A2B7_8FE762A3F785;;\"TC27-QuotesInTitle\";\"\""));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAID_70734508_A24A_4edd_B963_2C3787AC8F7A;EAPK_7EF083D6_24DD_4d45_A2B7_8FE762A3F785;\"Requirement1 \"\"X\"\"\";\"This is a requirement.\""));
            Assert.That(sr.ReadLine(), Is.Null);
        }

        [Test]
        [DeploymentItem(@"XMI\TC40-OrderedList1.xml")]
        public void OrderedList1()
        {
            EAModel model = EAModel.LoadXmi("TC40-OrderedList1.xml");
            MemoryStream ms = new MemoryStream();
            using (CsvDoorsTreePlainExport export = new CsvDoorsTreePlainExport(ms)) {
                export.ExportTree(model.Root, false);
            }
            ms.Flush(); ms.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(ms);

            Assert.That(sr.ReadLine(), Is.EqualTo("EAID;EAParent;Heading;Text"));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAPK_013C0CF7_4B22_4a7f_924B_7668A1429B28;;\"TC40-OrderedList1\";\"\""));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAID_FFE1947E_8E13_4a48_9EA8_E501C5A684D9;EAPK_013C0CF7_4B22_4a7f_924B_7668A1429B28;\"Requirement1\";\""));
            Assert.That(sr.ReadLine(), Is.EqualTo("\t 1. Ordered List"));
            Assert.That(sr.ReadLine(), Is.EqualTo("\""));
            Assert.That(sr.ReadLine(), Is.Null);
        }

        [Test]
        [DeploymentItem(@"XMI\TC41-OrderedList2.xml")]
        public void OrderedList2()
        {
            EAModel model = EAModel.LoadXmi("TC41-OrderedList2.xml");
            MemoryStream ms = new MemoryStream();
            using (CsvDoorsTreePlainExport export = new CsvDoorsTreePlainExport(ms)) {
                export.ExportTree(model.Root, false);
            }
            ms.Flush(); ms.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(ms);

            Assert.That(sr.ReadLine(), Is.EqualTo("EAID;EAParent;Heading;Text"));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAPK_5F88120E_85D8_47ab_948F_440065D4275C;;\"TC41-OrderedList2\";\"\""));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAID_0B06B1F4_7C98_4add_8359_07B9D77F48A0;EAPK_5F88120E_85D8_47ab_948F_440065D4275C;\"Requirement1\";\""));
            Assert.That(sr.ReadLine(), Is.EqualTo("\t 1. Ordered List 1"));
            Assert.That(sr.ReadLine(), Is.EqualTo("\t 2. Ordered List 2"));
            Assert.That(sr.ReadLine(), Is.EqualTo("\""));
            Assert.That(sr.ReadLine(), Is.Null);
        }

        [Test]
        [DeploymentItem(@"XMI\TC42-ItemizedList1.xml")]
        public void ItemizedList1()
        {
            EAModel model = EAModel.LoadXmi("TC42-ItemizedList1.xml");
            MemoryStream ms = new MemoryStream();
            using (CsvDoorsTreePlainExport export = new CsvDoorsTreePlainExport(ms)) {
                export.ExportTree(model.Root, false);
            }
            ms.Flush(); ms.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(ms);

            Assert.That(sr.ReadLine(), Is.EqualTo("EAID;EAParent;Heading;Text"));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAPK_B7864070_817D_425d_9585_32517009FB8F;;\"TC42-ItemizedList1\";\"\""));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAID_399036B5_2E9F_4b6a_AA10_BC773420DE1B;EAPK_B7864070_817D_425d_9585_32517009FB8F;\"Requirement1\";\""));
            Assert.That(sr.ReadLine(), Is.EqualTo("\t * ItemizedList1"));
            Assert.That(sr.ReadLine(), Is.EqualTo("\""));
            Assert.That(sr.ReadLine(), Is.Null);
        }

        [Test]
        [DeploymentItem(@"XMI\TC43-ItemizedList2.xml")]
        public void ItemizedList2()
        {
            EAModel model = EAModel.LoadXmi("TC43-ItemizedList2.xml");
            MemoryStream ms = new MemoryStream();
            using (CsvDoorsTreePlainExport export = new CsvDoorsTreePlainExport(ms)) {
                export.ExportTree(model.Root, false);
            }
            ms.Flush(); ms.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(ms);

            Assert.That(sr.ReadLine(), Is.EqualTo("EAID;EAParent;Heading;Text"));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAPK_4C5C5A46_1F1A_4614_AF40_F61963762C30;;\"TC43-ItemizedList2\";\"\""));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAID_6EB893C5_24C3_4cb5_9B12_E1E15DF9CA97;EAPK_4C5C5A46_1F1A_4614_AF40_F61963762C30;\"Requirement1\";\""));
            Assert.That(sr.ReadLine(), Is.EqualTo("\t * ItemizedList1"));
            Assert.That(sr.ReadLine(), Is.EqualTo("\t * ItemizedList2"));
            Assert.That(sr.ReadLine(), Is.EqualTo("\""));
            Assert.That(sr.ReadLine(), Is.Null);
        }

        [Test]
        [DeploymentItem(@"XMI\TC44-BothLists1.xml")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S125:Sections of code should not be commented out", Justification = "False positive")]
        public void BothLists1()
        {
            EAModel model = EAModel.LoadXmi("TC44-BothLists1.xml");
            MemoryStream ms = new MemoryStream();
            using (CsvDoorsTreePlainExport export = new CsvDoorsTreePlainExport(ms)) {
                export.ExportTree(model.Root, false);
            }
            ms.Flush(); ms.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(ms);

            //<ol>
            //&#xA; -> <li>Ordered List<ol>
            //&#xA; -> <li>Itemized List</li>
            //&#xA;</ol>
            //&#xA;</li>
            //&#xA;</ol>
            //&#xA;
            //&#xA;<ol>
            //&#xA; -> <li>Ordered List </li>
            //&#xA;</ol>
            //&#xA;(Note we really wanted nested lists, but EA doesn't seem to let this happen)

            // Why does EA add stupid &#xA's everywhere?
            //  Let's see if we can trim elements after <ol> before <li>

            Assert.That(sr.ReadLine(), Is.EqualTo("EAID;EAParent;Heading;Text"));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAPK_45ED754A_2FE2_43eb_A2AB_CE1B1ED09E57;;\"TC44-BothLists1\";\"\""));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAID_4982E1CB_A042_4f4f_A479_064D49ED0389;EAPK_45ED754A_2FE2_43eb_A2AB_CE1B1ED09E57;\"Requirement1\";\""));
            Assert.That(sr.ReadLine(), Is.EqualTo("\t 1. Ordered List"));
            Assert.That(sr.ReadLine(), Is.EqualTo("\t  1. Itemized List"));
            Assert.That(sr.ReadLine(), Is.EqualTo(string.Empty));
            Assert.That(sr.ReadLine(), Is.EqualTo(string.Empty));
            Assert.That(sr.ReadLine(), Is.EqualTo(string.Empty));
            Assert.That(sr.ReadLine(), Is.EqualTo(string.Empty));
            Assert.That(sr.ReadLine(), Is.EqualTo(string.Empty));
            Assert.That(sr.ReadLine(), Is.EqualTo("\t 1. Ordered List"));
            Assert.That(sr.ReadLine(), Is.EqualTo(string.Empty));
            Assert.That(sr.ReadLine(), Is.EqualTo("(Note we really wanted nested lists, but EA doesn't seem to let this happen)\""));
            Assert.That(sr.ReadLine(), Is.Null);
        }

        [Test]
        [DeploymentItem(@"XMI\TC45-BothLists2.xml")]
        public void BothLists2()
        {
            EAModel model = EAModel.LoadXmi("TC45-BothLists2.xml");
            MemoryStream ms = new MemoryStream();
            using (CsvDoorsTreePlainExport export = new CsvDoorsTreePlainExport(ms)) {
                export.ExportTree(model.Root, false);
            }
            ms.Flush(); ms.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(ms);

            //<ul>
            //&#xA;	<li>Itemized List 1<ul>
            //&#xA;	<li><ul>
            //&#xA;	<li><ul>
            //&#xA;	<li>Itemized List 2</li>
            //&#xA;	<li>Itemized List 3</li>
            //&#xA;</ul>
            //&#xA;</li>
            //&#xA;</ul>
            //&#xA;</li>
            //&#xA;</ul>
            //&#xA;</li>
            //&#xA;</ul>
            //&#xA;(Note we really wanted nested lists, but EA doesn't seem to let this happen)

            // Why does EA add stupid &#xA's everywhere?
            //  Let's see if we can trim elements after <ul> before <li>

            Assert.That(sr.ReadLine(), Is.EqualTo("EAID;EAParent;Heading;Text"));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAPK_A34D21F7_B624_4f82_B6FD_DD6E60EAD764;;\"TC45-BothLists2\";\"\""));
            Assert.That(sr.ReadLine(), Is.EqualTo("EAID_2EF736C4_FD48_472f_84E6_5FA4E0CC65BE;EAPK_A34D21F7_B624_4f82_B6FD_DD6E60EAD764;\"Requirement1\";\""));
            Assert.That(sr.ReadLine(), Is.EqualTo("\t * Itemized List 1"));
            Assert.That(sr.ReadLine(), Is.EqualTo("\t  *"));
            Assert.That(sr.ReadLine(), Is.EqualTo("\t   *"));
            Assert.That(sr.ReadLine(), Is.EqualTo("\t    * Itemized List 2"));
            Assert.That(sr.ReadLine(), Is.EqualTo("\t    * Itemized List 3"));
            Assert.That(sr.ReadLine(), Is.EqualTo(string.Empty));
            Assert.That(sr.ReadLine(), Is.EqualTo(string.Empty));
            Assert.That(sr.ReadLine(), Is.EqualTo(string.Empty));
            Assert.That(sr.ReadLine(), Is.EqualTo(string.Empty));
            Assert.That(sr.ReadLine(), Is.EqualTo(string.Empty));
            Assert.That(sr.ReadLine(), Is.EqualTo(string.Empty));
            Assert.That(sr.ReadLine(), Is.EqualTo(string.Empty));
            Assert.That(sr.ReadLine(), Is.EqualTo("(Note we really wanted nested lists, but EA doesn't seem to let this happen)\""));
            Assert.That(sr.ReadLine(), Is.Null);
        }
    }
}
