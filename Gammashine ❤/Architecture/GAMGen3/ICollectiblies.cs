using System;
using System.Collections.Generic;

namespace Snaplight
{
    public enum CollectorControllable { Undercollected, Overlimited, Showtime, Overtime, AllShowtime, AllOvertime, Destruction }

    public interface ICollectiblies
    {
        public ICollection<IModulable> Modules { get; set; }

        public void Overdrive(CollectorControllable controllable, params IModulable[] modules);
    }
}