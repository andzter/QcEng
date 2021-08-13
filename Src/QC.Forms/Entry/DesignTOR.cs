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
    public partial class DesignTOR : Telerik.WinControls.UI.RadForm
    {
        public DesignTOR()
        {
            InitializeComponent();

            var dtusers = new Repository.Lookup().GetUsers();
            QC.Lib.Common.FillControl(cboRoute, dtusers);

        }

        public DesignTOR(string id)
        {
            InitializeComponent();

            var dtusers = new Repository.Lookup().GetUsers();
            QC.Lib.Common.FillControl(cboRoute, dtusers);

            var data = new Repository.Project().GetProjectbyId(id);
            txtProject.Text = data["project"].ToString();

        }

    }
}
