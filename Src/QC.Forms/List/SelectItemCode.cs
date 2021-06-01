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

namespace QC.Forms.List
{
    public partial class SelectItemCode : Form
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

        public SelectItemCode()
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
            this.radGrid.EnableFiltering = false;
            this.radGrid.ShowColumnHeaders = true;
            this.radGrid.EnableGrouping = false;
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
                radGrid.MasterTemplate.AllowAddNewRow = false;
                radGrid.MasterTemplate.AllowEditRow = false;

                radGrid.Columns[0].IsVisible = false;
                radGrid.Columns[4].IsVisible = false;

                radGrid.Columns[1].Width = 70;
                radGrid.Columns[2].Width = 300;
                radGrid.Columns[3].Width = 70;

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
            return new QC.Repository.DUPA().GetDUPA();
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
    }
}
