using System;
using Installation_v2.InstallationLogic.Enums;
using Installation_v2.InstallationLogic.Interfaces;

namespace Installation_v2.InstallationLogic.Services {
    public class BaseService : IService {
        internal int ActionNumberInStep = 1;
        internal int TotalActionNumberInStep = 1;

        public BaseService() {
            StepReport = i => { };
        }

        public void InitService(IServiceLocator serviceLocator) {}

        public string ServiceStateReport {
            get {
                return TotalActionNumberInStep == 1
                           ? string.Empty
                           : string.Format("{0} / {1}", ActionNumberInStep, TotalActionNumberInStep);
            }
        }

        public Action<string> StepReport{ get; set;}
    }
}