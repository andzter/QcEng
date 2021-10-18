namespace QC.Forms.Entry
{
    partial class DesignProject
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.radPageView = new Telerik.WinControls.UI.RadPageView();
            this.pgEstimates = new Telerik.WinControls.UI.RadPageViewPage();
            this.pgSOW = new Telerik.WinControls.UI.RadPageViewPage();
            this.pgTakeOff = new Telerik.WinControls.UI.RadPageViewPage();
            this.pgSched = new Telerik.WinControls.UI.RadPageViewPage();
            this.pgEquipment = new Telerik.WinControls.UI.RadPageViewPage();
            this.pgManpower = new Telerik.WinControls.UI.RadPageViewPage();
            this.pgTechSpecs = new Telerik.WinControls.UI.RadPageViewPage();
            this.pgCADFile = new Telerik.WinControls.UI.RadPageViewPage();
            this.pgPDFFile = new Telerik.WinControls.UI.RadPageViewPage();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.cancelButton = new Telerik.WinControls.UI.RadButton();
            this.saveButton = new Telerik.WinControls.UI.RadButton();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView)).BeginInit();
            this.radPageView.SuspendLayout();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cancelButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveButton)).BeginInit();
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
            this.pnlTop.Size = new System.Drawing.Size(1090, 46);
            this.pnlTop.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(34, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(134, 31);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Estimates";
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
            // panelMain
            // 
            this.panelMain.Controls.Add(this.radPageView);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 206);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1090, 322);
            this.panelMain.TabIndex = 73;
            // 
            // radPageView
            // 
            this.radPageView.Controls.Add(this.pgEstimates);
            this.radPageView.Controls.Add(this.pgSOW);
            this.radPageView.Controls.Add(this.pgTakeOff);
            this.radPageView.Controls.Add(this.pgSched);
            this.radPageView.Controls.Add(this.pgEquipment);
            this.radPageView.Controls.Add(this.pgManpower);
            this.radPageView.Controls.Add(this.pgTechSpecs);
            this.radPageView.Controls.Add(this.pgCADFile);
            this.radPageView.Controls.Add(this.pgPDFFile);
            this.radPageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPageView.Location = new System.Drawing.Point(0, 0);
            this.radPageView.Name = "radPageView";
            this.radPageView.SelectedPage = this.pgEstimates;
            this.radPageView.Size = new System.Drawing.Size(1090, 322);
            this.radPageView.TabIndex = 0;
            // 
            // pgEstimates
            // 
            this.pgEstimates.ItemSize = new System.Drawing.SizeF(99F, 28F);
            this.pgEstimates.Location = new System.Drawing.Point(10, 37);
            this.pgEstimates.Name = "pgEstimates";
            this.pgEstimates.Size = new System.Drawing.Size(1069, 274);
            this.pgEstimates.Text = "Agency Estimate";
            // 
            // pgSOW
            // 
            this.pgSOW.ItemSize = new System.Drawing.SizeF(123F, 28F);
            this.pgSOW.Location = new System.Drawing.Point(10, 37);
            this.pgSOW.Name = "pgSOW";
            this.pgSOW.Size = new System.Drawing.Size(1069, 274);
            this.pgSOW.Text = "SOW/POW/Summary";
            // 
            // pgTakeOff
            // 
            this.pgTakeOff.ItemSize = new System.Drawing.SizeF(60F, 28F);
            this.pgTakeOff.Location = new System.Drawing.Point(10, 37);
            this.pgTakeOff.Name = "pgTakeOff";
            this.pgTakeOff.Size = new System.Drawing.Size(1069, 274);
            this.pgTakeOff.Text = "Take-Off";
            // 
            // pgSched
            // 
            this.pgSched.ItemSize = new System.Drawing.SizeF(99F, 28F);
            this.pgSched.Location = new System.Drawing.Point(10, 37);
            this.pgSched.Name = "pgSched";
            this.pgSched.Size = new System.Drawing.Size(1069, 274);
            this.pgSched.Text = "Project Schedule";
            // 
            // pgEquipment
            // 
            this.pgEquipment.ItemSize = new System.Drawing.SizeF(108F, 28F);
            this.pgEquipment.Location = new System.Drawing.Point(10, 37);
            this.pgEquipment.Name = "pgEquipment";
            this.pgEquipment.Size = new System.Drawing.Size(1069, 274);
            this.pgEquipment.Text = "List of Equipments";
            // 
            // pgManpower
            // 
            this.pgManpower.ItemSize = new System.Drawing.SizeF(103F, 28F);
            this.pgManpower.Location = new System.Drawing.Point(10, 37);
            this.pgManpower.Name = "pgManpower";
            this.pgManpower.Size = new System.Drawing.Size(1069, 274);
            this.pgManpower.Text = "List of Manpower";
            // 
            // pgTechSpecs
            // 
            this.pgTechSpecs.ItemSize = new System.Drawing.SizeF(129F, 28F);
            this.pgTechSpecs.Location = new System.Drawing.Point(10, 37);
            this.pgTechSpecs.Name = "pgTechSpecs";
            this.pgTechSpecs.Size = new System.Drawing.Size(1069, 274);
            this.pgTechSpecs.Text = "Technical Specification ";
            // 
            // pgCADFile
            // 
            this.pgCADFile.ItemSize = new System.Drawing.SizeF(58F, 28F);
            this.pgCADFile.Location = new System.Drawing.Point(10, 37);
            this.pgCADFile.Name = "pgCADFile";
            this.pgCADFile.Size = new System.Drawing.Size(1069, 274);
            this.pgCADFile.Text = "CAD File";
            // 
            // pgPDFFile
            // 
            this.pgPDFFile.ItemSize = new System.Drawing.SizeF(56F, 28F);
            this.pgPDFFile.Location = new System.Drawing.Point(10, 37);
            this.pgPDFFile.Name = "pgPDFFile";
            this.pgPDFFile.Size = new System.Drawing.Size(1069, 274);
            this.pgPDFFile.Text = "PDF File";
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.cancelButton);
            this.panelBottom.Controls.Add(this.saveButton);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 528);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1090, 39);
            this.panelBottom.TabIndex = 72;
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cancelButton.Location = new System.Drawing.Point(88, 1);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(70, 26);
            this.cancelButton.TabIndex = 63;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.ThemeName = "MedicalAppTheme";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.saveButton.Location = new System.Drawing.Point(8, 1);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(70, 26);
            this.saveButton.TabIndex = 62;
            this.saveButton.Text = "Save";
            this.saveButton.ThemeName = "MedicalAppTheme";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // panelInfo
            // 
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(0, 46);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(1090, 160);
            this.panelInfo.TabIndex = 71;
            // 
            // DesignProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 567);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.pnlTop);
            this.Name = "DesignProject";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "DesignEstimate";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPageView)).EndInit();
            this.radPageView.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cancelButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelBottom;
        private Telerik.WinControls.UI.RadPageView radPageView;
        private Telerik.WinControls.UI.RadPageViewPage pgEstimates;
        private Telerik.WinControls.UI.RadPageViewPage pgSOW;
        private Telerik.WinControls.UI.RadPageViewPage pgTakeOff;
        private Telerik.WinControls.UI.RadPageViewPage pgSched;
        private Telerik.WinControls.UI.RadPageViewPage pgEquipment;
        private Telerik.WinControls.UI.RadPageViewPage pgManpower;
        private Telerik.WinControls.UI.RadButton cancelButton;
        private Telerik.WinControls.UI.RadButton saveButton;
        private System.Windows.Forms.Panel panelInfo;
        private Telerik.WinControls.UI.RadPageViewPage pgTechSpecs;
        private Telerik.WinControls.UI.RadPageViewPage pgCADFile;
        private Telerik.WinControls.UI.RadPageViewPage pgPDFFile;
    }
}
