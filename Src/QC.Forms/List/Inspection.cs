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
    public partial class Inspection : BaseGridForm
    {
        public Inspection()
        {
            InitializeComponent();
        }

        protected override DataTable GetData()
        {
            return new Repository.Project().GetProjectInspectionList(_userId);
        }


        protected override void OpenRecord(GridViewDataRowInfo selectedrow)
        {
            if (selectedrow != null)
            {
                Entry.Inspection oEntry = new Entry.Inspection(selectedrow.Cells[0].Value.ToString());
                oEntry.InspectionUpdateHandler += GridRecord_Updated;
                oEntry.Show();
            }
        }

    }
}
