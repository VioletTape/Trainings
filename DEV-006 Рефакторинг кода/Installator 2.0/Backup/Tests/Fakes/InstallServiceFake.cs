using Installation_v2.InstallationLogic;
using Installation_v2.InstallationLogic.Enums;
using Installation_v2.InstallationLogic.Interfaces;
using Installation_v2.InstallationLogic.Services;

namespace Tests.Fakes {
    public class InstallServiceFake : BaseService, IInstallService {
        public void InitService(ServiceLocator serviceLocator) {}

        public Result InstallRequirementResult { get; set; }

        public Result InstallRequirement(Requirement requirement) {
            return InstallRequirementResult ?? new Result {OperationResult = OperationResult.Succed};
        }

        public Result InstallMainResult { get; set; }

        public Result InstallMain(InstallReq installReq) {
            return InstallMainResult ?? new Result {OperationResult = OperationResult.Succed};
        }

        public Result RepairMain(InstallReq installReq) {
            var result = new Result {OperationResult = OperationResult.Succed};

            return result;
        }

        public Result DeleteMain(InstallReq installReq) {
            var result = new Result {OperationResult = OperationResult.Succed};

            return result;
        }

        public void CreateShortcutOnDesktop() {}

        public void CreateShortcutOnProgram() {}
    }
}