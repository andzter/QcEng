using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace QC.Lib
{
    public class Common
    {
        public static string ComboVal(ComboBox cbo)
        {
            if (cbo.SelectedIndex == -1)
                return "";
            return cbo.SelectedValue.ToString();
        }

        public static string ComboVal(ListBox cbo)
        {
            if (cbo.SelectedIndex == -1)
                return "";
            return cbo.SelectedValue.ToString();
        }

        public static string ComboVal(RadDropDownList cbo)
        {
            if (cbo.SelectedIndex == -1)
                return "";
            return cbo.SelectedValue.ToString();
        }


        public static double GetSafeDbl(string val)
        {
            double d;
            if (val == null)
                return 0;
            Double.TryParse(val, out d);
            return d;
        }


        public static double GetSafeDbl(object val)
        {
            double d;
            if (val == null)
                return 0;
            Double.TryParse(val.ToString(), out d);
            return d;
        }

        public static int GetSafeInt(string val)
        {
            int d;
            if (val == null)
                return 0;
            int.TryParse(val, out d);
            return d;
        }


        public static int GetSafeInt(object val)
        {
            int d;
            if (val == null)
                return 0;
            int.TryParse(val.ToString(), out d);
            return d;
        }


        public static DateTime? GetSafeDate(object val)
        {
            try
            {
                DateTime d;
                if (val == null)
                    return null;
                DateTime.TryParse(val.ToString(), out d);
                return d;
            }
            catch
            {
                return null;
            }
        }

        public static DateTime? GetSafeDate(string val)
        {
            try
            {
                DateTime d;
                if (val == null)
                    return null;
                DateTime.TryParse(val, out d);
                return d;
            }
            catch
            {
                return null;
            }
        }

        public static string GetSafeString(object val)
        {
            if (val == null)
                return string.Empty;
            return val.ToString();
        }

        public static string GetSafeString(string val)
        {
            if (val == null)
                return string.Empty;
            return val;
        }

        public static void FillControl(ComboBox cbo, string sqlquery, string connstring)
        {
            cbo.Items.Clear();
            DataAccess daccess = new DataAccess(connstring);
            DataTable dt = daccess.GetDataTable(sqlquery);
            cbo.ValueMember = dt.Columns[0].ColumnName;
            cbo.DisplayMember = dt.Columns[1].ColumnName;
            cbo.DataSource = dt;


        }

        public static void FillControl(ComboBox cbo, DataTable dt)
        {

            cbo.Items.Clear();
            cbo.ValueMember = dt.Columns[0].ColumnName;
            cbo.DisplayMember = dt.Columns[1].ColumnName;
            cbo.DataSource = dt;


        }


        public static void FillControl(RadDropDownList cbo, string sqlquery, string connstring)
        {
            cbo.Items.Clear();
            DataAccess daccess = new DataAccess(connstring);
            DataTable dt = daccess.GetDataTable(sqlquery);
            cbo.ValueMember = dt.Columns[0].ColumnName;
            cbo.DisplayMember = dt.Columns[1].ColumnName;
            cbo.DataSource = dt;


        }

        public static void FillControl(RadDropDownList cbo, DataTable dt)
        {
            try
            {
                cbo.Items.Clear();
                cbo.ValueMember = dt.Columns[0].ColumnName;
                cbo.DisplayMember = dt.Columns[1].ColumnName;
                cbo.DataSource = dt;

            }
            catch
            {
                return;

            }


        }

        public static void SetComboVal(RadDropDownList cbo, string val)
        {
            if (cbo.Items.Count > 0)
                cbo.SelectedValue = val;
        }

        public static void SetComboVal(ComboBox cbo, string val)
        {
            if (cbo.Items.Count > 0)
                cbo.SelectedValue = val;
        }

        public static void SetDateVal(DateTimePicker dtp, string sdate)
        {
            dtp.Checked = false;
            try
            {
                if (sdate.Length > 0)
                {
                    dtp.Value = DateTime.Parse(sdate);
                    dtp.Checked = true;
                }

            }
            catch
            {
                return;
            }
        }

        public static void SetDateVal(DateTimePicker dtp, DateTime? date)
        {
            dtp.Checked = false;
            try
            {
                if (date != null)
                {
                    dtp.Value = (DateTime)date;
                    dtp.Checked = true;
                }

            }
            catch
            {
                return;
            }
        }

        public static void SetDateVal(RadDateTimePicker dtp, DateTime? date)
        {
            try
            {
                if (date != null)
                {
                    dtp.Value = (DateTime)date;
                }

            }
            catch
            {
                return;
            }
        }

        public static void SetDateVal(TextBox dtp, string sdate)
        {
            try
            {
                if (sdate.Length > 0)
                {
                    dtp.Text = DateTime.Parse(sdate).ToShortDateString();
                }

            }
            catch
            {
                dtp.Text = "";
                return;
            }
        }


        public static void SetDateVal(Label lbl, string sdate)
        {
            try
            {
                if (sdate.Length > 0)
                {
                    lbl.Text = DateTime.Parse(sdate).ToShortDateString();
                }

            }
            catch
            {
                lbl.Text = "";
                return;
            }
        }

        public static void SetChkVal(CheckBox chk, object val)
        {
            chk.Checked = false;
            try
            {
                chk.Checked = (bool)val;
            }
            catch
            {
                return;
            }

        }

        public static void SetMoneyVal(TextBox txt, string val)
        {
            txt.Text = String.Format("{0:#,#.00}", GetSafeDbl(val));
        }

        public static void SetMoneyVal(TextBox txt, double val)
        {
            txt.Text = String.Format("{0:#,#.00}", val);
        }

        public static void SetMoneyVal(Label txt, string val)
        {
            txt.Text = String.Format("{0:#,#.00}", GetSafeDbl(val));
        }

        public static void SetMoneyVal(Label txt, double val)
        {
            txt.Text = String.Format("{0:#,#.00}", val);
        }

        public static void SetIntVal(TextBox txt, string val)
        {
            txt.Text = String.Format("{0:N}", GetSafeInt(val));
        }

        public static void SetIntVal(TextBox txt, int val)
        {
            txt.Text = String.Format("{0:N}", val);
        }

        public static void ClearControl(Control c)
        {
            if (c is TextBox)
            {
                c.Text = "";
            }

            if (c is ComboBox) ((ComboBox)c).SelectedIndex = -1;

            if (c is DateTimePicker)
            {
                ((DateTimePicker)c).Checked = false;
                ((DateTimePicker)c).Value = DateTime.Now;
            }
            if (c is CheckBox) ((CheckBox)c).Checked = false;
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

        public static DateTime? DateVal(DateTimePicker dtp)
        {
            if (dtp.Checked)
                return dtp.Value;
            return null;
        }


        public static DateTime? DateVal(DateTime dt)
        {
            if (dt.ToString().StartsWith(@"1/1/0001"))
                return null;
            return dt;
        }

        public static string QueryNoOrderBy(string query)
        {
            try
            {
                return (query.ToLower().Replace("order by", "\t")).Split('\t')[0];
            }
            catch
            {
                return "";
            }
        }

        public static void OpenApplication(string app, string sFilePath)
        {
            //try
            //{
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = app;
            FileInfo finfo = new FileInfo(sFilePath);
            proc.StartInfo.Arguments = finfo.Name;
            proc.Start();
            //}
            //catch 
            //{
            //    return;
            //}

        }

        public static void CreateTextFile(string sFilePath, string data)
        {
            try
            {
                if (File.Exists(sFilePath)) File.Delete(sFilePath);
                TextWriter tw = new StreamWriter(sFilePath);
                tw.Write(data);
                tw.Close();
            }
            catch { return; }
        }

    }
}
