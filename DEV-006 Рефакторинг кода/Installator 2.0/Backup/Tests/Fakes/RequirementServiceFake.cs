using System;
using System.Collections.Generic;
using Installation_v2.InstallationLogic;
using Installation_v2.InstallationLogic.Enums;
using Installation_v2.InstallationLogic.Interfaces;
using Installation_v2.InstallationLogic.Services;
using Installation_v2.InstallationLogic.Specifications;

namespace Tests.Fakes {
    internal class RequirementServiceFake : BaseService, IRequirementService {
        private FileServiceFake fileService;
        private InstallEnvironmentFake installEnvironment;
        private RequirementManagerFake requirementManager;
        private RegistryServiceFake registry;

        public new void InitService(IServiceLocator serviceLocator) {
            fileService = (FileServiceFake) serviceLocator.Get<IFileService>();
            registry = (RegistryServiceFake) serviceLocator.Get<IRegistryService>();
            installEnvironment = (InstallEnvironmentFake) serviceLocator.Get<IInstallEnvironment>();
            requirementManager = (RequirementManagerFake) serviceLocator.Get<IRequirementManager>();
        }

        public OperationResult ProcessRequirements(Requirement requirement) {
            switch (requirement.RequirementType) {
                case RequirementType.Application:
                    return ExecuteApplicationRequirement(requirement);

                case RequirementType.CabFile:
                    return ExecuteCabFileRequirement(requirement);

                case RequirementType.Framework:
                    return ExecuteFrameworkRequirement(requirement);

                case RequirementType.SqlApplication:
                    return ExecuteSqlApplicationRequirement(requirement);

                case RequirementType.SqlScript:
                    return ExecuteSqlScriptRequirement(requirement);

                case RequirementType.System:
                    return ExecuteSystemRequirement(requirement);

                case RequirementType.UpdateFamily:
                    return ExecuteUpdateFamilyRequirement(requirement);
            }
            return OperationResult.Failed;
        }

        private OperationResult ExecuteUpdateFamilyRequirement(Requirement requirement) {
            if (new AppliedToSystemType(installEnvironment).IsSatisfied(requirement) &&
                new AppliedToSystemVersion(installEnvironment).IsSatisfied(requirement)) {
                requirement.RequirementState = new PrerequirmentsUpdateFamilyKB(
                                                   requirementManager.InstalledWindowsUpdates)
                                                   .IsSatisfied(requirement.SystemName)
                                                   ? RequirementState.Installed
                                                   : RequirementState.NotInstalled;
            }
            else {
                requirement.RequirementState = RequirementState.Installed;
            }

            return OperationResult.Succed;
        }

        private OperationResult ExecuteSqlScriptRequirement(Requirement requirement) {
            return OperationResult.Succed;
        }

        private OperationResult ExecuteSqlApplicationRequirement(Requirement requirement) {
            var mainPath = requirement.RegPath;

            if (!registry.PathExists(mainPath)) {
                requirement.RequirementState = RequirementState.NotInstalled;
                return OperationResult.Succed;
            }


            var keyNames = registry.GetKeys(mainPath);
            var list = new List<double>();
            keyNames.ConvertAll(item => item.Substring(1).Replace(".", ","))
                .ForEach(item => {
                             double i;
                             Double.TryParse(item, out i);
                             list.Add(i);
                         });
            requirement.RequirementState = list.Exists(item => item >= 3.5)
                                               ? RequirementState.Installed
                                               : RequirementState.NotInstalled;


//            if (installEnvironment.SystemType == SystemType.x86 &&
//                requirement.SystemType == SystemType.x64) {
//                requirement.RequirementState = RequirementState.Installed;
//            }
//
//            if (requirement.Sequence == 4 && installEnvironment.SystemType == SystemType.x86)
//                requirement.RequirementState = RequirementState.Installed;


            return OperationResult.Succed;
        }

        private OperationResult ExecuteFrameworkRequirement(Requirement requirement) {
            if (new AppliedToSystemType(installEnvironment).IsSatisfied(requirement) &&
                new AppliedToSystemVersion(installEnvironment).IsSatisfied(requirement)) {
                requirement.RequirementState = new PrerequirmentsNetFramework(requirementManager.InstalledFrameworks)
                                                   .IsSatisfied(requirement.SystemName)
                                                   ? RequirementState.Installed
                                                   : RequirementState.NotInstalled;
            }
            else {
                requirement.RequirementState = RequirementState.NotInstalled;
            }
            return OperationResult.Succed;
        }

        private OperationResult ExecuteApplicationRequirement(Requirement requirement) {
            return OperationResult.Succed;
        }

        private OperationResult ExecuteSystemRequirement(Requirement requirement) {
            return OperationResult.Succed;
        }

        private OperationResult ExecuteCabFileRequirement(Requirement requirement) {
            var result = OperationResult.Failed;
            try {
                fileService.CreateDirectory(installEnvironment.ExtractPath, InstallFileAccess.All);
                fileService.ExtractCab(installEnvironment.CurrentPath, requirement.SystemFile,
                                       installEnvironment.ExtractPath);
                result = OperationResult.Succed;
            }
            catch {}
            return result;
        }
    }
}