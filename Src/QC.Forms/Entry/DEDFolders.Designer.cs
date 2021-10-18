namespace QC.Forms.Entry
{
    partial class DEDFolders
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.radPageView = new Telerik.WinControls.UI.RadPageView();
            this.pgEstimates = new Telerik.WinControls.UI.RadPageViewPage();
            this.pgInspectionCert = new Telerik.WinControls.UI.RadPageViewPage();
            this.pgTechSpecs = new Telerik.WinControls.UI.RadPageViewPage();
            this.pgPlanDetails = new Telerik.WinControls.UI.RadPageViewPage();
            this.pgInspectionReport = new Telerik.WinControls.UI.RadPageViewPage();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView)).BeginInit();
            this.radPageView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.pictureBox1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(955, 46);
            this.pnlTop.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(34, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(186, 31);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "D.E.D Folders";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::QC.Forms.Properties.Resources.arrow1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(12, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 33);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panelInfo
            // 
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(0, 46);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(955, 263);
            this.panelInfo.TabIndex = 72;
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 571);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(955, 62);
            this.panelBottom.TabIndex = 73;
            // 
            // radPageView
            // 
            this.radPageView.Controls.Add(this.pgEstimates);
            this.radPageView.Controls.Add(this.pgInspectionCert);
            this.radPageView.Controls.Add(this.pgTechSpecs);
            this.radPageView.Controls.Add(this.pgPlanDetails);
            this.radPageView.Controls.Add(this.pgInspectionReport);
            this.radPageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPageView.Location = new System.Drawing.Point(0, 309);
            this.radPageView.Name = "radPageView";
            this.radPageView.SelectedPage = this.pgEstimates;
            this.radPageView.Size = new System.Drawing.Size(955, 262);
            this.radPageView.TabIndex = 74;
            // 
            // pgEstimates
            // 
            this.pgEstimates.ItemSize = new System.Drawing.SizeF(59F, 28F);
            this.pgEstimates.Location = new System.Drawing.Point(10, 37);
            this.pgEstimates.Name = "pgEstimates";
            this.pgEstimates.Size = new System.Drawing.Size(934, 214);
            this.pgEstimates.Text = "Estimate";
            // 
            // pgInspectionCert
            // 
            this.pgInspectionCert.ItemSize = new System.Drawing.SizeF(135F, 28F);
            this.pgInspectionCert.Location = new System.Drawing.Point(10, 37);
            this.pgInspectionCert.Name = "pgInspectionCert";
            this.pgInspectionCert.Size = new System.Drawing.Size(934, 214);
            this.pgInspectionCert.Text = "Certificate of Inspection";
            // 
            // pgTechSpecs
            // 
            this.pgTechSpecs.ItemSize = new System.Drawing.SizeF(129F, 28F);
            this.pgTechSpecs.Location = new System.Drawing.Point(10, 37);
            this.pgTechSpecs.Name = "pgTechSpecs";
            this.pgTechSpecs.Size = new System.Drawing.Size(934, 214);
            this.pgTechSpecs.Text = "Technical Specification ";
            // 
            // pgPlanDetails
            // 
            this.pgPlanDetails.ItemSize = new System.Drawing.SizeF(91F, 28F);
            this.pgPlanDetails.Location = new System.Drawing.Point(10, 37);
            this.pgPlanDetails.Name = "pgPlanDetails";
            this.pgPlanDetails.Size = new System.Drawing.Size(934, 214);
            this.pgPlanDetails.Text = "Plans & Details ";
            // 
            // pgInspectionReport
            // 
            this.pgInspectionReport.ItemSize = new System.Drawing.SizeF(105F, 28F);
            this.pgInspectionReport.Location = new System.Drawing.Point(10, 37);
            this.pgInspectionReport.Name = "pgInspectionReport";
            this.pgInspectionReport.Size = new System.Drawing.Size(934, 214);
            this.pgInspectionReport.Text = "Inspection Report";
            // 
            // DEDFolders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 633);
            this.Controls.Add(this.radPageView);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.pnlTop);
            this.Name = "DEDFolders";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "DEDFolders";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView)).EndInit();
            this.radPageView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Panel panelBottom;
        private Telerik.WinControls.UI.RadPageView radPageView;
        private Telerik.WinControls.UI.RadPageViewPage pgEstimates;
        private Telerik.WinControls.UI.RadPageViewPage pgInspectionCert;
        private Telerik.WinControls.UI.RadPageViewPage pgTechSpecs;
        private Telerik.WinControls.UI.RadPageViewPage pgPlanDetails;
        private Telerik.WinControls.UI.RadPageViewPage pgInspectionReport;
    }
}
