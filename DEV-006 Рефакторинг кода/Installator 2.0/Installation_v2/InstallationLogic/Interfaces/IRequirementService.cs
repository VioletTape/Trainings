using Installation_v2.InstallationLogic.Enums;

namespace Installation_v2.InstallationLogic.Interfaces {
    public interface IRequirementService : IService {
        OperationResult ProcessRequirements(Requirement requirement);
    }
}