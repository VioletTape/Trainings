using System.Text;
using StructureMap;
using StructureMap.Pipeline;

namespace ClassLibrary1
{
    public class LogService : ILogService
    {
        private StringBuilder log = new StringBuilder();
        
        public void Write(string message, params object[] param)
        {
            log.AppendFormat(message, param);
            log.AppendLine();
        }

        public string GetLog()
        {
            return log.ToString();
        }
    }

    public class NameGenerator : INameGenerator
    {
        public string GetName(bool isEvil)
        {
            return isEvil ? "Death Megatron 9000" : "Lighting Moe";
        }
    }

    public interface ISomeWeirdService
    {}

    public class SomeWeirdService : ISomeWeirdService
    {
        
    }

    public interface IBigRepository
    {}

    public class BigRepository : IBigRepository
    {
        
    }

    public class SuperHeroFactory : ISuperHeroFactory
    {
        private readonly INameGenerator nameGenerator;
        private readonly ILogService logService;

        public SuperHeroFactory(INameGenerator nameGenerator, ILogService logService)
        {
            this.nameGenerator = nameGenerator;
            this.logService = logService;
        }

        public SuperHero Create(bool isEvil)
        {
            var name = nameGenerator.GetName(isEvil);
            return new SuperHero
            {
                Name = name
            };
        }
    }

    public class SuperHeroViewModel
    {
        private readonly ISuperHeroFactory factory;
        private readonly ILogService logService;

        public SuperHeroViewModel(ISuperHeroFactory factory, ILogService logService, ISomeWeirdService someWeirdService, IBigRepository repository)
        {
            this.factory = factory;
            this.logService = logService;
        }

        public SuperHero CreateHero()
        {
            return factory.Create(isEvil: false);
        }

        public SuperHero CreateVillan()
        {
            return factory.Create(isEvil:true);
        }
    }

    public class SuperHero
    {
        public string Name { get; set; }
    }

    public class SomeBootstrapper
    {
        public SomeBootstrapper()
        {
            ObjectFactory.Configure(
                x =>
                {
                    x.For<ILogService>().Add<LogService>().SetLifecycleTo(new SingletonLifecycle());
                    x.For<INameGenerator>().Add<NameGenerator>().SetLifecycleTo<SingletonLifecycle>();
                    x.For<ISuperHeroFactory>().Add<SuperHeroFactory>();
                    x.For<SuperHeroViewModel>().Add<SuperHeroViewModel>();
                }
                );
        }

        public T Get<T>()
        {
            return ObjectFactory.GetInstance<T>();
        }
    }
}