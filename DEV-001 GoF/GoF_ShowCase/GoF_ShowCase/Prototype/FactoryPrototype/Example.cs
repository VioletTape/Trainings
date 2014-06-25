using System;
using System.Collections.Generic;

namespace GoF_ShowCase.Prototype.FactoryPrototype {
    public class Example {
        public Example() {
            var boxElement = ElementFactory.CreateBox();
        }
    }
}