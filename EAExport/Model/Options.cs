namespace EAExport.Model
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using HBAS.Utilities.CommandLine;

    public class Options : IOptions
    {
        [Option('o', "output")]
        public string Output { get; private set; }

        public string Input { get; private set; }

        [Option('r', "root")]
        public string RootGuid { get; private set; }

        [Option('?', "help")]
        public bool Help { get; private set; }

        [Option('f', "format")]
        public FormatType Format { get; private set; }

        [OptionArguments]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0044:Add readonly modifier", Justification = "Written via reflection")]
        private List<string> m_Arguments = new List<string>();

        public void Check()
        {
            if (Help) {
                Usage();
                Environment.Exit(0);
            }

            if (string.IsNullOrWhiteSpace(Output)) throw new OptionException("Option /o must be specified");
            if (m_Arguments.Count == 0) throw new OptionException("Must specify the input filename");
            if (m_Arguments.Count > 1) throw new OptionException("Can only specify a maximum of one input file");

            Input = m_Arguments[0];
            if (!File.Exists(Input)) throw new OptionException("File '" + Input + "' not found");
        }

        public void InvalidOption(string option)
        {
            Console.WriteLine("Invalid usage (error parsing option {0}). See help.", option);
        }

        public void Missing(IList<string> missingOptions)
        {
            Console.WriteLine("Mandatory options not specified on the command line. See help.");
        }

        public void Usage()
        {
            Console.WriteLine("EAExport.exe /o|/output:<outputfile> [/r|/root:<guid>] [/f|/format:<format>]");
            Console.WriteLine("             <inputfile>");
            Console.WriteLine("");
            Console.WriteLine("Version: {0}", typeof(frmEAExport).Assembly.GetName().Version);
            Console.WriteLine("");
            Console.WriteLine("Options");
            Console.WriteLine("  /o | /output <outputfile>");
            Console.WriteLine("    Specify the output filename after parsing the input.");
            Console.WriteLine("  /r | /root <eaid>");
            Console.WriteLine("    The EA ID of the object that is the root element, to start dumping from.");
            Console.WriteLine("    You can get this easily when starting the GUI, by selecting the element");
            Console.WriteLine("    and noting the 'Identifier'.");
            Console.WriteLine("  /f | /format <format>");
            Console.WriteLine("    Defines the format to use.");
            Console.WriteLine("     CSVHTML - HTML formatted CSV files. This is the default.");
            Console.WriteLine("     CSVTEXT - Plain text formatted CSV files.");
            Console.WriteLine("     DB45CHAPTERS - DocBook 4.5 fragment with Chapters as root.");
            Console.WriteLine("");
            Console.WriteLine("  <inputfile>");
            Console.WriteLine("    The XML file from Enterprise Architect (XMI 1.1) to parse for requirements.");
        }
    }
}
