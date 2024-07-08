using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snaplight.Folds.Scriptable
{
    [CreateAssetMenu(fileName = "TournametlightScriptableData", menuName = "Snaplight/Data/Scriptable/Tournametlight", order = 25)]
    public class TournametlightScriptableData : ScriptableObject
    {
        [VSlider(0, 2)] public int ParticipantLimit;

        [VSlider(0, 5)] public int ParticipantGroup;
    }
}