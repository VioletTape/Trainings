using Installation_v2.InstallationLogic;
using Installation_v2.InstallationLogic.Enums;
using Installation_v2.PresentationLogic;
using Installation_v2.PresentationLogic.Enums;
using Installation_v2.PresentationLogic.WelcomeUC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Fakes;

namespace Tests {
    [TestClass]
    public class WelcomeUCTests {
        private InstallState installState;
        private InstallEnvironmentFake installEnvironment;

        [TestInitialize]
        public void TestInitialize() {
            installState = new InstallState(new ServiceLocatorFake());
            installEnvironment = ((InstallEnvironmentFake) installState.InstallEnvironment);
            installEnvironment.ApplicationName = "Company";
        }

        [TestMethod]
        public void CheckUpUseCaseSettings() {
            var useCase = new WelcomeUseCase(installState);
            useCase.Run();
            var state = useCase.state;

            Assert.AreEqual("�����������", state.StepCaption);
            Assert.AreEqual(false, state.PrevStepVisible);
            Assert.AreEqual(UseCaseNames.License, state.NextUseCase);
            Assert.AreEqual(TrackName.InfoGathering, state.TrackName);
        }

        [TestMethod]
        public void CaptionWhenNoPrevInstalledVersion() {
            installEnvironment.ApplicationPreinstalledVersion = string.Empty;
            installEnvironment.ApplicationVersion = "1.0.1";

            var useCase = new WelcomeUseCase(installState);
            useCase.Run();
            var state = useCase.state;

            Assert.AreEqual("��� ������������ ��������� ��������� Company.\r\n\r\n����� ����������� ��������� ������ 1.0.1\r\n", state.StepInstructions);
        }

        [TestMethod]
        public void CaptionWhenOlderPrevInstalledVersion() {
            installEnvironment.ApplicationPreinstalledVersion = "1.0.1";
            installEnvironment.ApplicationVersion = "1.0.4";

            var useCase = new WelcomeUseCase(installState);
            useCase.Run();
            var state = useCase.state;

            Assert.AreEqual("��� ������������ ��������� ��������� Company.\r\n\r\n������ ��������� ������ 1.0.1 ��� ���� �����������,\r\n� �������� ��������� ��� ����� ��������� �� ������ 1.0.4\r\n", state.StepInstructions);
        }

        [TestMethod]
        public void CaptionWhenNewerPrevInstalledVersion() {
            installEnvironment.ApplicationPreinstalledVersion = "1.0.9";
            installEnvironment.ApplicationVersion = "1.0.4";

            var useCase = new WelcomeUseCase(installState);
            useCase.Run();
            var state = useCase.state;

            Assert.AreEqual("��� ������������ ��������� ��������� Company.\r\n\r\n������ ��������� ������ 1.0.9 ��� ���� �����������,\r\n����������� ��������� �� �������������.\r\n", state.StepInstructions);
        }

        [TestMethod]
        public void InstallIfMetMinimumVersion() {
            installEnvironment.ApplicationPreinstalledVersion = "1.0.5";
            installEnvironment.MinimumVersionToUpdate = "1.0.5";
            installEnvironment.ApplicationVersion = "1.0.7";

            var useCase = new WelcomeUseCase(installState);
            useCase.Run();
            var state = useCase.state;

            Assert.IsTrue(state.NextStepVisible);
            Assert.AreEqual("������", state.FinishStepCaption);
        }

        [TestMethod]
        public void DenyInstallIfNotMetMinimumVersion() {
            installEnvironment.ApplicationPreinstalledVersion = "1.0.4";
            installEnvironment.MinimumVersionToUpdate = "1.0.5";
            installEnvironment.ApplicationVersion = "1.0.7";

            var useCase = new WelcomeUseCase(installState);
            useCase.Run();
            var state = useCase.state;

            Assert.IsFalse(state.NextStepVisible);
            Assert.AreEqual("�������", state.FinishStepCaption);
        }

         [TestMethod]
        public void DenyTextIfNotMetMinimumVersion() {
            installEnvironment.ApplicationPreinstalledVersion = "1.0.4";
            installEnvironment.MinimumVersionToUpdate = "1.0.5";
            installEnvironment.ApplicationVersion = "1.0.7";

            var useCase = new WelcomeUseCase(installState);
            useCase.Run();
            var state = useCase.state;

            Assert.AreEqual("��� ������������ ��������� ��������� Company.\r\n\r\n������ ���������� ���������� �� ������ 1.0.4. �������� �� 1.0.5.", state.StepInstructions);
        }

        [TestMethod]
        public void InstallTypeInNormalSituation() {
            installEnvironment.ApplicationPreinstalledVersion = "1.0.5";
            installEnvironment.MinimumVersionToUpdate = "1.0.5";
            installEnvironment.ApplicationVersion = "1.0.7";

            var useCase = new WelcomeUseCase(installState);
            useCase.Run();

            Assert.AreEqual(InstallationType.Install, useCase.InstallState.InstallationType); 
        }

        [TestMethod]
        public void InstallTypeInRepairSituation() {
            installEnvironment.ApplicationPreinstalledVersion = "1.0.7";
            installEnvironment.MinimumVersionToUpdate = "1.0.5";
            installEnvironment.ApplicationVersion = "1.0.7";

            var useCase = new WelcomeUseCase(installState);
            useCase.Run();

            Assert.AreEqual(InstallationType.Repair, useCase.InstallState.InstallationType); 
        }
    }
}