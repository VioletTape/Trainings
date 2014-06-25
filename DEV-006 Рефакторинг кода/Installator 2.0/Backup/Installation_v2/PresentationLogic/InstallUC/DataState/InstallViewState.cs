using System.Collections.Generic;
using Installation_v2.PresentationLogic.RequirementsCheckupUC.DataState;

namespace Installation_v2.PresentationLogic.InstallUC.DataState {
    public class InstallViewState : BaseViewState {
        public List<RequirementsViewState> Requirements { get; set; }

        public bool ProgressInfoVisible { get; set; }
        public string ProgressInfoLabel { get; set; }

        public int ProgressMax { get; set; }
        public int ProgressStep { get; set; }

        public string ErrorMessage { get; set; }

        public InstallViewState() {
            ProgressInfoVisible = true;
        }
    }
}