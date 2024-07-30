using System;

namespace Snaplight
{
    [Serializable]
    public class ActressManifold : IFoldables<ActressManifold>
    {
        public IModulable[] Modules;
    }

    public class ActressFold
    {
        public IModulable[] Modules;

        public ManifoldControllable Controllable;
    }
}
