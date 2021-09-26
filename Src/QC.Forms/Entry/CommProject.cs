using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QC.Lib;

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
            var data = new Repository.Communications().GetbyId(id);
            txtrefno.Text = data["referenceNo"].ToString();
            txtproject.Text = data["project"].ToString();
            txtdocsource.Text = data["docsource"].ToString();
            txtRem.Text = data["remarks"].ToString();

            //var dtusers = new Repository.Lookup().GetUsers();

            var dtteams = new Repository.Lookup().GetTeams();

            QC.Lib.Common.FillControl(cboRoute, dtteams);

            radGrid.AllowAddNewRow = false;
            radGrid.AllowEditRow = false;
            radGrid.DataSource = new Repository.Communications().GetHistory(id, _userid);

            var uproj = new UserControls.CommProjects(id) { CommunicationId = id, Dock = DockStyle.Fill};
            tabProject.Controls.Add(uproj);

            _id = id;

        }

        protected override void SaveEntry()
        { 
            new Repository.Communications().Save(_id, txtproject.Text, radDocdate.Value, txtdocsource.Text, txtremarks.Text, Common.ComboVal(cboRoute),   _userid);
        }
    }
}
