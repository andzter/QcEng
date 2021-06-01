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
    public partial class Communication : BaseGridForm
    {

        public Communication()
        {
            InitializeComponent();
        }


        

        protected override DataTable GetData()
        {
            return new Repository.Project().CommunicationProject(_userId);
        }

        protected override void NewRecord()
        {
            Entry.NewProject oEntry = new Entry.NewProject();
            oEntry.UpdateHandler += Record_Updated;
            oEntry.Show();
        }

        protected override void OpenRecord(GridViewDataRowInfo selectedrow)
        {
            if (selectedrow != null)
            {

                Entry.CommProject oEntry = new Entry.CommProject(selectedrow.Cells[0].Value.ToString());
                oEntry.UpdateHandler += Record_Updated;
                oEntry.Show();
            }
        }
    }
}
