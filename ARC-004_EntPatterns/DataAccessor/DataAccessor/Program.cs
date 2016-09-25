using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessor
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }


    public class DataAccessor {
        private Dictionary<Type, ISpecificDataAccessor> mapper;
        private IUpdateFactory updateFactory;

        public DataAccessor() {
            mapper = new Dictionary<Type, ISpecificDataAccessor> {
                                                      {typeof(SuperHero), new SuperHeroDataAccessor(updateFactory)},
                                                  };
            updateFactory = IoC.Get<IUpdateFactory>();
        }

        public void Save<T>(IEnumerable<T> list) {
            mapper[typeof(T)].Update(list);
            
        }
    }

    internal class SuperHeroDataAccessor : ISpecificDataAccessor  {
        private readonly IUpdateFactory updateFactory;
        public SuperHeroDataAccessor(IUpdateFactory updateFactory) {
            this.updateFactory = updateFactory;
        }

        public void Update<T>(IEnumerable<T> list) {
            foreach (var item in list)
            {
                var query = string.Format("update heroes set {1} where id={2}", updateFactory.GetSetFor<T>(), item.Id);
                new TableGateWay().Update(query);
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

    public class SuperVillian { }
    public class Location { }
}
