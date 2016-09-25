namespace DataAccessor {

 public class Response
    {
        public int Id;
        public string RealName;
        public string Aka;
        public string Abilities;
        public string Age;
        public string Origins;
        public int Type;
    }

    public class SuperHero
    {
        public int Id;
        public string Name;
        public string Abilities;
        public Person RealPerson;
    }

    public class Person
    {
        public int Id;
        public string Name;
        public string Origins;
        public SuperHero AsHero;
    }

    public class MapperSuperHero
    {
        public SuperHero Get(Response response)
        {
            return new SuperHero
            {
                Id = response.Id,
                Name = response.Aka,
                Abilities = response.Abilities
            };
        }
    }

    public class MapperPerson
    {
        public Person Get(Response response)
        {
            return new Person()
            {
                Id = response.Id,
                Name = response.RealName,
                Origins = response.Origins
            };
        }
    }

    public class Mapper
    {
        public TOut MapFrom<TIn, TOut>(TIn from, TOut to) {
            
        }

        public void MapFrom(Response response, UnitOfWork unitOfWork)
        {
            var person = new MapperPerson().Get(response);
            SuperHero hero = new NullSuperHero();
            if (response.Type == 0)
            {
                hero = new MapperSuperHero().Get(response);
            }
            person.AsHero = hero;
            hero.RealPerson = person;

            unitOfWork.Register(person);
            unitOfWork.Register(hero);
        }

        public Response MapTo(Person person)
        {
            return new Response
            {
                //...
            };
        }
    }

    public class NullSuperHero : SuperHero
    {
        public NullSuperHero()
        {

        }
    }

    public class UnitOfWork
    {
        public void Register<T>(T person)
        {
            throw new NotImplementedException();
        }
    }

}