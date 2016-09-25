namespace GoF_ShowCase.Prototype.ShallowDeep {
    public interface IShallowCloneable {
        object ShallowClone();
    }

    public interface IDeepCloneable {
        object DeepClone();
    }

    // Serializable attribute is required for the DeepClone() method
}