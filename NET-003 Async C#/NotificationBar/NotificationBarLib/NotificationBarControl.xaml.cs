using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using NotificationBarLib.Core;
using PostSharp.Toolkit.Threading;
using StructureMap;

namespace NotificationBarLib {
    public partial class NotificationBarControl : UserControl, ILocalViewManager {
        private readonly Dictionary<NotificationInfo, PopupInfo> dictionaryLabels;
        private readonly Dictionary<NotificationInfo, Image> dictionaryIcons;

        private readonly Queue<NotificationInfo> outlinedIconsStack;
        private readonly Dictionary<NotificationInfo, Image> outlinedIcons;
        private readonly StatusMessageManager statusMessageManager;

        public int MaxHoverElements { get; set; }
        public int MaxIconElements { get; set; }

        public NotificationBarControl() {
            InitializeComponent();

            MaxHoverElements = 5;
            MaxIconElements = 12;

            FlowArea.Margin = new Thickness(0, (-1)*((MaxHoverElements*50) + 4), 0, 35);

            dictionaryLabels = new Dictionary<NotificationInfo, PopupInfo>();
            dictionaryIcons = new Dictionary<NotificationInfo, Image>();

            outlinedIconsStack = new Queue<NotificationInfo>();
            outlinedIcons = new Dictionary<NotificationInfo, Image>();

            statusMessageManager = new StatusMessageManager();
            statusMessageManager.MessageStream()
                .ObserveOnDispatcher()
                .Subscribe(SetMessage);
        }


        public void SetStatusMessage(string message, int freezeTimeSec = 0) {
            statusMessageManager.SetMessage(message, freezeTimeSec);
        }

        private void SetMessage(string message) {
            this.message.Text = message;
        }


        public void AddIcon(NotificationInfo info) {
            var icon = new Image {
                                     Source = info.Icon,
                                     DataContext = info
                                 };
            icon.MouseEnter += MouseOverIconStart;
            icon.MouseLeave += MouseOverIconEnd;
            icon.MouseUp += MouseIconRemove;
            RenderOptions.SetBitmapScalingMode(icon, BitmapScalingMode.HighQuality);

            info.RemoveIconAndNotification = RemoveIconAndNotification;
            info.RemoveHoverNotification = HideHoverMessage;

            dictionaryIcons.Add(info, icon);

            var ui = IconPanel.Children;

            // remove odd icons and save them for latter usage
            if (ui.Count >= MaxIconElements) {
                var notificationInfo = ((NotificationInfo) ((Image) ui[0]).DataContext);

                outlinedIcons.Add(notificationInfo, (Image) ui[0]);
                outlinedIconsStack.Enqueue(notificationInfo);

                ui.RemoveAt(0);
            }

            // finally add new icon
            ui.Add(icon);

            SetStatusMessage(info.Message, 2);
        }

        private void RemoveIconAndNotification(NotificationInfo info) {
            HideHoverMessage(info);
            RemoveIcon(info);
        }

        private void MouseIconRemove(object sender, MouseButtonEventArgs e) {
            var notificationInfo = ((NotificationInfo) ((Image) sender).DataContext);
            RemoveIcon(notificationInfo);
            NavigateToScreen(notificationInfo);
        }

        private void NavigateToScreen(NotificationInfo notificationInfo) {
            var globalViewManager = ObjectFactory.GetInstance<INotificationManager>();
            globalViewManager.NavigateToScreen(notificationInfo);
        }


        public void RemoveIcon(NotificationInfo info) {
            var indexOf = -1;
            if (dictionaryIcons.ContainsKey(info)) {
                var icon = dictionaryIcons[info];
                icon.MouseEnter -= MouseOverIconStart;
                icon.MouseLeave -= MouseOverIconEnd;
                icon.MouseUp -= MouseIconRemove;

                indexOf = IconPanel.Children.IndexOf(icon);
                IconPanel.Children.Remove(icon);

                dictionaryIcons.Remove(info);
            }

            if (dictionaryLabels.ContainsKey(info)) {
                FlowArea.Children.Remove(dictionaryLabels[info]);
                dictionaryLabels.Remove(info);
            }

            info.Dispose();

            var ui = IconPanel.Children;

            // bring older icons to the icon line
            if (ui.Count < MaxIconElements) {
                if (indexOf == -1) return;

                if (outlinedIconsStack.Count > 0) {
                    // shifting icons. The easiest way. 
                    var images = new List<Image>(MaxIconElements);
                    images.Add(outlinedIcons[outlinedIconsStack.Dequeue()]);

                    images.AddRange(ui.Cast<Image>());

                    ui.Clear();
                    images.ForEach(i => ui.Add(i));
                }
            }
        }

        public void RemoveIconsFor(Type directInterface) {
            var iconInfos = dictionaryIcons.Where(i => i.Key.OriginatorType == directInterface).Select(i => i.Key).ToList();
            foreach (var info in iconInfos) {
                RemoveIcon(info);
            }
        }


        private void MouseOverIconEnd(object sender, MouseEventArgs e) {
            var notificationInfo = ((NotificationInfo) ((Image) sender).DataContext);
            notificationInfo.PreventUnintendedHoverEnds();
            if (!dictionaryLabels.ContainsKey(notificationInfo)) return;

            notificationInfo.StartTimer();
        }

        [DispatchedMethod]
        private void HideHoverMessage(NotificationInfo notificationInfo) {
            var ui = FlowArea.Children;
            lock (dictionaryLabels) {
                if (!dictionaryLabels.ContainsKey(notificationInfo)) return;

                if (ui.Contains(dictionaryLabels[notificationInfo])) {
                    ui.Remove(dictionaryLabels[notificationInfo]);
                    dictionaryLabels.Remove(notificationInfo);
                    notificationInfo.RestartTimer();

                    if (!ui.OfType<PopupInfo>().Any()) {
                        ui.Clear();
                    }
                }
            }
        }


        private void MouseOverIconStart(object sender, MouseEventArgs e) {
            var notificationInfo = ((NotificationInfo) ((Image) sender).DataContext);
            notificationInfo.PreventUnintendedHover(ShowHoverMessage);
        }

        private void ShowHoverMessage(NotificationInfo notificationInfo) {
            if (dictionaryLabels.ContainsKey(notificationInfo)) {
                notificationInfo.RestartTimer();
                return;
            }

            var element = new PopupInfo {DataContext = notificationInfo};

            lock (dictionaryLabels) {
                dictionaryLabels.Add(notificationInfo, element);
            }

            var ui = FlowArea.Children;

            // take control on top delimeter line
            if (ui.Count == 0) {
                ui.Add(new Rectangle {
                                         Height = 2,
                                         Fill = new SolidColorBrush(Colors.Navy)
                                     });
            }
            else {
                ui.RemoveAt(ui.Count - 1);
            }

            // check max available hover notifications
            if (ui.Count >= MaxHoverElements + 1) {
                var info = ((NotificationInfo) ((UserControl) ui[1]).DataContext);
                HideHoverMessage(info);
            }


            // finally add hover message
            ui.Add(element);

            // add bottom delimeter line
            ui.Add(new Rectangle {
                                     Height = 2,
                                     Fill = new SolidColorBrush(Colors.Navy)
                                 });
        }
    }

    public interface ILocalViewManager {
        void AddIcon(NotificationInfo info);
        void RemoveIcon(NotificationInfo info);
        void RemoveIconsFor(Type directInterface);
    }
}