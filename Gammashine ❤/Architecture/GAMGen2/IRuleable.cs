namespace Snaplight
{
    public interface IRuleable
    {
        public void Underdrive(params IUniversalModulable[] modules);
        public void Playdrive(params IPlayable[] playables);
        public void Changedrive(params IChangeable[] changeables);
        public void Destruction(params IUniversalModulable[] modules);
    }
}
