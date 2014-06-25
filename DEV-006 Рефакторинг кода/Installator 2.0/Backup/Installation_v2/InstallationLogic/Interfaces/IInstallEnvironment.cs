using Installation_v2.InstallationLogic.Enums;

namespace Installation_v2.InstallationLogic.Interfaces {
    public interface IInstallEnvironment : IService  {
        string InstallPath { get; set; }
        string ExtractPath { get; set; }
        string CurrentPath { get; set; }
        string ReleaseCompany { get; }
        string ExecutableName { get; }
        string ShortcutName { get; }
        string CompanyName { get; }
        string ApplicationName { get; }
        string ApplicationVersion { get; }
        string ApplicationPreinstalledVersion { get; }
        SystemType SystemType { get; }
        SystemVersion SystemVersion { get; }
        string MinimumVersionToUpdate { get; }
        bool SystemAffected { get; set; }
        bool LightUpdate { get; set; }
    }
}