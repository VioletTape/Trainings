using System.Collections.Generic;

namespace Installation_v2.InstallationLogic.Specifications {
    public class PrerequirmentsNetFramework : ISpecification {
         private readonly List<string> versions;

        public PrerequirmentsNetFramework(List<string> versions) {
            this.versions = versions;
        }

        public bool IsSatisfied<T>(T version) {
            return versions.Contains(string.Format(".NET CLR {0}",version));
        }
    }
}