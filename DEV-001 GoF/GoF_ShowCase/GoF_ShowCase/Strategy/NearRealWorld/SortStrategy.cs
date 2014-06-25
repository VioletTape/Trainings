using System.Collections.Generic;

namespace GoF_ShowCase.Strategy.NearRealWorld {
    internal abstract class SortStrategy {
        public abstract void Sort(List<string> list);
    }
}