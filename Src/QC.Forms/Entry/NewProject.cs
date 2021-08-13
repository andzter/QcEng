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

        protected override void SaveEntry()
        { 
            new Repository.Communications().Save("", txtproject.Text, radDocdate.Value, txtdocsource.Text, txtremarks.Text,null, _userid);

        }
    }
}
