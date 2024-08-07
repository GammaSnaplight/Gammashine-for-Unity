using UnityEngine;

using Snaplight.Gen3;
using Snaplight.Controllable;

namespace Snaplight
{
    public class RulecoreSupremind : MonoBehaviour, IMasterable<Rulecorector>
    {
        [field: SerializeField] public Rulecorector Manifold { get; set; } = new();

        // Variable
        private UpdateControllable _updating;

        public void Collection()
        {
            Manifold.Changeover(
                UniversalManifoldControllable.Undercollected,
                (IMultipurposeModulable<ModulableData>)Manifold.RulecorePlayback);
        }

        public void Playback()
        {
            
        }

        public void Elimination()
        {
            Manifold.Changeover(UniversalManifoldControllable.Destruction);
        }

        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {
            
        }

        private void OnDestroy()
        {
            Manifold.Changeover(UniversalManifoldControllable.Destruction);
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

            Manifold.RulecorePlayback.UpdateControllableBind = _updating;

            Manifold.RulecorePlayback.Playback();
        }

        private void FixedUpdate()
        {
            _updating = UpdateControllable.Fixed;

            Manifold.RulecorePlayback.UpdateControllableBind = _updating;

            Manifold.RulecorePlayback.Playback();
        }

        private void LateUpdate()
        {
            _updating = UpdateControllable.Late;

            Manifold.RulecorePlayback.UpdateControllableBind = _updating;

            Manifold.RulecorePlayback.Playback();
        }
    }
}
