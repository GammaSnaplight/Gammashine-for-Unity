using System;
using System.Reflection;
using System.Collections.Generic;

using Snaplight.Gen3;
using Snaplight.Controllable;

using UnityEngine;
using Snaplight.Modules;

namespace Snaplight
{
    /// <summary>
    /// 0_Supremind - RulecoreSupremind является системой, которая проигрывает другие системы внутри себя
    /// используя автоматизацию где это возможно и помогает использовать фишки архитектуры для повышения производительности
    /// </summary>
    public class RulecoreSupremind : MonoBehaviour, IMasterable<IManifoldable<IModulable>>
    {
        // IMasterable
        public Rulecorector Rulecorector = new();
        public IManifoldable<IModulable> Manifold { get => Rulecorector; private set => Rulecorector = (Rulecorector)value; }

        // Variable
        private UpdateControllable _updating;

        public void Collection()
        {
            Rulecorector.RulecorePlayback.Masterminds = Automate.Masterminds<IMasterable<IManifoldable<IModulable>>>(Rulecorector.Fold.Masterminds);

            Rulecorector.RulecorePlayback.Collection();
        }

        public void Playback()
        {
            
        }

        public void Elimination()
        {
            
        }

        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {
            
        }

        private void OnDestroy()
        {
            Elimination();
        }

        private void Awake()
        {
            
        }

        private void Start()
        {
            Collection();
        }

        private void Update()
        {
            _updating = UpdateControllable.Update;

            Rulecorector.RulecorePlayback.UpdateControllable = _updating;

            Rulecorector.RulecorePlayback.Playback();
        }

        private void FixedUpdate()
        {
            _updating = UpdateControllable.Fixed;

            Rulecorector.RulecorePlayback.UpdateControllable = _updating;

            Rulecorector.RulecorePlayback.Playback();
        }

        private void LateUpdate()
        {
            _updating = UpdateControllable.Late;

            Rulecorector.RulecorePlayback.UpdateControllable = _updating;

            Rulecorector.RulecorePlayback.Playback();
        }
    }
}
