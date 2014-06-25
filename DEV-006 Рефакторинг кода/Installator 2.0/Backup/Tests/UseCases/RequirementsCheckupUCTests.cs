using System;
using System.Collections.Generic;
using System.Reflection;
using Installation_v2.InstallationLogic;
using Installation_v2.InstallationLogic.Enums;
using Installation_v2.InstallationLogic.Interfaces;
using Installation_v2.PresentationLogic;
using Installation_v2.PresentationLogic.Enums;
using Installation_v2.PresentationLogic.RequirementsCheckupUC;
using Installation_v2.PresentationLogic.RequirementsCheckupUC.DataState;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Fakes;

namespace Tests.UseCases {
    [TestClass]
    public class RequirementsCheckupUCTests {
        private InstallState installState;


        [TestInitialize]
        public void TestInitialize() {
            installState = new InstallState(new ServiceLocatorFake());
        }

        [TestMethod]
        public void ShouldInitRequirementsCheckup() {
            var useCase = new RequirementsCheckupUseCase(installState);
            useCase.Run();

            var state = ((RequirementCheckupViewState) useCase.BaseViewState);

            Assert.AreEqual("Установка необходимых компонентов", state.StepCaption);
            Assert.AreEqual("Идет процесс проверки необходимых компонентов", state.StepInstructions);
            Assert.AreEqual(TrackName.Install, state.TrackName);
            Assert.IsFalse(state.PrevStepVisible);
            Assert.IsFalse(state.NextStepVisible);

            Assert.IsNotNull(state.StopAllActions);
        }


        [TestMethod]
        public void ShouldConvertRequirements_x64() {
            ((InstallEnvironmentFake) installState.InstallEnvironment).SystemType = SystemType.x64;
            ((InstallEnvironmentFake) installState.InstallEnvironment).SystemVersion = SystemVersion.Vista;

            var useCase = new RequirementsCheckupUseCase(installState);
            useCase.Run();

            var state = ((RequirementCheckupViewState) useCase.BaseViewState);


            Assert.AreEqual(SystemType.x64, installState.InstallEnvironment.SystemType);
            Assert.AreEqual(3, state.Requirements.Count);

            Assert.AreEqual(".Net Framework 3.5 или выше", state.Requirements[0].Caption);
            Assert.AreEqual("Sql Server Compact Edition 3.5 или выше", state.Requirements[1].Caption);
            Assert.AreEqual("Sql Server Compact Edition 3.5 (x64 патч) или выше", state.Requirements[2].Caption);
        }

        [TestMethod]
        public void ShouldConvertRequirements_x86XP() {
            ((InstallEnvironmentFake) installState.InstallEnvironment).SystemType = SystemType.x86;
            ((InstallEnvironmentFake) installState.InstallEnvironment).SystemVersion = SystemVersion.XP;

            var useCase = new RequirementsCheckupUseCase(installState);
            useCase.Run();

            var state = ((RequirementCheckupViewState) useCase.BaseViewState);


            Assert.AreEqual(SystemType.x86, installState.InstallEnvironment.SystemType);
            Assert.AreEqual(3, state.Requirements.Count);

            Assert.AreEqual("Windows Installer 3.1 или выше", state.Requirements[0].Caption);
            Assert.AreEqual(".Net Framework 3.5 или выше", state.Requirements[1].Caption);
            Assert.AreEqual("Sql Server Compact Edition 3.5 или выше", state.Requirements[2].Caption);
        }

        [TestMethod]
        public void ShouldConvertRequirements_x86Vista() {
            ((InstallEnvironmentFake) installState.InstallEnvironment).SystemType = SystemType.x86;
            ((InstallEnvironmentFake) installState.InstallEnvironment).SystemVersion = SystemVersion.Vista;

            var useCase = new RequirementsCheckupUseCase(installState);
            useCase.Run();

            var state = ((RequirementCheckupViewState) useCase.BaseViewState);


            Assert.AreEqual(SystemType.x86, installState.InstallEnvironment.SystemType);
            Assert.AreEqual(2, state.Requirements.Count);

            Assert.AreEqual(".Net Framework 3.5 или выше", state.Requirements[0].Caption);
            Assert.AreEqual("Sql Server Compact Edition 3.5 или выше", state.Requirements[1].Caption);
        }


        [TestMethod]
        public void ShouldMoveOnTheNextStep() {
            var runner = new UseCaseRunnerHelper();
            var requirementManager = ((RequirementManagerFake) runner.ServiceLocator.Get<IRequirementManager>());
            requirementManager.InstalledFrameworks = new List<string> {".NET CLR 3.5"};

            runner.RunNext();
            runner.BaseViewState.NextUseCase = UseCaseNames.RequirementsCheckup;
            runner.RunNext();

            Assert.AreEqual(UseCaseNames.RequirementsCheckup, runner.CurrentUseCaseName);
            var useCase = ((RequirementsCheckupUseCase) runner.CurrentUseCase);

            useCase.Tick(new object(), new EventArgs());
            useCase.Tick(new object(), new EventArgs());
            useCase.Tick(new object(), new EventArgs());

            Assert.AreEqual(UseCaseNames.RequirementsInstall, runner.CurrentUseCaseName);
        }

        [TestMethod]
        public void ChangeStatusOnTick() {
            var installEnvironment = ((InstallEnvironmentFake) installState.InstallEnvironment);
            var requirementManager = ((RequirementManagerFake) installState.ServiceLocator.Get<IRequirementManager>());

            installEnvironment.SystemType = SystemType.x64;
            installEnvironment.SystemVersion = SystemVersion.Vista;

            requirementManager.InstalledFrameworks = new List<string> {".NET CLR 3.5"};

            var useCase = new RequirementsCheckupUseCase(installState);
            useCase.Run();

            var state = ((RequirementCheckupViewState) useCase.BaseViewState);
            state.SendChange = i => { };

            useCase.Tick(new object(), new EventArgs());
            useCase.Tick(new object(), new EventArgs());
            useCase.Tick(new object(), new EventArgs());


            Assert.AreEqual(".Net Framework 3.5 или выше", installState.Requirements[2].Title);
            Assert.AreEqual(RequirementState.Installed, installState.Requirements[2].RequirementState);

            Assert.AreEqual("Sql Server Compact Edition 3.5 или выше", installState.Requirements[3].Title);
            Assert.AreEqual(RequirementState.NotInstalled, installState.Requirements[3].RequirementState);

            Assert.AreEqual("Sql Server Compact Edition 3.5 (x64 патч) или выше", installState.Requirements[4].Title);
            Assert.AreEqual(RequirementState.NotInstalled, installState.Requirements[4].RequirementState);
        }
    }
}