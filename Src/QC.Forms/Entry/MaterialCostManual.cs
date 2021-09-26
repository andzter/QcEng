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
    public partial class MaterialCostManual : Telerik.WinControls.UI.RadForm
    {
        protected string _userid = Global.UserId();

        public delegate void UpdateEventHandler(object sender, EventArgs e);

        public event UpdateEventHandler UpdateHandler;

        private string _id = "";
        private string _headerid = "";

        public void Record_Updated(object sender, EventArgs e)
        {
            try
            {
                UpdateHandler(sender, e);
            }
            catch
            {
                return;
            }
        }

        public MaterialCostManual(string _hid)
        {
            InitializeComponent();
            _headerid = _hid;

            var dtMaterialCostCombo = new Repository.Lookup().GetMaterialCostCombo();

            QC.Lib.Common.FillControl(cbodescription, dtMaterialCostCombo);
        }

        public MaterialCostManual(string _hid, string id)
        {
            InitializeComponent();
            _id = id;
            _headerid = _hid;

            var dtMaterialCostCombo = new Repository.Lookup().GetMaterialCostCombo();

            QC.Lib.Common.FillControl(cbodescription, dtMaterialCostCombo);

            var data = new Repository.MaterialCostManual().GetDupaDetailsbyId(_id);
            cbodescription.Text = data["Description"].ToString();
            txtunits.Text = data["NoOfPersonsUnit"].ToString();
            txtquantity.Text = data["NoOfHoursQuantity"].ToString();
            //txtunitcostperarea.Text = data["UnitCostHourlyRate"].ToString();

            var var3 = 0;
            if (data["UnitCostHourlyRate"].ToString().Trim().Length > 0) var3 = (int)(double)(Convert.ToDouble(data["UnitCostHourlyRate"].ToString()));

            txtunitcostperarea.Text = var3.ToString();

            txtamount.Text = data["CostAmount"].ToString();
        }

        private void CloseWindow()
        {
            Dispose();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            //if (txtunits.Text.Trim().Length == 0) txtunits.Text = "0";
            if (txtquantity.Text.Trim().Length == 0) txtquantity.Text = "0";
            if (txtunitcostperarea.Text.Trim().Length == 0) txtunitcostperarea.Text = "0";

            //var var1 = Convert.ToDouble(txtunits.Text);
            var var2 = Convert.ToDouble(txtquantity.Text);
            var var3 = Convert.ToDouble(txtunitcostperarea.Text);

            double varCostAmount = 0;
            if (var2 == 0) varCostAmount = var3;
            else
            varCostAmount = var2 * var3;

            (new Repository.MaterialCostManual()).SaveDupaDetailsMaterial(_headerid, _id, "C", cbodescription.Text,
                txtunits.Text, txtquantity.Text, var3.ToString(), varCostAmount.ToString(), _userid);

            UpdateHandler(this, e); ///******

            CloseWindow();
        }

        private void cbodescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            string _laborid = QC.Lib.Common.ComboVal(cbodescription);
            DataRow dr = new QC.Lib.DataAccess().GetDataRow("Select PickPrice From MaterialCost Where id = '" + _laborid + "'");
            if (dr != null)
            {
                double vartemp = 0;
                txtunitcostperarea.Text = dr.ItemArray[0].ToString();
                if (txtunitcostperarea.Text.Trim().Length > 0) vartemp = Convert.ToDouble(txtunitcostperarea.Text);
                txtunitcostperarea.Text = vartemp.ToString();
            }
            else txtunitcostperarea.Text = "0";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseWindow();
        }
    }
}
