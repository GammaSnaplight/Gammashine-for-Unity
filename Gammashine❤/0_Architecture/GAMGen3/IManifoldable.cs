using System;
using System.Collections.Generic;

namespace Snaplight.Gen3
{ 
    public interface IManifoldableHeartiness<T, K>
        where T : IModulable
        where K : Enum
    { }

    public interface IManifoldable<T, K> : IManifoldableHeartiness<T, K>
        where T : IModulable
        where K : Enum
    {
        public IList<T> Modules { get; set; }

        public void Changeover(K controllable, params T[] modules);
    }

    public interface IUniversalManifoldable<K> : IManifoldable<IModulable, K> 
        where K : Enum
    { }

    public interface IStandardManifoldable : IUniversalManifoldable<ManifoldControllable>
    { }
}
