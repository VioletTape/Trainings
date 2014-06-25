using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Installation_v2.InstallationLogic;
using Installation_v2.InstallationLogic.Enums;
using Installation_v2.InstallationLogic.Interfaces;
using Installation_v2.PresentationLogic.Enums;
using Installation_v2.PresentationLogic.RequirementsCheckupUC.DataState;

namespace Installation_v2.PresentationLogic.RequirementsCheckupUC {
    public class RequirementsCheckupUseCase : UseCaseBase {
        private RequirementCheckupViewState state;
        private Timer timer = new Timer();
        private List<Requirement> requirement;
        private IRequirementService requirementService;

        public RequirementsCheckupUseCase(InstallState installState) : base(installState) {}

        public override void DoConfigure() {
            requirementService = ServiceLocator.Get<IRequirementService>();

            state = new RequirementCheckupViewState {
                                                        StepCaption = "Установка необходимых компонентов",
                                                        StepInstructions = "Идет процесс проверки необходимых компонентов",
                                                        TrackName = TrackName.Install,
                                                        PrevStepVisible = false,
                                                        NextStepVisible = false
                                                    };

            state.StopAllActions = StopAllActions;

            InstallState.InstallEnvironment.SystemAffected = true;

            requirement = InstallState.Requirements.FindAll(i => i.RequirementState == RequirementState.Unknow);

            SetupRequirements();

            BaseViewState = state;


            timer.Interval = 200;
            timer.Tick += Tick;
            timer.Start();
        }

        internal void StopAllActions(bool obj) {
            timer.Stop();
        }

        private void SetupRequirements() {
            state.Requirements = requirement.ConvertAll(i => new RequirementsViewState {
                                                                                           Caption = i.Title,
                                                                                           Status = ImageSetter.GetImage(i.RequirementState)
                                                                                       });
        }

        internal void Tick(object sender, EventArgs e) {
            var find = InstallState.Requirements.Find(i => i.RequirementState == RequirementState.Unknow);
            if (find == null) {
                GotoNextStep();
            }
            else {
                find.RequirementState = RequirementState.Processing;
                SetupRequirements();
                state.SendChange(true);

                InstallState.LogService.WriteToLog("Checkup Requirements: " + find.Title);
                requirementService.ProcessRequirements(find);
                
                SetupRequirements();
                state.SendChange(true);
            }
        }

        private void GotoNextStep() {
            timer.Stop();
            state.ForceStep(UseCaseNames.RequirementsInstall);
        }
    }
}