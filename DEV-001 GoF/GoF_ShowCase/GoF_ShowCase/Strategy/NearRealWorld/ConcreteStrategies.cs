using System;
using System.Collections.Generic;

namespace GoF_ShowCase.Strategy.NearRealWorld {
    internal class QuickSort : SortStrategy {
        public override void Sort(List<string> list) {
            list.Sort(); // Default is Quicksort
            Console.WriteLine("QuickSorted list ");
        }
    }

    internal class ShellSort : SortStrategy {
        public override void Sort(List<string> list) {
            //list.ShellSort(); not-implemented
            Console.WriteLine("ShellSorted list ");
        }
    }

    internal class MergeSort : SortStrategy {
        public override void Sort(List<string> list) {
            //list.MergeSort(); not-implemented
            Console.WriteLine("MergeSorted list ");
        }
    }
}