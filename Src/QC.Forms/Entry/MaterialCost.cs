using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using QC.Lib;

namespace QC.Forms.Entry
{
    public partial class MaterialCost : Telerik.WinControls.UI.RadForm
    {
        protected string _userid = Global.UserId();

        public delegate void UpdateEventHandler(object sender, EventArgs e);

        public event UpdateEventHandler UpdateHandler;

        public MaterialCost()
        {
            InitializeComponent();
            var dtunits = new Repository.Lookup().GetUnits();

            QC.Lib.Common.FillControl(cboUnit, dtunits);
        }

        private string _id = "";

        public MaterialCost(string id)
        {
            InitializeComponent();
            _id = id;

            var data = new Repository.MaterialCostcs().GetMaterialCostbyId(id);
            txtdescription.Text = data["Description"].ToString();
            cboUnit.Text = data["Unit"].ToString();
            txtprice1.Text = data["UnitCost1"].ToString();
            txtprice2.Text = data["UnitCost2"].ToString();
            txtprice3.Text = data["UnitCost3"].ToString();
            txtprice4.Text = data["UnitCost4"].ToString();
            txtpickprice.Text = data["PickPrice"].ToString();

            var dtunits = new Repository.Lookup().GetUnits();

            QC.Lib.Common.FillControl(cboUnit, dtunits);

        }
 
        private void savebutton_Click(object sender, EventArgs e)
        {
            if (txtprice1.Text.Trim().Length == 0) txtprice1.Text = "0";
            if (txtprice2.Text.Trim().Length == 0) txtprice2.Text = "0";
            if (txtprice3.Text.Trim().Length == 0) txtprice3.Text = "0";
            if (txtprice4.Text.Trim().Length == 0) txtprice4.Text = "0";

            var varPickPrice = Convert.ToDouble(txtprice1.Text);
            if (varPickPrice < Convert.ToDouble(txtprice2.Text)) varPickPrice = Convert.ToDouble(txtprice2.Text);
            if (varPickPrice < Convert.ToDouble(txtprice3.Text)) varPickPrice = Convert.ToDouble(txtprice3.Text);
            if (varPickPrice < Convert.ToDouble(txtprice4.Text)) varPickPrice = Convert.ToDouble(txtprice4.Text);

            txtpickprice.Text = varPickPrice.ToString();

            (new Repository.MaterialCostcs()).SaveMaterialCost(_id, txtdescription.Text, cboUnit.Text,
                txtprice1.Text, txtprice2.Text, txtprice3.Text, txtprice4.Text, txtpickprice.Text, _userid);
            CloseWindow();
        }

        private void CloseWindow()
        {
            Dispose();
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            CloseWindow();
        }
    }
}
