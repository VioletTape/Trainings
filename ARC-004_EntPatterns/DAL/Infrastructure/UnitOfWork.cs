using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Infrastructure {
    public class UnitOfWork : IUnitOfWork {
        private readonly Dictionary<Type, List<object>> persisted = new Dictionary<Type, List<object>>();
        private readonly Dictionary<Type, List<object>> saved = new Dictionary<Type, List<object>>();
        private readonly Dictionary<Type, List<object>> deleted = new Dictionary<Type, List<object>>();

        public void Save(object item) {
            var type = CheckTypeExistence(item, saved);

            if (!saved[type].Contains(item))
                saved[type].Add(item);

            deleted[type].Remove(item);
        }

        public void Delete(object item) {
            var type = CheckTypeExistence(item, deleted);

            saved[type].Remove(item);

            if (!deleted[type].Contains(item))
                deleted[type].Add(item);
        }

        public void Register(object item) {
            var type = CheckTypeExistence(item, persisted);

            persisted[type].Add(item);
        }

        public void RegisterAll<T>(List<T> item) {
            if (!item.Any()) return;

            var type = CheckTypeExistence(item.First(), persisted);

            persisted[type].AddRange(item.Cast<object>());
        }

        public void Commit() {
            foreach (var pair in saved) {
                persisted[pair.Key].AddRange(pair.Value);
                saved[pair.Key].Clear();

                persisted[pair.Key].RemoveAll(i => deleted[pair.Key].Contains(i));
                deleted[pair.Key].Clear();
            }
        }

        public void Rollback() {
            foreach (var pair in saved) {
                saved[pair.Key].Clear();
                deleted[pair.Key].Clear();
            }
        }

        public void Clear() {
            persisted.Clear();
            saved.Clear();
            deleted.Clear();
        }

        public List<T> GetActive<T>() {
            var type = typeof (T);

            if (!persisted.ContainsKey(type)) {
                return new List<T>();
            }

            return persisted[type]
                .Union(saved[type])
                .Except(deleted[type])
                .Cast<T>().Distinct().ToList();
        }


        private Type CheckTypeExistence(object item, Dictionary<Type, List<object>> list) {
            var type = item.GetType();

            if (!list.ContainsKey(type)) {
                saved[type] = new List<object>();
                deleted[type] = new List<object>();
                persisted[type] = new List<object>();
            }
            return type;
        }


        public void ForEachInserted<T>(Action<T> action) {
            var type = typeof (T);
            var list = saved[type].Except(persisted[type]).Cast<T>().ToList();
            list.ForEach(action);
        }

        public void ForEachUpdated<T>(Action<T> action) {
            var type = typeof (T);
            var list = saved[type].Intersect(persisted[type]).Cast<T>().ToList();
            list.ForEach(action);
        }

        public void ForEachDeleted<T>(Action<T> action) {
            deleted[typeof (T)].Cast<T>().ToList().ForEach(action);
        }


        public List<Type> GetRegisteredTypes() {
            return persisted.Keys.ToList();
        }
    }
}