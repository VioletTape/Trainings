using System;
using Installation_v2.InstallationLogic.Enums;

namespace Installation_v2.PresentationLogic.InstallSelectionUC.DataState {
    public class InstallSelectionViewState : BaseViewState{
        public string InstallPath{ get; set; }

        public bool InstallOptionVisible{ get; set; }

        public Action<object> Install{ get; set; }
        public Action<object> Repair{ get; set; }
        public Action<object> Delete{ get; set; }
    }
}