using DocumentFormat.OpenXml.Spreadsheet;
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

namespace QC.Forms
{
    public partial class BaseGridForm2 : Form
    {

        protected List<string> columnNames;
        protected Type[] columnTypes;
        protected string dataFormText;

        private string _modulecode = string.Empty;

        public string Title
        {
            set
            {
                lblTitle.Text = value;
            }
        }

        public string ModuleCode
        {
            set
            {
                _modulecode = value;
            }
        }

        public BaseGridForm2()
        {
            InitializeComponent();
            columnNames = new List<string>();
          
            this.radGrid.AllowAddNewRow = true;
            this.radGrid.AllowAutoSizeColumns = true;
            this.radGrid.AllowAddNewRow = true;
            this.radGrid.AutoSizeColumnsMode = (GridViewAutoSizeColumnsMode)VirtualGridAutoSizeColumnsMode.Fill;
            this.radGrid.AllowMultiColumnSorting = true;
            this.radGrid.AllowMultiColumnSorting = true;
            this.radGrid.AllowRowReorder = true;
            this.radGrid.SelectionMode = GridViewSelectionMode.FullRowSelect;
            this.radGrid.AllowEditRow = true;
            //this.radGrid.EnableFiltering = true;
            this.radGrid.ShowColumnHeaders = true;
            this.radGrid.EnableGrouping = true;
            this.radGrid.AllowMultiColumnSorting = true;
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

                radGrid.DataSource = GetData();

                radGrid.MasterTemplate.AllowAddNewRow = true;

                radGrid.Columns[0].IsVisible = false;
                radGrid.Columns[2].ReadOnly = true;
                radGrid.Columns[3].ReadOnly = true;
                radGrid.Columns[4].ReadOnly = true;

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
            return new QC.Repository.ProjectBom().GetProjectBom();
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
    }
}
