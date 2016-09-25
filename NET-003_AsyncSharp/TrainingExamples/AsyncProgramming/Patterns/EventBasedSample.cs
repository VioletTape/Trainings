using System;
using System.ComponentModel;
using System.Net;
using System.Threading;

namespace AsyncProgramming.Patterns {
    public class EventBasedSample {
        private static readonly string[] urls = new[] {
            "http://codeproject.com",
            "http://stackoverflow.com",
            "http://msdn.microsoft.com"
        };


        private readonly BackgroundWorker worker;

        public EventBasedSample() {
            worker = new BackgroundWorker {
                WorkerReportsProgress = true
            };
            worker.DoWork += LoadWebPages;
            worker.ProgressChanged += PageLoaded;
            worker.RunWorkerCompleted += LoadingCompleted;

            worker.RunWorkerAsync();
        }

        public void LoadWebPages(object sender, DoWorkEventArgs doWorkEventArgs) {
            foreach (var url in urls) {
                var webRequest = WebRequest.Create(url);
                var iac = webRequest.GetResponse();
                worker.ReportProgress(0, iac);
            }
        }

        private void PageLoaded(object sender, ProgressChangedEventArgs e) {
            try {
                var result = e.UserState;
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }

        private void LoadingCompleted(object sender, RunWorkerCompletedEventArgs e) {
            Console.WriteLine("Works complete");
        }
    }
















    public class EventBasedSampleX {
        private static readonly string[] urls = new[] {
            "http://codeproject.com",
            "http://stackoverflow.com",
            "http://msdn.microsoft.com"
        };

        public event Action<object> WebPageLoaded;
        public event Action WebPagesLoadCompleted;

        public EventBasedSampleX() {
            WebPageLoaded += o => { };
            WebPagesLoadCompleted += () => { };
        }

        public void LoadWebPages() {
            ThreadPool.QueueUserWorkItem(LoadPages);
        }

        private void LoadPages(object state) {
            foreach (var url in urls) {
                var webRequest = WebRequest.Create(url);
                var iac = webRequest.GetResponse();
                WebPageLoaded(iac);
            }
            WebPagesLoadCompleted();
        }
    }
}