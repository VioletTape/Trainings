using System;
using System.Threading.Tasks;
using Domain;
using NotificationBarLib.Attributes;
using Presentation.ViewInterfaces;
using StructureMap;
using ToAsyncLib;

namespace Presentation.Models {
    [SupportNotificationBar]
    public class StarsAndRainsModel : BaseModel, IStarsAndRains, IDisposable {
        private readonly IImportantService service;

        public Command CalculateStars { get; set; }
        public Command CalculateRains { get; set; }
        public Command CalculateMoments { get; set; }
        public Command ToTheMainScreen { get; set; }

        [NotifyContextImportant]
        public string Message1 { get; set; }

        [NotifyContextImportant]
        public string Message2 { get; set; }

        [NotifyContextImportant]
        public string Message3 { get; set; }



        public StarsAndRainsModel() {
            CalculateStars = new Command(CalculationStarsOverMe);
            CalculateRains = new Command(CalculationRainDrops);
            CalculateMoments = new Command(CalculationMoments);

            ToTheMainScreen = new Command(GoToTheMainScreen);

            service = ObjectFactory.GetInstance<IImportantService>();

            Title = "Stars And Rain drops";
        }

        private void GoToTheMainScreen() {
            ViewManager.Show<IStartScreen>();
            Dispose();
        }

        [TriggerNotifyAction(Id = "Stars")]
        public void CalculationStarsOverMe() {
            Async.For<int>(service.PretendItLastsFor)
                .Subscribe(CalculationStarsOverMeFinished)
                .Run(3);
        }

        [NotifyActionEnds(Id = "Stars", Icon = NotifyIcon.Chat)]
        private void CalculationStarsOverMeFinished(Task task) {
            Message1 = "Over 9000 stars";
        }


        [TriggerNotifyAction(Id = "Rain")]
        public void CalculationRainDrops() {
            Async.For<int>(service.PretendItLastsFor)
                .Subscribe(CalculationRainDropsFinished)
                .Run(4);
        }

        [NotifyActionEnds(Id = "Rain", Icon = NotifyIcon.Refresh,
            Message = "Over 9000 rain drops",
            Title = "It's ok")]
        private void CalculationRainDropsFinished(Task task) {
            Message2 = "Over 9000 rain drops";
        }


        [TriggerNotifyAction(Id = "Moments")]
        private void CalculationMoments() {
            Async.For<int>(service.PretendItLastsFor)
                .Subscribe(CalculationMomentsFinished)
                .Run(5);
        }

        [NotifyActionEnds(Id = "Moments", Icon = NotifyIcon.Reload,
            Message = "@Message3",
            Title = "@Title")]
        private void CalculationMomentsFinished(Task task) {
            Message3 = "Over 9000 memorable moments";
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