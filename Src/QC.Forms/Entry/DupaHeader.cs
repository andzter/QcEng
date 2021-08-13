using QC.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace QC.Forms.Entry
{
    public partial class DupaHeader : Telerik.WinControls.UI.RadForm
    {
        protected string _userid = Lib.Settings.GetSetting("userid");

        public delegate void UpdateEventHandler(object sender, EventArgs e);

        public event UpdateEventHandler UpdateHandler;

        public void Record_Updated(object sender, EventArgs e)
        {
            //event when edit record is fired.
            LoadDataLabor();
            LoadDataEquipment();
            LoadDataMaterial();
            LoadSummaryGrid();
        }

        

        public DupaHeader()
        {
            InitializeComponent();
            var dtUnitCombo = new Repository.Lookup().GetUnits();

            QC.Lib.Common.FillControl(cbounit, dtUnitCombo);
        }

        private string _id = "";

        public DupaHeader(string id)
        {
            InitializeComponent();
            _id = id;

            var dtUnitCombo = new Repository.Lookup().GetUnits();

            QC.Lib.Common.FillControl(cbounit, dtUnitCombo);

            var data = new Repository.DupaHeader().GetDupaHeaderbyId(id);
            txtitemcode.Text = data["ItemCode"].ToString();
            txtdescription.Text = data["Description"].ToString();
            cbounit.Text = data["Unit"].ToString();

            txtassumedoutput.Text = data["AssumedOutputHour"].ToString();
            txtassumedlength.Text = data["AssumedNoOfUnitsLength"].ToString();
            txtwidth.Text = data["Width"].ToString();
            txtarea.Text = data["Area"].ToString();
            txtdepth.Text = data["Depth"].ToString();
            txtvolume.Text = data["Volume"].ToString();

            LoadDataLabor();
            LoadDataEquipment();
            LoadDataMaterial();
            LoadSummaryGrid();
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
            if (txtwidth.Text.Trim().Length == 0) txtwidth.Text = "0";
            if (txtarea.Text.Trim().Length == 0) txtarea.Text = "0";
            if (txtdepth.Text.Trim().Length == 0) txtdepth.Text = "0";
            if (txtvolume.Text.Trim().Length == 0) txtvolume.Text = "0";
            if (txtunitcost.Text.Trim().Length == 0) txtunitcost.Text = "0";

            if (txtlaborcosttotal.Text.Trim().Length == 0) txtlaborcosttotal.Text = "0";
            if (txtequipmentcosttotal.Text.Trim().Length == 0) txtequipmentcosttotal.Text = "0";
            if (txtmaterialcosttotal.Text.Trim().Length == 0) txtmaterialcosttotal.Text = "0";

            if (txtassumedlength.Text.Trim().Length == 0) txtassumedlength.Text = "0";
            if (txtweight.Text.Trim().Length == 0) txtweight.Text = "0";
            if (txtassumednoofunits.Text.Trim().Length == 0) txtassumednoofunits.Text = "0";

            (new Repository.DupaHeader()).SaveDupaHeader(_id, txtitemcode.Text, txtdescription.Text,cbounit.Text,txtunitcost.Text,
                txtassumedoutput.Text,txtassumedlength.Text, txtwidth.Text, txtarea.Text, txtdepth.Text, txtvolume.Text, txtweight.Text,txtassumednoofunits.Text, _userid);

            if (_id.ToString().Trim().Length == 0)
            {
                var data = new Repository.DupaHeader().GetDupaHeaderId(txtitemcode.Text);
                _id = data["Id"].ToString();
            }

            LoadDataEquipment();
            LoadSummaryGrid();

            UpdateHandler(this, e);

            //CloseWindow();
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            //UpdateHandler(this, e);
            CloseWindow();
        }

        

        protected virtual void LoadDataLabor()
        {
            try
            {
                radGridView1.BeginUpdate();

                var data = GetDataLabor();

                radGridView1.DataSource = data;

                radGridView1.MasterTemplate.AllowAddNewRow = false;

                //GridUtil.InitDefualtGrid(radGridView1); 

                radGridView1.ShowGroupPanel = false;
                radGridView1.Columns[0].IsVisible = false;
                radGridView1.Columns[1].IsVisible = false;
                radGridView1.Columns[2].IsVisible = false;
                radGridView1.Columns[3].Width = 270;
                radGridView1.Columns[4].Width = 80;
                radGridView1.Columns[5].Width = 80;
                radGridView1.Columns[6].Width = 80;
                radGridView1.Columns[7].Width = 90;

                radGridView1.Columns[4].TextAlignment = ContentAlignment.MiddleRight;
                radGridView1.Columns[5].TextAlignment = ContentAlignment.MiddleRight;
                radGridView1.Columns[6].TextAlignment = ContentAlignment.MiddleRight;
                radGridView1.Columns[7].TextAlignment = ContentAlignment.MiddleRight;

                radGridView1.Columns[4].FormatString = "{0:#,##0.00}";
                radGridView1.Columns[5].FormatString = "{0:#,##0.00}";
                radGridView1.Columns[6].FormatString = "{0:#,##0.00}";
                radGridView1.Columns[7].FormatString = "{0:#,##0.00}";

                radGridView1.EndUpdate(true);

                double dblTotalLabor = 0;
                foreach (GridViewDataRowInfo dataRow in this.GetAllRows(this.radGridView1.MasterTemplate))
                {
                    dblTotalLabor += Convert.ToDouble(dataRow.Cells[7].Value);
                }
                txtlaborcosttotal.Text = string.Format("{0:#,##0.00}", dblTotalLabor.ToString());
                txtlaborcosttotal.TextAlign = HorizontalAlignment.Right;
            }
            catch (Exception ex)
            {

                if (InvokeRequired)
                {
                    Invoke(new EventHandler(delegate
                    {
                        FormUtils.ShowError(ex, "Get Data Error");
                    }));
                }
                else
                {
                    FormUtils.ShowError(ex, "Get Data Error");
                }


                return;
            }
        }

        protected virtual void LoadDataEquipment()
        {
            try
            {
                radGridView2.BeginUpdate();

                var data = GetDataEquipment();

                radGridView2.DataSource = data;

                radGridView2.MasterTemplate.AllowAddNewRow = false;

                radGridView2.ShowGroupPanel = false;
                radGridView2.Columns[0].IsVisible = false;
                radGridView2.Columns[1].IsVisible = false;
                radGridView2.Columns[2].IsVisible = false;
                radGridView2.Columns[3].Width = 270;
                radGridView2.Columns[4].Width = 80;
                radGridView2.Columns[5].Width = 80;
                radGridView2.Columns[6].Width = 80;
                radGridView2.Columns[7].Width = 90;

                radGridView2.Columns[4].TextAlignment = ContentAlignment.MiddleRight;
                radGridView2.Columns[5].TextAlignment = ContentAlignment.MiddleRight;
                radGridView2.Columns[6].TextAlignment = ContentAlignment.MiddleRight;
                radGridView2.Columns[7].TextAlignment = ContentAlignment.MiddleRight;

                radGridView2.Columns[4].FormatString = "{0:#,##0.00}";
                radGridView2.Columns[5].FormatString = "{0:#,##0.00}";
                radGridView2.Columns[6].FormatString = "{0:#,##0.00}";
                radGridView2.Columns[7].FormatString = "{0:#,##0.00}";

                radGridView2.EndUpdate(true);

                double dblTotalEquipment = 0;
                foreach (GridViewDataRowInfo dataRow in this.GetAllRows(this.radGridView2.MasterTemplate))
                {
                    dblTotalEquipment += Convert.ToDouble(dataRow.Cells[7].Value);
                }
                txtequipmentcosttotal.Text = string.Format("{0:#,##0.00}", dblTotalEquipment.ToString());
                txtequipmentcosttotal.TextAlign = HorizontalAlignment.Right;
            }
            catch (Exception ex)
            {

                if (InvokeRequired)
                {
                    Invoke(new EventHandler(delegate
                    {
                        FormUtils.ShowError(ex, "Get Data Error");
                    }));
                }
                else
                {
                    FormUtils.ShowError(ex, "Get Data Error");
                }


                return;
            }
        }

        protected virtual void LoadSummaryGrid()
        {
            try
            {
                if (radGridView4.Rows.Count == 0)
                {
                    GridViewTextBoxColumn textBoxColumn = new GridViewTextBoxColumn();
                    textBoxColumn.Name = "Column1";
                    textBoxColumn.HeaderText = "Description";
                    textBoxColumn.FieldName = "Description";
                    textBoxColumn.MaxLength = 200;
                    textBoxColumn.TextAlignment = ContentAlignment.MiddleLeft;
                    textBoxColumn.Width = 450;
                    radGridView4.MasterTemplate.Columns.Add(textBoxColumn);

                    GridViewTextBoxColumn textBoxColumn2 = new GridViewTextBoxColumn();
                    textBoxColumn2.Name = "Column2";
                    textBoxColumn2.HeaderText = "Say";
                    textBoxColumn2.FieldName = "Say";
                    textBoxColumn2.MaxLength = 100;
                    textBoxColumn2.TextAlignment = ContentAlignment.MiddleLeft;
                    textBoxColumn2.Width = 80;
                    radGridView4.MasterTemplate.Columns.Add(textBoxColumn2);

                    GridViewTextBoxColumn textBoxColumn3 = new GridViewTextBoxColumn();
                    textBoxColumn3.Name = "Column3";
                    textBoxColumn3.HeaderText = "Total";
                    textBoxColumn3.FieldName = "Total";
                    textBoxColumn3.MaxLength = 100;
                    textBoxColumn3.TextAlignment = ContentAlignment.MiddleLeft;
                    textBoxColumn3.Width = 90;
                    radGridView4.MasterTemplate.Columns.Add(textBoxColumn3);

                    radGridView4.Columns[0].TextAlignment = ContentAlignment.MiddleLeft;
                    radGridView4.Columns[1].TextAlignment = ContentAlignment.MiddleRight;
                    radGridView4.Columns[2].TextAlignment = ContentAlignment.MiddleRight;

                    radGridView4.Columns[2].FormatString = "{0:#,##0.00}";

                    if (txtassumedlength.Text.Trim().Length == 0) txtassumedlength.Text = "0";
                    if (txtvolume.Text.Trim().Length == 0) txtvolume.Text = "0";
                    if (txtweight.Text.Trim().Length == 0) txtweight.Text = "0";
                    if (txtassumednoofunits.Text.Trim().Length == 0) txtassumednoofunits.Text = "0";

                    if (txtlaborcosttotal.Text.Trim().Length == 0) txtlaborcosttotal.Text = "0";
                    if (txtequipmentcosttotal.Text.Trim().Length == 0) txtequipmentcosttotal.Text = "0";
                    if (txtmaterialcosttotal.Text.Trim().Length == 0) txtmaterialcosttotal.Text = "0";

                    double dblD = Convert.ToDouble(txtlaborcosttotal.Text) + Convert.ToDouble(txtequipmentcosttotal.Text) + Convert.ToDouble(txtmaterialcosttotal.Text);
                    double dblE = 0;
                    double dblF = 0;
                    double dblSay = 0;
                    string strG = string.Empty;

                    string str2ndRow = "";
                    string str3rdRow = "";
                    string str4thRow = "";

                    switch (cbounit.Text.Trim().ToUpper())
                    {
                        case "SQ.M.":
                            str2ndRow = "Total Area(sq.m)";
                            dblE = Convert.ToDouble(txtassumedlength.Text);
                            str3rdRow = "Unit Cost per Area";
                            dblF = RoundUp(dblD / dblE, 2);
                            dblSay = RoundUp(dblF, 1);
                            str4thRow = "Direct Unit Cost";
                            strG = dblSay + "/sq.m.";
                            break;
                        case "L.M.":
                            str2ndRow = "Total Linear meter (l.m.)";
                            dblE = Convert.ToDouble(txtassumedlength.Text);
                            str3rdRow = "Unit Cost per Area";
                            dblF = dblD / dblE;
                            dblSay = RoundUp(dblF, 2);
                            str4thRow = "Direct Unit Cost";
                            strG = dblSay + "/l.m.";
                            break;
                        case "EACH":
                            str2ndRow = "Total Quantity (each)";
                            dblE = Convert.ToDouble(txtassumedlength.Text);
                            str3rdRow = "Unit Cost per Area";
                            dblF = dblD / dblE;
                            dblSay = RoundUp(dblF, 2);
                            str4thRow = "Direct Unit Cost";
                            strG = dblSay + "/each";
                            break;
                        case "CU.M.":
                            str2ndRow = "Total Volume (cu.m.)";
                            dblE = Convert.ToDouble(txtvolume.Text);
                            str3rdRow = "Unit Cost per Volume";
                            dblF = dblD / dblE;
                            dblSay = RoundUp(dblF, 2);
                            str4thRow = "Direct Unit Cost";
                            strG = dblSay + "/cu.m.";
                            break;
                        case "M.T.":
                            str2ndRow = "Total Weight (Metric Tons)";
                            dblE = Convert.ToDouble(txtweight.Text);
                            str3rdRow = "Unit Cost per Weight";
                            dblF = dblD / dblE;
                            dblSay = RoundUp(dblF, 2);
                            str4thRow = "Direct Unit Cost";
                            strG = dblSay + "/m.t.";
                            break;
                        case "SET":
                            str2ndRow = "Total Quantity (set)";
                            dblE = Convert.ToDouble(txtassumednoofunits.Text);
                            str3rdRow = "Unit Cost";
                            dblF = dblD / dblE;
                            dblSay = RoundUp(dblF, 2);
                            str4thRow = "Direct Unit Cost";
                            strG = dblSay + "/set";
                            break;
                    }

                    radGridView4.Rows.Add("Total (A+B+C)", "", dblD.ToString());
                    radGridView4.Rows.Add(str2ndRow, "", dblE.ToString());
                    radGridView4.Rows.Add(str3rdRow, "", dblF.ToString());
                    radGridView4.Rows.Add("", "Say", dblSay.ToString());
                    radGridView4.Rows.Add(str4thRow, "", strG.ToString());
                    txtunitcost.Text = dblSay.ToString();
                }
                else
                {
                    if (txtassumedlength.Text.Trim().Length == 0) txtassumedlength.Text = "0";
                    if (txtvolume.Text.Trim().Length == 0) txtvolume.Text = "0";
                    if (txtweight.Text.Trim().Length == 0) txtweight.Text = "0";
                    if (txtassumednoofunits.Text.Trim().Length == 0) txtassumednoofunits.Text = "0";

                    double dblD = Convert.ToDouble(txtlaborcosttotal.Text) + Convert.ToDouble(txtequipmentcosttotal.Text) + Convert.ToDouble(txtmaterialcosttotal.Text);
                    double dblE = 0;
                    double dblF = 0;
                    double dblSay = 0;
                    string strG = string.Empty;

                    string str2ndRow = "";
                    string str3rdRow = "";
                    string str4thRow = "";

                    switch (cbounit.Text.Trim().ToUpper())
                    {
                        case "SQ.M.":
                            str2ndRow = "Total Area(sq.m)";
                            dblE = Convert.ToDouble(txtassumedlength.Text);
                            str3rdRow = "Unit Cost per Area";
                            dblF = RoundUp(dblD / dblE, 2);
                            dblSay = RoundUp(dblF, 1);
                            str4thRow = "Direct Unit Cost";
                            strG = dblSay + "/sq.m.";
                            break;
                        case "L.M.":
                            str2ndRow = "Total Linear meter (l.m.)";
                            dblE = Convert.ToDouble(txtassumedlength.Text);
                            str3rdRow = "Unit Cost per Area";
                            dblF = dblD / dblE;
                            dblSay = RoundUp(dblF, 2);
                            str4thRow = "Direct Unit Cost";
                            strG = dblSay + "/l.m.";
                            break;
                        case "EACH":
                            str2ndRow = "Total Quantity (each)";
                            dblE = Convert.ToDouble(txtassumedlength.Text);
                            str3rdRow = "Unit Cost per Area";
                            dblF = dblD / dblE;
                            dblSay = RoundUp(dblF, 2);
                            str4thRow = "Direct Unit Cost";
                            strG = dblSay + "/each";
                            break;
                        case "CU.M.":
                            str2ndRow = "Total Volume (cu.m.)";
                            dblE = Convert.ToDouble(txtvolume.Text);
                            str3rdRow = "Unit Cost per Volume";
                            dblF = dblD / dblE;
                            dblSay = RoundUp(dblF, 2);
                            str4thRow = "Direct Unit Cost";
                            strG = dblSay + "/cu.m.";
                            break;
                        case "M.T.":
                            str2ndRow = "Total Weight (Metric Tons)";
                            dblE = Convert.ToDouble(txtweight.Text);
                            str3rdRow = "Unit Cost per Weight";
                            dblF = dblD / dblE;
                            dblSay = RoundUp(dblF, 2);
                            str4thRow = "Direct Unit Cost";
                            strG = dblSay + "/m.t.";
                            break;
                        case "SET":
                            str2ndRow = "Total Quantity (set)";
                            dblE = Convert.ToDouble(txtassumednoofunits.Text);
                            str3rdRow = "Unit Cost";
                            dblF = dblD / dblE;
                            dblSay = RoundUp(dblF, 2);
                            str4thRow = "Direct Unit Cost";
                            strG = dblSay + "/set";
                            break;
                    }

                    radGridView4.Rows[0].Cells["Column1"].Value = "Total (A+B+C)";
                    radGridView4.Rows[0].Cells["Column3"].Value = dblD.ToString();

                    radGridView4.Rows[1].Cells["Column1"].Value = str2ndRow;
                    radGridView4.Rows[1].Cells["Column3"].Value = dblE.ToString();

                    radGridView4.Rows[2].Cells["Column1"].Value = str3rdRow;
                    radGridView4.Rows[2].Cells["Column3"].Value = dblF.ToString();

                    radGridView4.Rows[3].Cells["Column1"].Value = string.Empty;
                    radGridView4.Rows[3].Cells["Column3"].Value = dblSay.ToString();

                    radGridView4.Rows[4].Cells["Column1"].Value = str4thRow;
                    radGridView4.Rows[4].Cells["Column3"].Value = strG.ToString();

                    txtunitcost.Text = dblSay.ToString();
                }
            }
            catch (Exception ex)
            {

                if (InvokeRequired)
                {
                    Invoke(new EventHandler(delegate
                    {
                        FormUtils.ShowError(ex, "Get Data Error");
                    }));
                }
                else
                {
                    FormUtils.ShowError(ex, "Get Data Error");
                }


                return;
            }
        }

        public static double RoundUp(double input, int places)
        {
            double multiplier = Math.Pow(10, Convert.ToDouble(places));
            return Math.Ceiling(input * multiplier) / multiplier;
        }

        protected virtual void LoadDataMaterial()
        {
            try
            {
                radGridView3.BeginUpdate();

                var data = GetDataMaterial();

                radGridView3.DataSource = data;

                radGridView3.MasterTemplate.AllowAddNewRow = false;

                radGridView3.ShowGroupPanel = false;
                radGridView3.Columns[0].IsVisible = false;
                radGridView3.Columns[1].IsVisible = false;
                radGridView3.Columns[2].IsVisible = false;
                radGridView3.Columns[3].Width = 270;
                radGridView3.Columns[4].Width = 80;
                radGridView3.Columns[5].Width = 80;
                radGridView3.Columns[6].Width = 80;
                radGridView3.Columns[7].Width = 90;

                radGridView3.Columns[4].TextAlignment = ContentAlignment.MiddleRight;
                radGridView3.Columns[5].TextAlignment = ContentAlignment.MiddleRight;
                radGridView3.Columns[6].TextAlignment = ContentAlignment.MiddleRight;
                radGridView3.Columns[7].TextAlignment = ContentAlignment.MiddleRight;

                radGridView3.Columns[4].FormatString = "{0:#,##0.00}";
                radGridView3.Columns[5].FormatString = "{0:#,##0.00}";
                radGridView3.Columns[6].FormatString = "{0:#,##0.00}";
                radGridView3.Columns[7].FormatString = "{0:#,##0.00}";

                radGridView3.EndUpdate(true);

                double dblTotalMaterial = 0;
                foreach (GridViewDataRowInfo dataRow in this.GetAllRows(this.radGridView3.MasterTemplate))
                {
                    dblTotalMaterial += Convert.ToDouble(dataRow.Cells[7].Value);
                }
                txtmaterialcosttotal.Text = string.Format("{0:#,##0.00}", dblTotalMaterial.ToString());
                txtmaterialcosttotal.TextAlign = HorizontalAlignment.Right;
            }
            catch (Exception ex)
            {

                if (InvokeRequired)
                {
                    Invoke(new EventHandler(delegate
                    {
                        FormUtils.ShowError(ex, "Get Data Error");
                    }));
                }
                else
                {
                    FormUtils.ShowError(ex, "Get Data Error");
                }


                return;
            }
        }

        public List<GridViewRowInfo> GetAllRows(GridViewTemplate template)
        {
            List<GridViewRowInfo> allRows = new List<GridViewRowInfo>();
            allRows.AddRange(template.Rows);
            foreach (GridViewTemplate childTemplate in template.Templates)
            {
                List<GridViewRowInfo> childRows = this.GetAllRows(childTemplate);
                allRows.AddRange(childRows);
            }
            return allRows;
        }

        protected virtual DataTable GetDataLabor()
        {
            //return null;
            return new QC.Repository.DupaDetailsLabor().GetDupaDetailsLabor(_id);
        }

        protected virtual DataTable GetDataEquipment()
        {
            //return null;
            return new QC.Repository.DupaDetailsEquipment().GetDupaDetailsEquipment(_id);
        }

        protected virtual DataTable GetDataMaterial()
        {
            //return null;
            return new QC.Repository.DupaDetailsMaterial().GetDupaDetailsMaterial(_id);
        }

        private void radGridView1_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            int index = this.radGridView1.Rows.IndexOf(this.radGridView1.CurrentRow);
            if (index >= 0)
            {
                Entry.LaborCostManual oEntry = new Entry.LaborCostManual(_id, radGridView1.Rows[index].Cells[1].Value.ToString());
                oEntry.UpdateHandler += Record_Updated;
                oEntry.ShowDialog();

            }
        }

        private void btnaddlabor_Click(object sender, EventArgs e)
        {
            //savebutton_Click(this, e);
            Entry.LaborCostManual oEntry = new Entry.LaborCostManual(_id);
            oEntry.UpdateHandler += Record_Updated;
            oEntry.ShowDialog();
        }

        private void btnaddequipment_Click(object sender, EventArgs e)
        {
            //savebutton_Click(this, e);
            Entry.EquipmentCostManual oEntry = new Entry.EquipmentCostManual(_id,txtlaborcosttotal.Text);
            oEntry.UpdateHandler += Record_Updated;
            oEntry.ShowDialog();
        }

        private void radGridView2_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            int index = this.radGridView2.Rows.IndexOf(this.radGridView2.CurrentRow);
            if (index >= 0)
            {
                Entry.EquipmentCostManual oEntry = new Entry.EquipmentCostManual(_id, radGridView2.Rows[index].Cells[1].Value.ToString(), txtlaborcosttotal.Text);
                oEntry.UpdateHandler += Record_Updated;
                oEntry.ShowDialog();

            }
        }

        private void radGridView3_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            int index = this.radGridView3.Rows.IndexOf(this.radGridView3.CurrentRow);
            if (index >= 0)
            {
                Entry.MaterialCostManual oEntry = new Entry.MaterialCostManual(_id, radGridView3.Rows[index].Cells[1].Value.ToString());
                oEntry.UpdateHandler += Record_Updated;
                oEntry.ShowDialog();

            }
        }

        private void btnaddmaterial_Click(object sender, EventArgs e)
        {
            //savebutton_Click(this, e);
            Entry.MaterialCostManual oEntry = new Entry.MaterialCostManual(_id);
            oEntry.UpdateHandler += Record_Updated;
            oEntry.ShowDialog();
        }

        private void DupaHeader_Load(object sender, EventArgs e)
        {

        }
    }
}
