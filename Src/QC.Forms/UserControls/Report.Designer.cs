
namespace QC.Forms.UserControls
{
    partial class Report
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rviewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rviewer
            // 
            this.rviewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rviewer.LocalReport.ReportEmbeddedResource = "QC.Forms.Reports.Dupa.rdlc";
            this.rviewer.Location = new System.Drawing.Point(0, 0);
            this.rviewer.Name = "rviewer";
            this.rviewer.ServerReport.BearerToken = null;
            this.rviewer.Size = new System.Drawing.Size(813, 477);
            this.rviewer.TabIndex = 1;
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rviewer);
            this.Name = "Report";
            this.Size = new System.Drawing.Size(813, 477);
            this.Load += new System.EventHandler(this.Report_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rviewer;
    }
}
