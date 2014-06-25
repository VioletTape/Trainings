using Installation_v2.InstallationLogic.Enums;

namespace Installation_v2.InstallationLogic.Interfaces {
    public interface IInstallService : IService {
        Result InstallRequirement(Requirement requirement);
        Result InstallMain(InstallReq installReq);
        Result RepairMain(InstallReq installReq);
        Result DeleteMain(InstallReq installReq);
        void CreateShortcutOnDesktop();
        void CreateShortcutOnProgram();
    }
}