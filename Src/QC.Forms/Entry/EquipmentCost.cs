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
    public partial class EquipmentCost : Telerik.WinControls.UI.RadForm
    {
        protected string _userid = Lib.Settings.GetSetting("userid");

        public delegate void UpdateEventHandler(object sender, EventArgs e);

        public event UpdateEventHandler UpdateHandler;

        public EquipmentCost()
        {
            InitializeComponent();
        }

        private string _id = "";

        public EquipmentCost(string id)
        {
            InitializeComponent();
            _id = id;

            var data = new Repository.EquipmentCost().GetEquipmentCostbyId(id);
            txtdescription.Text = data["Description"].ToString();
            txtmodel.Text = data["Model"].ToString();
            txtflywheelhp.Text = data["Flywheelhp"].ToString();
            txtoutput.Text = data["Output"].ToString();
            txtrentalhour1.Text = data["RentalHour1"].ToString();
            txtrentalhour2.Text = data["RentalHour2"].ToString();
            txtremarks.Text = data["Remarks"].ToString();

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
            if (txtrentalhour1.Text.Trim().Length == 0) txtrentalhour1.Text = "0";
            if (txtrentalhour2.Text.Trim().Length == 0) txtrentalhour2.Text = "0";

            (new Repository.EquipmentCost()).SaveEquipmentCost(_id, txtdescription.Text,
                txtmodel.Text, txtflywheelhp.Text, txtoutput.Text, txtrentalhour1.Text, txtrentalhour2.Text, txtremarks.Text, _userid);

            UpdateHandler(this, e); ///******
            CloseWindow();
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            CloseWindow();
        }
    }
}
