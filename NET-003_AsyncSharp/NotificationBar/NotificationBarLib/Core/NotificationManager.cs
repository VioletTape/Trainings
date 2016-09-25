using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Media.Imaging;
using NotificationBarLib.Attributes;
using PostSharp.Toolkit.Threading;
using StructureMap;

namespace NotificationBarLib.Core {
    public interface INotificationManager {
        void RegisterForNotification(Type trackingType, object instance);

        void StartTracking(object trackingInstance);
        void StartTracking(string id, object trackingInstance);

        void SuccessfullNotification(object trackingInstance);
        void SuccessfullNotification(string id, object trackingInstance);
        void SuccessfullNotification(string id, object trackingInstance, string iconPath);
        void SuccessfullNotification(string id, object trackingInstance, string iconPath, string message, string title);

        void ExceptionNotification(object trackingInstance);
        List<string> Log { get; }


        void ExceptionNotification(string id, object trackingInstance);
        void ExceptionNotification(string id, object trackingInstance, string iconPath, string message, string title);


        void RegisterContextProperties(Type underlayingType, List<PropertyInfo> contextDependentProperties);
        void NavigateToScreen(NotificationInfo info);
        bool IsReconstituteProcess(Type underlayingType);
        List<ContextProperty> GetContextImportantProperties(Type underlayingType);
        void UnregisterNotifications(object instance);
    }

    public class NotificationManager : INotificationManager {
        private readonly INotificationViewManager globalViewManager;
        private readonly List<string> log = new List<string>();

        public Dictionary<Type, object> TrackingInstances;
        public Dictionary<Type, List<ContextProperty>> ContextProperties;

        private Dictionary<object, List<string>> instanceHandlers;
        private readonly ILocalViewManager localViewManager;

        public NotificationManager() {
            globalViewManager = ObjectFactory.GetInstance<INotificationViewManager>();
            localViewManager = ObjectFactory.GetInstance<ILocalViewManager>();

            Init();
        }

        public NotificationManager(INotificationViewManager globalViewManager) {
            this.globalViewManager = globalViewManager;
            localViewManager = ObjectFactory.GetInstance<ILocalViewManager>();
            Init();
        }

        private void Init() {
            TrackingInstances = new Dictionary<Type, object>();
            ContextProperties = new Dictionary<Type, List<ContextProperty>>();
            instanceHandlers = new Dictionary<object, List<string>>();
        }

        public List<string> Log {
            get { return log; }
        }


        public void RegisterForNotification(Type trackingType, object instance) {
            // get old instance and if we have no tracking operations then clear all references and delete it 
            var keyValuePairs = instanceHandlers
                .Where(i => i.Key.GetType() == trackingType)
                .Select(i => i)
                .ToList();

            foreach (var pair in keyValuePairs) {
                if (instanceHandlers[pair.Key].Any())
                    continue;
                ((IDisposable) pair.Key).Dispose();
            }


            log.Add(string.Format("register class with id={0} type={1}", trackingType, instance.GetType().Name));

            // if new instance and type approached
            if (!TrackingInstances.ContainsKey(trackingType))
                TrackingInstances.Add(trackingType, instance);

            instanceHandlers.Add(instance, new List<string>());

            // remove notification icons if any exists
            localViewManager.RemoveIconsFor(ExtractDirectInterface(instance));
        }


        public void StartTracking(object trackingInstance) {
            StartTracking("default", trackingInstance);
        }

        public void StartTracking(string id, object trackingInstance) {
            log.Add(string.Format("start tracking id={0} for {1}", id, trackingInstance.GetType().Name));

            // adding id of longtracking action to be aware of how much of them runs for particular type instance
            instanceHandlers[trackingInstance].Add(id);
        }


        public void SuccessfullNotification(object trackingInstance) {
            SuccessfullNotification("default", trackingInstance);
        }

        public void SuccessfullNotification(string id, object trackingInstance) {
            SuccessfullNotification(id, trackingInstance, "Icons/check_yes.png");
        }

        public void SuccessfullNotification(string id, object trackingInstance, string iconPath) {
            SuccessfullNotification(id, trackingInstance, iconPath, "Действие завершено", "Сообщение");
        }

        [DispatchedMethod]
        public void SuccessfullNotification(string id, object trackingInstance, string iconPath, string message, string title) {
            var format = string.Format("successfull end tracking id={0} for {1}", id, trackingInstance.GetType().Name);

            if (!IsOnTheSameView(trackingInstance)) {
                var info = new NotificationInfo {
                                                    ArrivalTime = DateTime.Now,
                                                    Message = message,
                                                    Title = title,
                                                    OriginatorType = ExtractDirectInterface(trackingInstance),
                                                    Icon = new BitmapImage(new Uri(iconPath, UriKind.RelativeOrAbsolute))
                                                };


                localViewManager.AddIcon(info);
            }


            // extracting contextImportant variables (result) from instacne
            // tracking instance in common case not the same that showing to the user
            // rule of thumb - the last who came is the most recent info and it will be displayed
            ContextProperties[trackingInstance.GetType()].ForEach(i => i.RetrieveValueFrom(trackingInstance));

            // remove id of longtracking action 
            // it's possible to get know how many actions are still runnging
            instanceHandlers[trackingInstance].Remove(id);
            TryReleaseInstance(trackingInstance);

            log.Add(format);
        }

        public void ExceptionNotification(object trackingInstance) {
            ExceptionNotification("default", trackingInstance);
        }

        public void ExceptionNotification(string id, object trackingInstance) {
           ExceptionNotification(id, trackingInstance, NotifyIcon.Exclamation, "Произошла ошибка", "Ошибка");
        }

        [DispatchedMethod]
        public void ExceptionNotification(string id, object trackingInstance, string iconPath, string message, string title) {
            var format = string.Format("exceptional end tracking id={0} for {1}", id, trackingInstance.GetType().Name);

            if (!IsOnTheSameView(trackingInstance)) {
                var info = new NotificationInfo {
                                                    ArrivalTime = DateTime.Now,
                                                    Message = message,
                                                    Title = title,
                                                    OriginatorType = ExtractDirectInterface(trackingInstance),
                                                    Icon = new BitmapImage(new Uri(iconPath, UriKind.RelativeOrAbsolute))
                                                };


                localViewManager.AddIcon(info);
            }


            // extracting contextImportant variables (result) from instacne
            // tracking instance in common case not the same that showing to the user
            // rule of thumb - the last who came is the most recent info and it will be displayed
            ContextProperties[trackingInstance.GetType()].ForEach(i => i.RetrieveValueFrom(trackingInstance));

            // remove id of longtracking action 
            // it's possible to get know how many actions are still runnging
            instanceHandlers[trackingInstance].Remove(id);
            TryReleaseInstance(trackingInstance);

            log.Add(format);
        }

        private void TryReleaseInstance(object trackingInstance) {
            if (!instanceHandlers.ContainsKey(trackingInstance)) return;

            if (instanceHandlers[trackingInstance].Any()) return;

            if (!IsOnTheSameView(trackingInstance))
                ReleaseInstanceByInnerCall(trackingInstance);
        }

        private void ReleaseInstanceByInnerCall(object trackingInstance) {
            ReleaseInstance(trackingInstance);
        }

        private void ReleaseInstanceByOuterCall(object trackingInstance) {
            ReleaseInstance(trackingInstance);
            if (ContextProperties.ContainsKey(trackingInstance.GetType())) {
                ContextProperties.Remove(trackingInstance.GetType());
            }
        }

        private void ReleaseInstance(object trackingInstance) {
            // remove all event handlers - unsubscribe
            var type = trackingInstance.GetType();

            if (TrackingInstances.ContainsKey(type)) {
                if (TrackingInstances[type].Equals(trackingInstance)) {
                    TrackingInstances.Remove(type);
                }
            }

            // free object
            instanceHandlers.Remove(trackingInstance);
        }

        public void UnregisterNotifications(object instance) {
            if (instanceHandlers.ContainsKey(instance) && instanceHandlers[instance].Any()) return;

            ReleaseInstanceByOuterCall(instance);
        }

        // -----------------------------
        // context dependecy
        // --------------------------------

        public void RegisterContextProperties(Type underlayingType, List<PropertyInfo> contextDependentProperties) {
            foreach (var info in contextDependentProperties) {
                log.Add(string.Format("prop for {0} : {1}", underlayingType, info.Name));
            }

            if (ContextProperties.ContainsKey(underlayingType)) return;

            ContextProperties.Add(underlayingType, contextDependentProperties.ConvertAll(i => new ContextProperty(i)));
        }


        public void NavigateToScreen(NotificationInfo info) {
            globalViewManager.Show(info.OriginatorType);
        }

        public bool IsReconstituteProcess(Type underlayingType) {
            var somethingWasHere = instanceHandlers.Any(i => i.GetType() == underlayingType);
            return TrackingInstances.ContainsKey(underlayingType) && somethingWasHere;
        }

        public List<ContextProperty> GetContextImportantProperties(Type underlayingType) {
            var infos = new List<ContextProperty>();
            ContextProperties.TryGetValue(underlayingType, out infos);
            return infos ?? new List<ContextProperty>();
        }


        // ------------------------------
        //    helpers
        // -----------------------------

        private bool IsOnTheSameView(object instance) {
            var @interface = ExtractDirectInterface(instance);
            return globalViewManager.CurrentViewInterface == @interface;
        }

        private static Type ExtractDirectInterface(object instance) {
            var type = instance.GetType();
            var @interface = type.FindInterfaces(DirectInterfaceFilter, type).Single();
            return @interface;
        }

        internal static bool DirectInterfaceFilter(Type typeObj, Object criteriaObj) {
            var value = ((Type) criteriaObj).Name;
            value = value.Replace("Model", "");
            return typeObj.Name.Contains(value);
        }
    }
}