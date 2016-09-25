using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Commons;
using FizzWare.NBuilder;
using FluentAssertions;
using NUnit.Framework;

namespace PureTasks {
    [TestFixture]
    public class BigArrayUsageTasks {
        private Stopwatch timer;
        private List<string> result;
        private List<string> data;

        [TestFixtureSetUp]
        public void Setup() {
            var service = new UpdateDataService();

            data = Builder<int>.CreateListOfSize(60).Build().Select(i => i.ToString()).ToList();

            timer = Stopwatch.StartNew();

            var tasks = new List<Task<string>>(4);

            foreach (var s in data) {
                var first = new Task<string>(() => service.StartPhase(s), TaskCreationOptions.LongRunning);
                var final = first.ContinueWith(t => service.MiddlePhase(t.Result))
                                 .ContinueWith(t => service.FinalPhase(t.Result));
                tasks.Add(final);
                first.Start();
            }

            Task.WaitAll(tasks.ToArray());

            timer.Stop();

            result = tasks.Select(i => i.Result).ToList();
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
                 .Be(1 + 2 + 1);
            // 40, 38, 42, 43, 40,  42, 41, 41, 40, 42

            // no op 53, 53, 53, 51, 52,  52, 53, 50, 51, 53
        }
    }
}