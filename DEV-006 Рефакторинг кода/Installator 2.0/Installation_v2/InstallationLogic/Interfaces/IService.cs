using System;

namespace Installation_v2.InstallationLogic.Interfaces {
    public interface IService {
        void InitService(IServiceLocator serviceLocator);
        string ServiceStateReport { get; }
        Action<string> StepReport { get; set; }
    }
}