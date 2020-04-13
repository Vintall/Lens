using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lens
{
    public partial class SaveForm : Form
    {
        public SaveForm()
        {
            InitializeComponent();
            nameBox.Text = SaveLoad.FileName;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            SaveLoad.Save();
            Close();
        }

        private void NameBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SaveLoad.FileName = nameBox.Text;
            }
            catch
            {
                nameBox.Text = "Error";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveLoad.Load();
        }
    }
}
