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
    public partial class CommProject : BaseEntryForm
    {

        private string _id = "";

        public CommProject()
        {
            InitializeComponent();
        }

        public CommProject(string id)
        {
            InitializeComponent();

            //MessageBox.Show(id);
            var data = new Repository.Project().GetProjectbyId(id);
            txtrefno.Text = data["referenceNo"].ToString();
            txtproject.Text = data["project"].ToString();
            txtdocsource.Text = data["docsource"].ToString();
            txtRem.Text = data["remarks"].ToString();

            var dtusers = new Repository.Lookup().GetUsers();

            QC.Lib.Common.FillControl(cboRoute, dtusers);

            radGrid.AllowAddNewRow = false;
            radGrid.AllowEditRow = false;
            radGrid.DataSource = new Repository.Project().GetProjectHistory(id);

            _id = id;

        }

        protected override void SaveEntry()
        { 
            new Repository.Project().SaveNewProject(_id, txtproject.Text, radDocdate.Value, txtdocsource.Text, txtremarks.Text, Lib.Common.ComboVal(cboRoute),   _userid);
        }
    }
}
