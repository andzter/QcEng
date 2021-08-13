using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace QC.Forms.Entry
{
    public partial class LaborCost : Telerik.WinControls.UI.RadForm
    {
        protected string _userid = Lib.Settings.GetSetting("userid");

        public delegate void UpdateEventHandler(object sender, EventArgs e);

        public event UpdateEventHandler UpdateHandler;

        public LaborCost()
        {
            InitializeComponent();
            var dtclassifications = new Repository.Lookup().GetClassifications();

            QC.Lib.Common.FillControl(cboclassification, dtclassifications);
        }

        private string _id = "";

        public LaborCost(string id)
        {
            InitializeComponent();
            _id = id;

            var dtclassification = new Repository.Lookup().GetClassifications();

            QC.Lib.Common.FillControl(cboclassification, dtclassification);

            var data = new Repository.LaborCost().GetLaborCostbyId(id);
            txtdescription.Text = data["Description"].ToString();
            txtprice1.Text = data["UnitCost1"].ToString();
            txtprice2.Text = data["UnitCost2"].ToString();
            txtprice3.Text = data["UnitCost3"].ToString();
            txtpickprice.Text = data["PickPrice"].ToString();
            cboclassification.Text = data["Classification"].ToString();
            txtsg.Text = data["SG"].ToString();



        }

        private void lblTtile_Click(object sender, EventArgs e)
        {

        }

        private void CloseWindow()
        {
            Dispose();
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            if (txtprice1.Text.Trim().Length == 0) txtprice1.Text = "0";
            if (txtprice2.Text.Trim().Length == 0) txtprice2.Text = "0";
            if (txtprice3.Text.Trim().Length == 0) txtprice3.Text = "0";

            var varPickPrice = Convert.ToDouble(txtprice1.Text);
            if (varPickPrice < Convert.ToDouble(txtprice2.Text)) varPickPrice = Convert.ToDouble(txtprice2.Text);
            if (varPickPrice < Convert.ToDouble(txtprice3.Text)) varPickPrice = Convert.ToDouble(txtprice3.Text);

            txtpickprice.Text = varPickPrice.ToString();

            (new Repository.LaborCost()).SaveLaborCost(_id, txtdescription.Text, 
                txtprice1.Text, txtprice2.Text, txtprice3.Text, txtpickprice.Text, cboclassification.Text, txtsg.Text, _userid);
            CloseWindow();
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            CloseWindow();
        }
    }
}
