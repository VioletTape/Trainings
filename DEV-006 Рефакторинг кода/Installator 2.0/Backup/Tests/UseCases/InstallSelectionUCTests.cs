using Installation_v2.InstallationLogic;
using Installation_v2.InstallationLogic.Enums;
using Installation_v2.PresentationLogic;
using Installation_v2.PresentationLogic.Enums;
using Installation_v2.PresentationLogic.InstallSelectionUC;
using Installation_v2.PresentationLogic.InstallSelectionUC.DataState;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Fakes;

namespace Tests.UseCases {
    [TestClass]
    public class InstallSelectionUCTests {
        private InstallState installState;

        [TestInitialize]
        public void TestInitialize() {
            installState = new InstallState(new ServiceLocatorFake());
        }

        [TestMethod]
        public void ShouldInitInstallSelection() {
            var useCase = new InstallSelectionUseCase(installState);
            useCase.Run();

            var state = ((InstallSelectionViewState) useCase.BaseViewState);

            Assert.AreEqual("Установка, удаление программы", state.StepCaption);
            Assert.AreEqual("Выбор режима работы установщика", state.StepInstructions);

            Assert.AreEqual(UseCaseNames.RequirementsCheckup, state.NextUseCase);
            Assert.AreEqual(UseCaseNames.License, state.PrevUseCase);

            Assert.AreEqual(TrackName.Setup, state.TrackName);

            Assert.IsNotNull(state.Install);
            Assert.IsNotNull(state.Repair);
            Assert.IsNotNull(state.Delete);

            Assert.AreEqual(useCase.InstallEnvironment.InstallPath, state.InstallPath);

            Assert.IsTrue(useCase.InstallEnvironment.SystemAffected);
        }

        [TestMethod]
        public void ShouldShowInstallButtonInNormalInstall() {
            installState.InstallationType = InstallationType.Install;

            var useCase = new InstallSelectionUseCase(installState);
            useCase.Run();

            var state = ((InstallSelectionViewState) useCase.BaseViewState);

            Assert.AreEqual("Установить", state.NextStepCaption);
            Assert.IsTrue(state.InstallOptionVisible);
        }

        [TestMethod]
        public void ShouldHideInstallButtonWhenReinstall() {
            installState.InstallationType = InstallationType.Repair;

            var useCase = new InstallSelectionUseCase(installState);
            useCase.Run();

            var state = ((InstallSelectionViewState) useCase.BaseViewState);

            Assert.AreEqual("Восстановить", state.NextStepCaption);
            Assert.IsFalse(state.InstallOptionVisible);
        }

        [TestMethod]
        public void ActionOnInstall() {
            var useCase = new InstallSelectionUseCase(installState);
            useCase.Run();
            var state = ((InstallSelectionViewState) useCase.BaseViewState);

            state.Install(true);

            Assert.AreEqual(InstallationType.Install, useCase.InstallState.InstallationType);
            Assert.IsTrue(useCase.InstallEnvironment.SystemAffected);
        }

        [TestMethod]
        public void ActionOnRepair() {
            var useCase = new InstallSelectionUseCase(installState);
            useCase.Run();
            var state = ((InstallSelectionViewState) useCase.BaseViewState);

            state.Repair(true);

            Assert.AreEqual(InstallationType.Repair, useCase.InstallState.InstallationType);
            Assert.IsTrue(useCase.InstallEnvironment.SystemAffected);
        }

        [TestMethod]
        public void ActionOnDelete() {
            var useCase = new InstallSelectionUseCase(installState);
            useCase.Run();
            var state = ((InstallSelectionViewState) useCase.BaseViewState);

            state.Delete(true);

            Assert.AreEqual(InstallationType.Delete, useCase.InstallState.InstallationType);
            Assert.IsFalse(useCase.InstallEnvironment.SystemAffected);
        }

        [TestMethod]
        public void ShouldAcceptNewInstallPath() {
            var useCase = new InstallSelectionUseCase(installState);
            useCase.Run();
            var state = ((InstallSelectionViewState) useCase.BaseViewState);

            state.InstallPath = @"c:\temp";
            state.AcceptChange(true);

            Assert.AreEqual(@"c:\temp", installState.InstallEnvironment.InstallPath);
            
        }
    }
}