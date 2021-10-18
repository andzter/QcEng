
namespace QC.Forms.UserControls
{
    partial class PlansDetailsTab
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
            this.tabCAD = new System.Windows.Forms.TabPage();
            this.tabPDF = new System.Windows.Forms.TabPage();
            this.tabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabCAD);
            this.tabs.Controls.Add(this.tabPDF);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(540, 306);
            this.tabs.TabIndex = 3;
            // 
            // tabCAD
            // 
            this.tabCAD.Location = new System.Drawing.Point(4, 22);
            this.tabCAD.Name = "tabCAD";
            this.tabCAD.Padding = new System.Windows.Forms.Padding(3);
            this.tabCAD.Size = new System.Drawing.Size(532, 280);
            this.tabCAD.TabIndex = 0;
            this.tabCAD.Text = "CAD File";
            this.tabCAD.UseVisualStyleBackColor = true;
            // 
            // tabPDF
            // 
            this.tabPDF.Location = new System.Drawing.Point(4, 22);
            this.tabPDF.Name = "tabPDF";
            this.tabPDF.Padding = new System.Windows.Forms.Padding(3);
            this.tabPDF.Size = new System.Drawing.Size(532, 280);
            this.tabPDF.TabIndex = 1;
            this.tabPDF.Text = "PDF File";
            this.tabPDF.UseVisualStyleBackColor = true;
            // 
            // PlansDetailsTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabs);
            this.Name = "PlansDetailsTab";
            this.Size = new System.Drawing.Size(540, 306);
            this.tabs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabCAD;
        private System.Windows.Forms.TabPage tabPDF;
    }
}
