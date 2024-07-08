namespace Snaplight
{
    public interface IActress<T>
        where T : IFoldables
    {
        public void Act(T data);
    }

    public interface ISuperActress<T> : IActress<T>
        where T : IFoldables
    {
        public T ActressSync { get; set; }
    }
}
