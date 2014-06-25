using System;
using System.Threading.Tasks;
using Domain;
using NotificationBarLib.Attributes;
using Presentation.ViewInterfaces;
using StructureMap;
using ToAsyncLib;

namespace Presentation.Models {
    [SupportNotificationBar]
    public class SingleNotificationModel : BaseModel, ISingleNotification, IDisposable {
        private readonly IImportantService service;

        public Command CalculateBlackHoles { get; set; }
        public Command ToTheMainScreen { get; set; }

        [NotifyContextImportant]
        public string Message1 { get; set; }

        public SingleNotificationModel() {
            service = ObjectFactory.GetInstance<IImportantService>();

            CalculateBlackHoles = new Command(CalculationStarsOverMe);
            ToTheMainScreen = new Command(GoToTheMainScreen);
        }

        private void GoToTheMainScreen() {
            ViewManager.Show<IStartScreen>();
            Dispose();
        }

        [TriggerNotifyAction]
        public void CalculationStarsOverMe() {
            Async.For<int>(service.PretendItLastsFor)
                .Subscribe(CalculationStarsOverMeFinished)
                .Run(3);
        }

        [NotifyActionEnds]
        private void CalculationStarsOverMeFinished(Task task) {
            Message1 = "A lot of black holes in the universe";
        }

        public void Dispose() {
            Cleanup(true);
            GC.SuppressFinalize(this);
        }

        private void Cleanup(bool disposing) {
            if (!disposing) {
                // Thread-specific code goes here
            }
            // Resource Cleanup goes here

            // events


            // and all other stuff
        }

        public void Finalize() {
            Cleanup(false);
        }
    }
}