using System.Collections.Generic;

namespace Installation_v2.InstallationLogic.Interfaces {
    public interface IRequirementManager : IService {
        List<string> InstalledFrameworks { get; }
        List<string> InstalledWindowsUpdates { get; }
    }
}