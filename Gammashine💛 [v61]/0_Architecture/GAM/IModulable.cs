namespace Snaplight
{
    public interface IModulable : ICollectibles, IEliminatable { }

    public interface IPlayableModulable : IModulable, IPlayable { }
}