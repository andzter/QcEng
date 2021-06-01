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
    public partial class DesignEstimate : Telerik.WinControls.UI.RadForm
    {

        protected string _userid = Lib.Settings.GetSetting("userid");

        public delegate void UpdateEventHandler(object sender, EventArgs e);

        public event UpdateEventHandler UpdateHandler;

        

        public DesignEstimate()
        {
            InitializeComponent();
        }

        private string _id = "";
        public DesignEstimate(string id)
        {
            InitializeComponent();
            _id = id;
            var dtusers = new Repository.Lookup().GetUsers();

            QC.Lib.Common.FillControl(cboRoute, dtusers);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            

        }

        private void cboRoute_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            (new Repository.Project()).SaveRoute(_id, _userid, QC.Lib.Common.ComboVal(cboRoute), txtComment.Text);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            (new List.ProjectBom2("1234")).Show();
        }
    }
}
