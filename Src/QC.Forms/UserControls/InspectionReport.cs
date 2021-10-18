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
    public partial class InspectionReport : UserControl
    {

        private string _projectId = "";

        public InspectionReport(string id)
        {
            _projectId = id;
            InitializeComponent();

            var ucSurveyReport = new SurveyReport(_projectId) { Dock = DockStyle.Fill };
            tabSurveyReport.Controls.Add(ucSurveyReport);

            var ucSer = new SER(_projectId) { Dock = DockStyle.Fill };
            tabSer.Controls.Add(ucSer);

            var ucPhoto = new InspectionPhoto(_projectId) { Dock = DockStyle.Fill };
            tabPhoto.Controls.Add(ucPhoto);

        }
    }
}
