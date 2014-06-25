using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using StructureMap.AutoMocking.NSubstitute;
using StructureMap.AutoMocking;

namespace TestProject
{
    [TestFixture]
    public class SuperHeroViewModelTests
    {
        [Test]
        public void IntegrationTest()
        {
            var bootstrapper = new SomeBootstrapper();
            var viewModel = bootstrapper.Get<SuperHeroViewModel>();

            viewModel.CreateHero()
                .Name
                .Should()
                .Be("Lighting Moe");

            viewModel.CreateVillan()
                .Name
                .Should()
                .Be("Death Megatron 9000");
        }

        [Test]
        public void ManualUnitTest()
        {
            var factory = Substitute.For<ISuperHeroFactory>();
            var log = Substitute.For<ILogService>();
            var someWeirdService = Substitute.For<ISomeWeirdService>();
            var repository = Substitute.For<IBigRepository>();

            factory.Create(isEvil:true)
                   .Returns(new SuperHero{Name = "Badass"});


            var viewModel = new SuperHeroViewModel(factory, log, someWeirdService, repository);

            viewModel.CreateVillan()
                .Name
                .Should()
                .Be("Badass");
        }

        [Test]
        public void AutoMockUsage()
        {
            
            var autoMocker = (AutoMocker<SuperHeroViewModel>)
                          NSubstituteAutoMockerBuilder.Build<SuperHeroViewModel>();

            autoMocker.Get<ISuperHeroFactory>()
                   .Create(isEvil: true)
                   .Returns(new SuperHero { Name = "Badass" });


            autoMocker.ClassUnderTest.CreateVillan()
                .Name
                .Should()
                .Be("Badass");
        }
    }
}
