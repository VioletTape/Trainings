using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncProgramming.Demos {
    public partial class Demo8SyncContext : Form {
        public Demo8SyncContext() {
            InitializeComponent();
        }

        private void GoClick(object sender, EventArgs e) {
            NotSoGoodExample();
        }











        private void BadExample() {
            new TaskFactory()
                .StartNew(() => {
                    Thread.Sleep(TimeSpan.FromSeconds(5));
                    label1.Text = DateTime.Now.Second.ToString();
                });
        }
















        private void BadExampleCorrected() {
            new TaskFactory()
                .StartNew(() => {
                    Thread.Sleep(TimeSpan.FromSeconds(5));
                    label1.Invoke((Action) (() => label1.Text = DateTime.Now.Second.ToString()));
                });
        }





















        private void GoodExample() {
            var task = new Task(() => Thread.Sleep(TimeSpan.FromSeconds(5)));
            task.ContinueWith(t => {
                label1.Text = DateTime.Now.Second.ToString();
            }
                , TaskScheduler.FromCurrentSynchronizationContext());
            
            task.Start();
        }



















        private void NotSoGoodExample() {
            var ui = TaskScheduler.FromCurrentSynchronizationContext();
            new TaskFactory(ui)
                .StartNew(() => {
                    Thread.Sleep(TimeSpan.FromSeconds(5));
                    label1.Text = DateTime.Now.Second.ToString();
                });
        }
    }
}