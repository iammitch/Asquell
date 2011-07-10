using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Asquell.Objects;

namespace Asquell.GUI
{
    public partial class FormMemoryDetail : Form
    {
        private AsquellObj _obj = null;
        public FormMemoryDetail()
        {
            InitializeComponent();
        }
        public FormMemoryDetail(AsquellObj obj)
        {
            InitializeComponent();
            _obj = obj;

            doGenerics();
            doSpecifics();
        }
        private void doGenerics()
        {
            propertyGrid_Generics.SelectedObject = _obj;
        }
        private void doSpecifics()
        {
            switch (_obj.Type)
            {
                case AsquellObjectType.Array:
                    displayArray();
                    break;
            }
        }

        //Specific Displays
        private void displayArray()
        {
            AsquellObj[] array = (AsquellObj[])_obj.Value;
            for (int i = 0; i < array.Length; i++)
            {
                listBox_Specifics.Items.Add("["+i+"] "+array[i].Value);
            }
        }

        private void listBox_Specifics_DoubleClick(object sender, EventArgs e)
        {
            if (listBox_Specifics.SelectedIndex >= 0)
            {
                if (_obj.Type == AsquellObjectType.Array)
                {
                    AsquellObj[] array = (AsquellObj[])_obj.Value;
                    new FormMemoryDetail(array[listBox_Specifics.SelectedIndex]).ShowDialog();
                }
            }
        }
    }
}
