using QC.Lib;
using System;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;

namespace QC.Forms.Lib
{
    public static class FormUtils
    {

        public static void ShowError(Exception ex, string errortitle)
        {
            RadMessageBox.SetThemeName(Settings.Theme);
            RadMessageBox.Show(ex.Message, errortitle, MessageBoxButtons.OK, RadMessageIcon.Error);
        }

        public static void ShowError(string ex, string errortitle)
        {
            RadMessageBox.SetThemeName(Settings.Theme);
            RadMessageBox.Show(ex, errortitle, MessageBoxButtons.OK, RadMessageIcon.Error);

        }

        public static void ShowInfoMessage(string msg, string infotitle)
        {
            RadMessageBox.SetThemeName(Settings.Theme);
            RadMessageBox.Show(msg, infotitle, MessageBoxButtons.OK, RadMessageIcon.Info);

        }

        public static AutoCompleteStringCollection autocompleteList(DataTable dt)
        {
            AutoCompleteStringCollection aList = new AutoCompleteStringCollection();
            if (dt != null)
                foreach (DataRow dr in dt.Rows)
                    aList.Add(dr[0].ToString());
            return aList;


        }

        public static void SetAutoComplete(TextBox txt, DataTable dt)
        {
            try
            {
                txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt.AutoCompleteCustomSource = autocompleteList(dt);
            }
            catch
            {

                return;
            }
        }

        public static void ClearControls(Control controls)
        {
            ClearControl(controls);
            if (controls.Controls.Count > 1)
                foreach (Control contr in controls.Controls)
                {
                    ClearControl(contr);
                    if (contr.Controls.Count > 1)
                        ClearControls(contr);
                }
        }

        public static void LockText(Control control)
        {
            foreach (Control contr in control.Controls)
            {
                if (contr is TextBox)
                    ((TextBox)contr).ReadOnly = true;
                if (contr is DateTimePicker)
                    ((DateTimePicker)contr).Enabled = false;
            }
        }

        public static void LockControls(Control control)
        {
            foreach (Control contr in control.Controls)
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

        public static void ClearControl(Control c)
        {
            if (c is TextBox)
            {
                c.Text = "";
            }

            if (c is ComboBox) ((ComboBox)c).SelectedIndex = -1;

            //if (c is RadComboBox) ((RadComboBox)c).SelectedIndex = -1;

            if (c is DateTimePicker)
            {
                ((DateTimePicker)c).Checked = false;
                ((DateTimePicker)c).Value = DateTime.Now;
            }
            if (c is CheckBox) ((CheckBox)c).Checked = false;
        }


    }
}
