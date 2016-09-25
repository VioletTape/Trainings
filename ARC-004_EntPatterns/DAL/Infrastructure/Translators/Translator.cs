namespace Infrastructure.Translators {
public abstract class Translator<TDomain, TBase> : ReadOnlyTranslator<TDomain, TBase>
    where TDomain : class
    where TBase : class {
    public abstract void Persist(TDomain domainObject, TBase dataObject, UnitOfWork unitOfWork);
    public abstract void AssertCanBeDeleted(TBase dataObject);
}
}