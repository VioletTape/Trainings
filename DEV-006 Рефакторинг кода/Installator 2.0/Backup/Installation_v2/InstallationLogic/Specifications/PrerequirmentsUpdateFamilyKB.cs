using System.Collections.Generic;

namespace Installation_v2.InstallationLogic.Specifications {
    public class PrerequirmentsUpdateFamilyKB : ISpecification {
        private readonly List<string> installedUpdates = new List<string>();

        public PrerequirmentsUpdateFamilyKB(List<string> installedUpdates) {
            this.installedUpdates = installedUpdates;
        }

        public bool IsSatisfied<T>(T item) {
            return installedUpdates.Find(i => i.StartsWith(item.ToString())) != null;
        }
    }
}