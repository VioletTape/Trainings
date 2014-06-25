using Installation_v2.InstallationLogic.Enums;
using Installation_v2.InstallationLogic.Interfaces;

namespace Tests.Fakes {
    public class InstallStateFake {
        public InstallationType InstallationType { get; set; }
        public IServiceLocator ServiceLocator { get; private set; }

        public ServiceLocatorFake ServiceLocatorFake {
            get { return (ServiceLocatorFake) ServiceLocator; }
        }

        public InstallStateFake() {
            ServiceLocator = new ServiceLocatorFake();
        }
    }
}