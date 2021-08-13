using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QC.Forms.Entry
{
    public partial class AddProject : BaseEntryForm
    {

        private string _commid = "";

        public AddProject()
        {
            InitializeComponent();
        }

        public AddProject(string commid)
        {
            InitializeComponent();
            _commid = commid;

            var record = new Repository.Communications().GetbyId(_commid);

            txtProject.Text = record["Project"].ToString();

            var dtusers = new Repository.Lookup().GetUsers();

            Lib.Common.FillControl(cboRoute, dtusers);

        }


        protected override void SaveEntry()
        {
            new Repository.Project().SaveNewProject(_commid, txtProject.Text, txtBarangay.Text, txtDistrict.Text, txtComment.Text, Lib.Common.ComboVal(cboRoute), _userid);

        }
    }
}
