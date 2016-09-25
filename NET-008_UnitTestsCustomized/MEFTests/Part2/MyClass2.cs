using System.ComponentModel.Composition;
using Commons;

namespace Part2 {
    [Export(typeof (IService))]
    public class MyClass2 : IService {
        public string Name { get; set; }

        public void Do(object obj) {
            Name = "Real MyClass2";
        }
    }
}