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
    public partial class EquipmetCost : BaseGridForm
    {
        public EquipmetCost()
        {
            InitializeComponent();
        }

        protected override DataTable GetData()
        {
            return new Repository.EquipmentCost().GetEquipmentCost();
        }

        protected override void NewRecord()
        {
            Entry.EquipmentCost oEntry = new Entry.EquipmentCost();
            oEntry.UpdateHandler += Record_Updated;
            oEntry.Show();


        }

        protected override void OpenRecord(GridViewDataRowInfo selectedrow)
        {
            if (selectedrow != null)
            {

                Entry.EquipmentCost oEntry = new Entry.EquipmentCost(selectedrow.Cells[0].Value.ToString());
                oEntry.UpdateHandler += Record_Updated;
                oEntry.Show();
            }
        }
    }
}
