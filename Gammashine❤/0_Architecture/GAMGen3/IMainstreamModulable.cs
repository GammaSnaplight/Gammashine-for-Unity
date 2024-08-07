namespace Snaplight.Gen3
{
    public interface IMainstreamModulable : IMultipurposeModulable<ModulableData>, IShuttable, IWeightable
    {
        public ModulableData Mod2ata { get; set; }
    }
}
