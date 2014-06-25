using System.Drawing;
using Installation_v2.InstallationLogic.Enums;
using Installation_v2.Properties;

namespace Installation_v2.PresentationLogic {
    public static class ImageSetter {
        public static Image GetImage(RequirementState state) {
            Image image = Resources.line;
            switch (state) {
                case RequirementState.Unknow:
                    image = Resources.pause;
                    break;
                case RequirementState.Pending:
                    image = Resources.pause;
                    break;
                case RequirementState.Processing:
                    image = Resources.player_play;
                    break;
                case RequirementState.Installed:
                    image = Resources.clean;
                    break;
                case RequirementState.NotInstalled:
                    image = Resources._16_em_cross;
                    break;
                case RequirementState.InstallSuccess:
                    image = Resources.clean;
                    break;
                case RequirementState.InstallFailed:
                    image = Resources._16_em_cross;
                    break;
            }
            return image;
        }
    }
}