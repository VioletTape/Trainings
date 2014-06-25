using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Installation_v2.InstallationLogic;
using Installation_v2.PresentationLogic.CreateUC;
using Installation_v2.PresentationLogic.CreateUC.DataState;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Fakes;

namespace Tests.UseCases {
    [TestClass]
    public class CreateUCTests {
        private InstallState installState;


        [TestInitialize]
        public void TestInitialize() {
            installState = new InstallState(new ServiceLocatorFake());
        }

        [TestMethod]
        public void InitVariablesOfCurrentInstallation() {
            var environment = ((InstallEnvironmentFake) installState.InstallEnvironment);
            environment.InstallPath = @"c:\PF\program";
            environment.MinimumVersionToUpdate = "1.0.010109";
            environment.ApplicationVersion = "1.0.070709";

            var useCase = new CreateUseCase(installState);
            useCase.Run();
            var state = ((CreateViewState) useCase.BaseViewState);

            Assert.AreEqual("1.0.010109", state.CurrentMinVersion);
            Assert.AreEqual("1.0.070709", state.CurrentVersion);

            Assert.AreEqual("1.0.010109", state.MinVersion);
            Assert.AreEqual("1.0.070709", state.Version);
        }

        [TestMethod]
        public void ActionsShouldBeInitialized() {
            var useCase = new CreateUseCase(installState);
            useCase.Run();
            var state = ((CreateViewState) useCase.BaseViewState);

            Assert.IsNotNull(state.CreateCore);
        }

        
    }
}