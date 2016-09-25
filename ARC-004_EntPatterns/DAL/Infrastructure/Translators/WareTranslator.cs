using Domain;
using Infrastructure.Context;
using SpecificationMain;

namespace Infrastructure.Translators {
    public class WareTranslator : ReadOnlyTranslator<Ware, ware> {
        protected override Ware DoReconstitute(ware dataObject, IsLazy<Ware> isLazy, IUnitOfWork unitOfWork) {
            return new Ware {
                                WareId = dataObject.WareId
                            };
        }

        protected override bool GetPredicate(Ware domain, ware data) {
            return data.WareId == domain.WareId;
        }
    }
}