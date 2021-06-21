using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Installer
{
    public class FileAssociation
    {
        private const string FILE_EXTENSION = ".PRO100";
        private const long SHCNE_ASSOCCHANGED = 0x8000000L;
        private const uint SHCNF_IDLIST = 0x0U;

        public static void Associate(string path, string description, string icon)
        {
            Registry.ClassesRoot.CreateSubKey(FILE_EXTENSION).SetValue("", "PRO100");

            using (RegistryKey key = Registry.ClassesRoot.CreateSubKey("PRO100"))
            {
                if (description != null)
                    key.SetValue("", description);

                if (icon != null)
                    key.CreateSubKey("DefaultIcon").SetValue("", ToShortPathName(icon));

                key.CreateSubKey(@"Shell\Open\Command").SetValue("", ToShortPathName(path) + " \"%1\"");
            }

            SHChangeNotify(SHCNE_ASSOCCHANGED, SHCNF_IDLIST, IntPtr.Zero, IntPtr.Zero);
        }

        public static bool IsAssociated
        {
            get { return (Registry.ClassesRoot.OpenSubKey(FILE_EXTENSION, false) != null); }
        }

        public static void Remove()
        {
            Registry.ClassesRoot.DeleteSubKeyTree(FILE_EXTENSION);
            Registry.ClassesRoot.DeleteSubKeyTree("PRO100");
        }

        [DllImport("shell32.dll", SetLastError = true)]
        private static extern void SHChangeNotify(long wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);

        [DllImport("Kernel32.dll")]
        private static extern uint GetShortPathName(string lpszLongPath, [Out] StringBuilder lpszShortPath, uint cchBuffer);

        private static string ToShortPathName(string longName)
        {
            StringBuilder s = new StringBuilder(1000);
            uint iSize = (uint)s.Capacity;
            uint iRet = GetShortPathName(longName, s, iSize);
            return s.ToString();
        }
    }
}
