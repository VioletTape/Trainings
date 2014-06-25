using Presentation.ViewInterfaces;

namespace Presentation.Models {
    public class StartScreenModel : BaseModel {
        public Command ToTheStarsAndRains { get; set; }
        public Command ToTheBlackHoles { get; set; }

        public StartScreenModel() {
            ToTheStarsAndRains = new Command(GoToTheStarsAndRains);
            ToTheBlackHoles = new Command(GoToTheBlackHoles);
        }

        private void GoToTheBlackHoles() {
            ViewManager.Show<ISingleNotification>();
        }

        private void GoToTheStarsAndRains() {
            ViewManager.Show<IStarsAndRains>();
        }
    }
}