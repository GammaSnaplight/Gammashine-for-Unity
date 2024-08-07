using System.Collections.Generic;

using Snaplight.Gen3;
using Snaplight.Controllable;

namespace Snaplight.Folds
{
    public class ModulesChangeoverFold : IFoldables<ModulesChangeoverFold>
    {
        public UpdateControllable Controllable;

        public List<IMainstreamModulable> Modules;
    }
}
