using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using Commons;
using FizzWare.NBuilder;
using FluentAssertions;
using NUnit.Framework;



namespace Pipelines {
    [TestFixture]
    public class BigArrayUsagePipeline {
        private Stopwatch timer;
        private readonly List<string> result = new List<string>();
        private List<string> data;

        [TestFixtureSetUp]
        public void Setup() {
            var service = new UpdateDataService();

            data = Builder<int>.CreateListOfSize(60).Build().Select(i => i.ToString()).ToList();

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
                var startPhaseResult = service.StartPhase(s);
                start.OnNext(startPhaseResult);
            }

            var timeSpan = timer.Elapsed.Seconds;

            while (result.Count < data.Count) {
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
                 .BeLessOrEqualTo(data.Count*2 + 1 + 1 + buffer); // 60*2 + 3 = 123
        }
    }

    [TestFixture]
    public class BigArrayUsagePipelineOpt {
        private Stopwatch timer;
        private readonly List<string> result = new List<string>();
        private List<string> data;
        private int elapsed;

        [TestFixtureSetUp]
        public void Setup() {
            var service = new UpdateDataService();

            data = Builder<int>.CreateListOfSize(60).Build().Select(i => i.ToString()).ToList();

            timer = Stopwatch.StartNew();
            var startTime = DateTime.Now;

            var start = new ReplaySubject<string>();
            var middle1 = new ReplaySubject<string>();
            var middle2 = new ReplaySubject<string>();
            var final = new ReplaySubject<string>();
            var collect = new ReplaySubject<string>();

            var observables = new Queue<ReplaySubject<string>>();
            observables.Enqueue(middle1);
            observables.Enqueue(middle2);

            var balancer = new ReplaySubject<string>();


            start
                .Subscribe(s => {
                               var startPhaseResult = service.StartPhase(s);
                               balancer.OnNext(startPhaseResult);
                           });

            balancer
                .Subscribe(s => {
                               var subject = observables.Dequeue();
                               subject.OnNext(s);
                               observables.Enqueue(subject);
                           });

            middle1
                .ObserveOn(NewThreadScheduler.Default)
                .Subscribe(s => final.OnNext(service.MiddlePhase(s+"1")));

            middle2
                .ObserveOn(NewThreadScheduler.Default)
                .Subscribe(s => final.OnNext(service.MiddlePhase(s+"2")));

            final
                .ObserveOn(NewThreadScheduler.Default)
                .Subscribe(s => collect.OnNext(service.FinalPhase(s)));

            collect
                .ObserveOn(NewThreadScheduler.Default)
                .Subscribe(s => result.Add(s));


            foreach (var s in data) {
                start.OnNext(s);
            }

            while (result.Count < data.Count) {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
            }

            var endTime = DateTime.Now;
            
            timer.Stop();

            elapsed = (endTime - startTime).Seconds;
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
            var buffer = 1;
            elapsed
                 .Should()
                 .Be(data.Count*2 + 1 + 1 + buffer); // 60*2 + 3 = 123
        }
    }
}
