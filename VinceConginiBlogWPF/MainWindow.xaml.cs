using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;

namespace ProgressBar
    {
    public partial class ProgressBarTask : Window
        {
        public ProgressBarTask ()
            {
            InitializeComponent ();
            }

        private void contentRendered (object sender, EventArgs e)
            {
            BackgroundWorker worker = new BackgroundWorker ();
            worker.WorkerReportsProgress = true;
            worker.DoWork += doWork;
            worker.ProgressChanged += worker_ProgressChanged;

            worker.RunWorkerAsync ();
            }

        void doWork (object sender, DoWorkEventArgs e)
            {
            for (int i = 0; i < 100; i++)
                {
                (sender as BackgroundWorker).ReportProgress (i);
                Thread.Sleep (100);
                }
            }

        void worker_ProgressChanged (object sender, ProgressChangedEventArgs e)
            {
            pbStatus.Value = e.ProgressPercentage;
            }
        }
    }