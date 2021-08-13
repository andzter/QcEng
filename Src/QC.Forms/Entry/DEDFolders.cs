using QC.Forms.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace QC.Forms.Entry
{
    public partial class DEDFolders : Telerik.WinControls.UI.RadForm
    {
        protected string _userid = Lib.Settings.GetSetting("userid");

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
