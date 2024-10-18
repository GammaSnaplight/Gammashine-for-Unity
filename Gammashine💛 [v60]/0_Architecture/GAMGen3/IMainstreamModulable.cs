namespace Snaplight.Gen3
{
    public interface IMainstreamModulable : IMultipurposeModulable<ModulableManifold>, IShuttable, IWeightable
    {
        public ModulableManifold Changeover { get; set; }
    }
}
