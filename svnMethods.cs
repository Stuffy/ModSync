using System;
using System.Windows.Forms;
using SharpSvn;
using System.Threading;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ModSync
{
	/// <summary>
	/// Description of svnMethods.
	/// </summary>
	public class svnMethods
	{
		public svnMethods()
		{
           checkIfReachable(Properties.Settings.Default.svnserver);	
		}
		
		SvnUpdateResult result;
		
		private volatile bool _shouldStop;

        private bool _done = false;
        public bool _IsReachable;
		public bool done {
            get
            {
                return _done;
            }
            set
            {
                _done = value;
            }
        }
		
		public void RequestStop()
		{
		    _shouldStop = true;
		}

        public void endThread()
        {
            checkout.Abort();
        }
		
		public Thread checkout;
		delegate void delegateVoid();
		
		public void startUpdate(Uri from, string to) {
            if (_IsReachable)
            {
                if (!IsWorkingCopy(to))
                {
                    checkout = new Thread(new ThreadStart(() => svnCheckout(from, to)));
                }
                else
                {
                    checkout = new Thread(new ThreadStart(() => svnUpdate(to)));
                }
                checkout.Start();

                while (!checkout.IsAlive) ;
            }
            else
            {
                MessageBox.Show("Der Server '" + Properties.Settings.Default.svnserver + "' konnte nicht erreicht werden.");
            }
		}

        private int retrys = 0;

        private void svnUpdate(string target_repo)
        {
            while (!_shouldStop)
            {
                using (SvnClient client = new SvnClient())
                {
                    try
                    {
                        client.Progress += new EventHandler<SvnProgressEventArgs>(cl_Progress);
                        SvnUpdateArgs sua = new SvnUpdateArgs();
                        sua.AllowObstructions = true;
                        //sua.Depth = SvnDepth.Infinity;
                        SvnUpdateResult result;
                        client.Update(target_repo, sua, out result);
                    }
                    catch (SvnException se)
                    {
                        if (retrys < 2)
                        {
                            performCleanup(client, target_repo);
                            svnUpdate(target_repo);
                            retrys++;
                        }
                        else
                        {
                            MessageBox.Show("Ein Fehler ist aufgetreten:" + se.Message);
                        }
                    }
                    SvnRevertArgs sra = new SvnRevertArgs();
                    sra.Depth = SvnDepth.Infinity;
                    client.Revert(target_repo, sra);
                }
                this.RequestStop();
            }
            _done = true;
            _shouldStop = false;
        }

        private void notifyme(object sender, SvnNotifyEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.Action.ToString());
        }
		
		private void svnCheckout(Uri from, string to) {
			while (!_shouldStop) {
				using (SvnClient client = new SvnClient()) {
                    try
                    {
                        client.Progress += new EventHandler<SvnProgressEventArgs>(cl_Progress);
                        //client.Notify += new EventHandler<SvnNotifyEventArgs>(notifyme);
                        SvnCheckOutArgs sco = new SvnCheckOutArgs();
                        //sco.Depth = SvnDepth.Infinity;
                        sco.AllowObstructions = false;
                        client.CheckOut(from, to, out result);
                    }
                    catch (SvnException se)
                    {
                        if (retrys < 2)
                        {
                            performCleanup(client, to);
                            svnCheckout(from, to);
                            retrys++;
                        }
                        else
                        {
                            MessageBox.Show("Ein Fehler ist aufgetreten:" + se.Message);
                        }
                    }
                    SvnRevertArgs sra = new SvnRevertArgs();
                    sra.Depth = SvnDepth.Infinity;
                    client.Revert(to, sra);
				}
				this.RequestStop();
			}
            _done = true;
            _shouldStop = false;
		}

        private void performCleanup(SvnClient client, string to) {
            try
            {
                client.CleanUp(to);
            }
            catch (SvnException svne)
            {
                MessageBox.Show(svne.Message);
            }
        }

        public List<SvnListEventArgs> getFiles()
        {
            bool gotList;
            List<SvnListEventArgs> files = new List<SvnListEventArgs>();

            using (SvnClient client = new SvnClient())
            {
                System.Collections.ObjectModel.Collection<SvnListEventArgs> list;

                gotList = client.GetList(Properties.Settings.Default.svnserver, out list);

                if (gotList)
                {
                    foreach (SvnListEventArgs item in list)
                    {
                        files.Add(item);
                    }
                }
            }
            return files;
        }
		
		private SvnProgressEventArgs progress;
		
		private void cl_Progress(object sender, SvnProgressEventArgs e) {
			progress = e;
		}
		
		public SvnProgressEventArgs getProgress() {
			return progress;
		}

        public static bool IsWorkingCopy(string path)
        {
            using (SvnClient client = new SvnClient())
            {
                var uri = client.GetUriFromWorkingCopy(path);
                return uri != null;
            }
        }

        public void checkIfReachable(string remote_repo)
        {
            if (remote_repo != "" && remote_repo != null)
            {
                SvnInfoEventArgs repo;
                using (SvnClient client = new SvnClient())
                {
                    try
                    {
                        client.GetInfo(remote_repo, out repo);
                        _IsReachable = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        _IsReachable = false;
                    }
                }
            }
            else
            {
                _IsReachable = false;
            }
        }
		
		public SvnInfoEventArgs[] svnGetDiff(string local_repo, string remote_repo) 
        {  
            SvnInfoEventArgs[] repos = new SvnInfoEventArgs[2];
            
            if (_IsReachable)
            {
                using (SvnClient client = new SvnClient())
                {
                    if (IsWorkingCopy(local_repo))
                    {
                        client.GetInfo(local_repo, out repos[0]);
                        client.GetInfo(remote_repo, out repos[1]);
                    }
                    else
                    {
                        repos[0] = null;
                        client.GetInfo(remote_repo, out repos[1]);
                    }
                }
            }
            else
            {
                MessageBox.Show("Der Server '" + Properties.Settings.Default.svnserver + "' konnte nicht erreicht werden.");
            }
            return repos;
		}

        public Collection<SvnLogEventArgs> GetLatestCommitMessages(Uri repository, int count)
        {
            System.Collections.ObjectModel.Collection<SvnLogEventArgs> logEntries = null;

            if (_IsReachable)
            {
                using (var client = new SvnClient())
                {
                    var args = new SvnLogArgs()
                    {
                        Limit = count
                    };


                    client.GetLog(repository, args, out logEntries);
                }
            }
            else
            {
                MessageBox.Show("Der Server '" + Properties.Settings.Default.svnserver + "' konnte nicht erreicht werden.");
            }

            return logEntries;
        }
	}
}
