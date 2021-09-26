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

            radPageViewPage1.Controls.Add(uc);
        }

        public DEDFolders(string id)
        {
            InitializeComponent();
           
            _id = id;

            var uc = new AddNewProject();
 

            radPageViewPage1.Controls.Add(uc);

            var data = new Repository.Project().GetProjectbyId(id);
            txtProject.Text = data["project"].ToString();

        }

    }
}
