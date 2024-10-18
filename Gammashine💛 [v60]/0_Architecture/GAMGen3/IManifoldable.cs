using System.Collections.Generic;

namespace Snaplight.Gen3
{ 
    public interface IManifoldable<T>
        where T : IModulable
    {
        public IList<T> Modules { get; set; }
    }
}
