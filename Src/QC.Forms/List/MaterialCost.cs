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
    public partial class MaterialCost : BaseGridForm
    {
        public MaterialCost()
        {
            InitializeComponent();
        }

        protected override DataTable GetData()
        {
            return new Repository.MaterialCostcs().GetMaterialCost();
        }

        protected override void NewRecord()
        {
            Entry.MaterialCost oEntry = new Entry.MaterialCost();
            oEntry.UpdateHandler += GridRecord_Updated;
            oEntry.Show();

            
        }

        protected override void OpenRecord(GridViewDataRowInfo selectedrow)
        {
            if (selectedrow != null)
            {

                Entry.MaterialCost oEntry = new Entry.MaterialCost(selectedrow.Cells[0].Value.ToString());
                oEntry.UpdateHandler += GridRecord_Updated;
                oEntry.Show();
            }
        }
    }
}
