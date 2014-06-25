using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reactive.Concurrency;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using Commons;
using FluentAssertions;
using NUnit.Framework;
using System.Reactive.Linq;

namespace Pipelines {
    [TestFixture]
    public class SmallArrayUsagePipelineOptimized {
        private Stopwatch timer;
        private readonly List<string> result = new List<string>();
        private List<string> data;

        [TestFixtureSetUp]
        public void Setup() {
            var service = new UpdateDataService();

            data = new List<string> {"1", "2", "3", "4"};

            timer = Stopwatch.StartNew();


            var start = new ReplaySubject<string>();
            var middle = new ReplaySubject<string>();
            var final = new ReplaySubject<string>();

            start
                .ObserveOn(NewThreadScheduler.Default)
                .Subscribe(s => middle.OnNext(service.MiddlePhase(s)));
            middle
                .ObserveOn(NewThreadScheduler.Default)
                .Subscribe(s => final.OnNext(service.FinalPhase(s)));
            final
                .ObserveOn(NewThreadScheduler.Default)
                .Subscribe(s => result.Add(s));

            foreach (var s in data) {
                start.OnNext(service.StartPhase(s));
            }

            var timeSpan = timer.Elapsed.Seconds;

            while (result.Count < 4) {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
            }

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
            var buffer = 1;
            timer.Elapsed.Seconds
                 .Should()
                 .BeLessOrEqualTo(data.Count*2 + 1 + 1 + buffer);
        }
    }
}