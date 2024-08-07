using System;
using System.Collections.Generic;

using Snaplight.Gen3;
using Snaplight.Modules;

namespace Snaplight
{
    public interface IUniversalRulecoreManifold : IUniversalManifoldable<UniversalManifoldControllable> { }
    public interface IRulecoreManifold : IManifoldable<IMultipurposeModulable<ModulableData>, UniversalManifoldControllable> { }

    [Serializable]
    public class Rulecorector : IRulecoreManifold
    {
        public IList<IMultipurposeModulable<ModulableData>> Modules { get; set; } = new List<IMultipurposeModulable<ModulableData>>();

        public RulecorePlayback RulecorePlayback = new();

        public void Changeover(UniversalManifoldControllable controllable, params IMultipurposeModulable<ModulableData>[] modules)
        {
            if (controllable == UniversalManifoldControllable.Undercollected)
            {
                foreach (IMultipurposeModulable<ModulableData> module in modules)
                {
                    module.Collection();

                    Modules.Add(module);
                }
            }

            if (controllable == UniversalManifoldControllable.Overlimited)
            {
                foreach (IMultipurposeModulable<ModulableData> module in modules)
                {
                    module.Elimination();

                    Modules.Remove(module);
                }
            }

            if (controllable == UniversalManifoldControllable.Destruction)
            {
                foreach (IMultipurposeModulable<ModulableData> module in Modules) module.Elimination();

                Modules.Clear();
            }
        }
    }
}
