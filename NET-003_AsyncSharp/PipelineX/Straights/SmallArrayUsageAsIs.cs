using System.Collections.Generic;
using System.Diagnostics;
using Commons;
using NUnit.Framework;
using FluentAssertions;

namespace Straights {
    [TestFixture]
    public class SmallArrayUsageAsIs {
        private Stopwatch timer;
        private List<string> result;
        private List<string> data;

        [TestFixtureSetUp]
        public void Setup() {
            var service = new UpdateDataService();

            data = new List<string> {"1", "2", "3", "4"};

            timer = Stopwatch.StartNew();
            result = data.ConvertAll(i =>
                                     service.FinalPhase(
                                         service.MiddlePhase(
                                             service.StartPhase(i))));
            timer.Stop();
        }
                
        [Test]
        public void CorrectnesTest() {  
            result
                .Should()
                .BeEquivalentTo(new[] {
                                          "1smf",
                                          "2smf",
                                          "3smf",
                                          "4smf",
                                      });
        }

        [Test]
        public void TimeElapsed() {
            timer.Elapsed.Seconds
                 .Should()
                 .Be(data.Count*(1 + 2 + 1));
        }
    }
}