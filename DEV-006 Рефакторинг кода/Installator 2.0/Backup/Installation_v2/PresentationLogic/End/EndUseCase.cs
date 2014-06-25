using Installation_v2.InstallationLogic;
using Installation_v2.InstallationLogic.Interfaces;
using Installation_v2.PresentationLogic.End.DataState;

namespace Installation_v2.PresentationLogic.End {
    public class EndUseCase  : UseCaseBase{
        public EndUseCase(InstallState installState) : base(installState) {}

        public override void DoConfigure() {
            var installService = ServiceLocator.Get<IInstallService>();
            BaseViewState = new EndViewState {
                                                StepCaption = "���������� ���������",
                                                StepInstructions = "�������, ��� ������� ���",

                                                NextStepVisible = false,
                                                PrevStepVisible = false,

                                                FinishStepCaption = "���������",
                                                TrackName = TrackName.Finish,

                                                CancelStepAction = i => { },
                                             };

            installService.CreateShortcutOnDesktop();
            installService.CreateShortcutOnProgram();

            var fileService = ServiceLocator.Get<IFileService>();
            var installPath = InstallState.InstallEnvironment.InstallPath;

            fileService.DeleteFile(installPath, "dc.cache");
        }
    }
}