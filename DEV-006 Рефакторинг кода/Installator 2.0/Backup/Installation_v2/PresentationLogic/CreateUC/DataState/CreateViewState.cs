using System;

namespace Installation_v2.PresentationLogic.CreateUC.DataState {
    public class CreateViewState : BaseViewState {
        public string CurrentVersion { get; set; }
        public string CurrentMinVersion { get; set; }
        public string Version { get; set; }
        public string MinVersion { get; set; }


        public string PathToCE { get; set; }
        public string PathToEnvBat { get; set; }
        public string PathToCsc { get; set; }
        public string PathToPlaceNewInstaller { get; set; }
        public string PathToAppl { get; set; }

        public string Scripts { get; set; }

        public string CreateProgress { get; set; }
        public Action<object> CreateCore { get; set; }
    }
}