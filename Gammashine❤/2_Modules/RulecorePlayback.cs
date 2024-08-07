using System;
using System.Collections.Generic;

using Snaplight.Gen3;
using Snaplight.Folds;
using Snaplight.Controllable;

namespace Snaplight.Modules
{
    [Serializable]
    public class RulecorePlayback : IRegularModulable
    {
        // Serializable
        public List<IUniversalMasterable<IUniversalManifoldable<ManifoldControllable>, ManifoldControllable>> Masterminds;

        public UpdateControllable UpdateControllableBind;

        // Variable
        private List<ModulesChangeoverFold> _modulesFold;

        public void Collection()
        {
            //===
            ModulesChangeoverFold updateModules = new()
            {
                Controllable = UpdateControllable.Update,
            };
            ModulesChangeoverFold fixedModules = new()
            {
                Controllable = UpdateControllable.Update,
            };
            ModulesChangeoverFold lateModules = new()
            {
                Controllable = UpdateControllable.Update,
            };

            //===
            foreach (IUniversalMasterable<IUniversalManifoldable<ManifoldControllable>, ManifoldControllable> mind in Masterminds)
            {
                foreach (IModulable module in mind.Manifold.Modules)
                {
                    if (module is IMainstreamModulable imm)
                    {
                        if (imm.Mod2ata.Updating == UpdateControllable.Update) updateModules.Modules.Add(imm);
                        if (imm.Mod2ata.Updating == UpdateControllable.Fixed) updateModules.Modules.Add(imm);
                        if (imm.Mod2ata.Updating == UpdateControllable.Late) updateModules.Modules.Add(imm);
                    }
                }
            }

            //===
            _modulesFold.Add(updateModules);
            _modulesFold.Add(fixedModules);
            _modulesFold.Add(lateModules);

            //===
            foreach (IUniversalMasterable<IUniversalManifoldable<ManifoldControllable>, ManifoldControllable> mind in Masterminds) mind.Collection();
        }

        public void Playback()
        {
            foreach (IUniversalMasterable<IUniversalManifoldable<ManifoldControllable>, ManifoldControllable> mind in Masterminds) mind.Playback();

            foreach (ModulesChangeoverFold fold in _modulesFold)
            {
                if (fold.Controllable == UpdateControllableBind)
                {
                    foreach (IMainstreamModulable module in fold.Modules)
                    {
                        if (module.Mod2ata.Undertaking == ModuleUndertaking.Playback) module.Playback();
                        else if (module.Mod2ata.Undertaking == ModuleUndertaking.Shutdown) module.Shutdown();
                        else if (module.Mod2ata.Undertaking == ModuleUndertaking.Lightweight) module.Lightback();
                        else if (module.Mod2ata.Undertaking == ModuleUndertaking.Finishes) module.Elimination();
                    }
                }
            }
        }

        public void Elimination()
        {
            foreach (IUniversalMasterable<IUniversalManifoldable<ManifoldControllable>, ManifoldControllable> mind in Masterminds) mind.Elimination();
        }
    }
}
