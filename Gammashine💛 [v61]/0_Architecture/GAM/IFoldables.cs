namespace Snaplight
{
    public interface IFoldables<T> : IUniversal<T>
    {
        public T Fold { get; set; }
    }
}
