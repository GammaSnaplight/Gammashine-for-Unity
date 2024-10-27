using System.Collections.Generic;

using Snaplight.Controllable;

namespace Snaplight.Folds
{
    public class ModulesManifold<T>
        where T : IModulable
    {
        public UpdateControllable Controllable;

        public List<T> Modules = new();
    }
}
