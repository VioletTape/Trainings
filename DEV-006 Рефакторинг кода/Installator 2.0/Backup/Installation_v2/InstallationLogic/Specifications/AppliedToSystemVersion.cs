using Installation_v2.InstallationLogic.Enums;
using Installation_v2.InstallationLogic.Interfaces;

namespace Installation_v2.InstallationLogic.Specifications {
    public class AppliedToSystemVersion {
        private readonly IInstallEnvironment installEnvironment;

        public AppliedToSystemVersion(IInstallEnvironment installEnvironment) {
            this.installEnvironment = installEnvironment;
        }

        public bool IsSatisfied(Requirement item) {
            var currentSystemType = installEnvironment.SystemVersion;
            return (item.SystemVersion == SystemVersion.Any || item.SystemVersion == currentSystemType);
        }
    }
}