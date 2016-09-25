using System;
using System.Linq;
using System.Reflection;
using NotificationBarLib.Core;
using PostSharp;
using PostSharp.Aspects;
using PostSharp.Aspects.Advices;
using PostSharp.Extensibility;
using StructureMap;

namespace NotificationBarLib.Attributes {
    [MulticastAttributeUsage(MulticastTargets.Class, PersistMetaData = true)]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    [Serializable]
    public class SupportNotificationBar : TypeLevelAspect {
        [OnMethodExitAdvice, MulticastPointcut(MemberName = ".ctor", Attributes = MulticastAttributes.Instance)]
        public void OnExit(MethodExecutionArgs args) {
            var manager = ObjectFactory.GetInstance<INotificationManager>();
            var underlayingType = args.Instance.GetType();

            var contextDependentProperties = underlayingType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(i => i.GetCustomAttributes<NotifyContextImportant>().Any())
                .Select(i => i)
                .ToList();

            var props = manager.GetContextImportantProperties(underlayingType);
            contextDependentProperties.ForEach(i => props.ForEach(p => p.SetValueFor(i, args.Instance)));
            manager.RegisterForNotification(underlayingType, args.Instance);
            manager.RegisterContextProperties(underlayingType, contextDependentProperties);
        }


        [OnMethodEntryAdvice, MulticastPointcut(MemberName = "Dispose", Attributes = MulticastAttributes.Instance)]
        public void OnClassDispose(MethodExecutionArgs args) {
            // send signal to manager that we are done with class and it's safely to remove it from tracking
            var manager = ObjectFactory.GetInstance<INotificationManager>();
            manager.UnregisterNotifications(args.Instance);
        }

        public override bool CompileTimeValidate(Type type) {
            if (type.GetInterface("IDisposable") == null) {
                var constructorInfo = type.GetConstructors().Single();
                Message.Write(MessageLocation.Of(constructorInfo), SeverityType.Error, "Not Implemented", "IDisposable is not implemented for the type {0}", type.Name);
                return false;
            }

            return base.CompileTimeValidate(type);
        }
    }
}