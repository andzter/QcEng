using QC.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QC.Forms.UserControls
{
    public partial class EstimatesTab : UserControl
    {
        private string _projectId = "";

        public EstimatesTab(string id)
        {
            _projectId = id;
            InitializeComponent();


            var repositoryBom = new Repository.ProjectBom();

            var data = repositoryBom.GetProjectBomDetailPrint(_projectId);
            var row = repositoryBom.GetProjectBomHeaderPrint(_projectId);


            var uAgencyEstimate = new UserControls.Report() { ReportFile = "AgencyEstimate.rdlc", ReportSource = "Dupadata", ReportData = data, Dock = DockStyle.Fill };
            uAgencyEstimate.AddReportParameters("ProjectName", row["ProjectName"].ToString());
            uAgencyEstimate.AddReportParameters("Location", row["Location"].ToString());
            uAgencyEstimate.AddReportParameters("Limits", row["Limits"].ToString());
            uAgencyEstimate.AddReportParameters("Lenght", row["Lenght"].ToString());
            uAgencyEstimate.AddReportParameters("Duration", row["Duration"].ToString());
            uAgencyEstimate.AddReportParameters("AAE", row["Total"].ToString().ToCurrecyString("P"));
            uAgencyEstimate.AddReportParameters("AmountInWords", row["Total"].ToString().ConvertToWords("Only").ToUpper());
            uAgencyEstimate.AddReportParameters("Total", row["Total"].ToString().ToCurrecyString("P"));

            tabEstimates.Controls.Add(uAgencyEstimate);
        
            var ucSOW = new  Report() { ReportFile = "ProgramOfWork.rdlc", ReportSource = "Dupadata", ReportData = data, Dock = DockStyle.Fill };
            ucSOW.AddReportParameters("ProjectName", row["ProjectName"].ToString());
            ucSOW.AddReportParameters("Location", row["Location"].ToString());
            ucSOW.AddReportParameters("Limits", row["Limits"].ToString());
            ucSOW.AddReportParameters("Lenght", row["Lenght"].ToString());
            ucSOW.AddReportParameters("Duration", row["Duration"].ToString());
            ucSOW.AddReportParameters("AAE", row["Total"].ToString().ToCurrecyString("P"));
            ucSOW.AddReportParameters("AmountInWords", row["Total"].ToString().ConvertToWords("Only").ToUpper());
            ucSOW.AddReportParameters("Total", row["Total"].ToString().ToCurrecyString("P"));
            tabSow.Controls.Add(ucSOW);

            var ucSched = new Schedule(_projectId) { Dock = DockStyle.Fill };
            tabSched.Controls.Add(ucSched);

            var dataManpower = (new Repository.Manpower()).GetList(_projectId);
            var rowManpower = repositoryBom.GetProjectBomHeaderPrint(_projectId);

            var ucManpower = new  Report() { ReportFile = "Manpower.rdlc", ReportSource = "datalist", ReportData = dataManpower, Dock = DockStyle.Fill };
            ucManpower.AddReportParameters("ProjectName", rowManpower["ProjectName"].ToString());
            ucManpower.AddReportParameters("Location", rowManpower["Location"].ToString());
            tabManpower.Controls.Add(ucManpower);

            var dataEquipment = (new Repository.Equipment()).GetList(_projectId);

            var uEquip = new  Report() { ReportFile = "Equipment.rdlc", ReportSource = "datalist", ReportData = dataEquipment, Dock = DockStyle.Fill};
            uEquip.AddReportParameters("ProjectName", rowManpower["ProjectName"].ToString());
            uEquip.AddReportParameters("Location", rowManpower["Location"].ToString());
            tabEquipment.Controls.Add(uEquip);

            var uTakeOff = new BOM(_projectId) { Dock = DockStyle.Fill };
            tabTakeOff.Controls.Add(uTakeOff);

        }



    }
}
