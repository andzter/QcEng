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

namespace QC.Forms.List
{
    public partial class ProjectBom2 : Form
    {
        protected List<string> columnNames;
        protected Type[] columnTypes;
        protected string dataFormText;

        private string _modulecode = string.Empty;

        public string Title2
        {
            set
            {
                lbltitle2.Text = value;
            }
        }

        public string Title
        {
            set
            {
                lblTitle.Text = value;
            }
        }

        public string Location
        {
            set
            {
                lbllocation.Text = value;
            }
        }

        public string Limit
        {
            set
            {
                lbllimit.Text = value;
            }
        }

        public string Length
        {
            set
            {
                lbllength.Text = value;
            }
        }

        public string ModuleCode
        {
            set
            {
                _modulecode = value;
            }
        }

        private string _id = "";

        public ProjectBom2(string id)
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

            this.Initialize();


            //MessageBox.Show(id);
            //var data = new Repository.ProjectBom2().GetProjectBombyId2(id);
            _id = id;
            //LoadData();
        }


        public ProjectBom2()
        {
            //InitializeComponent();
            //columnNames = new List<string>();
            //this.radGrid.AllowAddNewRow = false;
            //this.radGrid.AllowAutoSizeColumns = true;
            //this.radGrid.AllowAddNewRow = false;
            //this.radGrid.AutoSizeColumnsMode = (GridViewAutoSizeColumnsMode)VirtualGridAutoSizeColumnsMode.Fill;
            //this.radGrid.AllowMultiColumnSorting = true;
            //this.radGrid.AllowMultiColumnSorting = true;
            //this.radGrid.AllowRowReorder = true;
            //this.radGrid.SelectionMode = GridViewSelectionMode.FullRowSelect;
            //this.radGrid.AllowEditRow = false;
            //this.radGrid.EnableFiltering = false;
            //this.radGrid.ShowColumnHeaders = true;
            //this.radGrid.EnableGrouping = true;
            //this.radGrid.AllowMultiColumnSorting = true;
            //LoadData();
            //this.Initialize();

        }

        protected virtual void Initialize()
        {
            //throw new NotImplementedException();
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

                //GridViewTextBoxColumn textBoxColumn = new GridViewTextBoxColumn();
                //textBoxColumn.Name = "totallength";
                //textBoxColumn.HeaderText = "Total Length";
                ////textBoxColumn.FieldName = "Description";
                //textBoxColumn.MaxLength = 50;
                //textBoxColumn.TextAlignment = ContentAlignment.BottomRight;
                //textBoxColumn.Width = 70;
                //radGrid.MasterTemplate.Columns.Add(textBoxColumn);

                //GridViewTextBoxColumn textBoxColumn1 = new GridViewTextBoxColumn();
                //textBoxColumn1.Name = "volume";
                //textBoxColumn1.HeaderText = "Volume";
                ////textBoxColumn1.FieldName = "Description";
                //textBoxColumn1.MaxLength = 70;
                //textBoxColumn1.TextAlignment = ContentAlignment.BottomRight;
                //textBoxColumn1.Width = 70;
                //radGrid.MasterTemplate.Columns.Add(textBoxColumn1);

                //GridViewTextBoxColumn textBoxColumn2 = new GridViewTextBoxColumn();
                //textBoxColumn2.Name = "area";
                //textBoxColumn2.HeaderText = "Area";
                ////textBoxColumn2.FieldName = "Description";
                //textBoxColumn2.MaxLength = 70;
                //textBoxColumn2.TextAlignment = ContentAlignment.BottomRight;
                //textBoxColumn2.Width = 70;
                //radGrid.MasterTemplate.Columns.Add(textBoxColumn2);

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
                radGrid.Columns[17].FormatString = "{0:0.0#}";
                radGrid.Columns[18].FormatString = "{0:0.0#}";
                radGrid.Columns[19].FormatString = "{0:0.0#}";
                radGrid.Columns[20].FormatString = "{0:0.0#}";
                radGrid.Columns[21].FormatString = "{0:0.0#}";
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

        protected virtual void NewRecord()
        {
            //throw new NotImplementedException();
        }

        protected virtual void addButton_Click(object sender, EventArgs e)
        {
            NewRecord();
        }

        public void Record_Updated(object sender, EventArgs e)
        {
            //event when edit record is fired.
            RefreshData();
        }

        protected virtual void OpenRecord(GridViewDataRowInfo selectedrow)
        {

        }


        private void radGrid_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if (radGrid.CurrentRow != null && radGrid.CurrentRow is GridViewDataRowInfo)
                    OpenRecord((GridViewDataRowInfo)radGrid.CurrentRow);

            }
            catch (Exception ex)
            {
                FormUtils.ShowError($"Error Opening Record :{ex.Message}", "Open Record");
                return;
            }
        }

        private void radGrid_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement is GridHeaderCellElement)
            {
                e.CellElement.TextWrap = true;
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void pnlSearch_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radGrid_Click(object sender, EventArgs e)
        {

        }

        private void radGrid_CellDoubleClick_1(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if (radGrid.CurrentRow != null && radGrid.CurrentRow is GridViewDataRowInfo)
                {
                    List.SelectItemCode olist = new List.SelectItemCode();
                    olist.Title = "Select Item No.";
                    olist.ShowDialog();
                }
                    //MessageBox.Show("Hello");

            }
            catch (Exception ex)
            {
                FormUtils.ShowError($"Error Opening Record :{ex.Message}", "Open Record");
                return;
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

        private void radGrid_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            //MessageBox.Show(e.Row.Cells["Derivation"].Value.ToString());
            //ProcessOutput(e.RowIndex);
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            for (int r = 0; r < radGrid.RowCount; r++)
            {
                ProcessOutput(r);
            }
        }
    }
}
