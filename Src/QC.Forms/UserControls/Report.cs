using Microsoft.Reporting.WinForms;
using QC.Forms.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;

namespace QC.Forms.UserControls
{
    public partial class Report : UserControl
    {
        public string ReportFile { get; set; }

        public string ReportSource { get; set; }

        public DataTable ReportData { get; set; }

        List<RepParam> _paramLst = new List<RepParam>();

        public Report()
        {
            InitializeComponent();
        }

        private void ShowReport()
        {

            try
            {
                Cursor = Cursors.WaitCursor;
                rviewer.LocalReport.ReportPath = Application.StartupPath + @"\Reports\" + ReportFile;
                rviewer.LocalReport.DataSources.Clear();
                rviewer.LocalReport.DataSources.Add(new ReportDataSource(ReportSource, ReportData));

                if (_paramLst.Count > 0)
                {
                    ReportParameter[] param = new ReportParameter[_paramLst.Count];
                    for (int i = 0; i < _paramLst.Count; i++)
                    {
                        param[i] = new ReportParameter(_paramLst[i].ParameterName);
                        param[i].Values.Add(_paramLst[i].Value);
                    }
                    rviewer.LocalReport.SetParameters(param);
                }
                rviewer.RefreshReport();
            }
            catch (Exception ex)
            {
                //RadMessageBox.SetThemeName(Settings.Theme);
                RadMessageBox.Show(this, "Error Generating Report:\n" + ex.Message, "Report", MessageBoxButtons.OK, RadMessageIcon.Error);

            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        public void AddReportParameters(string paramName, string paramval)
        {
            _paramLst.Add(new RepParam { ParameterName = paramName, Value = paramval });
        }

        private void Report_Load(object sender, EventArgs e)
        {
            ShowReport();
        }
    }
}
