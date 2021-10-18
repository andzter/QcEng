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
    public partial class Folders : BaseGridForm
    {
        public Folders()
        {
            InitializeComponent();
        }

       
        protected override DataTable GetData()
        {
            return new Repository.Project().GetProjectFoldersList(_userId);
        }


        protected override void OpenRecord(GridViewDataRowInfo selectedrow)
        {
            if (selectedrow != null)
            {
                Entry.DEDFolders oEntry = new Entry.DEDFolders(selectedrow.Cells[0].Value.ToString());
                oEntry.UpdateHandler += GridRecord_Updated;
                oEntry.Show();
            }
        }
    }
}
