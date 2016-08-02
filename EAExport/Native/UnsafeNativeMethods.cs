namespace EAExport.Native
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    [SuppressUnmanagedCodeSecurity]
    internal static class UnsafeNativeMethods
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        public extern static int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);
    }
}
