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
    public partial class FilePDF : UserControl
    {
        public FilePDF()
        {
            InitializeComponent();
        }

        public FilePDF(string projectId)
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            //saveDialog1.Filter = "Excel (*.xls)|*.xls";
            //saveDialog1.FileName = Text + ".xls";

            if (openDialog.ShowDialog(this) == DialogResult.OK)
            {
                string file = openDialog.FileName;

                webBrowser.Navigate(file);

                //picBox.Image = new Bitmap(file);
            }
        }
    }
}
