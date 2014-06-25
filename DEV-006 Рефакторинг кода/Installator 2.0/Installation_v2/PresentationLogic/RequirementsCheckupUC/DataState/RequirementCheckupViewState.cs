using System.Collections.Generic;

namespace Installation_v2.PresentationLogic.RequirementsCheckupUC.DataState {
    public class RequirementCheckupViewState : BaseViewState{
        public List<RequirementsViewState> Requirements{ get; set; }
        public bool ProgressInfoVisible{ get; set; }
        public string ProgressInfoLabel{ get; set; }

        public int ProgressMax{ get; set; }
        public int ProgressStep{ get; set; }

        public string ErrorMessage{ get; set; }
    }
}