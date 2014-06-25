using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using FluentAssertions;
using NSubstitute;
using NSubstituteAutoMocker;
using NUnit.Framework;
using StructureMap.AutoMocking;

namespace TestProjectNSSide
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void ManualUnitTest()
        {
            var factory = Substitute.For<ISuperHeroFactory>();
            var log = Substitute.For<ILogService>();
            var someWeirdService = Substitute.For<ISomeWeirdService>();
            var repository = Substitute.For<IBigRepository>();

            factory.Create(isEvil: true)
                   .Returns(new SuperHero { Name = "Badass" });


            var viewModel = new SuperHeroViewModel(factory, log, someWeirdService, repository);

            viewModel.CreateVillan()
                .Name
                .Should()
                .Be("Badass");
        }

        [Test]
        public void AutoMockUsage()
        {
            var mock = new NSubstituteAutoMocker<SuperHeroViewModel>();

            mock.Get<ISuperHeroFactory>()
                   .Create(isEvil: true)
                   .Returns(new SuperHero { Name = "Badass" });


            mock.ClassUnderTest.CreateVillan()
                .Name
                .Should()
                .Be("Badass");
        }
    }
}
