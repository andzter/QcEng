using QC.Forms.Lib;
using QC.Forms.Reports;
using QC.Lib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace QC.Forms.UserControls
{
    public partial class ManpowerList : UserControl
    {
        private Repository.Manpower _service = new Repository.Manpower();
        private string _projectId = "";
        private bool isChange = false;
        private List<string> _dataDel = new List<string>();

        public delegate void ChangeEventHandler(object sender, EventArgs e);
        public event ChangeEventHandler ChangeHandler;

        private DataTable GetData()
        {
            //return null;
            return _service.GetList(_projectId);
        }

        public ManpowerList(string projectId)
        {
            _projectId = projectId;
            try
            {
                InitializeComponent();

                radGrid.BeginUpdate();

                var data = GetData();

                radGrid.DataSource = data;

                radGrid.MasterTemplate.AllowAddNewRow = false;

              
                //lblCount.Text = @"Record Count : " + rGrid.RowCount;

                radGrid.Columns[0].IsVisible = false;

             
      
                radGrid.Columns[1].Width = 100;
                radGrid.Columns[1].HeaderText = " ";
                radGrid.Columns[2].HeaderText = "Name of Equipment";
                radGrid.Columns[3].HeaderText = "No. of Unit";
                radGrid.EndUpdate(true);
                GridUtil.InitDefualtGrid(radGrid);
                SetNo();
            }
            catch (Exception ex)
            {
    
                RadMessageBox.Show(this, "Error in Equipment List\n" + ex.Message, "Equipment List", MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var data = _service.GetList(_projectId);
            var row = (new Repository.ProjectBom()).GetProjectBomHeaderPrint(_projectId);

            RptViewer report = new RptViewer() { ReportFile = "Manpower.rdlc", ReportSource = "datalist", ReportData = data };
            report.AddReportParameters("ProjectName", row["ProjectName"].ToString());
            report.AddReportParameters("Location", row["Location"].ToString());


            report.ShowDialog();
        }

        private void SetNo()
        {
            try
            {
                for (int i = 0; i < radGrid.Rows.Count; i++)
                    radGrid.Rows[i].Cells["Order"].Value = (i + 1).ToString();

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Find fnd = new Find("select distinct [Description] as Manpower from DUPADetails where ItemCode = 'A'", false);
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
                row.Cells["Manpower"].Value = e.SelectedRow.Cells["Manpower"].Value;
                row.Cells["No"].Value = 1; 
                radGrid.EndUpdate();
                 
                isChange = true;
                SetNo(); 
            }
            catch (Exception ex)
            {

                FormUtils.ShowError(ex, "Add Manpower");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (radGrid.CurrentRow != null && radGrid.CurrentRow is GridViewDataRowInfo)
            {
                if (!string.IsNullOrEmpty(radGrid.CurrentRow.Cells["id"].Value.ToString()))
                    _dataDel.Add(radGrid.CurrentRow.Cells["id"].Value.ToString());

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


            for (int i = 0; i < radGrid.Rows.Count; i++)
            {
                _service.Save(radGrid.Rows[i].Cells["id"].Value.ToString(), _projectId, 
                    radGrid.Rows[i].Cells["Order"].Value.ToString().ToInt(), 
                    radGrid.Rows[i].Cells["Manpower"].Value.ToString(),
                    radGrid.Rows[i].Cells["No"].Value.ToString().ToInt(),
                    QC.Lib.Global.UserId());
            } 

            if (_dataDel.Count > 0)
            {
                foreach (var delId in _dataDel)
                {
                    _service.Delete(delId);
                }
            }

        }
    }
}
