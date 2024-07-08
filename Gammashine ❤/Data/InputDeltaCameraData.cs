using System;

using UnityEngine;

using Snaplight;

namespace Snaplight.Folds
{
    [Serializable]
    public class InputDeltaCameraData : IFoldables
    {
        public float GlobalizationVariable { get; set; }

        public string Naming => throw new NotImplementedException();

        // Serializable
        [VNaming("Camera options")]
        [VSlider(0, 100)] public int RotationSmoothness;
        [Space]
        [VSlider(0, 3, 0.02F)] public float SensitivityX;
        [VSlider(0, 3, 0.02F)] public float SensitivityY;
        [Space]
        [VSlider(-90, 0)] public int DownLookLimit;
        [VSlider(0, 90)] public int UpLookLimit;

        public T Variability<T>(T value)
        {
            return default;
        }
    }
}
