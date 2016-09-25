using System;
using System.Collections;

namespace GoF_ShowCase.Builder.SimpleStructure {
    internal class Product {
        private readonly ArrayList parts = new ArrayList();

        public void Add(string part) {
            parts.Add(part);
        }

        public void Show() {
            Console.WriteLine("\nProduct Parts -------");
            foreach (string part in parts) {
                Console.WriteLine(part);
            }
        }
    }
}