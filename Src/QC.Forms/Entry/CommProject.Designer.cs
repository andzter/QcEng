
namespace QC.Forms.Entry
{
    partial class CommProject
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.lbldesc = new System.Windows.Forms.Label();
            this.txtproject = new System.Windows.Forms.TextBox();
            this.lblcd = new System.Windows.Forms.Label();
            this.txtrefno = new System.Windows.Forms.TextBox();
            this.txtremarks = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radDocdate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtdocsource = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboRoute = new System.Windows.Forms.ComboBox();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRem = new System.Windows.Forms.TextBox();
            this.radGrid = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radDocdate)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGrid.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // lbldesc
            // 
            this.lbldesc.AutoSize = true;
            this.lbldesc.Location = new System.Drawing.Point(15, 197);
            this.lbldesc.Name = "lbldesc";
            this.lbldesc.Size = new System.Drawing.Size(62, 13);
            this.lbldesc.TabIndex = 61;
            this.lbldesc.Text = "Comments :";
            // 
            // txtproject
            // 
            this.txtproject.Location = new System.Drawing.Point(97, 42);
            this.txtproject.MaxLength = 100;
            this.txtproject.Name = "txtproject";
            this.txtproject.Size = new System.Drawing.Size(507, 20);
            this.txtproject.TabIndex = 62;
            // 
            // lblcd
            // 
            this.lblcd.AutoSize = true;
            this.lblcd.Location = new System.Drawing.Point(15, 20);
            this.lblcd.Name = "lblcd";
            this.lblcd.Size = new System.Drawing.Size(80, 13);
            this.lblcd.TabIndex = 59;
            this.lblcd.Text = "Reference No :";
            // 
            // txtrefno
            // 
            this.txtrefno.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtrefno.Location = new System.Drawing.Point(97, 16);
            this.txtrefno.MaxLength = 50;
            this.txtrefno.Name = "txtrefno";
            this.txtrefno.Size = new System.Drawing.Size(255, 20);
            this.txtrefno.TabIndex = 60;
            // 
            // txtremarks
            // 
            this.txtremarks.Location = new System.Drawing.Point(18, 213);
            this.txtremarks.MaxLength = 500;
            this.txtremarks.Multiline = true;
            this.txtremarks.Name = "txtremarks";
            this.txtremarks.Size = new System.Drawing.Size(712, 71);
            this.txtremarks.TabIndex = 85;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(375, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 86;
            this.label1.Text = "Doc Date :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 87;
            this.label2.Text = "Subject :";
            // 
            // radDocdate
            // 
            this.radDocdate.Location = new System.Drawing.Point(440, 16);
            this.radDocdate.Name = "radDocdate";
            this.radDocdate.Size = new System.Drawing.Size(164, 20);
            this.radDocdate.TabIndex = 88;
            this.radDocdate.TabStop = false;
            this.radDocdate.Text = "Tuesday, May 25, 2021";
            this.radDocdate.Value = new System.DateTime(2021, 5, 25, 16, 39, 39, 318);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 89;
            this.label3.Text = "Doc Source :";
            // 
            // txtdocsource
            // 
            this.txtdocsource.Location = new System.Drawing.Point(97, 67);
            this.txtdocsource.MaxLength = 100;
            this.txtdocsource.Name = "txtdocsource";
            this.txtdocsource.Size = new System.Drawing.Size(507, 20);
            this.txtdocsource.TabIndex = 90;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 293);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 91;
            this.label4.Text = "Route To :";
            // 
            // cboRoute
            // 
            this.cboRoute.FormattingEnabled = true;
            this.cboRoute.Location = new System.Drawing.Point(97, 290);
            this.cboRoute.Name = "cboRoute";
            this.cboRoute.Size = new System.Drawing.Size(423, 21);
            this.cboRoute.TabIndex = 92;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.groupBox1);
            this.pnlTop.Controls.Add(this.txtrefno);
            this.pnlTop.Controls.Add(this.cboRoute);
            this.pnlTop.Controls.Add(this.lblcd);
            this.pnlTop.Controls.Add(this.label4);
            this.pnlTop.Controls.Add(this.txtproject);
            this.pnlTop.Controls.Add(this.txtdocsource);
            this.pnlTop.Controls.Add(this.lbldesc);
            this.pnlTop.Controls.Add(this.label3);
            this.pnlTop.Controls.Add(this.txtremarks);
            this.pnlTop.Controls.Add(this.radDocdate);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(742, 323);
            this.pnlTop.TabIndex = 93;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRem);
            this.groupBox1.Location = new System.Drawing.Point(18, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(721, 99);
            this.groupBox1.TabIndex = 93;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Remarks";
            // 
            // txtRem
            // 
            this.txtRem.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtRem.Location = new System.Drawing.Point(5, 19);
            this.txtRem.MaxLength = 500;
            this.txtRem.Multiline = true;
            this.txtRem.Name = "txtRem";
            this.txtRem.Size = new System.Drawing.Size(707, 71);
            this.txtRem.TabIndex = 86;
            // 
            // radGrid
            // 
            this.radGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGrid.Location = new System.Drawing.Point(0, 323);
            // 
            // 
            // 
            this.radGrid.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGrid.Name = "radGrid";
            this.radGrid.Size = new System.Drawing.Size(742, 241);
            this.radGrid.TabIndex = 94;
            // 
            // CommProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 614);
            this.Controls.Add(this.radGrid);
            this.Controls.Add(this.pnlTop);
            this.Name = "CommProject";
            this.Text = "New Communication";
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.radGrid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.radDocdate)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGrid.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbldesc;
        private System.Windows.Forms.TextBox txtproject;
        private System.Windows.Forms.Label lblcd;
        private System.Windows.Forms.TextBox txtrefno;
        private System.Windows.Forms.TextBox txtremarks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadDateTimePicker radDocdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtdocsource;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboRoute;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtRem;
        private Telerik.WinControls.UI.RadGridView radGrid;
    }
}