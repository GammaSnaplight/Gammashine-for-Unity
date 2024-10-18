using System;
using System.Collections.Generic;

using Snaplight.Gen3;
using Snaplight.Modules;

namespace Snaplight
{
    [Serializable]
    public class Rulecorector : IManifoldable<IModulable>
    {
        // IManifoldable
        public IList<IModulable> Modules { get; set; } = new List<IModulable>();

        // Manifolds
        public Rulefold Fold = new();

        // Actress
        public IActress<List<IModulable>, IManifoldable<IModulable>> Collection = new ModulesCollectionActress<IModulable>();

        // Modules
        public RulecorePlayback RulecorePlayback = new();
    }
}
