using System;

namespace Snaplight
{
    public struct SupervisionGammashineFold<T, K>
        where T : Enum
        where K : Enum
    {
        public T Controllable;
        public T Supplemental;
    }
}
