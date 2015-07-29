using System;
using System.Windows.Forms;
using CommandLine = HBAS.Utilities.CommandLine;

namespace EAExport
{
    static class Program
    {
        private static Model.Options options = new Model.Options();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0) {
                bool attached = Native.SafeNativeMethods.AttachConsole(Native.SafeNativeMethods.ATTACH_PARENT_PROCESS);
                CommandLineMode(args);
                if (attached) Native.SafeNativeMethods.FreeConsole();
            } else {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmEAExport());
            }
        }

        static void CommandLineMode(string[] args)
        {
            try {
                CommandLine.Options.Parse(options, args, CommandLine.OptionsStyle.Windows);
            } catch (CommandLine.OptionException e) {
                Console.WriteLine("ERROR: {0}", e.Message);
                return;
            }

            Model.EAModel eaModel;
            try {
                eaModel = Model.EAModel.LoadXmi(options.Input);
            } catch (Exception exception) {
                Console.WriteLine("Error loading model {0}\n  {1}", options.Input, exception.Message);
                return;
            }

            try {
                Model.EATree element;
                if (string.IsNullOrEmpty(options.RootGuid)) {
                    element = eaModel.Root;
                } else {
                    element = eaModel.FindGuid(options.RootGuid);
                    if (element == null) {
                        Console.WriteLine("Couldn't find node {0}. Aborting.", options.RootGuid);
                        return;
                    }
                }

                using (Model.ITreeExport exportFormat = new Model.CsvDoorsTreeExport(options.Output)) {
                    exportFormat.ExportTree(element, false);
                }
            } catch (Exception exception) {
                Console.WriteLine("Error exporting model {0} to {1}\n  {2}", options.Input, options.Output, exception.Message);
                return;
            }
        }
    }
}
