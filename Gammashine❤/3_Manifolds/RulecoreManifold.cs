using System.Collections.Generic;

using Snaplight.Gen3;
using Snaplight.Gen2;
using Snaplight.Controllable;

namespace Snaplight
{
    public class RulecoreManifold : IManifoldable<IModulable, ManifoldControllable>
    {
        // IManifoldable
        public IDictionary<string, IModulable> Modules { get; set; } = new Dictionary<string, IModulable>();
        public ManifoldControllable Controllable { get; set; }

        // Special - Actress
        public IActress<MonophaseControllable, ActressManifold> Undercollected => new _Undercollected();
        public IActress<MonophaseControllable, ActressManifold> Overlimited => new _Overlimited();
        public IActress<MonophaseControllable, ActressManifold> Showtime => new _Showtime();
        public IActress<MonophaseControllable, ActressManifold> Overtime => new _Overtime();
        public IActress<MonophaseControllable, ActressManifold> AllShowtime => new _All_Showtime();
        public IActress<MonophaseControllable, ActressManifold> AllOvertime => new _AllOvertime();
        public IActress<MonophaseControllable, ActressManifold> Destruction => new _Destruction();

        // Modules
        public Module Module = new();

        // Variable

        public void Changeover(IModulable[] modules, ManifoldControllable controllable)
        {
            if (controllable == ManifoldControllable.Undercollected)
            {
                if (Undercollected is IElegantActress<MonophaseControllable, ActressManifold> undercollected)
                {
                    foreach (IModulable module in modules) Modules.Add(nameof(module), module);

                    undercollected.Actress.Modules = modules;

                    undercollected.Act(undercollected.Actress);
                }
            }
            if (controllable == ManifoldControllable.Overlimited)
            {
                if (Overlimited is IElegantActress<MonophaseControllable, ActressManifold> overlimited)
                {
                    overlimited.Actress.Modules = modules;

                    overlimited.Act(overlimited.Actress);

                    foreach (IModulable module in modules) Modules.Remove(nameof(module));
                }
            }
        }

        private class _Undercollected : IElegantActress<MonophaseControllable, ActressManifold>
        {
            public ActressManifold Actress { get; set; } = new();

            public MonophaseControllable Act(ActressManifold data)
            {
                foreach (IModulable module in data.Modules)
                {
                    module.Collection();
                }

                return MonophaseControllable.Finishes;
            }
        }

        private class _Overlimited : IElegantActress<MonophaseControllable, ActressManifold>
        {
            public ActressManifold Actress { get; set; } = new();

            public MonophaseControllable Act(ActressManifold data)
            {
                foreach (IModulable module in data.Modules) module.Collection();

                return MonophaseControllable.Finishes;
            }
        }

        private class _Showtime : IElegantActress<MonophaseControllable, ActressManifold>
        {
            public ActressManifold Actress { get; set; } = new();

            public MonophaseControllable Act(ActressManifold data)
            {
                foreach (IModulable module in data.Modules)
                {
                    if (module is IUniversalModulable ium) ium.Undertaking = Selector.Playback;
                    if (module is IPlayableModulable ipm) ipm.Undertaking = Selector.Playback;
                }

                    return MonophaseControllable.Finishes;
                }
            }
        }
    }
}
