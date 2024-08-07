namespace Snaplight
{
    public interface IFoldables<T> { }

    public interface IUniversalFoldables<T> : IFoldables<T>
    {
        public T Fold { get; set; }
    }

    public interface IVariable : IUniversalFoldables<float>
    {
        public float GlobalizationVariable { get; set; }
    }
}
