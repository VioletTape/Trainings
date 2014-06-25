using System;
using System.Collections.Generic;
using System.Timers;
using System.Reactive.Subjects;

namespace NotificationBarLib.Core {
    public class StatusMessageManager {
        private readonly Stack<TemporaryMessage> timerMessages = new Stack<TemporaryMessage>();
        private string constMessage = "";
        private TemporaryMessage recentMessage;

        private readonly BehaviorSubject<string> subject = new BehaviorSubject<string>("");

        public IObservable<string> MessageStream() {
            return subject;
        }

        public void SetMessage(string message, int freezeTime = 0) {
            if (freezeTime < 0)
                freezeTime = 0;

            if (timerMessages.Count == 0) {
                subject.OnNext(message);
            }

            if (freezeTime == 0) {
                constMessage = message;
            }

            recentMessage = new TemporaryMessage(message, freezeTime, CheckNextMessage);
            if (freezeTime > 0) {
                timerMessages.Push(recentMessage);
                subject.OnNext(message);
            }
        }

        private void CheckNextMessage(TemporaryMessage expiredMessage) {
            TemporaryMessage message = null;

            if (timerMessages.Count == 0) {
                subject.OnNext(constMessage);

                return;
            }

            if (expiredMessage != timerMessages.Peek()) {
                return;
            }

            while (timerMessages.Count > 0) {
                message = timerMessages.Peek();
                if (!message.IsExpired)
                    break;

                timerMessages.Pop();
            }
            subject.OnNext(message == null || message.IsExpired
                               ? constMessage
                               : message.Message);
        }


        private class TemporaryMessage : IDisposable {
            private readonly Timer timer = new Timer();
            private readonly int lifeTime;
            private Action<TemporaryMessage> expired;

            public string Message { get; private set; }
            public bool IsExpired { get; private set; }

            public TemporaryMessage(string message, int lifeTime, Action<TemporaryMessage> expired) {
                this.lifeTime = lifeTime;
                this.expired = expired;

                Message = message;
                IsExpired = false;

                if (lifeTime > 0) {
                    timer.Interval = this.lifeTime*1000;
                    timer.Elapsed += (sender, args) => Elapsed();
                    timer.Start();
                }
            }

            private void Elapsed() {
                timer.Stop();

                IsExpired = true;
                expired(this);
            }

            public void Dispose() {
                expired = null;
                timer.Dispose();
            }
        }
    }
}