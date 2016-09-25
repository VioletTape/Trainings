using System.ComponentModel.Composition;
using Commons;

namespace Part1 {
    [Export(typeof (IService))]
    internal class MyClass1 : IService {
        public string Name { get; set; }

        public void Do(object obj) {
            Name = "Real MyClass1";
        }
    }
}