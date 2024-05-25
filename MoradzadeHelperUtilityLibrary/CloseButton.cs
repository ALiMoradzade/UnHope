using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoradzadeHelperUtilityLibrary
{
    internal static class CloseButton
    {
        const int SCClose = 0xf060, MFGrayed = 0x1, MFEnable = 0, MFDisable = 0x2;

        [DllImport("user32.dll")]
        static extern IntPtr GetSystemMenu(IntPtr HWNDValue, bool revert);

        [DllImport("user32.dll")]
        static extern IntPtr EnableMenuItem(IntPtr tMenu, int targetItem, int targetStatus);

        static void Enable(Form f) => EnableMenuItem(GetSystemMenu(f.Handle, false), SCClose, MFEnable);
        static void Grayed(Form f) => EnableMenuItem(GetSystemMenu(f.Handle, false), SCClose, MFGrayed);
        static void Disable(Form f) => EnableMenuItem(GetSystemMenu(f.Handle, false), SCClose, MFDisable);
    }
}
