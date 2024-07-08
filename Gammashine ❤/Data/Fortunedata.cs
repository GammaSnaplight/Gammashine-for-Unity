using System;
using System.Collections.Generic;

using UnityEngine;

using Snaplight;

namespace Snaplight.Origamma
{
    [Serializable]
    public struct Fortunedata<T>
    {
        // Serializable
        [VMe("Fortune")]
        [VSlider(0, 100)] public int FortunePercent;

        
    }
}
