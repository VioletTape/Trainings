using System;

namespace NotificationBarLib {
    public interface INotificationViewManager {
         void Show(Type screenType);
        Type CurrentViewInterface { get; set; }
    }
}