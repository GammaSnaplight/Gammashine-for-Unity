using System;

using UnityEngine;

namespace Snaplight.Gen3
{
    public interface IMasterableHeartiness<T> { }

    public interface IMasterable<T> : IMasterableHeartiness<T>, IRegularModulable
    {
        public T Manifold { get; set; }
    }

    public interface IUniversalMasterable<T, K> : IMasterable<IUniversalManifoldable<K>>
        where K : Enum
    { }

    public interface IStandardMasterable<T> : IUniversalMasterable<IUniversalManifoldable<ManifoldControllable>, ManifoldControllable>, IFoldables<T> 
    {
        public T Collector { get; set; }
    }
}
