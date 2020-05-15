namespace HBAS.Environment
{
    using System;

    /// <summary>
    /// Utility class providing OS specific functionality.
    /// </summary>
    public static class Platform
    {
        /// <summary>
        /// Determines whether the operating system is Windows NT or later.
        /// </summary>
        /// <returns>
        /// <see langword="true"/> if the operating system is Windows NT or later; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsWinNT()
        {
            return Environment.OSVersion.Platform == PlatformID.Win32NT;
        }
    }
}
