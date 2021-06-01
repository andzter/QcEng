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
    public partial class DesignPlanDetails : Telerik.WinControls.UI.RadForm
    {
        protected string _userid = Lib.Settings.GetSetting("userid");

        public delegate void UpdateEventHandler(object sender, EventArgs e);

        public event UpdateEventHandler UpdateHandler;

        public DesignPlanDetails()
        {
            InitializeComponent();
            var dtusers = new Repository.Lookup().GetUsers();

            QC.Lib.Common.FillControl(cboRoute, dtusers);
        }

        public DesignPlanDetails(string id)
        {
            InitializeComponent();

            var dtusers = new Repository.Lookup().GetUsers();
            QC.Lib.Common.FillControl(cboRoute, dtusers);
        }
    }
}
