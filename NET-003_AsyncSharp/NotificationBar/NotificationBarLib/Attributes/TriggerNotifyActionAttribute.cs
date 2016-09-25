using System;
using NotificationBarLib.Core;
using PostSharp.Aspects;
using StructureMap;

namespace NotificationBarLib.Attributes {
    [Serializable]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class TriggerNotifyActionAttribute : OnMethodBoundaryAspect {
        public string Id { get; set; }
       

        public override void OnSuccess(MethodExecutionArgs args) {
            var manager = ObjectFactory.GetInstance<INotificationManager>();
            manager.StartTracking(Id, args.Instance);

            base.OnSuccess(args);
        }


    }

  
}