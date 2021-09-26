using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QC.Forms.UserControls
{
    public partial class ProjectHeader : UserControl
    {

        private string _id = "";
        private string _projectId = "";

         
        public string ProjectId
        {
            set { _projectId = value; }
        }

        public ProjectHeader()
        {
            InitializeComponent();
            LoadData();
        }

        public ProjectHeader(string id)
        {
            _projectId = id;
            InitializeComponent();
            LoadData();
        }

        protected virtual void LoadData()
        {
            var data = new Repository.Project().GetProjectbyId(_projectId);

            if (data != null)
            {
                txtDEDNo.Text = data["DEDNo"].ToString();
                txtLocation.Text = data["Project"].ToString();
                txtLocation.Text = $"{data["Barangay"].ToString()} {data["District"].ToString()}";  
                txtLimits.Text = data["Limits"].ToString();
                txtLenght.Text = data["Lenght"].ToString();
                txtDuration.Text = data["Duration"].ToString();
                txtscope.Text = data["Scopeofwork"].ToString();
                txtAppropriation.Text = data["Appropriation"].ToString();
                txtPavementWidth.Text = data["PavementWidth"].ToString();
                txtSidewalkWidth.Text = data["SidewalkWidth"].ToString();
                txtDateEstimated.Text = data["DateEstimated"].ToString();
                txtRightofWay.Text = data["Rightofway"].ToString();
            }
        }

        public void SaveProjectHeader()
        {
            new Repository.Project().SaveHeader(_projectId, txtLimits.Text, txtLenght.Text, txtAppropriation.Text, txtscope.Text,
                    txtDateEstimated.Text,  txtRightofWay.Text, txtPavementWidth.Text, 
                    txtSidewalkWidth.Text, txtTypeofpavement.Text, txtDuration.Text);
        }



    }
}
