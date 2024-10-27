using System.Collections.Generic;

using Snaplight;
using Snaplight.Gen3;

using UnityEngine;

public class ModulesCollectionActress<T> : IActress<List<IModulable>, IManifoldable<T>>
    where T : IModulable
{
    public List<IModulable> Act(IManifoldable<T> data)
    {
        List<IPlayableModulable> modules = Automate.Gathering<IPlayableModulable>(data);

        foreach (IModulable module in modules) module.Collection();

        return default;
    }
}
