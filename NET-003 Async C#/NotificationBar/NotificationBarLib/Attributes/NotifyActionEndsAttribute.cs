using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using NotificationBarLib.Core;
using PostSharp.Aspects;
using StructureMap;

namespace NotificationBarLib.Attributes {
    [Serializable]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class NotifyActionEndsAttribute : OnMethodBoundaryAspect {
        public string Id { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }

        public override void OnSuccess(MethodExecutionArgs args) {
            var manager = ObjectFactory.GetInstance<INotificationManager>();

            if (string.IsNullOrWhiteSpace(Icon)) {
                Icon = NotifyIcon.Yes;
            }

            if (string.IsNullOrWhiteSpace(Title)) {
                Title = "Сообщение";
            }
            else {
                if (IsContextValue(Title))
                    Title = GetContextValueFor(args, Title);
            }

            if (string.IsNullOrWhiteSpace(Message)) {
                Message = "Действие завершено";
            }
            else {
                if (IsContextValue(Message))
                    Message = GetContextValueFor(args, Message);
            }
            manager.SuccessfullNotification(Id, args.Instance, Icon, Message, Title);

            base.OnSuccess(args);
        }


        public override void OnException(MethodExecutionArgs args) {
            var manager = ObjectFactory.GetInstance<INotificationManager>();
            manager.ExceptionNotification(Id, args.Instance);

            manager.ExceptionNotification(Id, args.Instance, NotifyIcon.Exclamation, ErrorMessage, Title);

            base.OnException(args);
        }



        private bool IsContextValue(string value) {
            return value.StartsWith("@");
        }

        private string GetContextValueFor(MethodExecutionArgs args, string value) {
            var name = value.Remove(0, 1);

            var type = args.Instance.GetType();

            var memberInfos = type.GetMember(name).SingleOrDefault();
            if (memberInfos != null) {
                if (memberInfos.MemberType == MemberTypes.Property) {
                    var obj = type.GetProperty(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
                    var val = obj.GetValue(args.Instance, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy, null, null, CultureInfo.CurrentCulture);
                    if (val == null) {
                        return value;
                    }
                    var valueFor = val.ToString();
                    return valueFor;
                }

                if (memberInfos.MemberType == MemberTypes.Field) {
                    var contextValueFor = type.GetField(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy)
                        .GetValue(args.Instance);
                    if (contextValueFor == null) {
                        return value;
                    }
                    return contextValueFor.ToString();
                }
            }

            return value;
        }
    }

    public static class NotifyIcon {
        public const string Question = @"Icons\128\question_128.png";
        public const string Chat = @"Icons\128\talk_128.png";
        public const string Yes = @"Icons\check_yes.png";
        public const string Exclamation = @"Icons\128\exclamation_128.png";
        public const string Refresh = @"Icons\128\refresh_128.png";
        public const string Reload = @"Icons\128\reload_128.png";
    }
}