using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace QC.Lib
{
    public static class GridUtil
    {
        public static void InitDefualtGrid(RadGridView rgrid)
        {

            rgrid.AutoSizeRows = false;
            rgrid.MasterTemplate.BestFitColumns();
             
            for (int i = 1; i < rgrid.ColumnCount; i++)
            {
                rgrid.Columns[i].HeaderText = rgrid.Columns[i].HeaderText.Replace("_", " ").ToUpperInvariant();
                if (rgrid.Columns[i].DataType.ToString().Equals("System.DateTime"))
                {
                    rgrid.Columns[i].FormatString = "{0:d}";
                }
                if (rgrid.Columns[i].DataType.ToString().Equals("System.Decimal"))
                {
                    rgrid.Columns[i].FormatString = "{0:#,#.00}";
                }

                if (rgrid.Columns[i].Width > 300)
                    rgrid.Columns[i].Width = 300;
            }
             

        }


        public static void SaveConditionalFormatting(RadGridView grd, string modulename)
        {
            StringBuilder sb = new StringBuilder();
            string sCol = "";
            for (int i = 0; i < grd.Columns.Count; i++)
            {
                sCol = grd.Columns[i].FieldName;
                if (grd.Columns[i].ConditionalFormattingObjectList.Count > 0)
                    foreach (ConditionalFormattingObject con in grd.Columns[i].ConditionalFormattingObjectList)
                    {

                        sb.AppendLine(sCol + "\t" + con.Name + "\t" + con.ConditionType.ToString() + "\t" + con.TValue1 + "\t" + con.TValue2
                            + "\t" + (con.ApplyToRow ? "1" : "0") + "\t" + (con.CaseSensitive ? "1" : "0")
                            + "\t" + con.RowBackColor.ToArgb().ToString()
                            + "\t" + con.RowForeColor.ToArgb().ToString()
                            + "\t" + con.CellBackColor.ToArgb().ToString()
                            + "\t" + con.CellForeColor.ToArgb().ToString()
                        );
                    }

            }
            Settings.SetSetting("GridFormat_" + modulename, sb.ToString());
        }

        public static void ApplyConditionalFormatting(RadGridView grd, string modulename)
        {

            string conformatting = Settings.GetSetting("GridFormat_" + modulename);

            if (conformatting.Length > 0)
            {
                string[] cformats = conformatting.Split('\n');
                foreach (string cfs in cformats)
                {
                    string[] cf = cfs.Split('\t');
                    if (grd.Columns[cf[0]] != null)
                    {
                        ConditionalFormattingObject cobj = new ConditionalFormattingObject
                            (cf[1], contype(cf[2]), cf[3], cf[4], cf[5].Equals("1") ? true : false);
                        cobj.CaseSensitive = cf[6].Equals("1") ? true : false;
                        if (cf[7].Length > 0) cobj.RowBackColor = Color.FromArgb(int.Parse(cf[7]));
                        if (cf[8].Length > 0) cobj.RowForeColor = Color.FromArgb(int.Parse(cf[8]));
                        if (cf[9].Length > 0) cobj.CellBackColor = Color.FromArgb(int.Parse(cf[9]));
                        if (cf[10].Length > 0) cobj.CellForeColor = Color.FromArgb(int.Parse(cf[10]));
                        grd.Columns[cf[0]].ConditionalFormattingObjectList.Add(cobj);
                    }
                }
            }
        }

        public static void SaveHideCols(RadGridView grd, string modulename)
        {

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < grd.ColumnChooser.Columns.Count; i++)
                sb.Append((i == 0 ? "" : "\t") + grd.ColumnChooser.Columns[i].FieldName);
            Settings.SetSetting("HIDECOL_" + modulename, sb.ToString());
        }

        public static void SaveColsIndex(RadGridView grd, string modulename)
        {

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < grd.Columns.Count; i++)
                sb.Append((i == 0 ? "" : "\t") + grd.Columns[i].FieldName);
            Settings.SetSetting("COLINDEX_" + modulename, sb.ToString());
        }


        public static void SetHideCols(RadGridView grd, string modulename)
        {
            //grd.ColumnChooser.Columns.Clear();

            string hcol = Settings.GetSetting("HIDECOL_" + modulename);
            if (hcol.Length > 0)
            {
                string[] hcs = hcol.Split('\t');
                foreach (string hc in hcs)
                {
                    if (grd.Columns[hc] != null)
                    {
                        try
                        {
                            grd.Columns[hc].IsVisible = false;
                            //grd.ColumnChooser.Columns.Add(grd.Columns[hc]);

                        }
                        catch { }
                    }
                }
            }

            //grd.ColumnChooser.Columns.Contains()
        }


        public static void SetColsIndex(RadGridView grd, string modulename)
        {

            string hcol = Settings.GetSetting("COLINDEX_" + modulename);

            if (hcol.Length > 0)
            {
                string[] hcs = hcol.Split('\t');
                string[] hCols = GetGridCols(grd);

                if (!CheckCols(hcs, hCols)) return;

                int i = 0;

                foreach (string s in hcs)
                {
                    int iPos = GetColPos(s, hCols);
                    if (iPos != i)
                    {
                        grd.Columns.Move(iPos, i);
                        hCols = GetGridCols(grd);
                    }
                    i++;
                }




            }
        }

        private static int GetColPos(string colName, string[] cols)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                if (cols[i].Equals(colName)) return i;
            }
            return 1;
        }
        private static string[] GetGridCols(RadGridView grd)
        {
            StringBuilder sb = new StringBuilder();
            for (int iCol = 0; iCol < grd.Columns.Count; iCol++)
                sb.Append(grd.Columns[iCol].FieldName + "\t");
            sb.Append("\t");
            string[] hCols = sb.ToString().Replace("\t\t", "").Split('\t');
            return hCols;
        }

        private static bool CheckCols(string[] newCols, string[] origCols)
        {
            bool isNotSame = false;
            for (int i = 0; i < origCols.Length; i++)
            {
                if (newCols.Length > i && origCols[i] != "")

                    if (!newCols[i].Equals(origCols[i]))
                    {
                        return true;
                    }

            }
            return isNotSame;
        }

        public static void SetColNames(RadGridView grd, string modulename, string connectionstring)
        {
            DataAccess da = new DataAccess(connectionstring);
            string scols = (string)da.ExecSQLScalarSP("select Colnames from SetColNames where ModuleCd = '" + modulename + "'");
            if (scols == null) return;
            if (scols.Length > 0)
            {
                string[] sCol = scols.Split('|');

                foreach (string sc in sCol)
                {
                    string[] s = sc.Split(',');
                    if (grd.Columns[s[0]] != null)
                        grd.Columns[s[0]].HeaderText = s[1];

                }
            }
        }

        private static ConditionTypes contype(string ctype)
        {
            switch (ctype)
            {
                case "StartsWith":
                    return ConditionTypes.StartsWith;
                case "NotEqual":
                    return ConditionTypes.NotEqual;
                case "NotBetween":
                    return ConditionTypes.NotBetween;
                case "None":
                    return ConditionTypes.None;
                case "LessOrEqual":
                    return ConditionTypes.LessOrEqual;
                case "Less":
                    return ConditionTypes.Less;
                case "GreaterOrEqual":
                    return ConditionTypes.GreaterOrEqual;
                case "Greater":
                    return ConditionTypes.Greater;
                case "Equal":
                    return ConditionTypes.Equal;
                case "EndsWith":
                    return ConditionTypes.EndsWith;
                case "DoesNotContain":
                    return ConditionTypes.DoesNotContain;
                case "Between":
                    return ConditionTypes.Between;
            }
            return ConditionTypes.Contains;
        }

    }

     

    


     
}
