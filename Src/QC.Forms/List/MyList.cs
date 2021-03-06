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
    public partial class MyList : BaseGridForm
    {
        public MyList()
        {
            this.Title = "My Task";
            InitializeComponent();
        }

        protected override DataTable GetData()
        {
            return new Repository.Project().MyTask(_userId);
        }

        protected override void OpenRecord(GridViewDataRowInfo selectedrow)
        {
            if (selectedrow != null)
            {

                Entry.CommProject oEntry = new Entry.CommProject(selectedrow.Cells[0].Value.ToString());
                oEntry.EntryUpdateHandler += GridRecord_Updated;
                oEntry.Show();
            }
        }
    }
}
