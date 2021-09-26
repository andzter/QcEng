using System;
using System.Windows.Forms;
using QC.Forms.Lib;
using QC.Lib;

namespace QC.Forms
{
    public partial class BaseEntryForm : Form
    {

        protected static string ModuleCode = "";
        protected bool isChange;
        protected bool isNew;
        protected static string MainTitle = "";
        protected static string ValidationMessage = "";

        protected string _userid = Global.UserId();

        static bool allowaddnew = true;

        public bool AllowAddNew
        {
            set { allowaddnew = value; }
        }

        public BaseEntryForm()
        {
            InitializeComponent();
        }

        public delegate void UpdateEventHandler(object sender, EventArgs e);

        public event UpdateEventHandler EntryUpdateHandler;

        protected virtual bool ValidateEntry()
        {
            return ValidationMessage.Equals("") ? true : false;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (ValidateEntry())
            {
                try
                {
                    SaveEntry();

                    saveButton.Visible = false;
                    cancelButton.Visible = false;
                    try
                    {
                        EntryUpdateHandler(this, e);
                    }
                    catch { }

                    isChange = false;
                    isNew = false;
 
                    //LoadRecord();

                }
                catch (Exception ex)
                {
                    FormUtils.ShowError($"Saving Error:\n{ex.Message}", "Save Record");
                    return;
                }


            }
            else
            {
                FormUtils.ShowInfoMessage(ValidationMessage, "Save Record");
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            if (isChange)
            {
                DialogResult dialogResult = MessageBox.Show("Changes were made\nAre you sure you want to cancel?",
                                                            "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    LoadRecord();
                    saveButton.Visible = false;
                    cancelButton.Visible = false;
                }
            }

        }

        protected virtual void InitLoadRec()
        {
            return;
        }

        private void LoadRecord()
        {
            LoadData();
            InitLoadRec();
            saveButton.Visible = false;
            cancelButton.Visible = false;
            isChange = false;

        }

        protected virtual void InitForm()
        {

        }

        protected virtual void LoadData()
        {

        }

        protected virtual void InitEntry()
        {

        }

        protected virtual void ClearEntry()
        {
            FormUtils.ClearControls(this);
            InitEntry();
            isChange = false;
            isNew = true;


        }

        protected virtual void LockEntry()
        {
            //Util.LockControls(this);
            foreach (Control contr in Controls)
            {
                if (contr is TextBox)
                    ((TextBox)contr).ReadOnly = true;
                else
                {
                    try
                    {
                        contr.Enabled = false;
                    }
                    catch
                    {
                    }
                }

            }
        }

        protected virtual void EnableEntry()
        {

        }

        private void Form_Load(object sender, EventArgs e)
        {
            LoadForm();

        }



        public void LoadForm()
        {

            InitForm();
            //_security = new Security(Settings.UserID, ModuleCode);
            //if (!_security.AllowWrite)
            //{
            //    LockEntry();
            //}
            ValidationMessage = "";
            isChange = false;
            cancelButton.Visible = false;
            saveButton.Visible = false;
            InitEntry();
            if (!isNew) LoadRecord();

        }



        protected virtual void SaveEntry()
        {

        }

        public void ChangeEntry()
        {
            isChange = true;
            saveButton.Visible = true;
            cancelButton.Visible = true;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            if (isChange)
            {
                DialogResult dialogResult = MessageBox.Show("Changes were made.\nAre you sure you want to exit?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    CloseWindow();

                }
            }
            else
                CloseWindow();
        }


        private void CloseWindow()
        {
            Dispose();
        }
    }
}
