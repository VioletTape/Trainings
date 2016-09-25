using System;
using System.Collections.Generic;

namespace DataAccessor.Example2
{
    public class MyClient {
        public void Foo() {
            DataAccessor dataAccessor = ioc.Get<DataAccessor>();
            dataAccessor.Save(new List<SuperHero>());
        }
    }

    public class DataAccessor
    {
        private IoC ioc;

        public DataAccessor(IoC ioc) {
            this.ioc = ioc;
        }

        public void Save<T>(IEnumerable<T> list)
        {
            ioc.Get<TableGateway<T>>.Update(list);

        }
    }

    internal class TableGateway<T> 
    {
        private readonly IUpdateFactory updateFactory;
        public TableGateway(IUpdateFactory updateFactory)
        {
            this.updateFactory = updateFactory;
        }

        public void Update<T>(IEnumerable<T> list)
        {
            foreach (var item in list)
            {
                var comand = string.Format("update heroes set {1} where id={2}", 
                    updateFactory.GetSetFor<T>(), item.Id);
                persistentStorage.ExequteNonQuery(comand);
            }
        }
    }

    public interface IUpdateFactory
    {
        object GetSetFor<T>();
    }

    public class SuperHero { }

    public class SuperVillian { }
    public class Location { }
}