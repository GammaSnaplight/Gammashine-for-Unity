using System;
using System.Collections.Generic;

using UnityEngine;

using Snaplight;

namespace Snaplight
{
    [Serializable]
    public class PlayableModule : IPlayableModulable
    {
        // IUniversalModulable
        public ModuleUndertaking Undertaking { get; set; }
        public ModuleLiabilities Liabilities { get; set; }

        // Dataset


        // Variable


        public void Collection()
        {
            Liabilities = ModuleLiabilities.Regular;

            if (Undertaking == ModuleUndertaking.Shutdown) return;
        }

        public void Playback()
        {
            if (Undertaking == ModuleUndertaking.Shutdown) return;
        }

        public void Elimination()
        {
            if (Undertaking == ModuleUndertaking.Shutdown) return;
        }
    }
}
