using System.Runtime.InteropServices;

namespace SEIMS.Services
{
    internal static class NativeMethods
    {
        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attribute, ref int value, int size);

        public static void OpenConsole()
        {
            AllocConsole();
        }

        /// <summary>Makes the Windows title bar dark (Windows 10 20H1+ / Windows 11).</summary>
        public static void UseDarkTitleBar(IntPtr handle)
        {
            try
            {
                int on = 1;
                DwmSetWindowAttribute(handle, 20, ref on, sizeof(int));
                DwmSetWindowAttribute(handle, 19, ref on, sizeof(int));
            }
            catch (Exception)
            {
                // older Windows: ignore
            }
        }
    }
}
