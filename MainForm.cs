/*
 * Created by SharpDevelop.
 * User: Niko
 * Date: 05.02.2014
 * Time: 16:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SharpSvn;
using System.Collections;
using System.Threading;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;

namespace ModSync
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

            checkIfArmaPathset();

            svnM = new svnMethods();

            initSettings();
		}
		
		svnMethods svnM;
		
		void Bt_checkoutClick(object sender, EventArgs e)
		{
            bool upt = true;
            if (checkforexe() == false)
            {
                if (MessageBox.Show("Die arma3.exe wurde im ausgewählten Update-Verzeichniss nicht gefunden. Sicher, das das Update durchgeführt werden soll?", "Arma3.exe nicht gefunden!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    upt = true;
                }
                else
                {
                    upt = false;
                }
            }
            if (upt)
            if (svnM._IsReachable)
            {
                if (bt_checkout.Text != "Abbrechen")
                {
                    svnM.startUpdate(new Uri(Properties.Settings.Default.svnserver), Properties.Settings.Default.arma3path);
                    bt_checkout.Text = "Abbrechen";
                    la_desc_dl1.Text = "Inhalte werden herruntergeladen...";
                    la_byte.Visible = true;
                    la_desc_dl1.Visible = true;
                    prgupdate = new Thread(new ThreadStart(() => updateProgress()));
                    prgupdate.Start();
                    while (!prgupdate.IsAlive) ;
                }
                else
                {
                    if (prgupdate.IsAlive)
                    {
                        svnM.endThread();
                        prgupdate.Abort();
                        ThreadDone(true);
                    }
                }
            }
            else
            {
                MessageBox.Show("Der Server '" + Properties.Settings.Default.svnserver + "' konnte nicht erreicht werden.");
            }
		}

        void checkIfArmaPathset()
        {
            if (Properties.Settings.Default.arma3path == "NONE")
            {
                string path = Environment.ExpandEnvironmentVariables("%programfiles(x86)%");
                path += "\\Steam\\SteamApps\\common\\Arma 3\\";
                Properties.Settings.Default.arma3path = path;
            }
        }
		
		Thread prgupdate;
		
		private volatile bool _shouldStop = false;
		
		public void RequestStop()
		{
		    _shouldStop = true;
		}
		
		void updateProgress() {
            SvnProgressEventArgs progress = null;
			while (!_shouldStop) {
				if (svnM.getProgress() != null) {
					progress = svnM.getProgress();
				}
				Invoke((MethodInvoker) delegate { setProgress(progress); });
				if (svnM.done) {
					this.RequestStop();
                    svnM.done = false;
                    Invoke((MethodInvoker)delegate { ThreadDone(false); });
				}
			}
            _shouldStop = false;
            
		}

        void setProgress(SvnProgressEventArgs progress)
        {
            if (progress != null)
            {
                if (progress.Progress > progress.TotalProgress) pb_dl.Maximum = (int)progress.Progress + 1;
                pb_dl.Step = (int)progress.Progress;
                pb_dl.PerformStep();
                long prog = progress.Progress / 1024;
                la_byte.Text = prog.ToString() + " KBytes";
            }
		}

        void ThreadDone(bool aborted)
        {
            //pb_dl.Maximum = 0;
            bt_checkout.Text = "Update";
            la_byte.Visible = false;
            if (aborted == false)
            {
                la_desc_dl1.Text = "Herrunterladen war erfolgreich!";
                updateresult = 0;
                setUpdateLabel(null, la_isuptodate);
            }
            else
            {
                la_desc_dl1.Text = "Operation abgebrochen";
            }

        }

        void initSettings()
        {
            chb_autojoin.Checked = Properties.Settings.Default.autojoin;
        }

        int checkforUpdate(out SvnInfoEventArgs[] repos, string repo_to_check) 
        {
            repos = svnM.svnGetDiff(Properties.Settings.Default.arma3path, repo_to_check);

            Collection<SvnLogEventArgs> logs = null;

            Uri svns;

            try {
                svns = new Uri(Properties.Settings.Default.svnserver);
            }
            catch (Exception) {
                return 3;
            }

            logs = svnM.GetLatestCommitMessages(svns, 55);
            rtb_changelog.Text = "";
            if ( logs != null)
            foreach (SvnLogEventArgs rev in logs)
            {
                if (rev != null)
                {
                    rtb_changelog.Text += rev.Time + "\r\nRevision " + rev.Revision + ":\r\n\r\n" + rev.LogMessage + "\r\n\r\n - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - \r\n\r\n";
                }
            }

            if (repos[0] != null && repos[1] != null)
            {
                if (repos[0].Revision < repos[1].Revision)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else if (repos[0] == null && repos[1] == null)
            {
                return 3;
            }
            else if (repos[0] == null && repos[1] != null)
            {
                return 4;
            }
            return 3;
        }
		
		void Button1Click(object sender, EventArgs e)
		{
			settings sett = new settings();
			
			if (sett.ShowDialog() == DialogResult.OK) {
                svnM.checkIfReachable(Properties.Settings.Default.svnserver);
			}
		}
		
		void Bt_getfilesClick(object sender, EventArgs e)
		{

            foreach (SvnListEventArgs item in svnM.getFiles())
            {
                Object[] row = new object[3];
                row[0] = item.Path;
                row[1] = item.Entry.Revision;
                row[2] = item.GetHashCode();
            }
		}

        private void bt_debug_Click(object sender, EventArgs e)
        {
            MessageBox.Show(svnM.checkout.IsAlive.ToString());
            MessageBox.Show(this.prgupdate.IsAlive.ToString());
        }

        int updateresult;

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.checkforupdates == true)
            {
                SvnInfoEventArgs[] repos;
                updateresult = checkforUpdate(out repos, Properties.Settings.Default.svnserver);
                setUpdateLabel(repos, la_isuptodate);
                if (updateresult == 1)
                {
                    MessageBox.Show("Ein Update ist verfügbar! Lokale Version: " + repos[0].Revision.ToString() + " Remote Version: " + repos[1].Revision.ToString());
                }
            }
        }

        private void setUpdateLabel(SvnInfoEventArgs[] repos, Label label_to_set)
        {
            if (updateresult == 1)
            {
                label_to_set.Text = "Nicht aktuell";
                label_to_set.BackColor = Color.Red;
            }
            else if (updateresult == 0)
            {
                label_to_set.Text = "Aktuell";
                label_to_set.BackColor = Color.Green;
            }
            else if (updateresult == 4)
            {
                label_to_set.Text = "Nicht installiert";
                label_to_set.BackColor = Color.Yellow;
            }
        }

        private void bt_checkforupdates_Click(object sender, EventArgs e)
        {
            SvnInfoEventArgs[] repos;
            updateresult = checkforUpdate(out repos, Properties.Settings.Default.svnserver);
            setUpdateLabel(repos, la_isuptodate);
            if (updateresult == 1)
            {
                MessageBox.Show("Ein Update ist verfügbar! Lokale Version: " + repos[0].Revision.ToString() + " Remote Version: " + repos[1].Revision.ToString(), "Neue Updates gefunden");
            }
            else if (updateresult == 0)
            {
                MessageBox.Show("Keine neuen Updates gefunden. Lokale Version: " + repos[0].Revision.ToString() + " Remote Version: " + repos[1].Revision.ToString(), "Keine neuen Updates");
            }
            else if (updateresult == 4)
            {
                MessageBox.Show("Keine Version des Modpackets gefunden! Bitte auf \"Update\" drücken!", "Keine Version des Updates gefunden!");
            }
        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            EndProgramm();
        }

        private void bt_launcharma_Click(object sender, EventArgs e)
        {
            string args = "";

            if (Properties.Settings.Default.nosplash)
            {
                args += " -nosplash";
            }
            if (Properties.Settings.Default.worldempty)
            {
                args += " -world=empty";
            }
            if (Properties.Settings.Default.autojoin || chb_autojoin.Checked)
            {
                string[] ip_port = new string[2];


                ip_port = Properties.Settings.Default.autojoinserver.Split(':');
                ip_port[0] = Dns.GetHostAddresses(ip_port[0])[0].ToString();
                args += " -connect=" + ip_port[0] + " -port=" + ip_port[1] + " -password=" + Properties.Settings.Default.password;
            }

            if (Properties.Settings.Default.otherstartup != "")
            {
                args += " " + Properties.Settings.Default.otherstartup;
            }


            string modstart = "";

            modstart = " -mod=" + Properties.Settings.Default.mods;

            args += modstart;
            if (checkforexe())
            {
                Process.Start(Properties.Settings.Default.arma3path + "\\" + Properties.Settings.Default.arma3exe, args);
            }
            else
            {
                MessageBox.Show("Konnte die arma3.exe unter dem angegebenen Pfad nicht finden");
            }
        }

        bool checkforexe()
        {
            if (File.Exists(Properties.Settings.Default.arma3path + "\\" + Properties.Settings.Default.arma3exe))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void EndProgramm()
        {
            Properties.Settings.Default.autojoin = chb_autojoin.Checked;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void beendenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EndProgramm();
        }

        private void einstellungenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            settings sett = new settings();

            if (sett.ShowDialog() == DialogResult.OK)
            {
                svnM.checkIfReachable(Properties.Settings.Default.svnserver);
            }
        }

        private void überToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            about a = new about();
            a.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.autojoin = chb_autojoin.Checked;
            Properties.Settings.Default.Save();
        }
		
		void Bt_updatempClick(object sender, EventArgs e)
		{
			bool upt = true;
            if (checkforexe() == false)
            {
                if (MessageBox.Show("Die arma3.exe wurde im ausgewählten Update-Verzeichniss nicht gefunden. Sicher, das das Update durchgeführt werden soll?", "Arma3.exe nicht gefunden!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    upt = true;
                }
                else
                {
                    upt = false;
                }
            }
            if (upt)
            if (svnM._IsReachable)
            {
                if (bt_checkout.Text != "Abbrechen")
                {
                    svnM.startUpdate(new Uri(Properties.Settings.Default.svnserver), Properties.Settings.Default.arma3path);
                    bt_checkout.Text = "Abbrechen";
                    la_desc_dl1.Text = "Inhalte werden herruntergeladen...";
                    la_byte.Visible = true;
                    la_desc_dl1.Visible = true;
                    prgupdate = new Thread(new ThreadStart(() => updateProgress()));
                    prgupdate.Start();
                    while (!prgupdate.IsAlive) ;
                }
                else
                {
                    if (prgupdate.IsAlive)
                    {
                        svnM.endThread();
                        prgupdate.Abort();
                        ThreadDone(true);
                    }
                }
            }
            else
            {
                MessageBox.Show("Der Server '" + Properties.Settings.Default.svnserver + "' konnte nicht erreicht werden.");
            }
		}
	}
}
