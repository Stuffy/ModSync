/*
 * Created by SharpDevelop.
 * User: Niko
 * Date: 05.02.2014
 * Time: 16:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ModSync
{
	partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.bt_checkout = new System.Windows.Forms.Button();
            this.bt_settings = new System.Windows.Forms.Button();
            this.pb_dl = new System.Windows.Forms.ProgressBar();
            this.la_byte = new System.Windows.Forms.Label();
            this.bt_launcharma = new System.Windows.Forms.Button();
            this.bt_checkforupdates = new System.Windows.Forms.Button();
            this.ms_main = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einstellungenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.überToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einstelleungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.überToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.überToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.la_name = new System.Windows.Forms.Label();
            this.tb_link = new System.Windows.Forms.TextBox();
            this.pb_logo = new System.Windows.Forms.PictureBox();
            this.chb_autojoin = new System.Windows.Forms.CheckBox();
            this.bt_updatemp = new System.Windows.Forms.Button();
            this.bt_mp_checkforupdates = new System.Windows.Forms.Button();
            this.bt_test = new System.Windows.Forms.Button();
            this.tb_console = new System.Windows.Forms.TextBox();
            this.ms_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_checkout
            // 
            this.bt_checkout.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_checkout.Location = new System.Drawing.Point(11, 51);
            this.bt_checkout.Name = "bt_checkout";
            this.bt_checkout.Size = new System.Drawing.Size(211, 65);
            this.bt_checkout.TabIndex = 0;
            this.bt_checkout.Text = "Update Mod-Pack";
            this.bt_checkout.UseVisualStyleBackColor = true;
            this.bt_checkout.Click += new System.EventHandler(this.bt_checkout_Click);
            // 
            // bt_settings
            // 
            this.bt_settings.Location = new System.Drawing.Point(536, 122);
            this.bt_settings.Name = "bt_settings";
            this.bt_settings.Size = new System.Drawing.Size(105, 27);
            this.bt_settings.TabIndex = 2;
            this.bt_settings.Text = "&Einstellungen";
            this.bt_settings.UseVisualStyleBackColor = true;
            // 
            // pb_dl
            // 
            this.pb_dl.Location = new System.Drawing.Point(11, 429);
            this.pb_dl.MarqueeAnimationSpeed = 25;
            this.pb_dl.Name = "pb_dl";
            this.pb_dl.Size = new System.Drawing.Size(736, 37);
            this.pb_dl.Step = 1;
            this.pb_dl.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pb_dl.TabIndex = 9;
            // 
            // la_byte
            // 
            this.la_byte.AutoSize = true;
            this.la_byte.Location = new System.Drawing.Point(12, 413);
            this.la_byte.Name = "la_byte";
            this.la_byte.Size = new System.Drawing.Size(42, 13);
            this.la_byte.TabIndex = 11;
            this.la_byte.Text = "0 Bytes";
            // 
            // bt_launcharma
            // 
            this.bt_launcharma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_launcharma.Location = new System.Drawing.Point(536, 51);
            this.bt_launcharma.Name = "bt_launcharma";
            this.bt_launcharma.Size = new System.Drawing.Size(211, 65);
            this.bt_launcharma.TabIndex = 12;
            this.bt_launcharma.Text = "Starte Arma 3 mit dem Modpacket";
            this.bt_launcharma.UseVisualStyleBackColor = true;
            this.bt_launcharma.Click += new System.EventHandler(this.bt_launcharma_Click);
            // 
            // bt_checkforupdates
            // 
            this.bt_checkforupdates.Location = new System.Drawing.Point(12, 122);
            this.bt_checkforupdates.Name = "bt_checkforupdates";
            this.bt_checkforupdates.Size = new System.Drawing.Size(211, 27);
            this.bt_checkforupdates.TabIndex = 13;
            this.bt_checkforupdates.Text = "Auf Updates überprüfen";
            this.bt_checkforupdates.UseVisualStyleBackColor = true;
            this.bt_checkforupdates.Click += new System.EventHandler(this.bt_checkforupdates_Click);
            // 
            // ms_main
            // 
            this.ms_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem1,
            this.bearbeitenToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            this.ms_main.Location = new System.Drawing.Point(0, 0);
            this.ms_main.Name = "ms_main";
            this.ms_main.Size = new System.Drawing.Size(761, 24);
            this.ms_main.TabIndex = 16;
            this.ms_main.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem1
            // 
            this.dateiToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beendenToolStripMenuItem1});
            this.dateiToolStripMenuItem1.Name = "dateiToolStripMenuItem1";
            this.dateiToolStripMenuItem1.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem1.Text = "&Datei";
            // 
            // beendenToolStripMenuItem1
            // 
            this.beendenToolStripMenuItem1.Name = "beendenToolStripMenuItem1";
            this.beendenToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            this.beendenToolStripMenuItem1.Text = "&Beenden";
            this.beendenToolStripMenuItem1.Click += new System.EventHandler(this.beendenToolStripMenuItem1_Click);
            // 
            // bearbeitenToolStripMenuItem
            // 
            this.bearbeitenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.einstellungenToolStripMenuItem1});
            this.bearbeitenToolStripMenuItem.Name = "bearbeitenToolStripMenuItem";
            this.bearbeitenToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.bearbeitenToolStripMenuItem.Text = "&Bearbeiten";
            // 
            // einstellungenToolStripMenuItem1
            // 
            this.einstellungenToolStripMenuItem1.Name = "einstellungenToolStripMenuItem1";
            this.einstellungenToolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
            this.einstellungenToolStripMenuItem1.Text = "&Einstellungen";
            this.einstellungenToolStripMenuItem1.Click += new System.EventHandler(this.einstellungenToolStripMenuItem1_Click);
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.überToolStripMenuItem2});
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.hilfeToolStripMenuItem.Text = "&Hilfe";
            // 
            // überToolStripMenuItem2
            // 
            this.überToolStripMenuItem2.Name = "überToolStripMenuItem2";
            this.überToolStripMenuItem2.Size = new System.Drawing.Size(99, 22);
            this.überToolStripMenuItem2.Text = "&Über";
            this.überToolStripMenuItem2.Click += new System.EventHandler(this.überToolStripMenuItem2_Click);
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "&Datei";
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.beendenToolStripMenuItem.Text = "&Beenden";
            // 
            // einstelleungenToolStripMenuItem
            // 
            this.einstelleungenToolStripMenuItem.Name = "einstelleungenToolStripMenuItem";
            this.einstelleungenToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.einstelleungenToolStripMenuItem.Text = "Bearbeiten";
            // 
            // einstellungenToolStripMenuItem
            // 
            this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            this.einstellungenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.einstellungenToolStripMenuItem.Text = "Einstellungen";
            // 
            // überToolStripMenuItem
            // 
            this.überToolStripMenuItem.Name = "überToolStripMenuItem";
            this.überToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.überToolStripMenuItem.Text = "Hilfe";
            // 
            // überToolStripMenuItem1
            // 
            this.überToolStripMenuItem1.Name = "überToolStripMenuItem1";
            this.überToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.überToolStripMenuItem1.Text = "Über";
            // 
            // la_name
            // 
            this.la_name.AutoSize = true;
            this.la_name.BackColor = System.Drawing.Color.Transparent;
            this.la_name.Location = new System.Drawing.Point(536, 371);
            this.la_name.Name = "la_name";
            this.la_name.Size = new System.Drawing.Size(115, 13);
            this.la_name.TabIndex = 19;
            this.la_name.Text = "23. Luftlandekompanie";
            // 
            // tb_link
            // 
            this.tb_link.Location = new System.Drawing.Point(536, 387);
            this.tb_link.Name = "tb_link";
            this.tb_link.ReadOnly = true;
            this.tb_link.Size = new System.Drawing.Size(204, 20);
            this.tb_link.TabIndex = 20;
            this.tb_link.Text = "http://23-luftlandekompanie.de";
            // 
            // pb_logo
            // 
            this.pb_logo.BackColor = System.Drawing.Color.Transparent;
            this.pb_logo.Image = global::ModSync.Properties.Resources.logo_small;
            this.pb_logo.Location = new System.Drawing.Point(536, 178);
            this.pb_logo.Name = "pb_logo";
            this.pb_logo.Size = new System.Drawing.Size(207, 190);
            this.pb_logo.TabIndex = 18;
            this.pb_logo.TabStop = false;
            // 
            // chb_autojoin
            // 
            this.chb_autojoin.AutoSize = true;
            this.chb_autojoin.BackColor = System.Drawing.Color.Transparent;
            this.chb_autojoin.Location = new System.Drawing.Point(536, 155);
            this.chb_autojoin.Name = "chb_autojoin";
            this.chb_autojoin.Size = new System.Drawing.Size(162, 17);
            this.chb_autojoin.TabIndex = 21;
            this.chb_autojoin.Text = "Automatisch Server beitreten";
            this.chb_autojoin.UseVisualStyleBackColor = false;
            // 
            // bt_updatemp
            // 
            this.bt_updatemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_updatemp.Location = new System.Drawing.Point(12, 198);
            this.bt_updatemp.Name = "bt_updatemp";
            this.bt_updatemp.Size = new System.Drawing.Size(211, 65);
            this.bt_updatemp.TabIndex = 24;
            this.bt_updatemp.Text = "Update Map-Pack";
            this.bt_updatemp.UseVisualStyleBackColor = true;
            // 
            // bt_mp_checkforupdates
            // 
            this.bt_mp_checkforupdates.Location = new System.Drawing.Point(12, 267);
            this.bt_mp_checkforupdates.Name = "bt_mp_checkforupdates";
            this.bt_mp_checkforupdates.Size = new System.Drawing.Size(210, 27);
            this.bt_mp_checkforupdates.TabIndex = 27;
            this.bt_mp_checkforupdates.Text = "Auf Updates überprüfen";
            this.bt_mp_checkforupdates.UseVisualStyleBackColor = true;
            // 
            // bt_test
            // 
            this.bt_test.Location = new System.Drawing.Point(15, 361);
            this.bt_test.Name = "bt_test";
            this.bt_test.Size = new System.Drawing.Size(75, 23);
            this.bt_test.TabIndex = 29;
            this.bt_test.Text = "Test";
            this.bt_test.UseVisualStyleBackColor = true;
            this.bt_test.Click += new System.EventHandler(this.bt_test_Click);
            // 
            // tb_console
            // 
            this.tb_console.Location = new System.Drawing.Point(12, 472);
            this.tb_console.Multiline = true;
            this.tb_console.Name = "tb_console";
            this.tb_console.Size = new System.Drawing.Size(735, 66);
            this.tb_console.TabIndex = 30;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(761, 550);
            this.Controls.Add(this.tb_console);
            this.Controls.Add(this.bt_test);
            this.Controls.Add(this.bt_mp_checkforupdates);
            this.Controls.Add(this.bt_updatemp);
            this.Controls.Add(this.chb_autojoin);
            this.Controls.Add(this.tb_link);
            this.Controls.Add(this.la_name);
            this.Controls.Add(this.pb_logo);
            this.Controls.Add(this.bt_checkforupdates);
            this.Controls.Add(this.bt_launcharma);
            this.Controls.Add(this.la_byte);
            this.Controls.Add(this.pb_dl);
            this.Controls.Add(this.bt_settings);
            this.Controls.Add(this.bt_checkout);
            this.Controls.Add(this.ms_main);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.ms_main;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "23. Luftlandekompanie ModSync";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ms_main.ResumeLayout(false);
            this.ms_main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Button bt_mp_checkforupdates;
		private System.Windows.Forms.Button bt_updatemp;
        private System.Windows.Forms.Button bt_settings;
        private System.Windows.Forms.Button bt_checkout;
        private System.Windows.Forms.ProgressBar pb_dl;
        private System.Windows.Forms.Label la_byte;
        private System.Windows.Forms.Button bt_launcharma;
        private System.Windows.Forms.Button bt_checkforupdates;
        private System.Windows.Forms.MenuStrip ms_main;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem einstelleungenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem überToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem überToolStripMenuItem1;
        private System.Windows.Forms.PictureBox pb_logo;
        private System.Windows.Forms.Label la_name;
        private System.Windows.Forms.TextBox tb_link;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bearbeitenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem überToolStripMenuItem2;
        private System.Windows.Forms.CheckBox chb_autojoin;
        private System.Windows.Forms.Button bt_test;
        private System.Windows.Forms.TextBox tb_console;
	}
}
