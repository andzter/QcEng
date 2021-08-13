using System;
using System.Windows.Forms;

namespace QC.Lib
{
    public static class Validation
    {
        public static string Required(string msg, Control control, string title)
        {
            string ret = msg;
            bool isreq = false;
            if (control is TextBox)
                if (control.Text.Trim().Length == 0) isreq = true;
            if (control is ComboBox)
                if (((ComboBox)control).SelectedIndex == -1) isreq = true;
            if (control is DateTimePicker)
                if (((DateTimePicker)control).Checked == false) isreq = true;
            if (isreq)
                ret += (ret.Equals("") ? "" : "\n") + title;
            return ret;
        }

        public static string DateGreater(string msg, DateTime dt1, DateTime dt2, string title)
        {
            string ret = msg;
            int i = DateTime.Compare(dt1, dt2);
            if (i <= 0)
                ret += (ret.Equals("") ? "" : "\n") + title;
            return ret;
        }
    }
}
