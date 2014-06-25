using System;
using System.IO;
using Installation_v2.InstallationLogic.Enums;
using Installation_v2.InstallationLogic.Interfaces;
using Installation_v2.InstallationLogic.Services;
using Installation_v2.Properties;
using Microsoft.Win32;

namespace Installation_v2.InstallationLogic {
    public class InstallEnvironment : BaseService, IInstallEnvironment {
        private IFileService fileService;
        private IRegistryService registryService;

        public string InstallPath { get; set; }
        public string ExtractPath { get; set; }
        public string CurrentPath { get; set; }
        public string ReleaseCompany { get; private set; }

        public string ExecutableName { get; private set; }
        public string ShortcutName { get; private set; }

        public string CompanyName { get; private set; }
        public string ApplicationName { get; private set; }
        public string ApplicationVersion { get; private set; }
        public string ApplicationPreinstalledVersion { get; private set; }
        public string MinimumVersionToUpdate { get; private set; }

        public bool LightUpdate { get; set; }


        public SystemType SystemType { get; private set; }
        public SystemVersion SystemVersion { get; private set; }

        public bool SystemAffected{ get; set; }

        public InstallEnvironment() {
            ApplicationName = Settings.Default.ApplicationName;
            ApplicationVersion = Settings.Default.ApplicationVersion;
            MinimumVersionToUpdate = Settings.Default.MinimumVersionToUpdate;
           

            CompanyName = Settings.Default.TargetCompany;
            ExecutableName = Settings.Default.ExecutableName;
            ShortcutName = Settings.Default.ShortcutName;

            ReleaseCompany = Settings.Default.ReleaseCompany;

            LightUpdate = Settings.Default.LightUpdate;

            SystemType = DetermineSystemType();
            SystemVersion = DetermineSystemVersion();

            InstallPath = DetermineInstallPath();
            ExtractPath = DetermineExtractPath();
            CurrentPath = Environment.CurrentDirectory;

            registryService = new RegistryService();
            ApplicationPreinstalledVersion = DeterminePreinstalledVersion();
        }

        private string DeterminePreinstalledVersion() {
            var value = registryService.GetKeyValue(string.Format("software\\{0}\\{1}", ReleaseCompany, ApplicationName), "Version");
            return value;
        }

        public new void InitService(IServiceLocator serviceLocator) {
            fileService = new FileService();
            
        }


        private string DetermineInstallPath() {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            path = Path.Combine(path, Settings.Default.InstallPath);

            return path;
        }

        private string DetermineExtractPath() {
            var path = Environment.GetEnvironmentVariable("TEMP");
            path = Path.Combine(path, ReleaseCompany);

            return path;
        }

        private static SystemVersion DetermineSystemVersion() {
            var key = GetRegistryKeyCurrentVersion();
            if (key == null) return SystemVersion.Unknown;

            var value = key.GetValue("CurrentVersion", "").ToString();
            if (value == "5.1") return SystemVersion.XP;
            if (value == "6.0") return SystemVersion.Vista;
            if (value == "6.1") return SystemVersion.Win7;

            return SystemVersion.Unknown;
        }

        private static SystemType DetermineSystemType() {
            var key = GetRegistryKeyCurrentVersion();
            if (key == null)
                return SystemType.Unknown;

            var value = key.GetValue("CurrentVersion", "").ToString();

            if (value == "5.1")
                return SystemType.x86;

            if (value == "6.0") {
                return key.GetValue("BuildLabEx", "").ToString().Contains("64fre")
                           ? SystemType.x64
                           : SystemType.x86;
            }

            if (value == "6.1") {
                return key.GetValue("BuildLabEx", "").ToString().Contains("64fre")
                           ? SystemType.x64
                           : SystemType.x86;
            }

            return SystemType.Unknown;
        }


        private static RegistryKey GetRegistryKeyCurrentVersion() {
            var mainPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
            return Registry.LocalMachine.OpenSubKey(mainPath);
        }
    }
}