using System;
using System.Collections.Generic;
using Installation_v2.InstallationLogic;
using Installation_v2.InstallationLogic.Enums;
using Installation_v2.InstallationLogic.Interfaces;
using Installation_v2.PresentationLogic.CreateUC;
using Installation_v2.PresentationLogic.CreateUC.Views;
using Installation_v2.PresentationLogic.End;
using Installation_v2.PresentationLogic.End.Views;
using Installation_v2.PresentationLogic.Enums;
using Installation_v2.PresentationLogic.InstallSelectionUC;
using Installation_v2.PresentationLogic.InstallSelectionUC.Views;
using Installation_v2.PresentationLogic.InstallUC;
using Installation_v2.PresentationLogic.InstallUC.Views;
using Installation_v2.PresentationLogic.LicenseUC;
using Installation_v2.PresentationLogic.LicenseUC.Views;
using Installation_v2.PresentationLogic.RemoveTempUC;
using Installation_v2.PresentationLogic.RemoveTempUC.Views;
using Installation_v2.PresentationLogic.RequirementsCheckupUC;
using Installation_v2.PresentationLogic.RequirementsCheckupUC.Views;
using Installation_v2.PresentationLogic.RequirementsInstallUC;
using Installation_v2.PresentationLogic.RequirementsInstallUC.Views;
using Installation_v2.PresentationLogic.WelcomeUC;
using Installation_v2.PresentationLogic.WelcomeUC.Views;

namespace Installation_v2.PresentationLogic {
    public class UseCaseRunner {
        private Dictionary<UseCaseNames, UseCaseBase> useCases;
        private UseCaseBase currentUseCase;
        private UseCaseNames currentName;

        private readonly Dictionary<UseCaseNames, object> views =
            new Dictionary<UseCaseNames, object> {
                                                     {UseCaseNames.Welcome, new WelcomeView()},
                                                     {UseCaseNames.License, new LicenseView()},
                                                     {UseCaseNames.RequirementsCheckup, new RequirementsCheckupView()},
                                                     {UseCaseNames.RequirementsInstall, new RequirementsInstallView()},
                                                     {UseCaseNames.Install, new InstallView()},
                                                     {UseCaseNames.InstallS, new InstallSelectionView()},
                                                     {UseCaseNames.End, new EndView()},
                                                     {UseCaseNames.RemoveTemp, new RemoveTempView()},
                                                     {UseCaseNames.Create, new CreateView()},
                                                 };

        private readonly IServiceLocator serviceLocator;
        private readonly InstallState installState;
        private ILogService logService;


        public Action<BaseViewState> OnStep { get; set; }
        public Action<object> OnStepView { get; set; }
        public Action<bool> OnExitWithConfiramtion { get; set; }
        public Action<bool> OnExitWithoutConfiramtion { get; set; }

        public string ApplicationName {
            get { return serviceLocator.Get<IInstallEnvironment>().ApplicationName; }
        }

        public UseCaseRunner(IServiceLocator serviceLocator) {
            this.serviceLocator = serviceLocator;
            installState = new InstallState(serviceLocator);
            RegisterUseCases();

            LogEnvironment();
        }

        private void LogEnvironment() {
            logService = serviceLocator.Get<ILogService>();
            var env = serviceLocator.Get<IInstallEnvironment>();

            logService.CreateLogFile(string.Format("log_{0}.{1}.{2}_{3}.log",
                                                   DateTime.Today.Day,
                                                   DateTime.Today.Month,
                                                   DateTime.Today.Year,
                                                   env.ApplicationName));
            logService.PrintDelimeter();
            logService.WriteToLog(string.Format("Start Time {0}", DateTime.Now));
            logService.WriteToLog("Application Name: " + env.ApplicationName);
            logService.WriteToLog("Application Version: " + env.ApplicationVersion);
            logService.WriteToLog("Application Preinstalled Version: " + env.ApplicationPreinstalledVersion);
            logService.WriteToLog("");
            logService.WriteToLog(string.Format("System {0} {1} (full ver. {2})", env.SystemVersion, env.SystemType, Environment.OSVersion));

            logService.PrintDelimeter();
            logService.WriteToLog("Command Line Args: " + string.Join(" ", Environment.GetCommandLineArgs()));
            logService.WriteToLog(".Net Version: " + Environment.Version);
            logService.WriteToLog("Processor Count: " + Environment.ProcessorCount);

            logService.PrintDelimeter();
        }


        public void RunNext(bool ignoredParam) {
            if (!string.IsNullOrEmpty(ProgramMode.RowParams)) {
                Run(UseCaseNames.Create);
                return;
            }

            if (currentUseCase == null)
                Run(UseCaseNames.Welcome);
            else
                Run(currentUseCase.BaseViewState.NextUseCase);
        }

        private void Run(UseCaseNames name) {
            currentName = name;
            logService.WriteToLog("Starting case: " + name);

            useCases[name].Run();
            ((IBaseView) views[name]).State = useCases[name].BaseViewState;
            OnStepView(views[name]);
            currentUseCase = useCases[name];

            RunBase();
            logService.WriteToLog("Finishing case: " + name);
            logService.PrintDelimeter();
        }

        private void RunPrev(bool ignoredParam) {
            if (currentUseCase == null)
                Run(UseCaseNames.Welcome);
            else
                Run(currentUseCase.BaseViewState.PrevUseCase);
        }

        private void RunBase() {
            currentUseCase.BaseViewState.NextStepAction = RunNext;
            currentUseCase.BaseViewState.PrevStepAction = RunPrev;

            currentUseCase.BaseViewState.AcceptChange += AcceptChange;
            currentUseCase.BaseViewState.ForceStep += Run;
            currentUseCase.BaseViewState.SendChange += AcceptChange;

            ExitMethodStyle();

            OnStep(currentUseCase.BaseViewState);
        }

        private void ExitMethodStyle() {
            if (currentUseCase.BaseViewState.CancelStepAction == OnExitWithConfiramtion ||
                currentUseCase.BaseViewState.CancelStepAction == OnExitWithoutConfiramtion)
                return;

            currentUseCase.BaseViewState.CancelStepAction =
                currentUseCase.BaseViewState.CancelStepAction == null
                    ? OnExitWithConfiramtion
                    : OnExitWithoutConfiramtion;
        }

        private void AcceptChange(bool obj) {
            ((IBaseView) views[currentName]).State = useCases[currentName].BaseViewState;
            ExitMethodStyle();
            OnStep(currentUseCase.BaseViewState);
        }

        private void RegisterUseCases() {
            useCases =
                new Dictionary<UseCaseNames, UseCaseBase> {
                                                              {UseCaseNames.Welcome, new WelcomeUseCase(installState)},
                                                              {UseCaseNames.License, new LicenseUseCase(installState)},
                                                              {UseCaseNames.RequirementsCheckup, new RequirementsCheckupUseCase(installState)},
                                                              {UseCaseNames.RequirementsInstall, new RequirementsInstallUseCase(installState)},
                                                              {UseCaseNames.Install, new InstallUseCase(installState)},
                                                              {UseCaseNames.InstallS, new InstallSelectionUseCase(installState)},
                                                              {UseCaseNames.End, new EndUseCase(installState)},
                                                              {UseCaseNames.RemoveTemp, new RemoveTempUseCase(installState)},
                                                              {UseCaseNames.Create, new CreateUseCase(installState)},
                                                          };
        }

        public void RunCancel() {
            if (currentName == UseCaseNames.RemoveTemp) return;

            if (!installState.InstallEnvironment.SystemAffected) {
                installState.InstallationType = InstallationType.Cancel;
                currentUseCase.BaseViewState.StopAllActions(true);


                logService.WriteToLog("End on " + DateTime.Now);
                OnExitWithoutConfiramtion(true);
                return;
            }

            logService.WriteToLog("End on " + DateTime.Now);
            Run(UseCaseNames.RemoveTemp);
        }

        public void Closing() {
            var service = installState.ServiceLocator.Get<IFileService>();
            service.DeleteDirectory(installState.InstallEnvironment.ExtractPath);
            logService.WriteToLog("End on " + DateTime.Now);
        }
    }
}