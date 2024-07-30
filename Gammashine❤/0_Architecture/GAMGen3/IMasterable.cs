using System;

namespace Snaplight.Gen3
{
    public interface IMasterable<T, K, M> : IRegularModulable
        where T : IManifoldable<K, M>
        where K : IModulable
        where M : Enum
    {
        public T Manifold { get; set; }
    }
}
