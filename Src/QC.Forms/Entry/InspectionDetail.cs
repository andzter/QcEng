using System;
using System.Windows.Forms;

namespace QC.Forms.Entry
{
    public partial class InspectionDetail : QC.Forms.BaseEntryForm
    {

        string _id = string.Empty;
        string _project = string.Empty;

        public InspectionDetail()
        {
            InitializeComponent();
        }

        public InspectionDetail(string project, string id)
        {
            InitializeComponent();
            _id = id;
            _project = project;

            if (!string.IsNullOrEmpty(id))
            {
                var record = new Repository.Inspection().GetDetail(_id);
                txt.Text = record["Description"].ToString();
            }
            //txt.Text = record["Description"].ToString();

        }

        protected override void SaveEntry()
        {
            var service = new Repository.Inspection();

            service.SaveDetail(_id, _project, txt.Text,string.Empty , _userid);
            //service.SaveDetailAttachment(_project, _id, _userid);
            Dispose();
        }

        private void btnFile_Click(object sender, EventArgs e)
        {


            OpenFileDialog openDialog = new OpenFileDialog();
            //saveDialog1.Filter = "Excel (*.xls)|*.xls";
            //saveDialog1.FileName = Text + ".xls";

            if (openDialog.ShowDialog(this) == DialogResult.OK)
            {
                string file = openDialog.FileName;
            }
        }
    }
}
