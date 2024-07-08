using System;

using UnityEngine;
using UnityEditor;

using Snaplight;

namespace Snaplight.VisualizationEngine
{
    public class VEngineMastermind : MonoBehaviour
    {
        // Serializable
        public static float TimeScale { get => Time.timeScale; private set => TimeScale = value; }
        [VSlider(0.1F, 10F, 0.1F)] public float TimeScaleModifier;
        public static int FPS => Mathf.FloorToInt(60F / Time.deltaTime);

        // Components

        // Modules

        // Variables: Property

        // Variables: Field

        private void OnEnable()
        {

        }

        private void OnDisable()
        {

        }

        private void Start()
        {

        }

        private void Update()
        {
            //TimeScale = TimeScaleModifier;

            TimeScaleChange();

            if (FPS <= 1)
            {
                Debug.LogError("FPS down");
                //EditorApplication.Step();
            }
        }

        private void TimeScaleChange()
        {
            //if (Keyboard.current[Key.NumpadPlus].wasPressedThisFrame) Time.timeScale += 0.1F;
            //else if (Keyboard.current[Key.NumpadMinus].wasPressedThisFrame) Time.timeScale -= 0.1F;
            //else if (Keyboard.current[Key.NumpadMultiply].wasPressedThisFrame) Time.timeScale += 1;
            //else if (Keyboard.current[Key.NumpadDivide].wasPressedThisFrame) Time.timeScale -= 1F;
            //else if (Keyboard.current[Key.NumpadEnter].wasPressedThisFrame) Time.timeScale = 1;

            Time.timeScale = Math.Clamp(Time.timeScale, 0.1F, 10F);
        }
    }
}
