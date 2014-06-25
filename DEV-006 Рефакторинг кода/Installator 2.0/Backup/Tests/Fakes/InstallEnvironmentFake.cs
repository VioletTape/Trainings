using Installation_v2.InstallationLogic;
using Installation_v2.InstallationLogic.Enums;
using Installation_v2.InstallationLogic.Interfaces;
using Installation_v2.InstallationLogic.Services;

namespace Tests.Fakes {
    public class InstallEnvironmentFake : BaseService, IInstallEnvironment {
        public string InstallPath { get; set; }
        public string ExtractPath { get; set; }
        public string CurrentPath { get; set; }

        public string ReleaseCompany { get; set; }

        public string ExecutableName { get; set; }
        public string ShortcutName { get; set; }

        public string CompanyName { get; set; }
        public string ApplicationName { get; set; }
        public string ApplicationVersion { get; set; }
        public string ApplicationPreinstalledVersion { get; set; }

        public SystemType SystemType { get; set; }
        public SystemVersion SystemVersion { get; set; }
        public string MinimumVersionToUpdate { get; set; }
        public bool SystemAffected { get; set; }
        public bool LightUpdate { get; set; }

        public new void InitService(ServiceLocator serviceLocator) {}
    }
}