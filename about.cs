using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModSync
{
    public partial class about : Form
    {
        public about()
        {
            InitializeComponent();
            la_version.Text = Properties.Settings.Default.Version;
        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
