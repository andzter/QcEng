using QC.Forms.UserControls;
using QC.Lib;
using System;
using System.Windows.Forms;

namespace QC.Forms.Entry
{
    public partial class DEDFolders : Telerik.WinControls.UI.RadForm
    {
        protected string _userid = Global.UserId();

        public delegate void UpdateEventHandler(object sender, EventArgs e);

        public event UpdateEventHandler UpdateHandler;

        private string _id = "";
 

        public DEDFolders()
        {
            InitializeComponent();

            var uc = new AddNewProject() {Dock= DockStyle.Fill };

            pgEstimates.Controls.Add(uc);
        }

        public DEDFolders(string id)
        {
            InitializeComponent();
           
            _id = id;

            var uc = new ProjectHeader(_id) { Dock = DockStyle.Fill };

            //radPageViewPage1.Controls.Add(uc);

            panelInfo.Controls.Add(uc);

            var ucEstTab = new EstimatesTab(_id) { Dock = DockStyle.Fill };

            pgEstimates.Controls.Add(ucEstTab);

            var ucCertInspection = new InspectionCertificate(_id) { Dock = DockStyle.Fill };
            pgInspectionCert.Controls.Add(ucCertInspection);

            var ucTOR = new TechSpecs(_id) { Dock = DockStyle.Fill };
            pgTechSpecs.Controls.Add(ucTOR);

            var ucPlansDetails = new PlansDetailsTab(_id) { Dock = DockStyle.Fill };
            pgPlanDetails.Controls.Add(ucPlansDetails);

            var ucInspReport = new InspectionReport(_id) { Dock = DockStyle.Fill };
            pgInspectionReport.Controls.Add(ucInspReport);


            
        }








    }
}
