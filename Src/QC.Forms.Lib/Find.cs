using QC.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace QC.Forms.Lib
{
    public partial class Find : RadForm
    {

        // add a delegate

        public delegate void FindUpdateEventHandler(object sender, FindUpdateEventArgs e);

        // add an event of the delegate type
        public event FindUpdateEventHandler FindHandler;

        public string HideCols { get; set; }

        public string Title
        {
            set { Text = value; }
        }

        static string Query = "";

        static bool HideId;
        private static DataTable _data = null;

        public Find()
        {
            InitializeComponent();
        }

        public Find(string query)
        {
            InitializeComponent();
            Query = query;
            _data = null;
        }


        public Find(string query, bool hideid = true)
        {
            InitializeComponent();
            Query = query;
            HideId = hideid;
            _data = null;

        }

        public Find(DataTable dt)
        {
            InitializeComponent();
            Query = "";
            _data = dt;
        }


        public Find(DataTable dt, bool hideid = true)
        {
            InitializeComponent();
            Query = "";
            HideId = hideid;
            _data = dt;
        }

        private void Find_Load(object sender, EventArgs e)
        {
            try
            {
                rGrid.DataSource = !Query.Equals("") ? (new DataAccess()).GetDataTable(Query) : _data;
                rGrid.BestFitColumns();
                if (HideId)
                {
                    rGrid.Columns[0].IsVisible = false;
                }

                if (HideCols != null && HideCols.Length > 0)
                {
                    string[] hCols = HideCols.Split(',');
                    foreach (string col in hCols)
                    {
                        GridUtil.HideColumn(rGrid, col);
                    }
                }


                for (int i = 1; i < rGrid.Columns.Count; i++)
                {
                    rGrid.Columns[i].HeaderText = rGrid.Columns[i].HeaderText.Replace("_", " ").ToUpperInvariant();
                    if (rGrid.Columns[i].DataType.ToString().Equals("System.DateTime"))
                    {
                        rGrid.Columns[i].FormatString = "{0:d}";
                    }
                    if (rGrid.Columns[i].DataType.ToString().Equals("System.Decimal"))
                    {
                        rGrid.Columns[i].FormatString = "{0:0,0.00}";
                    }
                }
            }
            catch
            { return; }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (rGrid.CurrentRow != null)
                    SelectRow(rGrid.CurrentRow);
            }
            catch (Exception ex)
            {
                RadMessageBox.SetThemeName(Settings.Theme);
                RadMessageBox.Show(this, "Error:" + ex.Message, "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }
        }

        private void rGrid_DoubleClick(object sender, EventArgs e)
        {
            if (rGrid.CurrentRow != null)
                SelectRow(rGrid.CurrentRow);
            //MessageBox.Show(rGrid.CurrentRo
        }

        private void SelectRow(GridViewRowInfo row)
        {
            try
            {
                //raise the event with the updated arguments
                FindHandler(this, new FindUpdateEventArgs(row.Cells[0].Value.ToString(), row));
            }
            finally
            {
                Close();
            }

        }
    }
}
