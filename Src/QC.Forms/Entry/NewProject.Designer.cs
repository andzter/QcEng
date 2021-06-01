
namespace QC.Forms.Entry
{
    partial class NewProject
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
            this.pnlTop = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.radDocdate)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbldesc
            // 
            this.lbldesc.AutoSize = true;
            this.lbldesc.Location = new System.Drawing.Point(15, 102);
            this.lbldesc.Name = "lbldesc";
            this.lbldesc.Size = new System.Drawing.Size(55, 13);
            this.lbldesc.TabIndex = 61;
            this.lbldesc.Text = "Remarks :";
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
            this.txtrefno.Location = new System.Drawing.Point(97, 16);
            this.txtrefno.MaxLength = 50;
            this.txtrefno.Name = "txtrefno";
            this.txtrefno.Size = new System.Drawing.Size(255, 20);
            this.txtrefno.TabIndex = 60;
            // 
            // txtremarks
            // 
            this.txtremarks.Location = new System.Drawing.Point(18, 118);
            this.txtremarks.MaxLength = 500;
            this.txtremarks.Multiline = true;
            this.txtremarks.Name = "txtremarks";
            this.txtremarks.Size = new System.Drawing.Size(581, 71);
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
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtrefno);
            this.pnlTop.Controls.Add(this.lblcd);
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
            this.pnlTop.Size = new System.Drawing.Size(635, 222);
            this.pnlTop.TabIndex = 93;
            // 
            // NewProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 275);
            this.Controls.Add(this.pnlTop);
            this.Name = "NewProject";
            this.Text = "New Communication";
            this.Controls.SetChildIndex(this.pnlTop, 0);
            ((System.ComponentModel.ISupportInitialize)(this.radDocdate)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
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
        private System.Windows.Forms.Panel pnlTop;
    }
}