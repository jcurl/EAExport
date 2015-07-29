namespace EAExport.Native
{
    using System.Runtime.InteropServices;

    internal class SafeNativeMethods
    {
        public const int ATTACH_PARENT_PROCESS = -1;

        [DllImport("kernel32.dll")]
        public static extern bool AttachConsole(int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool FreeConsole();
    }
}
