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
    public partial class EquipmentCostManual : Telerik.WinControls.UI.RadForm
    {
        protected string _userid = Lib.Settings.GetSetting("userid");

        public delegate void UpdateEventHandler(object sender, EventArgs e);

        public event UpdateEventHandler UpdateHandler;

        private string _id = "";
        private string _headerid = "";
        private string _strlaboramount = "";

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

        public EquipmentCostManual(string _hid, string _laboramount)
        {
            InitializeComponent();
            _headerid = _hid;
            _strlaboramount = _laboramount;

            var dtEquipmentCostCombo = new Repository.Lookup().GetEquipmentCostCombo();

            QC.Lib.Common.FillControl(cbodescription, dtEquipmentCostCombo);
        }

        public EquipmentCostManual(string _hid, string id, string _laboramount)
        {
            InitializeComponent();
            _id = id;
            _headerid = _hid;
            _strlaboramount = _laboramount;

            var dtEquipmentCostCombo = new Repository.Lookup().GetEquipmentCostCombo();

            QC.Lib.Common.FillControl(cbodescription, dtEquipmentCostCombo);

            var data = new Repository.EquipmentCostManual().GetDupaDetailsbyId(_id);
            cbodescription.Text = data["Description"].ToString();
            txtnoofunits.Text = data["NoOfPersonsUnit"].ToString();
            txtnoofhours.Text = data["NoOfHoursQuantity"].ToString();
            //txthourlyrate.Text = data["UnitCostHourlyRate"].ToString();

            var var3 = 0;
            if (data["UnitCostHourlyRate"].ToString().Trim().Length > 0) var3 = (int)(double)(Convert.ToDouble(data["UnitCostHourlyRate"].ToString()));

            txtcost.Text = data["CostAmount"].ToString();
        }

        private void CloseWindow()
        {
            Dispose();
        }

        private void cbodescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            string _laborid = QC.Lib.Common.ComboVal(cbodescription);
            DataRow dr = new QC.Lib.DataAccess().GetDataRow("Select RentalHour1,Model,FlywheelHP,Output From EquipmentCost Where id = '" + _laborid + "'");
            if (dr != null)
            {
                //txthourlyrate.Text = dr.ItemArray[0].ToString();

                double vartemp = 0;
                txthourlyrate.Text = dr.ItemArray[0].ToString();
                if (txthourlyrate.Text.Trim().Length > 0) vartemp = Convert.ToDouble(txthourlyrate.Text);
                txthourlyrate.Text = vartemp.ToString();

                txtmodel.Text = dr.ItemArray[1].ToString();
                txtflywheelhp.Text = dr.ItemArray[2].ToString();
                txtoutput.Text = dr.ItemArray[3].ToString();
            }
            else
            {
                txthourlyrate.Text = "0";
                txtmodel.Text = "";
                txtflywheelhp.Text = "";
                txtoutput.Text = "";
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string _la = _strlaboramount;

            if (txtnoofunits.Text.Trim().Length == 0) txtnoofunits.Text = "0";
            if (txtnoofhours.Text.Trim().Length == 0) txtnoofhours.Text = "0";
            if (txthourlyrate.Text.Trim().Length == 0) txthourlyrate.Text = "0";
            if (_strlaboramount.Trim().Length == 0) _la = "0";

            double var1 = Convert.ToDouble(txtnoofunits.Text);
            double var2 = Convert.ToDouble(txtnoofhours.Text);
            double var3 = Convert.ToDouble(txthourlyrate.Text);

            double varCostAmount = 0;

            if (cbodescription.Text.ToUpper().IndexOf("MINOR TOOLS") >= 0)
            {
                var1 = Convert.ToDouble(_la);
                var2 = (var1 * 0.1);
                varCostAmount = (double)(var2);
            }
            else
            {
                if (var1 == 0 || var2 == 0) varCostAmount = (double)(var3);
                else
                    varCostAmount = (double)(var1 * var2 * var3);
            }
            

            (new Repository.LaborCostManual()).SaveDupaDetailsLabor(_headerid, _id, "B", cbodescription.Text,
                txtnoofunits.Text, txtnoofhours.Text, var3.ToString(), varCostAmount.ToString(), _userid);

            UpdateHandler(this, e); ///******

            CloseWindow();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseWindow();
        }
    }
}
