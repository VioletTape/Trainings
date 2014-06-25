using System.Collections.Generic;
using Installation_v2.PresentationLogic.RequirementsCheckupUC.DataState;

namespace Installation_v2.PresentationLogic.RequirementsInstallUC.DataState {
    public class RequirementsInstallViewState : BaseViewState {
        public List<RequirementsViewState> Requirements { get; set; }

        public bool ErrorLabelVisible { get; set; }
        public string ErrorText { get; set; }
    }
}