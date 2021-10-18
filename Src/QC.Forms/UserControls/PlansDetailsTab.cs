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
    public partial class PlansDetailsTab : UserControl
    {
        private string _projectId = "";

        public PlansDetailsTab(string id)
        {
            InitializeComponent();

            var ucCad = new FileCAD(_projectId) { Dock = DockStyle.Fill };
            tabCAD.Controls.Add(ucCad);

            var ucPdf = new FilePDF(_projectId) { Dock = DockStyle.Fill };
            tabPDF.Controls.Add(ucPdf);
             
        }
    }
}
