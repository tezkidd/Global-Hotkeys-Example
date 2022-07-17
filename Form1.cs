using System;
using System.Windows.Forms;

namespace Hotkeys_Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Hotkeys.Init(comboBox1);
        }

        protected override void WndProc(ref Message hotkey)
        {
            bool Visible = this.Visible;
            base.WndProc(ref hotkey);

            if (Visible && hotkey.Msg == 0x0312)
            {
                //your code here
                MessageBox.Show("Global hotkey pressed");
            }

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Hotkeys.SetHotKey(comboBox1, Handle);
        }
    }
}
