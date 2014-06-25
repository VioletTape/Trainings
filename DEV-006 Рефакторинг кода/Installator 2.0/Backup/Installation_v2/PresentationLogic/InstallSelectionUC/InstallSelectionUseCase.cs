using Installation_v2.InstallationLogic;
using Installation_v2.InstallationLogic.Enums;
using Installation_v2.PresentationLogic.Enums;
using Installation_v2.PresentationLogic.InstallSelectionUC.DataState;

namespace Installation_v2.PresentationLogic.InstallSelectionUC {
    public class InstallSelectionUseCase : UseCaseBase {
        private InstallSelectionViewState state;

        public InstallSelectionUseCase(InstallState installState) : base(installState) {}

        public override void DoConfigure() {
            state = new InstallSelectionViewState {
                                                      StepCaption = "Установка, удаление программы",
                                                      StepInstructions = "Выбор режима работы установщика",
                                                      NextUseCase = UseCaseNames.RequirementsCheckup,
                                                      PrevUseCase = UseCaseNames.License,
                                                      TrackName = TrackName.Setup,
                                                      NextStepCaption = "Установить",
                                                      Install = InstallAction,
                                                      Repair = RepairAction,
                                                      Delete = DeleteAction,
                                                      InstallPath = InstallEnvironment.InstallPath,
                                                      InstallOptionVisible = (InstallState.InstallationType == InstallationType.Install),
                                                  };

            state.NextStepCaption = InstallState.InstallationType == InstallationType.Install
                                        ? "Установить"
                                        : "Восстановить";

            

            if (InstallState.InstallEnvironment.LightUpdate) {
                InstallState.Requirements.ForEach(r => r.RequirementState = RequirementState.Installed);
                InstallState.Requirements.Find(r => r.Sequence == 11).RequirementState = RequirementState.NotInstalled;
            }

            Bind();
            BaseViewState.AcceptChange += AcceptChange;
        }

        private void DeleteAction(object obj) {
            InstallState.InstallEnvironment.SystemAffected = false;

            InstallState.InstallationType = InstallationType.Delete;
            InstallState.LogService.WriteToLog("Installation Type" + InstallState.InstallationType);
            
            state.ForceStep(UseCaseNames.Install);
        }

        private void RepairAction(object obj) {
            InstallState.InstallationType = InstallationType.Repair;
            InstallState.LogService.WriteToLog("Installation Type" + InstallState.InstallationType);

            state.ForceStep(UseCaseNames.Install);
        }

        private void InstallAction(object obj) {
            InstallState.InstallationType = InstallationType.Install;
            InstallState.LogService.WriteToLog("Installation Type" + InstallState.InstallationType);
            
            state.ForceStep(UseCaseNames.RequirementsCheckup);
        }

        private void Bind() {
            BaseViewState = state;
        }

        private void AcceptChange(bool obj) {
            state = ((InstallSelectionViewState) BaseViewState);
            InstallEnvironment.InstallPath = state.InstallPath;
            InstallState.LogService.WriteToLog("Install Path " + InstallEnvironment.InstallPath);
            Bind();
        }
    }
}