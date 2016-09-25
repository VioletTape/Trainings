using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Commons;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace PureTasks {
    [TestFixture]
    public class SmallArrayUsageTasks {
        private Stopwatch timer;
        private List<string> result;
        private List<string> data;

        [TestFixtureSetUp]
        public void Setup() {
            var service = new UpdateDataService();

            data = new List<string> {"1", "2", "3", "4"};

            timer = Stopwatch.StartNew();

            var tasks = new List<Task<string>>(4);

            foreach (var s in data) {
                var first = new Task<string>(() => service.StartPhase(s));
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
                 .Be(1 + 2 + 1);
        }
    }
}