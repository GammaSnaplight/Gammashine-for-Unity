using System;

using Snaplight.Folds;

namespace Snaplight
{
    public class Controlight<T>
        where T : Enum
    {
        // Enumeration
        public enum MirrorControllable { Waiting, Entering, Starting, Updating, Finishing, Aftereffect, Special_Forever, Non }
        public MirrorControllable Mirror;

        // Serializable
        public T Mindable { get; set; }

        public int Elements => _enumerations.SyncCount;

        // Variables
        private readonly Dualist<Enum, Enum> _enumerations = new(true);

        public void Collection(T enumeration, MirrorControllable mirror = MirrorControllable.Non)
        {
            _enumerations.SyncAdd(enumeration, mirror);
        }

        public void Collections(params T[] enumerations)
        {
            foreach (T element in enumerations)
            {
                if (!_enumerations.SyncContains(element, MirrorControllable.Non)) _enumerations.SyncAdd(element, MirrorControllable.Non);
            }
        }

        public bool Checkout(T enumeration, MirrorControllable mirror = MirrorControllable.Non)
            => _enumerations.SyncContains(enumeration, mirror);

        public bool Checkouts(params T[] enumerations)
        {
            foreach (T element in enumerations)
            {
                if (!_enumerations.SyncContains(element, MirrorControllable.Non))
                    return false;
            }
            return true;
        }

        public void Elimination(T enumeration, MirrorControllable mirror = MirrorControllable.Non)
        {
            _enumerations.SyncRemove(enumeration, mirror);
        }

        public void Eliminations(params T[] enumerations)
        {
            foreach (T element in enumerations)
            {
                if (!_enumerations.SyncContains(element, MirrorControllable.Non)) _enumerations.SyncRemove(element, MirrorControllable.Non);
            }
        }

        public void Destruction() => _enumerations.SyncClear();

        public void Automation(bool isCriterion, T enumeration)
        {
            if (isCriterion) Collection(enumeration);
            else Elimination(enumeration);
        }

        public void Automation(bool isCriterion, T collectedEnumeration, T eliminatedEnumeration)
        {
            if (isCriterion)
            {
                Collection(collectedEnumeration);
                Elimination(eliminatedEnumeration);
            }
            else
            {
                Elimination(collectedEnumeration);
                Collection(eliminatedEnumeration);
            }
        }
    }
}