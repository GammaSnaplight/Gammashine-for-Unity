using System;
using System.Collections.Generic;

using UnityEngine;

namespace Snaplight
{
    public abstract class AbstractGlobalization<T> : MonoBehaviour, IUniversalModulable
        where T : MonoBehaviour
    {
        public ModuleUndertaking Undertaking { get; set; }
        public ModuleLiabilities Liabilities { get; set; }

        public abstract void Collection();
        public abstract void Elimination();
        public abstract void Awake();
    }

    public abstract class GlobalizationBaseline<T> : AbstractGlobalization<T>
        where T : MonoBehaviour
    {
        public static event Action GlobalizationCollected;
        public static event Action GlobalizationEliminated;

        private static T _data;

        private static readonly object _lock = new();

        public static T Data
        {
            get
            {
                _data ??= FindFirstObjectByType<T>();

                if (_data == null)
                {
                    lock (_lock)
                    {
                        GameObject go = new(typeof(T).Name);
                        _data = go.AddComponent<T>();
                    }
                }

                return _data;
            }
        }

        public override void Collection()
        {
            Liabilities = ModuleLiabilities.Extreme;

            _data ??= this as T;
            DontDestroyOnLoad(gameObject);


            GlobalizationCollected?.Invoke();
        }

        public override void Elimination()
        {
            _data = null;

            Destroy(gameObject);

            GlobalizationEliminated?.Invoke();
        }

        public override void Awake()
        {
            if (_data != null && _data != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Collection();
            }
        }
    }

    public abstract class GlobalizationMonostate<T> : AbstractGlobalization<T>
        where T : MonoBehaviour
    {
        public static event Action GlobalizationCollected;
        public static event Action GlobalizationEliminated;

        private static T _data;
        private static readonly object _lock = new();

        public static T Data
        {
            get
            {
                if (_data == null)
                {
                    lock (_lock)
                    {
                        GameObject go = new(typeof(T).Name);
                        _data = go.AddComponent<T>();
                    }
                }

                return _data;
            }
        }

        public override void Collection()
        {
            Liabilities = ModuleLiabilities.Extreme;

            if (_data == null)
            {
                _data = this as T;
                DontDestroyOnLoad(gameObject);
            }

            GlobalizationCollected?.Invoke();
        }

        public override void Elimination()
        {
            _data = null;

            Destroy(gameObject);

            GlobalizationEliminated?.Invoke();
        }

        public override void Awake() => Collection();
    }

    // TODO: Доработать класс
    public abstract class GlobalizationMultiton<T> : AbstractGlobalization<T>
        where T : MonoBehaviour
    {
        public static event Action GlobalizationCollected;
        public static event Action GlobalizationEliminated;

        public abstract int ElementLimitation { get; set; }

        private static readonly Dictionary<string, T> _dataset = new Dictionary<string, T>();
        private static readonly object _lock = new();

        private int _elements;

        public static T Data(string key)
        {
            if (!_dataset.ContainsKey(key))
            {
                lock (_lock)
                {
                    if (!_dataset.ContainsKey(key))
                    {
                        GameObject go = new(typeof(T).Name);
                        T instance = go.AddComponent<T>();
                        _dataset.Add(key, instance);
                    }
                }
            }

            return _dataset[key];
        }

        public override void Collection()
        {
            Liabilities = ModuleLiabilities.Extreme;

            if (!_dataset.ContainsKey(gameObject.name))
            {
                _dataset.Add(gameObject.name, this as T);
                DontDestroyOnLoad(gameObject);
            }

            _elements++;

            GlobalizationCollected?.Invoke();
        }

        public override void Elimination()
        {
            if (_dataset.ContainsKey(gameObject.name))
            {
                _dataset.Remove(gameObject.name);
            }

            _elements--;

            Destroy(gameObject);

            GlobalizationEliminated?.Invoke();
        }

        public virtual void Eliminations()
        {

        }

        public override void Awake() => Collection();

        private bool CheckoutLimitation()
        {
            if (ElementLimitation == 0) return false;
            else if (_elements > ElementLimitation) return true;
            else return false;
        }
    }

    public class RulecoreSuprememind<T> : MonoBehaviour where T : class
    {
        private static RulecoreSuprememind<T> _rulecore;

        public static RulecoreSuprememind<T> Rulecore => _rulecore = _rulecore != null ? _rulecore : FindFirstObjectByType<RulecoreSuprememind<T>>();

        private readonly Dictionary<Type, T> _masterminds = new();

        public void Collection<U>(U obj) where U : T
        {
            _masterminds[typeof(U)] = obj;
        }

        public U Gathering<U>() where U : T
        {
            if (_masterminds.TryGetValue(typeof(U), out T value))
            {
                return (U)value;
            }
            throw new NullReferenceException($"Non mind - {typeof(T)}");
        }

        public void Elimination<U>() where U : T
        {
            _masterminds.Remove(typeof(U));
        }

        public void Awake()
            => _rulecore = this;
    }
}