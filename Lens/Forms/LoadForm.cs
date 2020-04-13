using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lens
{
    public partial class LoadForm : Form
    {
        public LoadForm()
        {
            InitializeComponent();
            string[] files = Directory.GetFiles(SaveLoad.Path);
            for (int i = 0; i < files.Length; i++)
            {
                lvi = new ListViewItem();
                lvi.Text = files[i].Remove(0, files[i].LastIndexOf('\\') + 1);
                if (lvi.Text.Substring(lvi.Text.Length - SaveLoad.FileFormat.Length) == SaveLoad.FileFormat) 
                {
                    lvi.Text = lvi.Text.Remove(lvi.Text.Length - SaveLoad.FileFormat.Length, SaveLoad.FileFormat.Length);
                    listView1.Items.Add(lvi);
                }
            }
            listView1.TileSize = new Size(listView1.Width, listView1.Height / 5);
        }
        ListViewItem lvi;
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            lvi = listView1.FocusedItem;
            SaveLoad.FileName = lvi.Text;
            SaveLoad.Load();

            Close();
        }
    }
}
