using System;
using System.Collections.Generic;

namespace Snaplight.Gen3
{ 
    public interface IManifoldable<T, K> : IControllable<K>
        where T : IModulable
        where K : Enum
    {
        public IDictionary<string, T> Modules { get; set; }

        public void Changeover(T[] modules, K controllable);
    }
}
