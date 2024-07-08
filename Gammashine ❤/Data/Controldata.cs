using System;

using Snaplight.Folds;

namespace Snaplight
{
    public class Controldata<TControllable, KValue>
        where TControllable : Enum
        where KValue : struct, IComparable, IComparable<KValue>, IConvertible, IEquatable<KValue>, IFormattable
    {
        private readonly Dualist<TControllable, KValue> _dualist = new(true);

        public int Elements 
            => _dualist.SyncCount;

        public Controldata<TControllable, KValue> Collect(TControllable controllable, KValue value)
        {
            _dualist.SyncAdd(controllable, value);
            return this;
        }

        public Controldata<TControllable, KValue> Eliminate(TControllable controllable, KValue value)
        {
            _dualist.SyncRemove(controllable, value);
            return this;
        }

        public KValue Gather(TControllable controllable) 
            => _dualist.SyncCorrespondingRight(controllable);

        //public KValue This(TControllable controllable)
        //{
        //    KValue value = default;

        //    _dualist.Synchronization(false);
        //    if (_dualist.Contains(Dualist<TControllable, KValue>.SideList.Left, controllable))
        //    {
        //        value = _dualist.This(false, controllable);
        //    }
        //    _dualist.Synchronization(true);

        //    return value;
        //}
    }
}