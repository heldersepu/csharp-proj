using Microsoft.Win32;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ChangeDeskWallpaper
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SetColor(Color.Black);
        }

        public static void SetColor(Color color)
        {
            // Remove the current wallpaper
            NativeMethods.SystemParametersInfo(
                NativeMethods.SPI_SETDESKWALLPAPER, 0, "",
                NativeMethods.SPIF_UPDATEINIFILE | NativeMethods.SPIF_SENDWININICHANGE);

            // Set the new desktop solid color for the current session
            int[] elements = { NativeMethods.COLOR_DESKTOP };
            int[] colors = { System.Drawing.ColorTranslator.ToWin32(color) };
            NativeMethods.SetSysColors(elements.Length, elements, colors);

            // Save value in registry so that it will persist
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Control Panel\\Colors", true);
            key.SetValue(@"Background", string.Format("{0} {1} {2}", color.R, color.G, color.B));
        }

        private static class NativeMethods
        {
            public const int COLOR_DESKTOP = 1;
            public const int SPI_SETDESKWALLPAPER = 20;
            public const int SPIF_UPDATEINIFILE = 0x01;
            public const int SPIF_SENDWININICHANGE = 0x02;

            [DllImport("user32.dll")]
            public static extern bool SetSysColors(int cElements, int[] lpaElements, int[] lpaRgbValues);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        }
    }
}
