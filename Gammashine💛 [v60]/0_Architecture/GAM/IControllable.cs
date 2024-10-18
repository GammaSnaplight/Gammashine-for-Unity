using System;

namespace Snaplight
{
    public interface IControllable<T>
        where T : Enum
    {
        public T Controllable { get; set; }
    }
}
