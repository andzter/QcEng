using QC.Forms.UserControls;
using QC.Lib;
using System;
using System.Windows.Forms;

namespace QC.Forms.Entry
{
    public partial class DesignProject : Telerik.WinControls.UI.RadForm
    {

        protected string _userid = Global.UserId();

        public delegate void UpdateEventHandler(object sender, EventArgs e);

        public event UpdateEventHandler UpdateHandler;
        

        public DesignProject()
        {
            InitializeComponent();
        }

        private string _id = "";

        public DesignProject(string id)
        {
            InitializeComponent();
            _id = id;
            var dtusers = new Repository.Lookup().GetUsers();

            var uProjHeader = new QC.Forms.UserControls.ProjectHeader(id);

            panelInfo.Controls.Add(uProjHeader);


            //QC.Lib.Common.FillControl(cboRoute, dtusers);

            var uBom = new BOM(_id) { Dock = DockStyle.Fill };
            pgEstimates.Controls.Add(uBom);
            pgSOW.Controls.Add(uBom);
            pgTakeOff.Controls.Add(uBom);


            //var lstEquipment = 
           // var lstManpower = new PersonnelList(_id) { Dock = DockStyle.Fill };

            pgEquipment.Controls.Add(new EquipmentList(_id) { Dock = DockStyle.Fill });
            pgManpower.Controls.Add(new ManpowerList(_id) { Dock = DockStyle.Fill });

            var data = new Repository.Project().GetProjectbyId(id);
            //txtProject.Text = data["project"].ToString();

            pgEstimates.Controls.Add(new UserControls.BOM(id) { Dock = DockStyle.Fill });

            pgCADFile.Controls.Add(new UserControls.FileCAD(id) { Dock = DockStyle.Fill });

            pgPDFFile.Controls.Add(new UserControls.FilePDF(id) { Dock = DockStyle.Fill });

            pgTechSpecs.Controls.Add(new UserControls.FilePDF(id) { Dock = DockStyle.Fill });

            //pgSOW.Text = "Technical Specification";

            // pgSOW.Controls.Add(new UserControls.FileCAD(id) { Dock = DockStyle.Fill });

            pgSched.Controls.Add(new UserControls.Schedule(id) { Dock = DockStyle.Fill });

        }

        private void label4_Click(object sender, EventArgs e)
        {
            

        }

        private void cboRoute_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //(new Repository.Project()).SaveRoute(_id, _userid, QC.Lib.Common.ComboVal(cboRoute), txtComment.Text);

            // var frm = (new DesignPlanDetails(_id));
            // frm.Show();

            MessageBox.Show("Saved!");
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            (new List.ProjectBom2("1234")).Show();
        }
    }
}
