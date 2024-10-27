using Snaplight.Gen3;

using System;
using System.Collections.Generic;

namespace Snaplight.Modules.Manifold
{
    [Serializable]
    public class FramerateManifold : IManifoldable<IModulable>
    {
        // IManifoldable
        public IList<IModulable> Modules { get; set; } = new List<IModulable>();

        // Actress
        public IActress<List<IModulable>, IManifoldable<IModulable>> Collection = new ModulesCollectionActress<IModulable>();

        // Modules
        public FramerateModule FramerateModule = new();
        public FrameratePerformanceModule PerformanceModule = new();   
    }
}
