using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;

namespace ModSync
{
    public class rsync
    {
        public delegate void MessageHandler(rsync r, MessageReceivedArgs Args);
        public event MessageHandler NewMessageReceived;

        public delegate void DownloadMessageHandler(rsync r, DownloadMessageReceivedArgs Args);
        public event DownloadMessageHandler NewDownloadMessageReceived;

        public event UpdateCheckReceivingDoneHandler UpdateCheckReceivingDone;
        public EventArgs e = null;
        public delegate void UpdateCheckReceivingDoneHandler(rsync r, EventArgs e);

        public event DownloadDoneHandler DownloadDone;
        public EventArgs ea = null;
        public delegate void DownloadDoneHandler(rsync r, EventArgs ea);

        private BackgroundWorker bw = new BackgroundWorker();

        public rsync()
        {
            this.UpdateCheckReceivingDone += new UpdateCheckReceivingDoneHandler(handle_update_check_exit);

            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += new DoWorkEventHandler(rsync_update);
            //bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            //bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
        }

        private Process init_rsync_proc(string arguments)
        {
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {

                    FileName = "rsync.exe",
                    Arguments = arguments,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            return proc;
        }

        public void rsync_checkforupdates()
        {
            var proc = init_rsync_proc("-n -a -i --delete -r " + Properties.Settings.Default.rsyncserver + " /cygdrive/\"C/Users/Niko/Desktop/eng/\"");
            this.NewMessageReceived += new rsync.MessageHandler(handle_message);
            
            proc.Start();
            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine();
                if (NewMessageReceived != null)
                {
                    MessageReceivedArgs mra = new MessageReceivedArgs(line, "update");
                    NewMessageReceived(this, mra);
                }
            }
            if (UpdateCheckReceivingDone != null)
            {
                UpdateCheckReceivingDone(this, e);
            }
            this.NewMessageReceived -= new rsync.MessageHandler(handle_message);
            proc.Close();
        }

        int new_files = 0, changed_files = 0, deleted_files = 0;

        private void handle_message(object sender, MessageReceivedArgs mra)
        {
            switch (mra.Type)
            {
                case "update":
                    string[] split = mra.Message.Split(' ');
                    switch (split[0][0])
                    {
                        case '>':
                            if (split[0][1] == 'f')
                            {
                                if (split[0][2] == '+')
                                {
                                    new_files++;
                                }
                                else if (split[0][3] == 's' || split[0][4] == 't')
                                {
                                    changed_files++;
                                }
                            }
                            break;
                        case '*':
                            if (split[0].Substring(1, 8) == "deleting")
                            {
                                deleted_files++;
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        private void handle_update_check_exit(object sender, EventArgs e)
        {
            if (new_files == 0 && changed_files == 0 && deleted_files == 0)
            {
                MessageBox.Show("Keine Updates gefunden!");
            }
            else
            {
                MessageBox.Show(new_files.ToString() + " - " + changed_files.ToString() + " - " + deleted_files.ToString());
            }
            new_files = 0;
            changed_files = 0;
            deleted_files = 0;
        }

        public void start_download()
        {
            if (bw.IsBusy != true)
            {
                bw.RunWorkerAsync();
            }
        }

        private void rsync_update(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            var proc = init_rsync_proc("-a -v --progress -r " + Properties.Settings.Default.rsyncserver + " /cygdrive/\"C/Users/Niko/Desktop/eng/\"");

            proc.Start();
            while (!proc.StandardOutput.EndOfStream)
            {
                if ((worker.CancellationPending == true))
                {
                    proc.Kill();
                    e.Cancel = true;
                    break;
                }
                else
                {
                    string line = proc.StandardOutput.ReadLine();
                    if (NewDownloadMessageReceived != null)
                    {
                        DownloadMessageReceivedArgs mra = new DownloadMessageReceivedArgs(line, "download");
                        NewDownloadMessageReceived(this, mra);
                    }
                }
            }
            if (DownloadDone != null)
            {
                DownloadDone(this, e);
            }
            proc.Close();
        }
    }

    public class MessageReceivedArgs : EventArgs
    {
        private string message_p;
        private string type_p;

        public MessageReceivedArgs(string message, string type)
        {
            this.message_p = message;
            this.type_p = type;
        }

        public string Message
        {
            set
            {
                message_p = value;
            }
            get
            {
                return message_p;
            }
        }

        public string Type
        {
            set
            {
                type_p = value;
            }
            get
            {
                return type_p;
            }
        }
    }

    public class DownloadMessageReceivedArgs : EventArgs
    {
        private string message_p;
        private string type_p;

        public DownloadMessageReceivedArgs(string message, string type)
        {
            this.message_p = message;
            this.type_p = type;
        }

        public string Message
        {
            set
            {
                message_p = value;
            }
            get
            {
                return message_p;
            }
        }

        public string Type
        {
            set
            {
                type_p = value;
            }
            get
            {
                return type_p;
            }
        }
    }
}
