using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace QC.Forms.List
{
    public partial class DupaHeader : BaseGridForm
    {
        protected override void InitGrid()
        {
            //base.InitGrid();

            //radGrid.ShowGroupPanel = false;

            //radGrid.Columns[1].WrapText = true;
            //radGrid.Columns[2].WrapText = true;
            //radGrid.Columns[3].WrapText = true;
            //radGrid.Columns[4].WrapText = true;
            //radGrid.Columns[5].WrapText = true;
            //radGrid.Columns[6].WrapText = true;
            //radGrid.Columns[7].WrapText = true;
            //radGrid.Columns[8].WrapText = true;
            //radGrid.Columns[9].WrapText = true;
            //radGrid.Columns[10].WrapText = true;

            //radGrid.Columns[1].Width = 50; //itemcode
            //radGrid.Columns[2].Width = 350; //description
            //radGrid.Columns[3].Width = 50; // unit
            //radGrid.Columns[4].Width = 70; //unit cost
            //radGrid.Columns[5].Width = 90; //assumed output
            //radGrid.Columns[6].Width = 90; //assumed no
            //radGrid.Columns[7].Width = 60; // Width 
            //radGrid.Columns[8].Width = 60; // Area
            //radGrid.Columns[9].Width = 60; // Depth
            //radGrid.Columns[10].Width = 60; // Volume

            //radGrid.Columns[1].TextAlignment = ContentAlignment.MiddleRight;
            //radGrid.Columns[2].TextAlignment = ContentAlignment.MiddleRight;
            //radGrid.Columns[3].TextAlignment = ContentAlignment.MiddleRight;
            //radGrid.Columns[4].TextAlignment = ContentAlignment.MiddleRight;
            //radGrid.Columns[5].TextAlignment = ContentAlignment.MiddleRight;
            //radGrid.Columns[6].TextAlignment = ContentAlignment.MiddleRight;
            //radGrid.Columns[7].TextAlignment = ContentAlignment.MiddleRight;
            //radGrid.Columns[8].TextAlignment = ContentAlignment.MiddleRight;
            //radGrid.Columns[9].TextAlignment = ContentAlignment.MiddleRight;
            //radGrid.Columns[10].TextAlignment = ContentAlignment.MiddleRight;


            //radGrid.Columns[4].FormatString = "{0:#,##0.00}";
            //radGrid.Columns[5].FormatString = "{0:#,##0.00}";
            //radGrid.Columns[6].FormatString = "{0:#,##0.00}";
            //radGrid.Columns[7].FormatString = "{0:#,##0.00}";
            //radGrid.Columns[8].FormatString = "{0:#,##0.00}";
            //radGrid.Columns[9].FormatString = "{0:#,##0.00}";
            //radGrid.Columns[10].FormatString = "{0:#,##0.00}";
        }


        public DupaHeader()
        {
            InitializeComponent();
        }

        protected override DataTable GetData()
        {
            return new Repository.DupaHeader().GetDupaHeader();
        }

        protected override void NewRecord()
        {
            Entry.DupaHeader oEntry = new Entry.DupaHeader();
            oEntry.UpdateHandler += Record_Updated;
            oEntry.Show();


        }

        protected override void OpenRecord(GridViewDataRowInfo selectedrow)
        {
            if (selectedrow != null)
            {

                Entry.DupaHeader oEntry = new Entry.DupaHeader(selectedrow.Cells[0].Value.ToString());
                oEntry.UpdateHandler += Record_Updated;
                oEntry.Show();
            }
        }
    }
}
