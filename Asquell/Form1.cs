using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Asquell.Objects;

namespace Asquell
{
    public partial class Form1 : Form
    {
        private Dictionary<string, AsquellObj> _mem = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_Execute_Click(object sender, EventArgs e)
        {
            Asquell scriptRuntime = new Asquell(textBox_Code.Text.Split(new string[] { Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries));

            scriptRuntime.Run();

            _mem = scriptRuntime.MemorySnapshot();
            foreach (string memName in _mem.Keys)
            {
                listBox_MemoryObjects.Items.Add(memName);
            }
        }

        private void listBox_MemoryObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_MemoryObjects.SelectedIndex >= 0)
            {
                string key = (string)listBox_MemoryObjects.Items[listBox_MemoryObjects.SelectedIndex];
                if (key!=null)
                    propertyGrid_MemoryObj.SelectedObject = _mem[key];
            }
        }
    }
}
