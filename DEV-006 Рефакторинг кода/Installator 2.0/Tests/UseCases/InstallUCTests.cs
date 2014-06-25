using System;
using Installation_v2.InstallationLogic;
using Installation_v2.InstallationLogic.Enums;
using Installation_v2.InstallationLogic.Interfaces;
using Installation_v2.PresentationLogic;
using Installation_v2.PresentationLogic.Enums;
using Installation_v2.PresentationLogic.InstallUC;
using Installation_v2.PresentationLogic.InstallUC.DataState;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Fakes;

namespace Tests.UseCases {
    [TestClass]
    public class InstallUCTests {
        private InstallState installState;

        [TestInitialize]
        public void TestInitialize() {
            installState = new InstallState(new ServiceLocatorFake());
        }

        [TestMethod]
        public void ShouldInitInstallUC() {
            var useCase = new InstallUseCase(installState);
            useCase.Run();

            var state = ((InstallViewState) useCase.BaseViewState);

            Assert.AreEqual("Установка, удаление программы", state.StepCaption);
            Assert.AreEqual(TrackName.Install, state.TrackName);
            Assert.IsFalse(state.PrevStepVisible);
            Assert.IsFalse(state.NextStepVisible);

            Assert.IsFalse(state.ProgressInfoVisible);
            Assert.AreEqual(0, state.ProgressMax);
            Assert.AreEqual(0, state.ProgressStep);
            Assert.AreEqual("0/0", state.ProgressInfoLabel);

            Assert.AreEqual("", state.ErrorMessage);

            Assert.IsNotNull(state.StopAllActions);
        }

        [TestMethod]
        public void StepInstructionOnInstall() {
            installState.InstallationType = InstallationType.Install;
            var useCase = new InstallUseCase(installState);
            useCase.Run();

            var state = ((InstallViewState) useCase.BaseViewState);

            Assert.AreEqual("Идет процесс установки", state.StepInstructions);
        }

        [TestMethod]
        public void StepInstructionOnRepair() {
            installState.InstallationType = InstallationType.Repair;
            var useCase = new InstallUseCase(installState);
            useCase.Run();

            var state = ((InstallViewState) useCase.BaseViewState);

            Assert.AreEqual("Идет переустановка программы", state.StepInstructions);
        }

        [TestMethod]
        public void StepInstructionOnDelete() {
            installState.InstallationType = InstallationType.Delete;
            var useCase = new InstallUseCase(installState);
            useCase.Run();

            var state = ((InstallViewState) useCase.BaseViewState);

            Assert.AreEqual("Идет удаление программы", state.StepInstructions);
        }

        [TestMethod]
        public void StepInfoVisible() {
            var useCase = new InstallUseCase(installState);
            useCase.Run();
            var state = ((InstallViewState) useCase.BaseViewState);
            state.SendChange = i => { };

            useCase.StepReport("2/7");

            Assert.IsTrue(state.ProgressInfoVisible);
            Assert.AreEqual(7, state.ProgressMax);
            Assert.AreEqual(2, state.ProgressStep);
            Assert.AreEqual("2/7", state.ProgressInfoLabel);
        }

        [TestMethod]
        public void StepInfoHide() {
            var useCase = new InstallUseCase(installState);
            useCase.Run();
            var state = ((InstallViewState) useCase.BaseViewState);
            state.SendChange = i => { };

            useCase.StepReport("");

            Assert.IsFalse(state.ProgressInfoVisible);
        }

        [TestMethod]
        public void ProcessInstallingStepSuccess() {
            var helper = new UseCaseRunnerHelper();
            var installService = ((InstallServiceFake) helper.ServiceLocator.Get<IInstallService>());
            installService.InstallMainResult = new Result {OperationResult = OperationResult.Succed};

            helper.Run(UseCaseNames.Install);

            var useCase = ((InstallUseCase) helper.CurrentUseCase);
            useCase.InstallState.InstallationType = InstallationType.Install;
            useCase.InstallState.InstallReq.ForEach(i => i.InstallState = RequirementState.Pending);

            useCase.Tick(new object(), new EventArgs());

            Assert.AreEqual(RequirementState.Installed, useCase.InstallState.InstallReq[0].InstallState);
        }

        [TestMethod]
        public void ProcessRepairingStepSuccess() {
            var helper = new UseCaseRunnerHelper();
            var installService = ((InstallServiceFake) helper.ServiceLocator.Get<IInstallService>());
            installService.InstallMainResult = new Result {OperationResult = OperationResult.Succed};

            helper.Run(UseCaseNames.Install);

            var useCase = ((InstallUseCase) helper.CurrentUseCase);
            useCase.InstallState.InstallationType = InstallationType.Repair;
            useCase.InstallState.InstallReq.ForEach(i => i.InstallState = RequirementState.Pending);

            useCase.Tick(new object(), new EventArgs());

            Assert.AreEqual(RequirementState.Installed, useCase.InstallState.InstallReq[0].InstallState);
        }

        [TestMethod]
        public void ProcessDeletingStepSuccess() {
            var helper = new UseCaseRunnerHelper();
            var installService = ((InstallServiceFake) helper.ServiceLocator.Get<IInstallService>());
            installService.InstallMainResult = new Result {OperationResult = OperationResult.Succed};

            helper.Run(UseCaseNames.Install);

            var useCase = ((InstallUseCase) helper.CurrentUseCase);
            useCase.InstallState.InstallationType = InstallationType.Delete;
            useCase.InstallState.InstallReq.ForEach(i => i.InstallState = RequirementState.Pending);

            useCase.Tick(new object(), new EventArgs());

            Assert.AreEqual(RequirementState.Installed, useCase.InstallState.InstallReq[0].InstallState);
        }

        [TestMethod]
        public void ProcessInstallingStepFailed() {
            var helper = new UseCaseRunnerHelper();
            var installService = ((InstallServiceFake) helper.ServiceLocator.Get<IInstallService>());
            installService.InstallMainResult = new Result {OperationResult = OperationResult.Failed};

            helper.Run(UseCaseNames.Install);

            var useCase = ((InstallUseCase) helper.CurrentUseCase);
            useCase.InstallState.InstallationType = InstallationType.Install;
            useCase.InstallState.InstallReq.ForEach(i => i.InstallState = RequirementState.Pending);

            useCase.Tick(new object(), new EventArgs());

            Assert.AreEqual(RequirementState.NotInstalled, useCase.InstallState.InstallReq[0].InstallState);
        }

        [TestMethod]
        public void ShowRemoveTempOnSuccessfullInstallation() {
            var helper = new UseCaseRunnerHelper();
            helper.Run(UseCaseNames.Install);

            var useCase = ((InstallUseCase) helper.CurrentUseCase);
            useCase.InstallState.InstallationType = InstallationType.Install;
            useCase.InstallState.InstallReq.ForEach(i => i.InstallState = RequirementState.Installed);

            Assert.AreEqual(UseCaseNames.Install, helper.CurrentUseCaseName);

            useCase.Tick(new object(), new EventArgs());
            useCase.Tick(new object(), new EventArgs());
            useCase.Tick(new object(), new EventArgs());
            useCase.Tick(new object(), new EventArgs());
            useCase.Tick(new object(), new EventArgs());
            useCase.Tick(new object(), new EventArgs());
            useCase.Tick(new object(), new EventArgs());

            Assert.AreEqual(UseCaseNames.RemoveTemp, helper.CurrentUseCaseName);
        }

        [TestMethod]
        public void DontShowRemoveTempOnSuccessfullDelete() {
            var helper = new UseCaseRunnerHelper();
            helper.Run(UseCaseNames.Install);

            var useCase = ((InstallUseCase) helper.CurrentUseCase);

            useCase.InstallState.InstallationType = InstallationType.Delete;
            useCase.InstallState.InstallReq.ForEach(i => i.InstallState = RequirementState.Installed);

            Assert.AreEqual(UseCaseNames.Install, helper.CurrentUseCaseName);

            useCase.Tick(new object(), new EventArgs());
            useCase.Tick(new object(), new EventArgs());
            useCase.Tick(new object(), new EventArgs());
            useCase.Tick(new object(), new EventArgs());
            useCase.Tick(new object(), new EventArgs());
            useCase.Tick(new object(), new EventArgs());
            useCase.Tick(new object(), new EventArgs());

            Assert.AreEqual(UseCaseNames.End, helper.CurrentUseCaseName);
        }

        [TestMethod]
        public void StayOnSameScreenOnError() {
             var helper = new UseCaseRunnerHelper();
            helper.Run(UseCaseNames.Install);

            var useCase = ((InstallUseCase) helper.CurrentUseCase);
            useCase.InstallState.InstallationType = InstallationType.Install;
            useCase.InstallState.InstallReq.ForEach(i => i.InstallState = RequirementState.NotInstalled);

            Assert.AreEqual(UseCaseNames.Install, helper.CurrentUseCaseName);

            useCase.Tick(new object(), new EventArgs());

            Assert.AreEqual(UseCaseNames.Install, helper.CurrentUseCaseName);
        }
    }
}