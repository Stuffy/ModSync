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
            r = new rsync();
            initSettings();

            r.NewDownloadMessageReceived += new rsync.DownloadMessageHandler(handle_download);
            r.DownloadDone += new rsync.DownloadDoneHandler(r_DownloadDone);
		}

        rsync r;

        void checkIfArmaPathset()
        {
            if (Properties.Settings.Default.arma3path == "NONE")
            {
                string path = Environment.ExpandEnvironmentVariables("%programfiles(x86)%");
                path += "\\Steam\\SteamApps\\common\\Arma 3\\";
                Properties.Settings.Default.arma3path = path;
            }
        }

        void initSettings()
        {
            chb_autojoin.Checked = Properties.Settings.Default.autojoin;
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
            if (chb_autojoin.Checked)
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

        private void bt_test_Click(object sender, EventArgs e)
        {

            r.rsync_checkforupdates();
        }

        private void bt_checkforupdates_Click(object sender, EventArgs e)
        {
            r.rsync_checkforupdates();
        }

        private void bt_checkout_Click(object sender, EventArgs e)
        {
            r.start_download();
        }

        void r_DownloadDone(rsync r, EventArgs ea)
        {
            //r.NewDownloadMessageReceived -= new rsync.DownloadMessageHandler(handle_download);
        }

        private object[] filter_progress(string progress_message)
        {
            object[] progress = new object[4];

            string[] split = progress_message.Split(' ');

            int found_string = 0;
            
            for (int i = 0; i < split.Length; i++)
            {
                if (split[i] != "")
                {
                    found_string++;
                    switch (found_string)
                    {
                        //size
                        case 1:
                            progress[0] = split[i];
                            break;
                        // Progress
                        case 2:
                            progress[1] = split[i].Replace("%","");
                            break;
                        // dl speed
                        case 3:
                            progress[2] = split[i].Replace("kB/s", "");
                            break;
                        // time remaining
                        case 4:
                            progress[3] = split[i];
                            break;
                    }
                }
            }

            //MessageBox.Show(progress_message);
            return progress;
        }

        int skip_lines = 0;
        bool received_filelist = false;

        private void handle_download(object sender, DownloadMessageReceivedArgs mra)
        {
            if (mra.Message == "receiving incremental file list")
            {
                received_filelist = true;
            }
            if (received_filelist == true)
            {
                if (mra.Message != "")
                {
                    if (skip_lines < 2)
                    {
                        skip_lines++;
                    }
                    else if (mra.Message[0] != ' ')
                    {
                        this.Invoke((MethodInvoker)(() => tb_console.AppendText("File-Name: " + mra.Message)));
                    }
                    else if (mra.Message[0] == ' ')
                    {
                        object[] prog = filter_progress(mra.Message);
                        this.Invoke((MethodInvoker)(() => pb_dl.Value = Convert.ToInt32(prog[1])));
                        this.Invoke((MethodInvoker)(() => la_byte.Text = prog[2].ToString()));
                    }
                }
            }
        }
	}
}
