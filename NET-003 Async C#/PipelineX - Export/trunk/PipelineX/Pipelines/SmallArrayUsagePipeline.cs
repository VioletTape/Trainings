using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reactive.Subjects;
using Commons;
using NUnit.Framework;
using FluentAssertions;

namespace Pipelines {
    [TestFixture]
    public class SmallArrayUsagePipeline {
        private Stopwatch timer;
        private List<string> result = new List<string>();
        private List<string> data;

        [TestFixtureSetUp]
        public void Setup() {
            var service = new UpdateDataService();

            data = new List<string> {"1", "2", "3", "4"};

            timer = Stopwatch.StartNew();
            

            var start = new Subject<string>();
            var middle = new Subject<string>();
            var final = new Subject<string>();

            start.Subscribe(s => middle.OnNext(service.MiddlePhase(s)));
            middle.Subscribe(s => final.OnNext(service.FinalPhase(s)));
            final.Subscribe(s => result.Add(s));

            foreach (var s in data) {
                start.OnNext(service.StartPhase(s));
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
                 .Be(data.Count*(1 + 2 + 1));
        }
    }
}