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
    public partial class LaborCost : BaseGridForm
    {
        public LaborCost()
        {
            InitializeComponent();
        }

        protected override DataTable GetData()
        {
            return new Repository.LaborCost().GetLaborCost();
        }

        protected override void NewRecord()
        {
            Entry.LaborCost oEntry = new Entry.LaborCost();
            oEntry.UpdateHandler += Record_Updated;
            oEntry.Show();


        }

        protected override void OpenRecord(GridViewDataRowInfo selectedrow)
        {
            if (selectedrow != null)
            {

                Entry.LaborCost oEntry = new Entry.LaborCost(selectedrow.Cells[0].Value.ToString());
                oEntry.UpdateHandler += Record_Updated;
                oEntry.Show();
            }
        }
    }
}
