
namespace QC.Forms
{
    partial class BaseEntryForm
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
            this.grpButton = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.closeButton = new Telerik.WinControls.UI.RadButton();
            this.cancelButton = new Telerik.WinControls.UI.RadButton();
            this.saveButton = new Telerik.WinControls.UI.RadButton();
            this.grpButton.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancelButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveButton)).BeginInit();
            this.SuspendLayout();
            // 
            // grpButton
            // 
            this.grpButton.Controls.Add(this.panel2);
            this.grpButton.Controls.Add(this.saveButton);
            this.grpButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpButton.Location = new System.Drawing.Point(0, 529);
            this.grpButton.Name = "grpButton";
            this.grpButton.Size = new System.Drawing.Size(596, 50);
            this.grpButton.TabIndex = 0;
            this.grpButton.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.closeButton);
            this.panel2.Controls.Add(this.cancelButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(384, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(209, 31);
            this.panel2.TabIndex = 2;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.closeButton.Location = new System.Drawing.Point(102, 3);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(93, 24);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "Close";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cancelButton.Location = new System.Drawing.Point(3, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(93, 24);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.cancel_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.saveButton.Location = new System.Drawing.Point(12, 19);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(93, 24);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // BaseEntryForm
            // 
            this.ClientSize = new System.Drawing.Size(596, 579);
            this.Controls.Add(this.grpButton);
            this.Name = "BaseEntryForm";
            this.Text = ",";
            this.grpButton.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancelButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpTop;
        private Telerik.WinControls.UI.RadButton cancelButton;
        private Telerik.WinControls.UI.RadButton saveButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grpButton;
        private System.Windows.Forms.Panel panel2;
        private Telerik.WinControls.UI.RadButton closeButton;
    }
}