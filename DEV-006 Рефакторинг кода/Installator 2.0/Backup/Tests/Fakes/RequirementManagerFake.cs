using System;
using System.Collections.Generic;
using Installation_v2.InstallationLogic.Interfaces;

namespace Tests.Fakes {
    public class RequirementManagerFake : IRequirementManager {
        public List<string> InstalledFrameworks { get; set; }
        public List<string> InstalledWindowsUpdates { get; set; }

        public void InitService(IServiceLocator serviceLocator) {}

        public string ServiceStateReport {
            get { return ""; }
        }

        public Action<string> StepReport { get; set; }
    }

    public class LogServiceFake : ILogService {
        public void InitService(IServiceLocator serviceLocator) {}

        public string ServiceStateReport {
            get { return ""; }
        }

        public Action<string> StepReport { get; set; }

        public void CreateLogFile(string fileName) {}
        public void WriteToLog(string messageLine) {}
        public void PrintDelimeter() {}
        public void CloseFile() {}
    }
}