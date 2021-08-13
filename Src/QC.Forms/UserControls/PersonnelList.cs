﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QC.Forms.UserControls
{
    public partial class PersonnelList : UserControl
    {
        public PersonnelList()
        {
            InitializeComponent();
        }

        protected virtual DataTable GetData()
        {
            //return null;
            return new QC.Repository.Project().GetDataTable("select Manpower, UnitNo[No.Of Unit] from [ProjectManpower]");


        }

        public PersonnelList(string projectId)
        {
            InitializeComponent();
            radGrid.DataSource = GetData();
        }
    }
}