using System.Collections.Generic;

namespace Snaplight
{
    public enum WhateverMode { AllPlayback, AllShutdown, AllElimination }

    public interface IUniversalCollectibles
    {
        public List<IUniversalModulable> Modules { get; set; }

        public void Undercollected(params IUniversalModulable[] modules);
        public void Overlimited(params IUniversalModulable[] modules);
        public void Wrap(params IUniversalModulable[] modules);
        public void Unwrap(params IUniversalModulable[] modules);
        public void Whatever(WhateverMode mode);
    }

    public interface IPlayableCollectibles
    {
        public List<IPlayableModulable> Modules { get; set; }

        public void Undercollected(params IPlayableModulable[] modules);
        public void Overlimited(params IPlayableModulable[] modules);
        public void Wrap(params IPlayableModulable[] modules);
        public void Unwrap(params IPlayableModulable[] modules);
        public void Whatever(WhateverMode mode);
    }
}