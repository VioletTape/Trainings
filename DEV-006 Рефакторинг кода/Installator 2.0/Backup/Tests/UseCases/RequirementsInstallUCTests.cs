using System;
using System.Collections.Generic;
using Installation_v2.InstallationLogic;
using Installation_v2.InstallationLogic.Enums;
using Installation_v2.InstallationLogic.Interfaces;
using Installation_v2.PresentationLogic;
using Installation_v2.PresentationLogic.Enums;
using Installation_v2.PresentationLogic.RequirementsCheckupUC;
using Installation_v2.PresentationLogic.RequirementsInstallUC;
using Installation_v2.PresentationLogic.RequirementsInstallUC.DataState;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Fakes;

namespace Tests.UseCases {
    [TestClass]
    public class RequirementsInstallUCTests {
        private InstallState installState;

        [TestInitialize]
        public void TestInitialize() {
            installState = new InstallState(new ServiceLocatorFake());
        }

        [TestMethod]
        public void ShouldInitRequirementsInstallUC() {
            var useCase = new RequirementsInstallUseCase(installState);
            useCase.Run();

            var state = ((RequirementsInstallViewState) useCase.BaseViewState);

            Assert.AreEqual("Установка необходимых компонентов", state.StepCaption);
            Assert.AreEqual("Идет процесс установки необходимых компонентов", state.StepInstructions);
            Assert.AreEqual(TrackName.Install, state.TrackName);
            Assert.IsFalse(state.PrevStepVisible);
            Assert.IsFalse(state.NextStepVisible);

            Assert.IsFalse(state.ErrorLabelVisible);
            Assert.AreEqual("Не удалось выполнить операцию. Установка далее невозможна.", state.ErrorText);

            Assert.IsNotNull(state.StopAllActions);
        }

        [TestMethod]
        public void ShouldMoveStatusFromNotInstallToPending() {
            installState.Requirements.ForEach(i => i.RequirementState = RequirementState.NotInstalled);

            var useCase = new RequirementsInstallUseCase(installState);
            useCase.Run();

//            var state = ((RequirementsInstallViewState) useCase.BaseViewState);

            Assert.AreEqual(4, installState.Requirements.Count);

            Assert.AreEqual(RequirementState.Pending, installState.Requirements[0].RequirementState);
            Assert.AreEqual(RequirementState.Pending, installState.Requirements[1].RequirementState);
            Assert.AreEqual(RequirementState.Pending, installState.Requirements[2].RequirementState);
            Assert.AreEqual(RequirementState.Pending, installState.Requirements[3].RequirementState);
        }

        [TestMethod]
        public void ShouldMoveOnTheNextStep() {
            var runner = new UseCaseRunnerHelper();
            var requirementManager = ((RequirementManagerFake) runner.ServiceLocator.Get<IRequirementManager>());
            requirementManager.InstalledFrameworks = new List<string> {".NET CLR 3.5"};

            runner.RunNext();
            runner.BaseViewState.NextUseCase = UseCaseNames.RequirementsInstall;
            runner.RunNext();

            Assert.AreEqual(UseCaseNames.RequirementsInstall, runner.CurrentUseCaseName);
            var useCase = ((RequirementsInstallUseCase) runner.CurrentUseCase);

            useCase.Tick(new object(), new EventArgs());
            useCase.Tick(new object(), new EventArgs());
            useCase.Tick(new object(), new EventArgs());
            useCase.Tick(new object(), new EventArgs());

            Assert.AreEqual(UseCaseNames.Install, runner.CurrentUseCaseName);
        }

        [TestMethod]
        public void ShouldNotMoveOnTheNextStepIfErrors() {
            var runner = new UseCaseRunnerHelper();

            var installService = ((InstallServiceFake) runner.ServiceLocator.Get<IInstallService>());
            installService.InstallRequirementResult = new Result {OperationResult = OperationResult.Failed};

            installState.Requirements.ForEach(i => i.RequirementState = RequirementState.Pending);

            runner.RunNext();
            runner.BaseViewState.NextUseCase = UseCaseNames.RequirementsInstall;
            runner.RunNext();

            Assert.AreEqual(UseCaseNames.RequirementsInstall, runner.CurrentUseCaseName);
            var useCase = ((RequirementsInstallUseCase) runner.CurrentUseCase);

            useCase.Tick(new object(), new EventArgs());
            useCase.Tick(new object(), new EventArgs());
            useCase.Tick(new object(), new EventArgs());
            useCase.Tick(new object(), new EventArgs());

             Assert.AreEqual(UseCaseNames.RequirementsInstall, runner.CurrentUseCaseName);
            Assert.AreEqual("Закрыть", runner.BaseViewState.FinishStepCaption);
        }
    }
}