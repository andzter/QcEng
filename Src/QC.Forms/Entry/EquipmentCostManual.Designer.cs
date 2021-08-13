namespace QC.Forms.Entry
{
    partial class EquipmentCostManual
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.txtcost = new System.Windows.Forms.TextBox();
            this.txthourlyrate = new System.Windows.Forms.TextBox();
            this.txtnoofhours = new System.Windows.Forms.TextBox();
            this.txtnoofunits = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbodescription = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtmodel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtflywheelhp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtoutput = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(277, 237);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 28);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(168, 237);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(88, 28);
            this.btnsave.TabIndex = 22;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // txtcost
            // 
            this.txtcost.Enabled = false;
            this.txtcost.Location = new System.Drawing.Point(102, 185);
            this.txtcost.Name = "txtcost";
            this.txtcost.Size = new System.Drawing.Size(100, 20);
            this.txtcost.TabIndex = 21;
            this.txtcost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txthourlyrate
            // 
            this.txthourlyrate.Enabled = false;
            this.txthourlyrate.Location = new System.Drawing.Point(102, 160);
            this.txthourlyrate.Name = "txthourlyrate";
            this.txthourlyrate.Size = new System.Drawing.Size(100, 20);
            this.txthourlyrate.TabIndex = 20;
            this.txthourlyrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtnoofhours
            // 
            this.txtnoofhours.Location = new System.Drawing.Point(102, 135);
            this.txtnoofhours.Name = "txtnoofhours";
            this.txtnoofhours.Size = new System.Drawing.Size(100, 20);
            this.txtnoofhours.TabIndex = 19;
            this.txtnoofhours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtnoofunits
            // 
            this.txtnoofunits.Location = new System.Drawing.Point(102, 110);
            this.txtnoofunits.Name = "txtnoofunits";
            this.txtnoofunits.Size = new System.Drawing.Size(100, 20);
            this.txtnoofunits.TabIndex = 18;
            this.txtnoofunits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Cost :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Hourly Rate :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "No. Of Hours :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "No. Of Units :";
            // 
            // cbodescription
            // 
            this.cbodescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbodescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbodescription.DropDownHeight = 100;
            this.cbodescription.FormattingEnabled = true;
            this.cbodescription.IntegralHeight = false;
            this.cbodescription.Location = new System.Drawing.Point(102, 12);
            this.cbodescription.Name = "cbodescription";
            this.cbodescription.Size = new System.Drawing.Size(394, 21);
            this.cbodescription.TabIndex = 13;
            this.cbodescription.SelectedIndexChanged += new System.EventHandler(this.cbodescription_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Description :";
            // 
            // txtmodel
            // 
            this.txtmodel.Enabled = false;
            this.txtmodel.Location = new System.Drawing.Point(102, 36);
            this.txtmodel.Name = "txtmodel";
            this.txtmodel.Size = new System.Drawing.Size(394, 20);
            this.txtmodel.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Model :";
            // 
            // txtflywheelhp
            // 
            this.txtflywheelhp.Enabled = false;
            this.txtflywheelhp.Location = new System.Drawing.Point(102, 60);
            this.txtflywheelhp.Name = "txtflywheelhp";
            this.txtflywheelhp.Size = new System.Drawing.Size(394, 20);
            this.txtflywheelhp.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Flywheel HP :";
            // 
            // txtoutput
            // 
            this.txtoutput.Enabled = false;
            this.txtoutput.Location = new System.Drawing.Point(102, 85);
            this.txtoutput.Name = "txtoutput";
            this.txtoutput.Size = new System.Drawing.Size(394, 20);
            this.txtoutput.TabIndex = 29;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(42, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Output :";
            // 
            // EquipmentCostManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 276);
            this.Controls.Add(this.txtoutput);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtflywheelhp);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtmodel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.txtcost);
            this.Controls.Add(this.txthourlyrate);
            this.Controls.Add(this.txtnoofhours);
            this.Controls.Add(this.txtnoofunits);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbodescription);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EquipmentCostManual";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EquipmentCostManual";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.TextBox txtcost;
        private System.Windows.Forms.TextBox txthourlyrate;
        private System.Windows.Forms.TextBox txtnoofhours;
        private System.Windows.Forms.TextBox txtnoofunits;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbodescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtmodel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtflywheelhp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtoutput;
        private System.Windows.Forms.Label label8;
    }
}