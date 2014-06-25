using System;
using System.Windows.Forms;
using Installation_v2.InstallationLogic;
using Installation_v2.InstallationLogic.Enums;
using Installation_v2.InstallationLogic.Interfaces;
using Installation_v2.PresentationLogic.Enums;
using Installation_v2.PresentationLogic.InstallUC.DataState;
using Installation_v2.PresentationLogic.RequirementsCheckupUC.DataState;

namespace Installation_v2.PresentationLogic.InstallUC {
    internal class InstallUseCase : UseCaseBase {
        private InstallViewState state;

        private readonly Timer timer = new Timer();
        private IInstallService installService;
        private Result Result;

        private int stepProcessing;

        public InstallUseCase(InstallState installState) : base(installState) {}

        public override void DoConfigure() {
            installService = InstallState.ServiceLocator.Get<IInstallService>();
            installService.StepReport += StepReport;

            state = new InstallViewState {
                                             StepCaption = "Установка, удаление программы",
                                             TrackName = TrackName.Install,
                                             PrevStepVisible = false,
                                             NextStepVisible = false,
                                             ProgressInfoLabel = "0/0",
                                             ProgressInfoVisible = false,
                                             ProgressMax = 0,
                                             ProgressStep = 0,
                                             ErrorMessage = ""
                                         };
            state.StopAllActions = StopAllActions;

            SetupRequirements();
            state.StepInstructions = GetStepInstructions();


            Bind();
            Result = new Result();
            timer.Interval = 1000;
            timer.Tick += Tick;
            timer.Start();
        }

        private void StopAllActions(bool obj) {
            timer.Stop();
        }

        internal void StepReport(string progress) {
            if (string.IsNullOrEmpty(progress)) {
                state.ProgressInfoVisible = false;
                state.SendChange(true);
                return;
            }

            state.ProgressInfoLabel = progress;
            state.ProgressInfoVisible = true;

            var split = progress.Split('/');

            state.ProgressMax = Convert.ToInt32(split[1]);
            state.ProgressStep = Convert.ToInt32(split[0]);
            state.SendChange(true);
        }

        internal void Tick(object sender, EventArgs e) {
            if (stepProcessing == InstallState.InstallReq.Count) {
                GotoNextStep();
                return;
            }
            var find = InstallState.InstallReq[stepProcessing];

            find.InstallState = RequirementState.Processing;
            state.SendChange(true);

            InstallState.LogService.WriteToLog("");
            InstallState.LogService.WriteToLog("Install: " + find.Title);

            switch (InstallState.InstallationType) {
                case InstallationType.Install:
                    Result = installService.InstallMain(find);
                    break;
                case InstallationType.Repair:
                    Result = installService.RepairMain(find);
                    break;
                case InstallationType.Delete:
                    Result = installService.DeleteMain(find);
                    break;
            }

            find.InstallState = Result.OperationResult == OperationResult.Succed
                                    ? RequirementState.Installed
                                    : RequirementState.NotInstalled;

            InstallState.LogService.WriteToLog("Installed : " + Result.OperationResult);

            state.Requirements[stepProcessing].Error = Result.OperationResult == OperationResult.Succed
                                                           ? "Ok"
                                                           : "Ошибка";
            state.Requirements[stepProcessing].ErrorFullText = Result.ErrorText;
            state.Requirements[stepProcessing].Status = ImageSetter.GetImage(find.InstallState);

            state.SendChange(true);
            stepProcessing++;
        }

        private void GotoNextStep() {
            timer.Stop();
            var requirement = InstallState.InstallReq.Find(i => i.InstallState == RequirementState.NotInstalled);
            if (requirement != null) {
                state.FinishStepCaption = "Закрыть";
                state.CancelStepAction = i => { };

                state.SendChange(true);
            }
            else {
                if (InstallState.InstallationType == InstallationType.Delete) {
                    state.ForceStep(UseCaseNames.End);
                }
                else {
                    state.ForceStep(UseCaseNames.RemoveTemp);
                }
            }
        }

        private void Bind() {
            BaseViewState = state;
        }

        private void SetupRequirements() {
            state.Requirements = InstallState.InstallReq.ConvertAll(i => new RequirementsViewState {
                                                                                                       Caption = i.Title,
                                                                                                       Status = ImageSetter.GetImage(i.InstallState),
                                                                                                       Error = "",
                                                                                                       ErrorFullText = ""
                                                                                                   });
        }

        private string GetStepInstructions() {
            var result = "";
            switch (InstallState.InstallationType) {
                case InstallationType.Install:
                    result = "Идет процесс установки";
                    break;
                case InstallationType.Repair:
                    result = "Идет переустановка программы";
                    break;
                case InstallationType.Delete:
                    result = "Идет удаление программы";
                    break;
            }
            return result;
        }
    }
}