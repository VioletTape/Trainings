using System.Diagnostics;
using System.Threading.Tasks;
using Commons;
using FluentAssertions;
using NUnit.Framework;

namespace PureTasks {
    [TestFixture]
    public class ObviousUsageTasks {
        [Test]
        public void ShouldTakeAtLeast4Seconds()
        {
            // arrange
            var service = new EmptyService();

            // act
            var timer = Stopwatch.StartNew();

            var first = new Task(service.StartPhase);
            var final = first.ContinueWith(t => service.MiddlePhase())
                .ContinueWith(t => service.FinalPhase());
            first.Start();
            final.Wait();

            timer.Stop();

            // assert
            timer.Elapsed.Seconds
                 .Should()
                 .Be(4);
        }
    }
}