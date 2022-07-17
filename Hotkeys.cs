using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Hotkeys_Example
{
    internal class Hotkeys
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk); //handle, Id of hotkey, modifier (e.g ALT + DEL), hotkey key
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public static void Init(ComboBox comboBox)
        {
            var hotkeys = new List<string>() { "DEL", "INSERT", "HOME" };
            comboBox.DataSource = hotkeys;
        }

        public static void SetHotKey(ComboBox comboBox, IntPtr hWnd)
        {
            UnregisterHotKey(hWnd, 0);

            if (comboBox.Text == "DEL")
                RegisterHotKey(hWnd, 0, 0, Keys.Delete.GetHashCode());

            if (comboBox.Text == "INSERT")
                RegisterHotKey(hWnd, 0, 0, Keys.Insert.GetHashCode());

            if (comboBox.Text == "HOME")
                RegisterHotKey(hWnd, 0, 0, Keys.Home.GetHashCode());
        }
    }
}
