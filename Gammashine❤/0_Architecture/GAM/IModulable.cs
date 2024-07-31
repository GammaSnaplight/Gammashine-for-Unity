namespace Snaplight
{
    public interface IModulableHeartiness { }

    public interface IModulable : ICollectibles, IEliminatable, IModulableHeartiness { }

    public interface IRegularModulable : IModulable, IPlayable { }

    public interface ICinematicModulable : IRegularModulable, IShuttable, IZeroable, IContinueable { }
}
