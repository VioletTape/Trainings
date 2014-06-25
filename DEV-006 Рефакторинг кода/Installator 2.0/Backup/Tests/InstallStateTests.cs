using Installation_v2.InstallationLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Fakes;

namespace Tests {
    [TestClass]
    public class InstallStateTests {
        [TestMethod]
        public void CheckUpRequirmentsNumber() {
            var requirements = new InstallState(new ServiceLocator()).Requirements;

            Assert.AreEqual(5, requirements.Count);
        }

        [TestMethod]
        public void InstallEnvironmentShouldBeInitialized() {
            Assert.IsNotNull(new InstallState(new ServiceLocator()).InstallEnvironment);
        }

       
    }
}