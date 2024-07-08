using System;

using UnityEngine;

using Snaplight.Folds;
using Snaplight.VisualizationEngine;

namespace Snaplight.Modules
{
    [Serializable]
    public class InputDeltaCameraModule
    {
        // Serializable
        [SerializeField] private InputDeltaCameraData _data = new();

        // Gammachine
        public string Naming => $"[Module] - {VEngine.NameClass(this)}";
        public bool Selector { get => true; set => Selector = value; }

        public event Action Collected;
        public event Action Eliminated;
        public event Action Selected;

        // Variables: Module
        private Quaternion _currentPitchRotation = Quaternion.identity;
        private Quaternion _currentYawRotation = Quaternion.identity;

        private float _currentCameraPitchAngle;
        private float _currentCameraYawAngle;

        public void Collection()
        {
            if (CheckoutSelector()) return;

            Collected?.Invoke();
        }

        public void Elimination()
        {
            if (CheckoutSelector()) return;

            Eliminated?.Invoke();
        }

        public string Write(bool full)
        {
            return Naming;
        }

        public bool CheckoutSelector()
        {
            Selected?.Invoke();

            return Selector;
        }

        public Vector3 ConvertInputLook(Vector2 inputDelta, bool isInvert)
        {
            CheckoutSelector();

            if (isInvert) return new(inputDelta.x, inputDelta.y, 0);
            else return new(inputDelta.x, -inputDelta.y, 0);
        }

        public (Quaternion, Quaternion) PitchYawRotationTuple(Vector2 input)
        {
            CheckoutSelector();

            _currentCameraPitchAngle += input.y * _data.SensitivityY;
            _currentCameraYawAngle += input.x * _data.SensitivityX;

            _currentCameraPitchAngle = Mathf.Clamp(_currentCameraPitchAngle, _data.DownLookLimit, _data.UpLookLimit);

            Quaternion x = Quaternion.AngleAxis(_currentCameraPitchAngle, Vector3.right);
            Quaternion y = Quaternion.AngleAxis(_currentCameraYawAngle, Vector3.up);

            return (x, y);
        }

        public (Quaternion, Quaternion) PitchYawRotationSmoothnessTuple(Vector2 input)
        {
            CheckoutSelector();

            _currentCameraPitchAngle += input.y * _data.SensitivityY;
            _currentCameraYawAngle += input.x * _data.SensitivityX;

            _currentCameraPitchAngle = Mathf.Clamp(_currentCameraPitchAngle, _data.DownLookLimit, _data.UpLookLimit);

            Quaternion x = Quaternion.AngleAxis(_currentCameraPitchAngle, Vector3.right);
            Quaternion y = Quaternion.AngleAxis(_currentCameraYawAngle, Vector3.up);

            _currentPitchRotation = Quaternion.Lerp(_currentPitchRotation, x, Time.deltaTime * _data.RotationSmoothness);
            _currentYawRotation = Quaternion.Lerp(_currentYawRotation, y, Time.deltaTime * _data.RotationSmoothness);

            return (_currentPitchRotation, _currentYawRotation);
        }

        public void YawRotation(Transform transform, Vector2 input)
        {
            input = ConvertInputLook(input, false);
            (_, Quaternion yawCamera) = PitchYawRotationTuple(input);

            transform.rotation = yawCamera;
        }

        public void YawRotationSmoothness(Transform transform, Vector2 input)
        {
            input = ConvertInputLook(input, false);
            (_, Quaternion yawCamera) = PitchYawRotationSmoothnessTuple(input);

            transform.rotation = yawCamera;
        }

        public void PitchYawRotation(Transform transform, Vector2 input)
        {
            input = ConvertInputLook(input, false);

            (Quaternion pitchCamera, Quaternion yawCamera) = PitchYawRotationTuple(input);

            transform.rotation = yawCamera * pitchCamera;
        }

        public void PitchYawRotationSmoothness(Transform transform, Vector2 input)
        {
            input = ConvertInputLook(input, false);

            (Quaternion pitchCamera, Quaternion yawCamera) = PitchYawRotationSmoothnessTuple(input);

            transform.rotation = yawCamera * pitchCamera;
        }
    }
}
