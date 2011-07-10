using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Asquell.Objects;
using System.IO;

namespace Asquell
{
    public partial class FormMain : Form
    {
        private Dictionary<string, AsquellObj> _mem = null;

        Asquell scriptRuntime = null;
        bool running = false;
        int pos = 0;
        string[] runLineCode = null;

        public FormMain()
        {
            InitializeComponent();
        }

        private void button_Execute_Click(object sender, EventArgs e)
        {
            Running = true;

            scriptRuntime = new Asquell(textBox_Code.Text.Split(new string[] { Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries));

            scriptRuntime.Run();

            displayMemorySnapshot();

            Running = false;
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
        public bool Running
        {
            get { return running; }
            set
            {
                button_Execute.Enabled = !value;
                running = value;
            }
        }

        private void button_RunLine_Click(object sender, EventArgs e)
        {
            Running = true;
            if (runLineCode == null)
            {
                runLineCode = textBox_Code.Text.Split(new string[] { Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries);
                scriptRuntime = new Asquell(runLineCode);
            }

            scriptRuntime.RunLine(pos);

            displayMemorySnapshot();

            textBox_lastLine.Text = runLineCode[pos];

            pos++;

            if (pos == runLineCode.Length)
            {
                Running = false;
                runLineCode = null;
                pos = 0;
            }
        }

        private void displayMemorySnapshot()
        {
            listBox_MemoryObjects.Items.Clear();
            _mem = scriptRuntime.MemorySnapshot();
            foreach (string memName in _mem.Keys)
            {
                listBox_MemoryObjects.Items.Add(memName);
            }
        }

        private void listBox_MemoryObjects_DoubleClick(object sender, EventArgs e)
        {
            if (listBox_MemoryObjects.SelectedIndex >= 0)
            {
                string key = (string)listBox_MemoryObjects.Items[listBox_MemoryObjects.SelectedIndex];
                if (key != null)
                    new GUI.FormMemoryDetail(_mem[key]).ShowDialog();
            }
        }

        private void button_loadScript_Click(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog_LoadScript.ShowDialog();
            if (res == DialogResult.OK)
            {
                textBox_Code.Text = File.ReadAllText(openFileDialog_LoadScript.FileName);
            }
        }

        private void button_saveScript_Click(object sender, EventArgs e)
        {
            DialogResult res = saveFileDialog_SaveScript.ShowDialog();
            if (res == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDialog_SaveScript.FileName, textBox_Code.Text);
                }
                catch (IOException ioe)
                {
                    MessageBox.Show(ioe.Message, "Script Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
