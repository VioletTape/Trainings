using System.Collections.Generic;

namespace Installation_v2.InstallationLogic.Specifications {
    public class PrerequirmentsUpdateExactKB : ISpecification {
        private readonly List<string> installedUpdates = new List<string>();

        public PrerequirmentsUpdateExactKB(List<string> installedUpdates) {
            this.installedUpdates = installedUpdates;
        }

        public bool IsSatisfied<T>(T item) {
            return installedUpdates.Contains(item.ToString());
        }
    }
}