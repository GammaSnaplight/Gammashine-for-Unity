using System;
using System.Collections.Generic;

namespace Snaplight
{
    public class UniversalCollector : ICollectiblies
    {
        public ICollection<IModulable> Modules { get; set; } = new List<IModulable>();

        public void Overdrive(CollectorControllable controllable, params IModulable[] modules)
        {
            if (controllable == CollectorControllable.Undercollected)
            {
                foreach (IModulable module in modules)
                {
                    if (module is IUniversalModulable universalModule) universalModule.Undertaking = ModuleUndertaking.Playback;

                    Modules.Add(module);
                }
            }
            if (controllable == CollectorControllable.Overlimited)
            {
                foreach (IModulable module in modules)
                {
                    if (Modules.Contains(module))
                    {
                        if (module is IUniversalModulable universalModule)
                        {
                            if (universalModule.Liabilities == ModuleLiabilities.Extreme) return;
                        }
                        else Modules.Remove(module);
                    }
                    else throw new Exception("Module is not collection in ICollection<IModulable> Modules (Undercollected)");
                }
            }
            if (controllable == CollectorControllable.Showtime)
            {
                foreach (IModulable module in modules)
                {
                    if (Modules.Contains(module))
                    {
                        if (module is IUniversalModulable universalModule)
                        {
                            universalModule.Undertaking = ModuleUndertaking.Playback;
                        }
                        else throw new Exception("Module is not IUniversal/Playable/BrillanceModulable");
                    }
                    else throw new Exception("Module is not collection in ICollection<IModulable> Modules (Undercollected)");
                }
            }
            if (controllable == CollectorControllable.Overtime)
            {
                foreach (IModulable module in modules)
                {
                    if (Modules.Contains(module))
                    {
                        if (module is IUniversalModulable universalModule)
                        {
                            universalModule.Undertaking = ModuleUndertaking.Shutdown;
                        }
                        else throw new Exception("Module is not IUniversal/Playable/BrillanceModulable");
                    }
                    else throw new Exception("Module is not collection in ICollection<IModulable> Modules (Undercollected)");
                }
            }
            if (controllable == CollectorControllable.AllShowtime)
            {
                foreach (IModulable module in Modules)
                {
                    if (Modules.Count != 0)
                    {
                        if (module is IUniversalModulable universalModule)
                        {
                            universalModule.Undertaking = ModuleUndertaking.Playback;
                        }
                        else throw new Exception("Module is not IUniversal/Playable/BrillanceModulable");
                    }
                    else throw new Exception("Modules is not collection in ICollection<IModulable> Modules (Undercollected)");
                }
            }
            if (controllable == CollectorControllable.AllOvertime)
            {
                foreach (IModulable module in Modules)
                {
                    if (Modules.Count != 0)
                    {
                        if (module is IUniversalModulable universalModule)
                        {
                            universalModule.Undertaking = ModuleUndertaking.Shutdown;
                        }
                        else throw new Exception("Module is not IUniversal/Playable/BrillanceModulable");
                    }
                    else throw new Exception("Modules is not collection in ICollection<IModulable> Modules (Undercollected)");
                }
            }
            if (controllable == CollectorControllable.Destruction)
            {
                if (Modules.Count != 0)
                {
                    Modules.Clear();
                }
                else throw new Exception("Modules is not collection in ICollection<IModulable> Modules (Undercollected)");
            }
        }
    }
}
