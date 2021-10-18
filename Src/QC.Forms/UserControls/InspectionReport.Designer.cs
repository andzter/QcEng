
namespace QC.Forms.UserControls
{
    partial class InspectionReport
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
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabSurveyReport = new System.Windows.Forms.TabPage();
            this.tabSer = new System.Windows.Forms.TabPage();
            this.tabPhoto = new System.Windows.Forms.TabPage();
            this.tabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabSurveyReport);
            this.tabs.Controls.Add(this.tabSer);
            this.tabs.Controls.Add(this.tabPhoto);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(520, 390);
            this.tabs.TabIndex = 2;
            // 
            // tabSurveyReport
            // 
            this.tabSurveyReport.Location = new System.Drawing.Point(4, 22);
            this.tabSurveyReport.Name = "tabSurveyReport";
            this.tabSurveyReport.Padding = new System.Windows.Forms.Padding(3);
            this.tabSurveyReport.Size = new System.Drawing.Size(512, 364);
            this.tabSurveyReport.TabIndex = 0;
            this.tabSurveyReport.Text = "Survey Report";
            this.tabSurveyReport.UseVisualStyleBackColor = true;
            // 
            // tabSer
            // 
            this.tabSer.Location = new System.Drawing.Point(4, 22);
            this.tabSer.Name = "tabSer";
            this.tabSer.Padding = new System.Windows.Forms.Padding(3);
            this.tabSer.Size = new System.Drawing.Size(528, 383);
            this.tabSer.TabIndex = 1;
            this.tabSer.Text = "SER";
            this.tabSer.UseVisualStyleBackColor = true;
            // 
            // tabPhoto
            // 
            this.tabPhoto.Location = new System.Drawing.Point(4, 22);
            this.tabPhoto.Name = "tabPhoto";
            this.tabPhoto.Size = new System.Drawing.Size(528, 383);
            this.tabPhoto.TabIndex = 2;
            this.tabPhoto.Text = "Photographs";
            this.tabPhoto.UseVisualStyleBackColor = true;
            // 
            // InspectionReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabs);
            this.Name = "InspectionReport";
            this.Size = new System.Drawing.Size(520, 390);
            this.tabs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabSurveyReport;
        private System.Windows.Forms.TabPage tabSer;
        private System.Windows.Forms.TabPage tabPhoto;
    }
}
