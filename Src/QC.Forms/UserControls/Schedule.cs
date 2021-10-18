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
    public partial class Schedule : UserControl
    {
        protected List<string> columnNames;
        protected Type[] columnTypes;
        protected string dataFormText;
        private string _id = "";

        public delegate void ChangeEventHandler(object sender, EventArgs e);
        public event ChangeEventHandler ChangeHandler;

        private bool isChange = false;


        public Schedule(string id)
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
            this.radGrid.AutoGenerateColumns = true;
            LoadData();
             
            _id = id;
            //LoadData();
        }

        protected virtual void LoadData()
        {
            try
            {
                radGrid.BeginUpdate();

                radGrid.DataSource = GetData();
                //radGrid.MasterTemplate.AllowAddNewRow = true;
                radGrid.MasterTemplate.AllowEditRow = true;
                

                radGrid.Columns[0].IsVisible = false;


                radGrid.MasterTemplate.AllowAddNewRow = true;

                radGrid.Columns[0].IsVisible = false;

                //var x = radGrid.Columns;

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

        public DataTable GetData()
        {
            //return null;
            var data = new Repository.ProjectSchedule().Get(_id);

            return data;
        }
 
        public void RefreshData()
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
           
            isChange = true;
        }


        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (radGrid.CurrentRow != null && radGrid.CurrentRow is GridViewDataRowInfo)
            {
                radGrid.Rows.Remove((GridViewDataRowInfo)radGrid.CurrentRow);
                isChange = true;
                SetNo(); 
               
            }
            else
                Util.ShowInfoMessage("Please Select Row to Remove", "Remove");
        }

        public void SaveDetails()
        {

            if (!isChange)
                return;


            //for (int i = 0; i < radGrid.Rows.Count; i++)
            //{
            //    _service.Save(radGrid.Rows[i].Cells["id"].Value.ToString(), _projectId,
            //        radGrid.Rows[i].Cells["Order"].Value.ToString().ToInt(),
            //        radGrid.Rows[i].Cells["Manpower"].Value.ToString(),
            //        radGrid.Rows[i].Cells["No"].Value.ToString().ToInt(),
            //        QC.Lib.Global.UserId());
            //}

            //if (_dataDel.Count > 0)
            //{
            //    foreach (var delId in _dataDel)
            //    {
            //        _service.Delete(delId);
            //    }
            //}

        }

    }
}
