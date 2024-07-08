using System;
using System.Collections.Generic;

namespace Snaplight
{
    [Serializable]
    public class Autodata<TVariable, KControllable>
        where KControllable : Enum
    {
        // Serializable
        public bool IsChangeover { get; private set; }

        // Variables
        public List<TVariable> Variables;
        public List<KControllable> Controllables;

        private TVariable InitialVariable;
        private TVariable MeantimeVariable;

        private KControllable _mirrorControllable;
        private KControllable _previousControllable;

        private bool _isInitial;

        private EqualityComparer<KControllable> _comparer = EqualityComparer<KControllable>.Default;

        public Autodata<TVariable, KControllable> Collection(TVariable variable, KControllable controllable)
        {
            Variables.Add(variable);
            Controllables.Add(controllable);
            return this;
        }

        public Autodata<TVariable, KControllable> Initial(TVariable variable)
        {
            InitialVariable = variable;
            return this;
        }

        public Autodata<TVariable, KControllable> Meantime(TVariable variable)
        {
            MeantimeVariable = variable;
            return this;
        }

        public TVariable Default() => InitialVariable;

        public KControllable This() => _mirrorControllable;

        public TVariable Automation(KControllable controllable)
        {
            if (!_isInitial)
            {
                if (Controllables.Contains(controllable)) _isInitial = true;
                else return InitialVariable;
            }

            for (int i = 0; i < Variables.Count; i++)
            {
                if (_comparer.Equals(controllable, Controllables[i]))
                {
                    _mirrorControllable = controllable;
                    IsChangeover = !_comparer.Equals(_mirrorControllable, _previousControllable);
                    _previousControllable = _mirrorControllable;
                    return Variables[i];
                }
            }

            return MeantimeVariable;
        }

        //public static TVariable Combination(params Autodata<TVariable, KControllable>[] autodatas)
        //{
        //    foreach (Autodata<TVariable, KControllable> data in autodatas)
        //    {
        //        TVariable result = data.Automation(_mirrorControllable);
        //        if (!result.Equals(data.MeantimeVariable))
        //        {
        //            return result;
        //        }
        //    }

        //    return MeantimeVariable;
        //}
    }
}