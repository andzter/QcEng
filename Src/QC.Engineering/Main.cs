using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QC.Engineering
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            hideSubMenu();
        }

        private void hideSubMenu()
        {
            panelAdministration.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdministration_Click(object sender, EventArgs e)
        {
            showSubMenu(panelAdministration);
        }

        #region AdministrationSubMenu
        private void btnDupa_Click(object sender, EventArgs e)
        {
            openChildForm(new QC.Forms.List.DupaHeader() { Title = "DUPA" });
            hideSubMenu();
        }

        //private void btnUsers_Click(object sender, EventArgs e)
        //{
        //    //openChildForm(new QC.Forms.List.Users() { Title = "Users" });
        //    //hideSubMenu();
        //}

        //private void btnAuthorization_Click(object sender, EventArgs e)
        //{
        //    //..
        //    //your codes
        //    //..
        //    hideSubMenu();
        //}
        //private void btnAuditTrail_Click(object sender, EventArgs e)
        //{
        //    //..
        //    //your codes
        //    //..
        //    hideSubMenu();
        //}
        //private void btnConfiguration_Click(object sender, EventArgs e)
        //{
        //    //..
        //    //your codes
        //    //..
        //    hideSubMenu();
        //}

        #endregion

        private void btnCommunication_Click(object sender, EventArgs e)
        {
            openChildForm(new QC.Forms.List.Communication() {Title = "Communication" });
            hideSubMenu();
        }

        private void btnMyTask_Click(object sender, EventArgs e)
        {
            openChildForm(new QC.Forms.List.MyList() { Title = "My Task", ShowAdd = false });
            hideSubMenu();
        }

        private void btnInspection_Click(object sender, EventArgs e)
        {
            openChildForm(new QC.Forms.List.Inspection() { Title = "Survey/Inspection", ShowAdd = false });
            hideSubMenu();
        }

        private void btnDesign_Click(object sender, EventArgs e)
        {
            openChildForm(new QC.Forms.List.Design() { Title = "Design", ShowAdd = false });
            hideSubMenu();
        }

        private void btnDEDFolders_Click(object sender, EventArgs e)
        {
            openChildForm(new QC.Forms.List.Folders() { Title = "DED Folders", ShowAdd = false });
            hideSubMenu();
        }

        private void panelSideMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMaterialCost_Click(object sender, EventArgs e)
        {
            openChildForm(new QC.Forms.List.MaterialCost() { Title = "Material Cost" });
            hideSubMenu();
        }

        private void btnLaborCost_Click(object sender, EventArgs e)
        {
            openChildForm(new QC.Forms.List.LaborCost() { Title = "Labor Cost" });
            hideSubMenu();
        }

        private void btnEquipmentCost_Click(object sender, EventArgs e)
        {
            openChildForm(new QC.Forms.List.EquipmetCost() { Title = "Equipment Cost" });
            hideSubMenu();
        }
    }
}
