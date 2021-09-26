using DocumentFormat.OpenXml.Spreadsheet;
using QC.Forms.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace QC.Forms.UserControls
{
    public partial class BOM : UserControl
    {
        protected List<string> columnNames;
        protected Type[] columnTypes;
        protected string dataFormText;
        private string _id = "";

        public delegate void ChangeEventHandler(object sender, EventArgs e);
        public event ChangeEventHandler ChangeHandler;

        private bool isChange = false;


        public BOM(string id)
        {
            InitializeComponent();
            columnNames = new List<string>();
            this.radGrid.AllowAddNewRow = true;
            this.radGrid.AllowAutoSizeColumns = false;
            this.radGrid.AllowAddNewRow = true;
            this.radGrid.AutoSizeColumnsMode = (GridViewAutoSizeColumnsMode)VirtualGridAutoSizeColumnsMode.None;
            this.radGrid.AllowMultiColumnSorting = true;
            this.radGrid.AllowMultiColumnSorting = true;
            this.radGrid.AllowRowReorder = true;
            this.radGrid.SelectionMode = GridViewSelectionMode.FullRowSelect;
            this.radGrid.AllowEditRow = true;
            this.radGrid.EnableFiltering = false;
            this.radGrid.ShowColumnHeaders = true;
            this.radGrid.EnableGrouping = false;
            this.radGrid.AllowMultiColumnSorting = true;
            LoadData();


            //MessageBox.Show(id);
            //var data = new Repository.ProjectBom2().GetProjectBombyId2(id);
            _id = id;
            //LoadData();
        }

        protected virtual void LoadData()
        {
            try
            {
                radGrid.BeginUpdate();

                radGrid.DataSource = GetData();
                radGrid.MasterTemplate.AllowAddNewRow = true;
                radGrid.MasterTemplate.AllowEditRow = true;

                radGrid.Columns[0].IsVisible = false;

                foreach (GridViewColumn column in radGrid.Columns)
                {
                    if (column is GridViewDataColumn)
                    {
                        GridViewDataColumn col = column as GridViewDataColumn;
                        if (col != null)
                        {
                            switch (col.Index)
                            {
                                case 2: col.Width = 300; col.ReadOnly = true; break;
                                case 1:
                                case 3:
                                case 19:
                                case 20:
                                case 21: col.Width = 70; col.ReadOnly = true; break;
                                case 4: col.Width = 160; col.ReadOnly = true; break;
                                default: col.Width = 70; col.ReadOnly = false; break;
                            }
                            if (col.Index >= 17) col.FormatString = "{0:#,##}";

                        }
                    }
                }

                radGrid.MasterTemplate.AllowAddNewRow = true;

                radGrid.Columns[0].IsVisible = false;
                //radGrid.Columns[17].FormatString = "{0:0.0#}";
                //radGrid.Columns[18].FormatString = "{0:0.0#}";
                //radGrid.Columns[19].FormatString = "{0:0.0#}";
                //radGrid.Columns[20].FormatString = "{0:0.0#}";
                //radGrid.Columns[21].FormatString = "{0:0.0#}";
                //radGrid.Columns[2].ReadOnly = true;
                //radGrid.Columns[3].ReadOnly = true;
                //radGrid.Columns[4].ReadOnly = true;

                radGrid.EndUpdate(true);
                //lblCount.Text = @"Record Count : " + rGrid.RowCount;


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

        protected virtual DataTable GetData()
        {
            //return null;
            return new QC.Repository.ProjectBom2().GetProjectBom2();
        }

        protected virtual Workbook CreateWorkbook()
        {
            return new Workbook();
        }
        protected virtual void RefreshData()
        {
            LoadData();
        }

        public void Record_Updated(object sender, EventArgs e)
        {
            //event when edit record is fired.
            RefreshData();
        }

        private void radGrid_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement is GridHeaderCellElement)
            {
                e.CellElement.TextWrap = true;
            }
        }

        private void ProcessOutput(int i)
        {
            var _leftvar = "";
            var _rightvar = "";
            var _transform1 = "";
            var _temp = "";
            string _derivation = radGrid.Rows[i].Cells[4].Value.ToString();
            var _expression = _derivation.Split('=');
            if (_expression.Count() > 1)
            {
                _leftvar = _expression[0].ToString();
                _rightvar = _expression[1].ToString();
                //MessageBox.Show("Left : " + _leftvar + "   " + "Right : " + _rightvar);
            }
            else
            {
                _leftvar = "L";
                _rightvar = _expression[0].ToString();
            }

            _transform1 = _rightvar.Replace('X', '*');
            if (_transform1.IndexOf("30%") != -1)
            {
                _temp = "0.3";
                if (_temp.Trim().Length == 0) _temp = "0";
                _transform1 = _transform1.Replace("30%", _temp);
            }

            if (_transform1.IndexOf("NO.of sides") != -1)
            {
                _temp = radGrid.Rows[i].Cells[11].Value.ToString();
                if (_temp.Trim().Length == 0) _temp = "0";
                _transform1 = _transform1.Replace("NO.of sides", _temp);
            }
            if (_transform1.IndexOf("No.of MH") != -1)
            {
                _temp = radGrid.Rows[i].Cells[15].Value.ToString();
                if (_temp.Trim().Length == 0) _temp = "0";
                _transform1 = _transform1.Replace("No.of MH", _temp);
            }
            if (_transform1.IndexOf("L") != -1)
            {
                _temp = radGrid.Rows[i].Cells[5].Value.ToString();
                if (_temp.Trim().Length == 0) _temp = "0";
                _transform1 = _transform1.Replace("L", _temp);
            }
            if (_transform1.IndexOf("W") != -1)
            {
                _temp = radGrid.Rows[i].Cells[6].Value.ToString();
                if (_temp.Trim().Length == 0) _temp = "0";
                _transform1 = _transform1.Replace("W", _temp);
            }
            if (_transform1.IndexOf("D") != -1)
            {
                _temp = radGrid.Rows[i].Cells[7].Value.ToString();
                if (_temp.Trim().Length == 0) _temp = "0";
                _transform1 = _transform1.Replace("D", _temp);
            }
            if (_transform1.IndexOf("t") != -1)
            {
                _temp = radGrid.Rows[i].Cells[8].Value.ToString();
                if (_temp.Trim().Length == 0) _temp = "0";
                _transform1 = _transform1.Replace("t", _temp);
            }
            if (_transform1.IndexOf("N") != -1)
            {
                _temp = radGrid.Rows[i].Cells[17].Value.ToString();
                if (_temp.Trim().Length == 0) _temp = "0";
                _transform1 = _transform1.Replace("N", _temp);
            }

            DataTable dt = new DataTable();
            var v = dt.Compute(_transform1, "");

            switch (_leftvar)
            {
                case "A": radGrid.Rows[i].Cells[21].Value = v; break;
                case "V":
                    radGrid.Rows[i].Cells[20].Value = v;
                    break;
                case "L": radGrid.Rows[i].Cells[19].Value = v; break;
                case "N": radGrid.Rows[i].Cells[17].Value = v; break;
            }

            //MessageBox.Show(_transform1);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Find fnd = new Find("select id, ItemCode, Description, Unit, UnitCost from DUPAHeader", true);
                fnd.FindHandler += AddItem_Clicked;
                fnd.ShowDialog();
                fnd.FindHandler -= AddItem_Clicked;
            }
            catch (Exception ex)
            {
                FormUtils.ShowError(ex, "Add Row");
            }
        }

        private void AddItem_Clicked(object sender, FindUpdateEventArgs e)
        {
            try
            {
                GridViewRowInfo row = radGrid.Rows.AddNew();
                row.Cells["id"].Value = string.Empty; //e.SelectedRow.Cells["id"].Value;
                row.Cells["DupaId"].Value = e.SelectedRow.Cells["id"].Value;
                row.Cells["ItemCode"].Value = e.SelectedRow.Cells["ItemCode"].Value;
                row.Cells["Description"].Value = e.SelectedRow.Cells["Description"].Value;
                row.Cells["Qty"].Value = 1;
                row.Cells["Unit"].Value = e.SelectedRow.Cells["Unit"].Value;
                row.Cells["UnitCost"].Value = e.SelectedRow.Cells["UnitCost"].Value;
                row.Cells["Amount"].Value = e.SelectedRow.Cells["UnitCost"].Value;


                radGrid.EndUpdate();

                // Change_Entry(sender, new EventArgs());
                isChange = true;
                SetNo();
                GetTotal();
            }
            catch (Exception ex)
            {

                FormUtils.ShowError(ex, "Add Row");
            }
        }


        private void SetNo()
        {
            try
            {
                for (int i = 0; i < radGrid.Rows.Count; i++)
                    radGrid.Rows[i].Cells["No"].Value = (i + 1).ToString();
                
                radGrid.Refresh();

            }
            catch
            {

                return;
            }
        }

        private void Change_Entry(Object sender, EventArgs e)
        {
            try
            {
                ChangeHandler(sender, e);
            }
            catch
            {
                return;
            }

        }

        private void radGrid_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            GetTotal();
            isChange = true;
        }


        private void GetTotal()
        {
            try
            {
                double dTotal = 0;
                for (int i = 0; i < radGrid.Rows.Count; i++)
                {
                    var total = double.Parse(radGrid.Rows[i].Cells["UnitCost"].Value.ToString()) + double.Parse(radGrid.Rows[i].Cells["qty"].Value.ToString());
                    radGrid.Rows[i].Cells["Amount"].Value = total;
                    dTotal += total;
                }

                txtTotal.Text = dTotal.ToString();
                radGrid.Refresh();

            }
            catch
            {

                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (radGrid.CurrentRow != null && radGrid.CurrentRow is GridViewDataRowInfo)
            {
                radGrid.Rows.Remove((GridViewDataRowInfo)radGrid.CurrentRow);
                isChange = true;
                SetNo(); 
                GetTotal();
            }
            else
                Util.ShowInfoMessage("Please Select Row to Remove", "Remove");
        }
    }
}
