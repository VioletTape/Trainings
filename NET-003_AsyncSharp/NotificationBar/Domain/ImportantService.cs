using System;
using System.Threading;

namespace Domain {
    public class ImportantService : IImportantService {
         public void PretendItLastsFor(int seconds) {
             Thread.Sleep(TimeSpan.FromSeconds(seconds));
         }

        public T PretendItLastsFor<T>(int seconds) {
            return default(T);
        }
    }
}