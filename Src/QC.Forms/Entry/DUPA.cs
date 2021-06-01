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
    public partial class DUPA : BaseEntryForm
    {
        private string _id = "";

        public DUPA()
        {
            InitializeComponent();
        }

        public DUPA(string id)
        {
            InitializeComponent();

            MessageBox.Show(id);
            var data = new Repository.DUPA().GetDUPAbyId(id);
            txtitemcode.Text = data["ItemCode"].ToString();
            txtdescription.Text = data["Description"].ToString();
            txtunit.Text = data["Unit"].ToString();
            txtunitcost.Text = data["UnitCost"].ToString();
            _id = id;
        }

        protected override void SaveEntry()
        {
            new Repository.DUPA().SaveDUPA(_id, txtitemcode.Text, txtdescription.Text, txtunit.Text,
                txtunitcost.Text, _userid);

        }
    }
}
