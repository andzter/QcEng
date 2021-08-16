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
    public partial class CommProjects : UserControl
    {

       private string _commid = "";

       public string CommunicationId
       {
            set { _commid = value; }
       }

        public void Record_Updated(object sender, EventArgs e)
        {
            //event when added project is fired.
            LoadData();
        }

        private DataTable GetData()
        {
            return new Repository.Communications().ProjectList(_commid);
        }
        
        private void LoadData()
        {
            try
            {
                radGrid.BeginUpdate();

                radGrid.DataSource = GetData();

                radGrid.MasterTemplate.AllowAddNewRow = false;

                radGrid.EndUpdate(true);
                //lblCount.Text = @"Record Count : " + rGrid.RowCount;

                radGrid.Columns[0].IsVisible = false;

             

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

        public CommProjects(string commId)
        {
            _commid = commId;
            CommLoad();

        }


        private void CommLoad()
        {
            InitializeComponent();

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
        }


        public CommProjects()
        {
            CommLoad();

        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Entry.AddProject oEntry = new Entry.AddProject(_commid);
            oEntry.UpdateHandler += Record_Updated;
            oEntry.Show();
        }

      

    }
}
