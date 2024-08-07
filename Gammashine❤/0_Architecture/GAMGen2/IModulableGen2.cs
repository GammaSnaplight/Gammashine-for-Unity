namespace Snaplight.Gen2
{
    public interface IUniversalModulable : IModulable, IUndertaking, ILiabilities { }

    public interface IPlayableModulable : IUniversalModulable, IPlayable, IUndertaking, ILiabilities { }
}
