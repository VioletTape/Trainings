using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using Commons;
using FluentAssertions;
using NUnit.Framework;

namespace Pipelines {
    [TestFixture]
    public class SmallArrayUsagePipelineAsynOptimized {
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
                .Subscribe(async s => {
                                     var t = new TaskFactory<string>().StartNew(() => service.MiddlePhase(s));
                                     await t;
                                     middle.OnNext(t.Result);
                                 }, () => { middle.OnCompleted(); });
            middle
                .Subscribe(async s => {
                                     var t = new TaskFactory<string>().StartNew(() => service.FinalPhase(s));
                                     await t;
                                     final.OnNext(t.Result);
                                 }, () => final.OnCompleted());
            final
                .Subscribe(s => result.Add(s));

            foreach (var s in data) {
                start.OnNext(service.StartPhase(s));
            }
            

            while (result.Count < 4) {
                Thread.Sleep(TimeSpan.FromSeconds(1));
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
            timer.Elapsed.Seconds
                 .Should()
                 .BeLessOrEqualTo(data.Count + 2 + 1 + 1);
        }
    }
}