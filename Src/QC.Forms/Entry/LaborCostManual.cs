using System;
using System.Data;
using Telerik.WinControls.UI;
using QC.Lib;

namespace QC.Forms.Entry
{
    public partial class LaborCostManual : RadForm
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

        public LaborCostManual(string _hid)
        {
            InitializeComponent();
            _headerid = _hid;

            var dtLaborCostCombo = new Repository.Lookup().GetLaborCostCombo();

            QC.Lib.Common.FillControl(cbodescription, dtLaborCostCombo);
            cbodescription.MaxDropDownItems = 10;

        }



        public LaborCostManual(string _hid, string id)
        {
            InitializeComponent();
            _id = id;
            _headerid = _hid;

            var dtLaborCostCombo = new Repository.Lookup().GetLaborCostCombo();

            QC.Lib.Common.FillControl(cbodescription, dtLaborCostCombo);
            cbodescription.MaxDropDownItems = 10;

            var data = new Repository.LaborCostManual().GetDupaDetailsbyId(_id);
            cbodescription.Text = data["Description"].ToString();
            txtnoofperson.Text = data["NoOfPersonsUnit"].ToString();
            txtnoofhours.Text = data["NoOfHoursQuantity"].ToString();

            var var3 = 0; 
            if (data["UnitCostHourlyRate"].ToString().Trim().Length > 0) var3 = (int)(double)(Convert.ToDouble(data["UnitCostHourlyRate"].ToString()));

            txthourlyrate.Text = var3.ToString();

            txtamount.Text = data["CostAmount"].ToString();
        }

        private void CloseWindow()
        {
            Dispose();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtnoofperson.Text.Trim().Length == 0) txtnoofperson.Text = "0";
            if (txtnoofhours.Text.Trim().Length == 0) txtnoofhours.Text = "0";
            if (txthourlyrate.Text.Trim().Length == 0) txthourlyrate.Text = "0";

            var var1 = Convert.ToDouble(txtnoofperson.Text);
            var var2 = Convert.ToDouble(txtnoofhours.Text);
            var var3 = Convert.ToDouble(txthourlyrate.Text);

            var varCostAmount = var1 * var2 * var3;

            (new Repository.LaborCostManual()).SaveDupaDetailsLabor(_headerid, _id, "A", cbodescription.Text,
                txtnoofperson.Text, txtnoofhours.Text, var3.ToString(), varCostAmount.ToString(), _userid);

            UpdateHandler(this, e); ///******

            CloseWindow();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseWindow();
        }

        private void cbodescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            string _laborid = QC.Lib.Common.ComboVal(cbodescription);
            DataRow dr = new QC.Lib.DataAccess().GetDataRow("Select PickPrice From LaborCost Where id = '" + _laborid + "'");
            if (dr != null)
            {
                double vartemp = 0;
                txthourlyrate.Text = dr.ItemArray[0].ToString();
                if (txthourlyrate.Text.Trim().Length > 0) vartemp = Convert.ToDouble(txthourlyrate.Text);
                txthourlyrate.Text = vartemp.ToString();
            }
            else txthourlyrate.Text = "0.00";
        }
    }
}
