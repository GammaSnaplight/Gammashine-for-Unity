using System;

namespace Snaplight
{
    public interface IMasterable<T, K> : IModulable
        where T : Enum
        where K : IUniversalCollectibles
    {
        public Controlight<T> Controlight { get; set; }
        public K Collector { get; set; }
    }

    public interface IPlayableMasterable<T, K> : IModulable
        where T : Enum
        where K : IPlayableCollectibles
    {
        public Controlight<T> Controlight { get; set; }
        public K Collector { get; set; }
    }
}
