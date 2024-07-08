using System;

namespace Snaplight
{
    public interface IEliminatableMarkout
    {

    }

    public interface IEliminatable : IEliminatableMarkout
    {
        public void Elimination();
    }

    public interface IEliminatable<T> : IEliminatableMarkout
        where T : IFoldables
    {
        public T Elimination();
    }

    public interface IEliminatableChainlet<T> : IEliminatableMarkout
    {
        public T Elimination();
    }

    public interface IEliminatableCallback 
    {
        public event Action Eliminated;
    }
}
