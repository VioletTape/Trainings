using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Installation_v2.InstallationLogic;
using Installation_v2.InstallationLogic.Enums;
using Installation_v2.InstallationLogic.Interfaces;
using Installation_v2.PresentationLogic.Enums;
using Installation_v2.PresentationLogic.RequirementsCheckupUC.DataState;
using Installation_v2.PresentationLogic.RequirementsInstallUC.DataState;

namespace Installation_v2.PresentationLogic.RequirementsInstallUC {
    public class RequirementsInstallUseCase : UseCaseBase {
        private RequirementsInstallViewState state;
        private readonly Timer timer = new Timer();
        private List<Requirement> requirements;
        private List<Result> results;
        private IInstallService installService;


        public RequirementsInstallUseCase(InstallState installState) : base(installState) {}

        public override void DoConfigure() {
            installService = InstallState.ServiceLocator.Get<IInstallService>();

            state = new RequirementsInstallViewState {
                                                         StepCaption = "Установка необходимых компонентов",
                                                         StepInstructions = "Идет процесс установки необходимых компонентов",
                                                         TrackName = TrackName.Install,
                                                         PrevStepVisible = false,
                                                         NextStepVisible = false,
                                                         ErrorLabelVisible = false,
                                                         ErrorText = "Не удалось выполнить операцию. Установка далее невозможна."
                                                     };
            state.StopAllActions = StopAllActions;

            UpdateRequirementsState();
            SetupRequirements();

            Bind();
            timer.Interval = 200;
            timer.Tick += Tick;
            timer.Start();
        }

        private void StopAllActions(bool obj) {
            timer.Stop();
        }

        private void UpdateRequirementsState() {
            requirements = InstallState.Requirements.FindAll(i => i.RequirementState == RequirementState.NotInstalled);
            requirements.ForEach(i => i.RequirementState = RequirementState.Pending);
            results = new List<Result>(requirements.Count);
        }

        internal void Tick(object sender, EventArgs e) {
            var requirement = requirements.Find(i => i.RequirementState == RequirementState.Pending);
            if (requirement == null) {
                GotoNextStep();
            }
            else {
                requirement.RequirementState = RequirementState.Processing;
                SetupRequirements();
                state.SendChange(true);

                InstallState.LogService.WriteToLog("");
                InstallState.LogService.WriteToLog("Install Requirement: " + requirement.Title);

                var result = installService.InstallRequirement(requirement);
                
                requirement.RequirementState = result.OperationResult == OperationResult.Succed
                                                   ? RequirementState.Installed
                                                   : RequirementState.NotInstalled;
                InstallState.LogService.WriteToLog("Operation Result: " + result.OperationResult);
                results.Add(result);
                SetupRequirements();
                state.SendChange(true);
            }
        }

        private void SetupRequirements() {
            var all = requirements.ConvertAll(i => new RequirementsViewState {
                                                                                 Caption = i.Title,
                                                                                 Status = ImageSetter.GetImage(i.RequirementState),
                                                                                 Error = "",
                                                                                 ErrorFullText = ""
                                                                             });
            for (var i = 0; i < results.Count; i++) {
                all[i].Error = results[i].OperationResult == OperationResult.Succed
                                                           ? "Ok"
                                                           : "Ошибка";
                all[i].ErrorFullText = results[i].ErrorText;
            }
            state.Requirements = all;
        }


        private void GotoNextStep() {
            timer.Stop();
            var requirement = InstallState.Requirements.Find(i => i.RequirementState == RequirementState.NotInstalled);
            if (requirement != null) {
                state.FinishStepCaption = "Закрыть";
                state.CancelStepAction = i => { };
                state.ErrorLabelVisible = true;
                state.SendChange(true);
            }
            else {
                state.ForceStep(UseCaseNames.Install);
            }
        }

        private void Bind() {
            BaseViewState = state;
        }
    }
}