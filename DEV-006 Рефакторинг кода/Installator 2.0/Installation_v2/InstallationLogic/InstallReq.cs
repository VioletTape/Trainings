using System.Collections.Generic;
using Installation_v2.InstallationLogic.Enums;

namespace Installation_v2.InstallationLogic {
    public class InstallReq {
        public string Title { set; get; }
        public RequirementState InstallState { get; set; }
        public InstallReqType InstallReqType { get; set; }
        public string Destination{ get; set; }
        public FileAction FileAction { get; set; }
        public List<string> Keys { get; set; }
    }
}