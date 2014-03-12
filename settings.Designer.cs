/*
 * Created by SharpDevelop.
 * User: Niko
 * Date: 05.02.2014
 * Time: 20:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ModSync
{
	partial class settings
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.bt_ok = new System.Windows.Forms.Button();
			this.tc_settings = new System.Windows.Forms.TabControl();
			this.tp_armasettings = new System.Windows.Forms.TabPage();
			this.tb_otherstartup = new System.Windows.Forms.TextBox();
			this.la_other = new System.Windows.Forms.Label();
			this.la_ipport = new System.Windows.Forms.Label();
			this.la_password = new System.Windows.Forms.Label();
			this.tb_password = new System.Windows.Forms.TextBox();
			this.tb_autojoinserver = new System.Windows.Forms.TextBox();
			this.la_autojoinserver = new System.Windows.Forms.Label();
			this.tb_modlaunch = new System.Windows.Forms.TextBox();
			this.la_mods = new System.Windows.Forms.Label();
			this.chb_worldempty = new System.Windows.Forms.CheckBox();
			this.chb_nosplash = new System.Windows.Forms.CheckBox();
			this.bt_selecta3path = new System.Windows.Forms.Button();
			this.la_armapath = new System.Windows.Forms.Label();
			this.tb_armapath = new System.Windows.Forms.TextBox();
			this.tp_sync = new System.Windows.Forms.TabPage();
			this.chb_checkforupdates = new System.Windows.Forms.CheckBox();
			this.tb_svnserver = new System.Windows.Forms.TextBox();
			this.la_syncserver = new System.Windows.Forms.Label();
			this.bt_abort = new System.Windows.Forms.Button();
			this.tb_mp_svnserver = new System.Windows.Forms.TextBox();
			this.la_syncserver_mp = new System.Windows.Forms.Label();
			this.tc_settings.SuspendLayout();
			this.tp_armasettings.SuspendLayout();
			this.tp_sync.SuspendLayout();
			this.SuspendLayout();
			// 
			// bt_ok
			// 
			this.bt_ok.Location = new System.Drawing.Point(12, 261);
			this.bt_ok.Name = "bt_ok";
			this.bt_ok.Size = new System.Drawing.Size(75, 23);
			this.bt_ok.TabIndex = 3;
			this.bt_ok.Text = "Ok";
			this.bt_ok.UseVisualStyleBackColor = true;
			this.bt_ok.Click += new System.EventHandler(this.Bt_okClick);
			// 
			// tc_settings
			// 
			this.tc_settings.Controls.Add(this.tp_armasettings);
			this.tc_settings.Controls.Add(this.tp_sync);
			this.tc_settings.Location = new System.Drawing.Point(13, 12);
			this.tc_settings.Name = "tc_settings";
			this.tc_settings.SelectedIndex = 0;
			this.tc_settings.Size = new System.Drawing.Size(397, 243);
			this.tc_settings.TabIndex = 4;
			// 
			// tp_armasettings
			// 
			this.tp_armasettings.Controls.Add(this.tb_otherstartup);
			this.tp_armasettings.Controls.Add(this.la_other);
			this.tp_armasettings.Controls.Add(this.la_ipport);
			this.tp_armasettings.Controls.Add(this.la_password);
			this.tp_armasettings.Controls.Add(this.tb_password);
			this.tp_armasettings.Controls.Add(this.tb_autojoinserver);
			this.tp_armasettings.Controls.Add(this.la_autojoinserver);
			this.tp_armasettings.Controls.Add(this.tb_modlaunch);
			this.tp_armasettings.Controls.Add(this.la_mods);
			this.tp_armasettings.Controls.Add(this.chb_worldempty);
			this.tp_armasettings.Controls.Add(this.chb_nosplash);
			this.tp_armasettings.Controls.Add(this.bt_selecta3path);
			this.tp_armasettings.Controls.Add(this.la_armapath);
			this.tp_armasettings.Controls.Add(this.tb_armapath);
			this.tp_armasettings.Location = new System.Drawing.Point(4, 22);
			this.tp_armasettings.Name = "tp_armasettings";
			this.tp_armasettings.Padding = new System.Windows.Forms.Padding(3);
			this.tp_armasettings.Size = new System.Drawing.Size(389, 217);
			this.tp_armasettings.TabIndex = 0;
			this.tp_armasettings.Text = "Arma 3 Einstellung";
			this.tp_armasettings.UseVisualStyleBackColor = true;
			// 
			// tb_otherstartup
			// 
			this.tb_otherstartup.Location = new System.Drawing.Point(9, 159);
			this.tb_otherstartup.Name = "tb_otherstartup";
			this.tb_otherstartup.Size = new System.Drawing.Size(374, 20);
			this.tb_otherstartup.TabIndex = 16;
			// 
			// la_other
			// 
			this.la_other.AutoSize = true;
			this.la_other.Location = new System.Drawing.Point(6, 143);
			this.la_other.Name = "la_other";
			this.la_other.Size = new System.Drawing.Size(136, 13);
			this.la_other.TabIndex = 15;
			this.la_other.Text = "Sonstige Startup-Parameter";
			// 
			// la_ipport
			// 
			this.la_ipport.AutoSize = true;
			this.la_ipport.Location = new System.Drawing.Point(6, 113);
			this.la_ipport.Name = "la_ipport";
			this.la_ipport.Size = new System.Drawing.Size(39, 13);
			this.la_ipport.TabIndex = 14;
			this.la_ipport.Text = "IP:Port";
			// 
			// la_password
			// 
			this.la_password.AutoSize = true;
			this.la_password.Location = new System.Drawing.Point(227, 113);
			this.la_password.Name = "la_password";
			this.la_password.Size = new System.Drawing.Size(50, 13);
			this.la_password.TabIndex = 13;
			this.la_password.Text = "Passwort";
			// 
			// tb_password
			// 
			this.tb_password.Location = new System.Drawing.Point(283, 110);
			this.tb_password.Name = "tb_password";
			this.tb_password.Size = new System.Drawing.Size(100, 20);
			this.tb_password.TabIndex = 12;
			// 
			// tb_autojoinserver
			// 
			this.tb_autojoinserver.Location = new System.Drawing.Point(51, 110);
			this.tb_autojoinserver.Name = "tb_autojoinserver";
			this.tb_autojoinserver.Size = new System.Drawing.Size(170, 20);
			this.tb_autojoinserver.TabIndex = 11;
			// 
			// la_autojoinserver
			// 
			this.la_autojoinserver.AutoSize = true;
			this.la_autojoinserver.Location = new System.Drawing.Point(5, 90);
			this.la_autojoinserver.Name = "la_autojoinserver";
			this.la_autojoinserver.Size = new System.Drawing.Size(166, 13);
			this.la_autojoinserver.TabIndex = 10;
			this.la_autojoinserver.Text = "Server zum automatischem Beitritt";
			// 
			// tb_modlaunch
			// 
			this.tb_modlaunch.Location = new System.Drawing.Point(9, 63);
			this.tb_modlaunch.Name = "tb_modlaunch";
			this.tb_modlaunch.Size = new System.Drawing.Size(374, 20);
			this.tb_modlaunch.TabIndex = 9;
			// 
			// la_mods
			// 
			this.la_mods.AutoSize = true;
			this.la_mods.Location = new System.Drawing.Point(6, 47);
			this.la_mods.Name = "la_mods";
			this.la_mods.Size = new System.Drawing.Size(33, 13);
			this.la_mods.TabIndex = 8;
			this.la_mods.Text = "Mods";
			// 
			// chb_worldempty
			// 
			this.chb_worldempty.AutoSize = true;
			this.chb_worldempty.Location = new System.Drawing.Point(84, 194);
			this.chb_worldempty.Name = "chb_worldempty";
			this.chb_worldempty.Size = new System.Drawing.Size(88, 17);
			this.chb_worldempty.TabIndex = 7;
			this.chb_worldempty.Text = "-world=empty";
			this.chb_worldempty.UseVisualStyleBackColor = true;
			// 
			// chb_nosplash
			// 
			this.chb_nosplash.AutoSize = true;
			this.chb_nosplash.Location = new System.Drawing.Point(7, 194);
			this.chb_nosplash.Name = "chb_nosplash";
			this.chb_nosplash.Size = new System.Drawing.Size(71, 17);
			this.chb_nosplash.TabIndex = 6;
			this.chb_nosplash.Text = "-nosplash";
			this.chb_nosplash.UseVisualStyleBackColor = true;
			// 
			// bt_selecta3path
			// 
			this.bt_selecta3path.Location = new System.Drawing.Point(308, 22);
			this.bt_selecta3path.Name = "bt_selecta3path";
			this.bt_selecta3path.Size = new System.Drawing.Size(75, 23);
			this.bt_selecta3path.TabIndex = 5;
			this.bt_selecta3path.Text = "Auswählen...";
			this.bt_selecta3path.UseVisualStyleBackColor = true;
			this.bt_selecta3path.Click += new System.EventHandler(this.bt_selecta3path_Click);
			// 
			// la_armapath
			// 
			this.la_armapath.Location = new System.Drawing.Point(6, 3);
			this.la_armapath.Name = "la_armapath";
			this.la_armapath.Size = new System.Drawing.Size(72, 20);
			this.la_armapath.TabIndex = 4;
			this.la_armapath.Text = "Arma 3 Pfad";
			// 
			// tb_armapath
			// 
			this.tb_armapath.Location = new System.Drawing.Point(9, 24);
			this.tb_armapath.Name = "tb_armapath";
			this.tb_armapath.ReadOnly = true;
			this.tb_armapath.Size = new System.Drawing.Size(293, 20);
			this.tb_armapath.TabIndex = 3;
			// 
			// tp_sync
			// 
			this.tp_sync.Controls.Add(this.tb_mp_svnserver);
			this.tp_sync.Controls.Add(this.la_syncserver_mp);
			this.tp_sync.Controls.Add(this.chb_checkforupdates);
			this.tp_sync.Controls.Add(this.tb_svnserver);
			this.tp_sync.Controls.Add(this.la_syncserver);
			this.tp_sync.Location = new System.Drawing.Point(4, 22);
			this.tp_sync.Name = "tp_sync";
			this.tp_sync.Padding = new System.Windows.Forms.Padding(3);
			this.tp_sync.Size = new System.Drawing.Size(389, 217);
			this.tp_sync.TabIndex = 1;
			this.tp_sync.Text = "Sync Einstellungen";
			this.tp_sync.UseVisualStyleBackColor = true;
			// 
			// chb_checkforupdates
			// 
			this.chb_checkforupdates.AutoSize = true;
			this.chb_checkforupdates.Location = new System.Drawing.Point(10, 154);
			this.chb_checkforupdates.Name = "chb_checkforupdates";
			this.chb_checkforupdates.Size = new System.Drawing.Size(199, 17);
			this.chb_checkforupdates.TabIndex = 2;
			this.chb_checkforupdates.Text = "Automatisch auf Updates überprüfen";
			this.chb_checkforupdates.UseVisualStyleBackColor = true;
			// 
			// tb_svnserver
			// 
			this.tb_svnserver.Location = new System.Drawing.Point(10, 23);
			this.tb_svnserver.Name = "tb_svnserver";
			this.tb_svnserver.Size = new System.Drawing.Size(231, 20);
			this.tb_svnserver.TabIndex = 1;
			// 
			// la_syncserver
			// 
			this.la_syncserver.AutoSize = true;
			this.la_syncserver.Location = new System.Drawing.Point(7, 7);
			this.la_syncserver.Name = "la_syncserver";
			this.la_syncserver.Size = new System.Drawing.Size(111, 13);
			this.la_syncserver.TabIndex = 0;
			this.la_syncserver.Text = "SVN Server Modpack";
			// 
			// bt_abort
			// 
			this.bt_abort.Location = new System.Drawing.Point(335, 261);
			this.bt_abort.Name = "bt_abort";
			this.bt_abort.Size = new System.Drawing.Size(75, 23);
			this.bt_abort.TabIndex = 5;
			this.bt_abort.Text = "Abbrechen";
			this.bt_abort.UseVisualStyleBackColor = true;
			this.bt_abort.Click += new System.EventHandler(this.bt_abort_Click);
			// 
			// tb_mp_svnserver
			// 
			this.tb_mp_svnserver.Location = new System.Drawing.Point(10, 74);
			this.tb_mp_svnserver.Name = "tb_mp_svnserver";
			this.tb_mp_svnserver.Size = new System.Drawing.Size(231, 20);
			this.tb_mp_svnserver.TabIndex = 4;
			// 
			// la_syncserver_mp
			// 
			this.la_syncserver_mp.AutoSize = true;
			this.la_syncserver_mp.Location = new System.Drawing.Point(10, 58);
			this.la_syncserver_mp.Name = "la_syncserver_mp";
			this.la_syncserver_mp.Size = new System.Drawing.Size(111, 13);
			this.la_syncserver_mp.TabIndex = 3;
			this.la_syncserver_mp.Text = "SVN Server Mappack";
			// 
			// settings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(422, 296);
			this.Controls.Add(this.bt_abort);
			this.Controls.Add(this.tc_settings);
			this.Controls.Add(this.bt_ok);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "settings";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Einstellungen";
			this.tc_settings.ResumeLayout(false);
			this.tp_armasettings.ResumeLayout(false);
			this.tp_armasettings.PerformLayout();
			this.tp_sync.ResumeLayout(false);
			this.tp_sync.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label la_syncserver_mp;
		private System.Windows.Forms.TextBox tb_mp_svnserver;
        private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.TabControl tc_settings;
        private System.Windows.Forms.TabPage tp_armasettings;
        private System.Windows.Forms.TabPage tp_sync;
        private System.Windows.Forms.Button bt_selecta3path;
        private System.Windows.Forms.Label la_armapath;
        private System.Windows.Forms.TextBox tb_armapath;
        private System.Windows.Forms.CheckBox chb_worldempty;
        private System.Windows.Forms.CheckBox chb_nosplash;
        private System.Windows.Forms.TextBox tb_modlaunch;
        private System.Windows.Forms.Label la_mods;
        private System.Windows.Forms.CheckBox chb_checkforupdates;
        private System.Windows.Forms.TextBox tb_svnserver;
        private System.Windows.Forms.Label la_syncserver;
        private System.Windows.Forms.Button bt_abort;
        private System.Windows.Forms.TextBox tb_autojoinserver;
        private System.Windows.Forms.Label la_autojoinserver;
        private System.Windows.Forms.Label la_ipport;
        private System.Windows.Forms.Label la_password;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.TextBox tb_otherstartup;
        private System.Windows.Forms.Label la_other;
	}
}
