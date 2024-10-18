namespace Snaplight.Gen3
{
    public interface IMultipurposeModulable<T> : IPlayableModulable
        where T : IUniversal<T>
    {
    }
}
