
namespace QC.Forms.UserControls
{
    partial class CommProjects
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            this.grpButton = new System.Windows.Forms.GroupBox();
            this.addButton = new Telerik.WinControls.UI.RadButton();
            this.refreshButton = new Telerik.WinControls.UI.RadButton();
            this.radGrid = new Telerik.WinControls.UI.RadGridView();
            this.grpButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refreshButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGrid.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // grpButton
            // 
            this.grpButton.Controls.Add(this.refreshButton);
            this.grpButton.Controls.Add(this.addButton);
            this.grpButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpButton.Location = new System.Drawing.Point(0, 475);
            this.grpButton.Name = "grpButton";
            this.grpButton.Size = new System.Drawing.Size(569, 50);
            this.grpButton.TabIndex = 1;
            this.grpButton.TabStop = false;
            // 
            // addButton
            // 
            this.addButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.addButton.Location = new System.Drawing.Point(12, 19);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(93, 24);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.refreshButton.Location = new System.Drawing.Point(111, 19);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(93, 24);
            this.refreshButton.TabIndex = 2;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // radGrid
            // 
            this.radGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGrid.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.radGrid.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.radGrid.Name = "radGrid";
            this.radGrid.Size = new System.Drawing.Size(569, 475);
            this.radGrid.TabIndex = 4;
            // 
            // CommProjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radGrid);
            this.Controls.Add(this.grpButton);
            this.Name = "CommProjects";
            this.Size = new System.Drawing.Size(569, 525);
            this.grpButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.addButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refreshButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGrid.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpButton;
        private Telerik.WinControls.UI.RadButton addButton;
        private Telerik.WinControls.UI.RadButton refreshButton;
        private Telerik.WinControls.UI.RadGridView radGrid;
    }
}
