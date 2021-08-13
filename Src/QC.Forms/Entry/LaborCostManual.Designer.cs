namespace QC.Forms.Entry
{
    partial class LaborCostManual
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbodescription = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtnoofperson = new System.Windows.Forms.TextBox();
            this.txtnoofhours = new System.Windows.Forms.TextBox();
            this.txthourlyrate = new System.Windows.Forms.TextBox();
            this.txtamount = new System.Windows.Forms.TextBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Description :";
            // 
            // cbodescription
            // 
            this.cbodescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbodescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbodescription.DropDownHeight = 100;
            this.cbodescription.FormattingEnabled = true;
            this.cbodescription.IntegralHeight = false;
            this.cbodescription.Location = new System.Drawing.Point(106, 19);
            this.cbodescription.Name = "cbodescription";
            this.cbodescription.Size = new System.Drawing.Size(394, 21);
            this.cbodescription.TabIndex = 1;
            this.cbodescription.SelectedIndexChanged += new System.EventHandler(this.cbodescription_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "No. Of Person :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "No. Of Hours :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Hourly Rate :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Amount :";
            // 
            // txtnoofperson
            // 
            this.txtnoofperson.Location = new System.Drawing.Point(106, 48);
            this.txtnoofperson.Name = "txtnoofperson";
            this.txtnoofperson.Size = new System.Drawing.Size(100, 20);
            this.txtnoofperson.TabIndex = 6;
            this.txtnoofperson.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtnoofhours
            // 
            this.txtnoofhours.Location = new System.Drawing.Point(106, 80);
            this.txtnoofhours.Name = "txtnoofhours";
            this.txtnoofhours.Size = new System.Drawing.Size(100, 20);
            this.txtnoofhours.TabIndex = 7;
            this.txtnoofhours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txthourlyrate
            // 
            this.txthourlyrate.Enabled = false;
            this.txthourlyrate.Location = new System.Drawing.Point(106, 109);
            this.txthourlyrate.Name = "txthourlyrate";
            this.txthourlyrate.Size = new System.Drawing.Size(100, 20);
            this.txthourlyrate.TabIndex = 8;
            this.txthourlyrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtamount
            // 
            this.txtamount.Enabled = false;
            this.txtamount.Location = new System.Drawing.Point(106, 137);
            this.txtamount.Name = "txtamount";
            this.txtamount.Size = new System.Drawing.Size(100, 20);
            this.txtamount.TabIndex = 9;
            this.txtamount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(172, 182);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(88, 28);
            this.btnsave.TabIndex = 10;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(281, 182);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 28);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // LaborCostManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 222);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.txtamount);
            this.Controls.Add(this.txthourlyrate);
            this.Controls.Add(this.txtnoofhours);
            this.Controls.Add(this.txtnoofperson);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbodescription);
            this.Controls.Add(this.label1);
            this.Name = "LaborCostManual";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Labor Cost";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbodescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtnoofperson;
        private System.Windows.Forms.TextBox txtnoofhours;
        private System.Windows.Forms.TextBox txthourlyrate;
        private System.Windows.Forms.TextBox txtamount;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnClose;
    }
}