using Snaplight.Gen3;
using Snaplight.Folds;
using Snaplight.Controllable;

using System;
using System.Collections.Generic;

using UnityEngine;

namespace Snaplight.Modules
{
    [Serializable]
    public class RulecorePlayback : IPlayableModulable
    {
        // Serializable
        [HideInInspector] public List<IMasterable<IManifoldable<IModulable>>> Masterminds = new();

        [HideInInspector] public UpdateControllable UpdateControllable;

        // Variable
        private List<ModulesManifold<IMainstreamModulable>> _modulesFold = new();

        public void Collection()
        {
            //---
            ModulesManifold<IMainstreamModulable> updateModules = new()
            {
                Controllable = UpdateControllable.Update,
            };
            ModulesManifold<IMainstreamModulable> fixedModules = new()
            {
                Controllable = UpdateControllable.Fixed,
            };
            ModulesManifold<IMainstreamModulable> lateModules = new()
            {
                Controllable = UpdateControllable.Late,
            };

            //---
            foreach (IMasterable<IManifoldable<IModulable>> mind in Masterminds)
            {
                mind.Collection();

                foreach (IModulable module in mind.Manifold.Modules)
                {
                    if (module is IMainstreamModulable imm)
                    {
                        if (imm.Changeover.Updating == UpdateControllable.Update) updateModules.Modules.Add(imm);
                        else if(imm.Changeover.Updating == UpdateControllable.Fixed) fixedModules.Modules.Add(imm);
                        else if(imm.Changeover.Updating == UpdateControllable.Late) lateModules.Modules.Add(imm);
                    }
                }
            }

            //---
            _modulesFold.Add(updateModules);
            _modulesFold.Add(fixedModules);
            _modulesFold.Add(lateModules);
        }

        public void Playback()
        {
            foreach (ModulesManifold<IMainstreamModulable> fold in _modulesFold)
            {
                if (fold.Controllable == UpdateControllable)
                {
                    foreach (IMainstreamModulable module in fold.Modules)
                    {
                        if (module.Changeover.Undertaking == ModuleUndertaking.Finishes) return;
                        if (module.Changeover.Undertaking == ModuleUndertaking.Playback) module.Playback();
                        else if (module.Changeover.Undertaking == ModuleUndertaking.Lightweight) module.Lightback();
                        else if (module.Changeover.Undertaking == ModuleUndertaking.Elimination) module.Elimination();
                        else if (module.Changeover.Undertaking == ModuleUndertaking.Shutdown)
                        {
                            module.Shutdown();

                            module.Changeover.Undertaking = ModuleUndertaking.Finishes;
                        }
                    }
                }
            }
        }

        public void Elimination()
        {
            foreach (IMasterable<IManifoldable<IModulable>> mind in Masterminds) mind.Elimination();
        }
    }
}
