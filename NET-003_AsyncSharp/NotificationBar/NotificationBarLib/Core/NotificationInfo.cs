using System;
using System.Timers;
using System.Windows.Media.Imaging;
using PostSharp.Toolkit.Threading;

namespace NotificationBarLib.Core {
    public class NotificationInfo : IDisposable {
        private Timer hoveringTimer;
        private const int HoverTimeInMilliseconds = 1500;

        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime ArrivalTime { get; set; }

        public string DisplayTime {
            get { return ArrivalTime.ToString("HH:mm"); }
        }

        public BitmapImage Icon { get; set; }

        public Type OriginatorType { get; set; }

        public Action<NotificationInfo> RemoveIconAndNotification { get; set; }
        public Action<NotificationInfo> RemoveHoverNotification { get; set; }

        public NotificationInfo() {
            Icon = new BitmapImage(new Uri("Icons/check_yes.png", UriKind.RelativeOrAbsolute));

            hoveringTimer = new Timer(HoverTimeInMilliseconds);
            hoveringTimer.Stop();
            hoveringTimer.Elapsed += RemoveNotification;
        }

        public void RemoveWithoutNavigation() {
            RemoveIconAndNotification(this);
        }

        public void StartTimer() {
            if (hoveringTimer != null)
                hoveringTimer.Start();
        }

        public void RestartTimer() {
            hoveringTimer.Stop();
            hoveringTimer.Elapsed -= RemoveNotification;
            hoveringTimer = new Timer(HoverTimeInMilliseconds);
            hoveringTimer.Elapsed += RemoveNotification;
        }

        private void RemoveNotification(object sender, ElapsedEventArgs elapsedEventArgs) {
            RemoveHoverNotification(this);
        }


        public void Dispose() {
            Cleanup(true);
            GC.SuppressFinalize(this);
        }

        private void Cleanup(bool disposing) {
            if (!disposing) {
                // Thread-specific code goes here
            }

            if (hoveringTimer != null) {
                hoveringTimer.Stop();
                hoveringTimer.Elapsed -= RemoveNotification;
                hoveringTimer = null;
            }

            if (unintendedPopupTimer != null) {
                unintendedPopupTimer.Stop();
                unintendedPopupTimer.Elapsed -= Show;
                unintendedPopupTimer = null;
            }

            RemoveHoverNotification = null;
            RemoveIconAndNotification = null;
            showHoverMessage = null;
            // Resource Cleanup goes here
        }

        public void Finalize() {
            Cleanup(false);
        }


        private Action<NotificationInfo> showHoverMessage;
        private Timer unintendedPopupTimer;

        public void PreventUnintendedHover(Action<NotificationInfo> showHoverMessage) {
            this.showHoverMessage = showHoverMessage;
            unintendedPopupTimer = new Timer(300);
            unintendedPopupTimer.Elapsed += Show;
            unintendedPopupTimer.Start();
        }

        [DispatchedMethod]
        private void Show(object sender, ElapsedEventArgs e) {
            unintendedPopupTimer.Stop();
            unintendedPopupTimer.Elapsed -= Show;
            unintendedPopupTimer = null;

            showHoverMessage(this);
        }

        public void PreventUnintendedHoverEnds() {
            if (unintendedPopupTimer != null) {
                unintendedPopupTimer.Stop();
                unintendedPopupTimer.Elapsed -= Show;
                unintendedPopupTimer = null;
            }
        }
    }
}