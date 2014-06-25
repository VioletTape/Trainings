using System;
using System.Collections.Generic;

namespace GoF_ShowCase.Strategy.NearRealWorld {
    internal class SortedList {
        private readonly List<string> list = new List<string>();
        private SortStrategy sortstrategy;

        public void SetSortStrategy(SortStrategy sortstrategy) {
            this.sortstrategy = sortstrategy;
        }

        public void Add(string name) {
            list.Add(name);
        }

        public void Sort() {
            sortstrategy.Sort(list);

            // Iterate over list and display results
            foreach (var name in list) {
                Console.WriteLine(" " + name);
            }
            Console.WriteLine();
        }
    }
}