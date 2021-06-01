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
    public partial class Inspection : Telerik.WinControls.UI.RadForm
    {
        protected string _userid = Lib.Settings.GetSetting("userid");

        public delegate void UpdateEventHandler(object sender, EventArgs e);

        public event UpdateEventHandler UpdateHandler;

 

        public Inspection()
        {
            InitializeComponent();
        }


        private string _id = "";
        public Inspection(string id)
        {
            InitializeComponent();
            _id = id;
            var dtusers = new Repository.Lookup().GetUsers();

            QC.Lib.Common.FillControl(cboRoute, dtusers);
        }

        private void lblTtile_Click(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            (new Repository.Project()).SaveRoute(_id, _userid, QC.Lib.Common.ComboVal(cboRoute), txtComment.Text);
        }
    }
}
