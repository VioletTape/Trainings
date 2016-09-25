using System;
using System.Diagnostics;
using System.Reactive.Subjects;
using Commons;
using FluentAssertions;
using NUnit.Framework;

namespace Pipelines {
    [TestFixture]
    public class ObviousUsagePipeline {
        [Test]
        public void ShouldTakeAtLeast4Seconds() {
            // arrange
            var service = new EmptyService();

            // act
            var timer = Stopwatch.StartNew();



            var start = new Subject<Action>();
            var middle = new Subject<Action>();
            var final = new Subject<Action>();

            start.Subscribe(s => {
                                s();
                                middle.OnNext(service.MiddlePhase);
                            });
            middle.Subscribe(m => {
                                 m();
                                 final.OnNext(service.FinalPhase);
                             });

            final.Subscribe(f => f());

            start.OnNext(service.StartPhase);

            timer.Stop();

            // assert
            timer.Elapsed.Seconds
                 .Should()
                 .Be(4);
        }
    }
}