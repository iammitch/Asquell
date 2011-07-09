using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Asquell
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Execute_Click(object sender, EventArgs e)
        {
            Asquell scriptRuntime = new Asquell(textBox_Code.Text.Split(new string[] { Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries));

            scriptRuntime.Run();
        }
    }
}
