using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QC.Forms.UserControls
{
    public partial class FileCAD : UserControl
    {
        public FileCAD()
        {
            InitializeComponent();
        }

        public FileCAD(string id)
        {
            InitializeComponent();
            string file = @"E:\QC_Engr\CadFile.png";
            picBox.Image = new Bitmap(file);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            //saveDialog1.Filter = "Excel (*.xls)|*.xls";
            //saveDialog1.FileName = Text + ".xls";

            if (openDialog.ShowDialog(this) == DialogResult.OK)
            {
                string file = openDialog.FileName;

                picBox.Image = new Bitmap(file);
            }
        }
    }
}
