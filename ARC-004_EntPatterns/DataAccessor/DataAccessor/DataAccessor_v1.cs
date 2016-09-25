using System;
using System.Collections.Generic;

namespace DataAccessor.Example1 {
    public class MyClient {
        public void Foo() {
            DataAccessor dataAccessor = ioc.Get<DataAccessor>();
            dataAccessor.Save(new List<SuperHero>());
        }
    }

















    public class DataAccessor {
        private readonly Dictionary<Type, ISpecificDataAccessor> mapper;
        private readonly IUpdateFactory updateFactory;

        public DataAccessor() {
            mapper = new Dictionary<Type, ISpecificDataAccessor> {
                              {typeof(SuperHero), new SuperHeroDataAccessor(updateFactory)}
                                                                 };
            updateFactory = IoC.Get<IUpdateFactory>();
        }

        public void Save<T>(IEnumerable<T> list) {
            mapper[typeof(T)].Update(list);
        }
    }

    internal class SuperHeroDataAccessor : ISpecificDataAccessor {
        private readonly IUpdateFactory updateFactory;

        public SuperHeroDataAccessor(IUpdateFactory updateFactory) {
            this.updateFactory = updateFactory;
        }

        public void Update<T>(IEnumerable<T> list) {
            foreach (var item in list) {
                new TableGateWay("heroes").Update(item);
                new TableGateWay("persons").Update(item);
            }
        }
    }

    public interface ISpecificDataAccessor {
        void Update<T>(IEnumerable<T> list);
    }

    public interface IUpdateFactory {
        object GetSetFor<T>();
    }

    public class SuperHero {}

    public class SuperVillian {}

    public class Location {}
}