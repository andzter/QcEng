using DocumentFormat.OpenXml.Spreadsheet;
using QC.Forms.Lib;
using QC.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace QC.Forms
{
    public partial class BaseGridForm : Form
    {
        protected List<string> columnNames;
        protected Type[] columnTypes;
        protected string dataFormText;

        private string _modulecode = string.Empty;
        protected string _userId = Global.UserId();
        protected string _userName = Global.UserName();

        public string Title
        {
            set {
                lblTitle.Text = value;
            }
        }

        public bool ShowAdd
        {
            set
            {
                addButton.Visible = value;
            }
        }

        public string ModuleCode
        {
            set
            {
                _modulecode = value;
            }
        }

        public BaseGridForm()
        {
            InitializeComponent();
            columnNames = new List<string>();
            this.radGrid.AllowAddNewRow = false;
            this.radGrid.AllowAutoSizeColumns = true;
            this.radGrid.AllowAddNewRow = false;
            this.radGrid.AutoSizeColumnsMode = (GridViewAutoSizeColumnsMode)VirtualGridAutoSizeColumnsMode.Fill;
            this.radGrid.AllowMultiColumnSorting = true;
            this.radGrid.AllowMultiColumnSorting = true;
            this.radGrid.AllowRowReorder = true;
            this.radGrid.SelectionMode = GridViewSelectionMode.FullRowSelect;
            this.radGrid.AllowEditRow = false;
            //this.radGrid.EnableFiltering = true;
            LoadData();
            this.Initialize();
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

                var data = GetData();

                radGrid.DataSource = data;

                radGrid.MasterTemplate.AllowAddNewRow = false;

                radGrid.EndUpdate(true);
                //lblCount.Text = @"Record Count : " + rGrid.RowCount;

                radGrid.Columns[0].IsVisible = false;

                lblTotal.Text = $"Total Records : {data.Rows.Count}";

                InitGrid();
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
            return new QC.Repository.Project().GetAllProjects();
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

        public void GridRecord_Updated(object sender, EventArgs e)
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

        private void pnlTop_Paint(object sender, PaintEventArgs e)
        {

        }


        protected virtual void InitGrid()
        {
            try
            {
                GridUtil.InitDefualtGrid(radGrid);
               // GridUtil.ApplyConditionalFormatting(radGrid, ModuleCode + SelectedView);
               // GridUtil.SetHideCols(radGrid, ModuleCode + SelectedView);
               // GridUtil.SetColsIndex(radGrid, ModuleCode + SelectedView);
               // GridUtil.SetColNames(radGrid, ModuleCode, _Config.ConnectionString);
            }
            catch (Exception ex)
            {
                //RadMessageBox.SetThemeName(_Config.Theme);
                RadMessageBox.Show(this, "Error in Init Grid\n" + ex.Message, "Init Grid", MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }

        }
    }
}
