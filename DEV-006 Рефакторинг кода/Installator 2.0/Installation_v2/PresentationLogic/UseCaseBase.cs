using System.ComponentModel;
using Installation_v2.InstallationLogic;
using Installation_v2.InstallationLogic.Interfaces;

namespace Installation_v2.PresentationLogic {
    public abstract class UseCaseBase {
        private readonly InstallState installState;
        private BackgroundWorker worker = new BackgroundWorker();

        public BaseViewState BaseViewState { get; set; }

        public IInstallEnvironment InstallEnvironment {
            get { return InstallState.InstallEnvironment; }
        }

        public IServiceLocator ServiceLocator {
            get{ return InstallState.ServiceLocator;}
        }

        public InstallState InstallState {
            get { return installState; }
        }


        protected UseCaseBase(InstallState installState) {
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;


            worker.ProgressChanged += ProgressChanged;
            worker.DoWork += AsyncWork;

            this.installState = installState;
        }

        internal virtual void AsyncWork(object sender, DoWorkEventArgs e) {}

        internal virtual void ProgressChanged(object sender, ProgressChangedEventArgs e) {}

        internal void RunAsync() {
            worker.RunWorkerAsync();
        }


        public void Run() {
            DoConfigure();
        }

        public abstract void DoConfigure();
    }
}