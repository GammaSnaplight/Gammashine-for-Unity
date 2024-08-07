using Snaplight.Controllable;

namespace Snaplight.Gen3 
{
    public struct ModulableData : IFoldables<ModulableData>
    {
        public ModuleUndertaking Undertaking;
        public ModuleLiabilities Liabilities;
        public CrushloadControllable Crushload;
        public UpdateControllable Updating;

        public IMultipurposeModulable<ModulableData> Module;
    }
}
