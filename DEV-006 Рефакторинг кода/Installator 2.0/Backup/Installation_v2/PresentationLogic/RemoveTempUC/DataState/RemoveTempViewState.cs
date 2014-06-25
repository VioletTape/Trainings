using System.Collections.Generic;
using Installation_v2.PresentationLogic.RequirementsCheckupUC.DataState;

namespace Installation_v2.PresentationLogic.RemoveTempUC.DataState {
    public class RemoveTempViewState : BaseViewState{
        public List<RequirementsViewState> Requirements{ get; set; }
    }
}