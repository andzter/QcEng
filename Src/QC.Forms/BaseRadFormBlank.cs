using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace QC.Forms
{
    public partial class BaseRadFormBlank : Telerik.WinControls.UI.RadForm
    {

        protected string _userid = Lib.Settings.GetSetting("userid");

        public delegate void UpdateEventHandler(object sender, EventArgs e);

        public event UpdateEventHandler UpdateHandler;

        public BaseRadFormBlank()
        {
            InitializeComponent();
        }
    }
}
