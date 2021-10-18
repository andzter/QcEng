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
    public partial class TechSpecs : UserControl
    {
        public TechSpecs(string id)
        {
            InitializeComponent();
            string url = @"E:\QC_Engr\techspecs.pdf";

            webBrowser.Navigate(url);
        }
    }
}
