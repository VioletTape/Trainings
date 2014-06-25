using Installation_v2.InstallationLogic.Enums;
using Installation_v2.InstallationLogic.Interfaces;

namespace Installation_v2.InstallationLogic.Specifications {
    public class AppliedToSystemType {
        private readonly IInstallEnvironment installEnvironment;

        public AppliedToSystemType(IInstallEnvironment installEnvironment) {
            this.installEnvironment = installEnvironment;
        }

        public bool IsSatisfied(Requirement item) {
            var currentSystemType = installEnvironment.SystemType;
            return (item.SystemType == SystemType.Any || item.SystemType == currentSystemType);
        }
    }
}