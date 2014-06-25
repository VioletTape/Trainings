#define Win_x64
//#define Win_x86


using Installation_v2.InstallationLogic;
using Installation_v2.InstallationLogic.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
    [TestClass]
    public class InstallEnvironmentTests {
        [TestInitialize]
        public void TestInitialize() {}

        [TestMethod]
        public void ShouldReadDataFromSettingsFile() {
            var environment = new InstallEnvironment();

            Assert.AreEqual("Гранде", environment.ApplicationName);
            Assert.AreEqual("1.0.090715", environment.ApplicationVersion);
            Assert.AreEqual("Гранде", environment.CompanyName);
            Assert.AreEqual("Grande.exe", environment.ExecutableName);
            Assert.AreEqual("Grande.lnk", environment.ShortcutName);
            Assert.AreEqual("WBR_Violet_Tape", environment.ReleaseCompany);
        }

#if (Win_x64)
        [TestMethod]
        public void ShouldDetermineSystemType() {
            var environment = new InstallEnvironment();
            
            Assert.AreEqual(SystemType.x64, environment.SystemType);
        }

        [TestMethod]
        public void ShouldDetermineSystemVersion() {
            var environment = new InstallEnvironment();
            
            Assert.AreEqual(SystemVersion.Win7, environment.SystemVersion);
        }

        [TestMethod]
        public void ShouldDeremineInstallPathForX64() {
             var environment = new InstallEnvironment();

            Assert.AreEqual(@"C:\Program Files (x86)\Wbr\Grande", environment.InstallPath);
        }

#endif


#if (Win_x86)
        [TestMethod]
        public void ShouldDetermineSystemType() {
            var environment = new InstallEnvironment();

            Assert.AreEqual(SystemType.x86, environment.SystemType);
        }

        [TestMethod]
        public void ShouldDetermineSystemVersion() {
            var environment = new InstallEnvironment();

            Assert.AreEqual(SystemVersion.XP, environment.SystemVersion);
        }

        [TestMethod]
        public void ShouldDeremineInstallPathForX86() {
            var environment = new InstallEnvironment();

            Assert.AreEqual(@"C:\Program Files\Wbr\Grande", environment.InstallPath);
        }
#endif

        [TestMethod]
        public void ShouldFindoutPreviousVersion() {
            var environment = new InstallEnvironment();

            Assert.IsTrue(string.IsNullOrEmpty(environment.ApplicationPreinstalledVersion));
        }
    }
}