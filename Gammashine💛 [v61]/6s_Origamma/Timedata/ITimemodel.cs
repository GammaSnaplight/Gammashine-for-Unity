using System;

namespace Snaplight.Origamma
{
    public partial interface ITimemodel<T> : IPlayableModulable
        where T : IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
    {
        public T Limit { get; set; }

        public T Timer { get; set; }
    }
}
