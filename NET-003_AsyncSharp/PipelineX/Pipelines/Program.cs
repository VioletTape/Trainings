namespace Pipelines {
    internal class Program {
        private static void Main(string[] args) {
//            new SmallArrayUsagePipelineOptimized().Setup();

            var pipeline = new PipelineCloserToRealWorld();
            pipeline.Setup();

            pipeline.Start();
        }
    }
}