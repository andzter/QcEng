using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Telerik.WinControls;

namespace QC.Forms.Reports
{

    public partial class RptViewer : Form
    {

        public string ReportFile { get; set; }

        public string ReportSource { get; set; }

        public DataTable ReportData { get; set; }

        List<RepParam> _paramLst = new List<RepParam>();

        public RptViewer()
        {
            InitializeComponent();
        }

        private void RptViewer_Load(object sender, EventArgs e)
        {

            ShowReport();
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

                //rviewer.LocalReport.EnableHyperlinks = true;
                //// Required since the logo image in Customer Orders report is external
                //rviewer.LocalReport.EnableExternalImages = true;
                //// Required since the Custom Orders report is using a custom function to access the external image
                //rviewer.LocalReport.ExecuteReportInCurrentAppDomain(
                //    System.Reflection.Assembly.GetExecutingAssembly().Evidence);
                //rviewer.Clear();


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
    }

    public class RepParam
    {
        public string ParameterName { get; set; }
        public string Value { get; set; }
    }

}
