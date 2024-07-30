using Snaplight.Gen3;

using UnityEngine;

namespace Snaplight
{
    public class RulecoreSupremind : MonoBehaviour, IMasterable<RulecoreManifold, IModulable, ManifoldControllable>
    {
        public RulecoreManifold Manifold { get; set; } = new();

        public void Collection()
        {
            
        }

        public void Playback()
        {
            
        }

        public void Elimination()
        {
            
        }

        private void Start()
        {
            Collection();
        }
    }
}
