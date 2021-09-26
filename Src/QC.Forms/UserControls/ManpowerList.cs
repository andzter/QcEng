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

namespace QC.Forms.UserControls
{
    public partial class ManpowerList : UserControl
    {
        public ManpowerList()
        {
            InitializeComponent();
        }

        private DataTable GetData()
        {
            //return null;
            return new QC.Repository.Project().GetDataTable("select 1 as id, Manpower, UnitNo[No.Of Unit] from [ProjectManpower]");
        }

        public ManpowerList(string projectId)
        {
            try
            {
                InitializeComponent();

                radGrid.BeginUpdate();

                var data = GetData();

                radGrid.DataSource = data;

                radGrid.MasterTemplate.AllowAddNewRow = false;

                radGrid.EndUpdate(true);
                //lblCount.Text = @"Record Count : " + rGrid.RowCount;

                radGrid.Columns[0].IsVisible = false;

                GridUtil.InitDefualtGrid(radGrid);
            }
            catch (Exception ex)
            {
                //RadMessageBox.SetThemeName(_Config.Theme);
                RadMessageBox.Show(this, "Error in Equipment List\n" + ex.Message, "Equipment List", MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }

        }
    }
}
