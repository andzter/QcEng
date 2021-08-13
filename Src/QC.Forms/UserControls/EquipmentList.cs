using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QC.Forms.UserControls
{
    public partial class EquipmentList : UserControl
    {
        public EquipmentList()
        {
            InitializeComponent();
        }

        protected virtual DataTable GetData()
        {
            //return null;
            return new QC.Repository.Project().GetDataTable("select Equipment [Name of Equipment], UnitNo [No.Of Unit] from[ProjectEquipments]");

           



        }


        public EquipmentList(string projectId)
        {
            InitializeComponent();
            radGrid.DataSource = GetData();

        }
    }
}
