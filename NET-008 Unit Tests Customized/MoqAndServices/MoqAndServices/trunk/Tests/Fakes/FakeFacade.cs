using System;
using System.Collections.Generic;
using Application.Services.Interfaces;

namespace Tests.Fakes {
    public class FakeFacade : IDataFacade {
        private readonly Dictionary<Type, dynamic> storedItems = new Dictionary<Type, dynamic>();

        public void Store<T>(List<T> items) {
            var type = typeof (T);

            if (!storedItems.ContainsKey(type)) {
                storedItems[type] = new List<T>();
            }

            ((List<T>) storedItems[type]).AddRange(items);
        }

        public List<T> Get<T>(Func<T, bool> spec) {
            var type = typeof (T);

            if (storedItems.ContainsKey(type)) {
                return ((List<T>) storedItems[type]);
            }

            return new List<T>();
        }
    }
}