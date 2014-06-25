using Installation_v2.InstallationLogic.Enums;

namespace Installation_v2.InstallationLogic {
    public class Requirement {
        public int Sequence{ get; set; }
        public string Title{ get; set; }

        public RequirementState RequirementState { get; set; }
        public RequirementType RequirementType { get; set; }

        public SystemType SystemType { get; set; }
        public SystemVersion SystemVersion { get; set; }

        public string SystemName{ get; set;}
        public string SystemFile{ get; set;}
        public string RegPath{ get; set; }

    }
}