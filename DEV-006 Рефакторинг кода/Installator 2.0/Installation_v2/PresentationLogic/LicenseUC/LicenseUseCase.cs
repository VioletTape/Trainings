using Installation_v2.InstallationLogic;
using Installation_v2.PresentationLogic.Enums;
using Installation_v2.PresentationLogic.LicenseUC.DataState;

namespace Installation_v2.PresentationLogic.LicenseUC {
    public class LicenseUseCase : UseCaseBase {
        private LicenseViewState licenseViewState;

        public LicenseUseCase(InstallState installState) : base(installState) {}

        public override void DoConfigure() {
            licenseViewState = new LicenseViewState {
                                                        NextUseCase = UseCaseNames.InstallS,
                                                        PrevUseCase = UseCaseNames.Welcome,

                                                        NextStepCaption = "��������",
                                                        FinishStepCaption = "�� ��������",

                                                        StepCaption = "������������ ����������",
                                                        StepInstructions = "����������� � ������� ����������",
                                                        TrackName = TrackName.InfoGathering,

                                                        CancelStepAction = i => { }
                                                    };
             BaseViewState = licenseViewState;
        }
    }
}