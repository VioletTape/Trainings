using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Commons;
using FizzWare.NBuilder;
using FluentAssertions;
using NUnit.Framework;

namespace Straights {
    [TestFixture]
    public class BigArrayUsageAsIs {
        private Stopwatch timer;
        private List<string> result;
        private List<string> data;

        [TestFixtureSetUp]
        public void Setup() {
            var service = new UpdateDataService();

            data = Builder<int>.CreateListOfSize(60).Build().Select(i => i.ToString()).ToList();

            timer = Stopwatch.StartNew();
            result = data.ConvertAll(i =>
                                     service.FinalPhase(
                                         service.MiddlePhase(
                                             service.StartPhase(i))));
            timer.Stop();
        }
                
        [Test]
        public void CorrectnesTest() {  
           var expected = Builder<int>.CreateListOfSize(60).Build().Select(i => i.ToString()+"smf").ToList();

            result
                .Should()
                .BeEquivalentTo(expected);
        }

        [Test]
        public void TimeElapsed() {
            timer.Elapsed.Seconds
                 .Should()
                 .Be(data.Count*(1 + 2 + 1));
        }
    }
}