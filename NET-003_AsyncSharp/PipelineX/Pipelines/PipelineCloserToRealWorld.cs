using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using Commons;
using FizzWare.NBuilder;

namespace Pipelines {
    public class PipelineCloserToRealWorld {
        private ReadData readService;

        public void Setup() {
            // get/init services
            readService = new ReadData();
            var processServiceA = new ProcessData();
            var processServiceB = new ProcessData();
            var writeService = new WriteData();

            // setup balancer
            var processBalancer = new StreamBalancer<string>();
            processBalancer.AddWorker(s => processServiceA.Process(s));
            processBalancer.AddWorker(s => processServiceB.Process(s));

            // setup pipeline workflow
            readService.ReadStream
                       .Subscribe(processBalancer.Balance);

            processServiceA.ProcessedStream
                           .ObserveOn(NewThreadScheduler.Default)
                           .Subscribe(writeService.Write);

            processServiceB.ProcessedStream
                           .ObserveOn(NewThreadScheduler.Default)
                           .Subscribe(writeService.Write);
        }

        public void Start() {
            var data = Builder<string>.CreateListOfSize(60)
                                   .Build()
                                   .ToList();

            foreach (var s in data) {
                readService.Read(s);
            }
        }
    }

    internal class StreamBalancer<TDataType> {
        private readonly Queue<Action<TDataType>> actions = new Queue<Action<TDataType>>();

        public void AddWorker(Action<TDataType> action) {
            actions.Enqueue(action);
        }

        public void Balance<TData>(TData data) where TData : TDataType {
            var worker = actions.Dequeue();
            worker(data);
            actions.Enqueue(worker);
        }
    }
}