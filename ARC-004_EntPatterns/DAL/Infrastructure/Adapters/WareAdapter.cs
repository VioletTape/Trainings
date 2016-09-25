using Domain;
using Infrastructure.Adapters.Base;
using Infrastructure.Context;
using Infrastructure.Translators;

namespace Infrastructure.Adapters {
    public class WareAdapter : ReadOnlyAdapter<Ware, ware> {
        public WareAdapter() : base(new WareTranslator()) {}
    }
}