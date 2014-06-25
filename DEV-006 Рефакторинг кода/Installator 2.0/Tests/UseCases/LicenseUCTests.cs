using Installation_v2.InstallationLogic;
using Installation_v2.PresentationLogic;
using Installation_v2.PresentationLogic.Enums;
using Installation_v2.PresentationLogic.LicenseUC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Fakes;

namespace Tests.UseCases {
    [TestClass]
    public class LicenseUCTests {
        private InstallState installState;

        [TestInitialize]
        public void TestInitialize() {
            installState = new InstallState(new ServiceLocatorFake());
        }

        [TestMethod]
        public void ShouldInitLicenseUC() {
            var useCase = new LicenseUseCase(installState);
            useCase.Run();

            var state = useCase.BaseViewState;

            Assert.AreEqual("������������ ����������", state.StepCaption);
            Assert.AreEqual("����������� � ������� ����������", state.StepInstructions);

            Assert.AreEqual(UseCaseNames.InstallS, state.NextUseCase);
            Assert.AreEqual(UseCaseNames.Welcome, state.PrevUseCase);

            Assert.AreEqual("��������", state.NextStepCaption);
            Assert.AreEqual("�� ��������", state.FinishStepCaption);

            Assert.AreEqual(TrackName.InfoGathering, state.TrackName);

            Assert.IsNotNull(state.CancelStepAction);
        }
    }
}