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
    public partial class NewProject : BaseEntryForm
    {

        private string _id = "";

        public NewProject()
        {
            InitializeComponent();
        }

        public NewProject(string id)
        {
            InitializeComponent();

            MessageBox.Show(id);
            var data = new Repository.Project().GetProjectbyId(id);
            txtrefno.Text = data["referenceNo"].ToString();
            txtproject.Text = data["project"].ToString();
            txtdocsource.Text = data["docsource"].ToString();
            txtremarks.Text = data["remarks"].ToString();
            _id = id;
        }

        protected override void SaveEntry()
        { 
            new Repository.Project().SaveNewProject(_id, txtproject.Text, radDocdate.Value, txtdocsource.Text, txtremarks.Text,null, _userid);

        }
    }
}
