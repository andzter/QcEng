
namespace QC.Forms.UserControls
{
    partial class EstimatesTab
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabEstimates = new System.Windows.Forms.TabPage();
            this.tabSow = new System.Windows.Forms.TabPage();
            this.tabTakeOff = new System.Windows.Forms.TabPage();
            this.tabSched = new System.Windows.Forms.TabPage();
            this.tabEquipment = new System.Windows.Forms.TabPage();
            this.tabManpower = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabEstimates);
            this.tabControl1.Controls.Add(this.tabSow);
            this.tabControl1.Controls.Add(this.tabTakeOff);
            this.tabControl1.Controls.Add(this.tabSched);
            this.tabControl1.Controls.Add(this.tabEquipment);
            this.tabControl1.Controls.Add(this.tabManpower);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(667, 431);
            this.tabControl1.TabIndex = 0;
            // 
            // tabEstimates
            // 
            this.tabEstimates.Location = new System.Drawing.Point(4, 22);
            this.tabEstimates.Name = "tabEstimates";
            this.tabEstimates.Padding = new System.Windows.Forms.Padding(3);
            this.tabEstimates.Size = new System.Drawing.Size(659, 405);
            this.tabEstimates.TabIndex = 0;
            this.tabEstimates.Text = "Agency Estimates";
            this.tabEstimates.UseVisualStyleBackColor = true;
            // 
            // tabSow
            // 
            this.tabSow.Location = new System.Drawing.Point(4, 22);
            this.tabSow.Name = "tabSow";
            this.tabSow.Padding = new System.Windows.Forms.Padding(3);
            this.tabSow.Size = new System.Drawing.Size(659, 405);
            this.tabSow.TabIndex = 1;
            this.tabSow.Text = "SOW/POW/Summary";
            this.tabSow.UseVisualStyleBackColor = true;
            // 
            // tabTakeOff
            // 
            this.tabTakeOff.Location = new System.Drawing.Point(4, 22);
            this.tabTakeOff.Name = "tabTakeOff";
            this.tabTakeOff.Size = new System.Drawing.Size(659, 405);
            this.tabTakeOff.TabIndex = 2;
            this.tabTakeOff.Text = "Take-Off BOM/BOQ ";
            this.tabTakeOff.UseVisualStyleBackColor = true;
            // 
            // tabSched
            // 
            this.tabSched.Location = new System.Drawing.Point(4, 22);
            this.tabSched.Name = "tabSched";
            this.tabSched.Size = new System.Drawing.Size(659, 405);
            this.tabSched.TabIndex = 3;
            this.tabSched.Text = "Project Schedule";
            this.tabSched.UseVisualStyleBackColor = true;
            // 
            // tabEquipment
            // 
            this.tabEquipment.Location = new System.Drawing.Point(4, 22);
            this.tabEquipment.Name = "tabEquipment";
            this.tabEquipment.Size = new System.Drawing.Size(659, 405);
            this.tabEquipment.TabIndex = 4;
            this.tabEquipment.Text = "List of Equipment";
            this.tabEquipment.UseVisualStyleBackColor = true;
            // 
            // tabManpower
            // 
            this.tabManpower.Location = new System.Drawing.Point(4, 22);
            this.tabManpower.Name = "tabManpower";
            this.tabManpower.Size = new System.Drawing.Size(659, 405);
            this.tabManpower.TabIndex = 5;
            this.tabManpower.Text = "List of Manpower";
            this.tabManpower.UseVisualStyleBackColor = true;
            // 
            // EstimatesTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "EstimatesTab";
            this.Size = new System.Drawing.Size(667, 431);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabEstimates;
        private System.Windows.Forms.TabPage tabSow;
        private System.Windows.Forms.TabPage tabTakeOff;
        private System.Windows.Forms.TabPage tabSched;
        private System.Windows.Forms.TabPage tabEquipment;
        private System.Windows.Forms.TabPage tabManpower;
    }
}
