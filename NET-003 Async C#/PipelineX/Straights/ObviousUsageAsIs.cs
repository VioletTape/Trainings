using System.Diagnostics;
using Commons;
using NUnit.Framework;
using FluentAssertions;

namespace Straights {
    [TestFixture]
    public class  ObviousUsageAsIs {
        [Test] 
        public void ShouldTakeAtLeast4Seconds() {
            // arrange
            var service = new EmptyService();

            // act
            var timer = Stopwatch.StartNew();

            service.StartPhase();
            service.MiddlePhase();
            service.FinalPhase();

            timer.Stop();

            // assert
            timer.Elapsed.Seconds
                 .Should()
                 .Be(4);
        }
    }
}