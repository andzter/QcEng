using QC.Forms.Lib;
using QC.Lib;
using System;
using Telerik.WinControls.UI;

namespace QC.Forms.Entry
{
    public partial class Inspection : Telerik.WinControls.UI.RadForm
    {


        public delegate void UpdateEventHandler(object sender, EventArgs e);

        public event UpdateEventHandler InspectionUpdateHandler;

        protected string _userid = Global.UserId();

        public Inspection()
        {
            InitializeComponent();
        }

        public void DetailRecord_Updated(object sender, EventArgs e)
        {
            try
            {
                LoadGridData();  
            }
            catch
            {
                return;
            }
        }
         

        private string _id = "";


        public void LoadGridData()
        {
              
            try
            {
                radGridView.BeginUpdate();

                var data = new Repository.Inspection().GetDetails(_id);

                radGridView.DataSource = data;

                radGridView.MasterTemplate.AllowAddNewRow = false;

                radGridView.EndUpdate(true);
                //lblCount.Text = @"Record Count : " + rGrid.RowCount;

                radGridView.Columns[0].IsVisible = false;
                 
                GridUtil.InitDefualtGrid(radGridView);

                radGridView.Columns[1].Width = 1000;
                radGridView.AutoSizeRows = true;

            }
            catch (Exception ex)
            {

                if (InvokeRequired)
                {
                    Invoke(new EventHandler(delegate
                    {
                        FormUtils.ShowError(ex, "Get Data Error");
                    }));
                }
                else
                {
                    FormUtils.ShowError(ex, "Get Data Error");
                }
                return;
            }
        }

        public Inspection(string id)
        {
            InitializeComponent();
            _id = id;
            var dtusers = new Repository.Lookup().GetUsers();

            var rec = new Repository.Inspection().Get(id);

            if (rec != null)
            {
                txtDedNo.Text = rec["DEDNo"].ToString();
                txtProject.Text = rec["Project"].ToString();
                txtContractAmount.Text = rec["ContractAmount"].ToString();
                txtContractor.Text = rec["Contractor"].ToString();
                Common.SetDateVal(dtStart, Common.GetSafeDate(  rec["DateStart"].ToString()));
                Common.SetDateVal(dtExpiry, Common.GetSafeDate(rec["DateExpiry"].ToString()));
                Common.SetDateVal(dtRevised, Common.GetSafeDate(rec["Date1stRevisedExpiry"].ToString()));
                Common.SetDateVal(dtAmmended, Common.GetSafeDate(rec["Date1stAmmendedExpiry"].ToString()));
            }


            QC.Lib.Common.FillControl(cboRoute, dtusers);
            LoadGridData();
        }

        

        // add validation here
        private bool validateEntry()
        {
            return true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

            if (!validateEntry())
                return;

            var dt = dtStart.Value.ToString();
            //1/1/0001

            (new Repository.Project()).SaveRoute(_id, _userid, QC.Lib.Common.ComboVal(cboRoute), txtComment.Text);

            (new Repository.Inspection()).Save(_id, txtContractor.Text,
                Common.DateVal(dtStart.Value),
                Common.DateVal(dtExpiry.Value),
                Common.DateVal(dtRevised.Value),
                Common.DateVal(dtAmmended.Value),
                Common.GetSafeDbl(txtContractAmount.Text),
                _userid);

            InspectionUpdateHandler(this, e);

        }


      

        protected void OpenRecord(GridViewDataRowInfo selectedrow)
        {
            if (selectedrow != null)
            {
                Entry.InspectionDetail oEntry = new Entry.InspectionDetail(_id, selectedrow.Cells[0].Value.ToString());
                oEntry.EntryUpdateHandler += DetailRecord_Updated;
                oEntry.Show();
            }
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            Entry.InspectionDetail oEntry = new Entry.InspectionDetail(_id, "");
            oEntry.EntryUpdateHandler += DetailRecord_Updated;
            oEntry.Show();
        }
    }
}
