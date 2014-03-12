/*
 * Created by SharpDevelop.
 * User: Niko
 * Date: 05.02.2014
 * Time: 20:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ModSync
{
	/// <summary>
	/// Description of settings.
	/// </summary>
	public partial class settings : Form
	{
		public settings()
		{
            InitializeComponent();
            initSettings();
		}

        void initSettings()
        {
            if (Properties.Settings.Default.arma3path == "NONE")
            {
                string path = Environment.ExpandEnvironmentVariables("%programfiles(x86)%");
                path += "\\Steam\\SteamApps\\common\\Arma 3\\";
                Properties.Settings.Default.arma3path = path;
            }
            tb_armapath.Text = Properties.Settings.Default.arma3path;
            tb_modlaunch.Text = Properties.Settings.Default.mods;
            chb_nosplash.Checked = Properties.Settings.Default.nosplash;
            chb_worldempty.Checked = Properties.Settings.Default.worldempty;
            tb_autojoinserver.Text = Properties.Settings.Default.autojoinserver;
            tb_password.Text = Properties.Settings.Default.password;
            tb_otherstartup.Text = Properties.Settings.Default.otherstartup;

            tb_svnserver.Text = Properties.Settings.Default.svnserver;
            tb_mp_svnserver.Text = Properties.Settings.Default.mp_svnserver;
            chb_checkforupdates.Checked = Properties.Settings.Default.checkforupdates;
        }

        void saveSettings()
        {
            Properties.Settings.Default.arma3path = tb_armapath.Text;
            Properties.Settings.Default.mods = tb_modlaunch.Text;
            Properties.Settings.Default.nosplash = chb_nosplash.Checked;
            Properties.Settings.Default.worldempty = chb_worldempty.Checked;

            Properties.Settings.Default.svnserver = tb_svnserver.Text;
            Properties.Settings.Default.checkforupdates = chb_checkforupdates.Checked;
            Properties.Settings.Default.autojoinserver = tb_autojoinserver.Text;
            Properties.Settings.Default.password = tb_password.Text;
            Properties.Settings.Default.otherstartup = tb_otherstartup.Text;
            Properties.Settings.Default.mp_svnserver = tb_mp_svnserver.Text;

            Properties.Settings.Default.Save();
        }
		
		void Bt_okClick(object sender, EventArgs e)
		{
            saveSettings();
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

        private void bt_selecta3path_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tb_armapath.Text = fbd.SelectedPath;
            }
        }

        private void bt_abort_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }
	}
}
