using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using Commons;

namespace MEFTests {
    public class MyClass {
        private CompositionContainer container;

        [ImportMany]
        public Lazy<IService>[] Services { get; set; }

        public void Init(CompositionContainer container = null) {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog("AddIns"));
            this.container = container ?? new CompositionContainer(catalog, CompositionOptions.DisableSilentRejection | CompositionOptions.IsThreadSafe);
            this.container.ComposeParts(this);
        }

        
    }
}