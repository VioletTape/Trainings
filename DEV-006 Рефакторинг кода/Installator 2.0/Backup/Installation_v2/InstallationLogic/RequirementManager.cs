using System;
using System.Collections.Generic;
using Installation_v2.InstallationLogic.Enums;
using Installation_v2.InstallationLogic.Interfaces;
using Microsoft.Win32;

namespace Installation_v2.InstallationLogic {
    public class RequirementManager : IRequirementManager {
        private SystemVersion systemVersion;
        private List<string> installedFrameworks;
        private List<string> installedWinUpdates;


        public List<string> InstalledFrameworks {
            get { return installedFrameworks ?? GetInstalledFrameworks(); }
        }

        public List<string> InstalledWindowsUpdates {
            get { return installedWinUpdates ?? GetInstalledWinUpdates(); }
        }


        private List<string> GetInstalledWinUpdates() {
            var mainPath = @"SOFTWARE\Microsoft\Updates";
            if (systemVersion != SystemVersion.XP) {
                mainPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Component Based Servicing\Packages";
            }
            var key = Registry.LocalMachine.OpenSubKey(mainPath);
            if (key == null)
                return new List<string>();
            installedWinUpdates = GetNames(key, systemVersion);
            return installedWinUpdates;
        }

        private List<string> GetInstalledFrameworks() {
            var key = Registry.LocalMachine.OpenSubKey(
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\Internet Settings\5.0\User Agent\Post Platform");
            if (key == null) {
                return new List<string>();
            }
            var frameworks = key.GetValueNames();
            installedFrameworks = new List<string>();
            for (var i = 0; i < frameworks.Length; i++) {
                if (frameworks[i].StartsWith(".NET", StringComparison.OrdinalIgnoreCase))
                    if(frameworks[i].Length > 12)
                       installedFrameworks.Add(frameworks[i].Substring(0, 12));
                    else
                        installedFrameworks.Add(frameworks[i]);

            }
            return installedFrameworks;
        }

        private static List<string> GetNames(RegistryKey key, SystemVersion systemVersion) {
            var list = new List<string>();
            var keyNames = key.GetSubKeyNames();

            foreach (var name in keyNames) {
                if (systemVersion == SystemVersion.XP) {
                    if (name.StartsWith("KB")) {
                        list.Add(name);
                    }
                    else {
                        list.AddRange(GetNames(key.OpenSubKey(name), systemVersion));
                    }
                }
                else {
                    if (name.Contains("KB")) {
                        var substring = name.Substring(name.IndexOf("KB"));
                        substring = substring.Substring(0, substring.IndexOf("~"));
                        list.Add(substring);
                    }
                    else {
                        list.AddRange(GetNames(key.OpenSubKey(name), systemVersion));
                    }
                }
            }
            return list;
        }

        public void InitService(IServiceLocator serviceLocator) {
            var environment = serviceLocator.Get<IInstallEnvironment>();
            systemVersion = environment.SystemVersion;
        }

        public string ServiceStateReport {
            get { return ""; }
        }

        public Action<string> StepReport { get; set; }
    }
}