using System;

namespace Snaplight
{
    public interface IElementableMarkout
    {

    }

    public interface IElementable : IElementableMarkout
    {
        public void Collection();
    }

    public interface IElementable<in T> : IElementableMarkout
        where T : IFoldables
    {
        public void Collection(T data);
    }

    public interface ISuperElementable<T> : IElementableMarkout
        where T : IFoldables
    {
        public T Collection(T data);
    }

    public interface IBrillianceElementable<out TReturn, in KData> : IElementableMarkout
        where KData : IFoldables
    {
        public TReturn Collection(KData data);
    }

    public interface IElemantableHybridauth<T> : IElementable, IElementable<T>
        where T : IFoldables
    {

    }

    public interface IElementableChainlet<T> : IElementableMarkout, IChainable<T>
    {
        public T Collection();
    }

    public interface IElementableCallback
    {
        public event Action Collected;
    }
}
