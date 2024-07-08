namespace Snaplight
{
    public interface ICinematic : IPlayable, IMemorable
    {
        public void Rewind();
        public void Unwind();
    }
}