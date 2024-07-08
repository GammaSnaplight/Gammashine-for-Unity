namespace Snaplight
{
    public interface IMemorable
    {
        public void Snapshot();
        public void Recover();
    }

    public interface IMemorable<T>
    {
        public void Snapshot(T snapshot);
        public T Recover(T snapshot);
    }
}