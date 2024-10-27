using System;

using UnityEngine;

namespace Snaplight.Origamma
{
    /// <summary>
    /// 6_Origamma: Magazine является специальной коллекцией, которая перемещается по данным поочередно в обе стороны безопасно предоставляя данные.
    /// Полезная связка подобной коллекции связана с использованием UI, где надо переключатся между значениями.
    /// </summary>
    /// <typeparam name="T"> Обобщенный тип без ограничений </typeparam>
    [Serializable]
    public class Magazine<T>
    {
        // Serializable
        [SerializeField] private T[] _cartridges;
        [SerializeField] private int _currentIndex;

        // Serializable: Property
        public int Count => _capacity;
        public int CurrentIndex => _currentIndex;
        public int PreviousIndex => _previousIndex;

        // Hide
        [HideInInspector] public T Cartridge => _cartridges[_currentIndex];
        [HideInInspector] public T PreviousCartridge => _cartridges[_previousIndex];
        [HideInInspector] public bool IsChangeover { get; private set; }

        // Variable
        private int _previousIndex;
        private int _capacity;

        //---
        public Magazine(params T[] cartridges)
        {
            //---
            _capacity = cartridges.Length;
            _cartridges = new T[_capacity];

            //---
            cartridges.AsSpan().CopyTo(_cartridges);
        }

        public Magazine<T> Collection(params T[] cartridges)
        {
            //---
            int newCapacity = _capacity + cartridges.Length;
            T[] newCartridges = new T[newCapacity];

            //---
            _cartridges.AsSpan().CopyTo(newCartridges);
            cartridges.AsSpan().CopyTo(newCartridges.AsSpan(_capacity));

            _cartridges = newCartridges;
            _capacity = newCapacity;

            return this;
        }

        public void Initial(int initialRecalculation)
            => _currentIndex = initialRecalculation;

        public T Recalculation()
        {
            //---
            _previousIndex = _currentIndex;
            _currentIndex++;

            IsChangeover = _previousIndex != _currentIndex;

            //---
            _currentIndex = Mathlight.Magazine(_currentIndex, 0, _capacity - 1);
            return _cartridges[_currentIndex];
        }

        public T Previous()
        {
            //---
            _previousIndex = _currentIndex;
            _currentIndex--;

            IsChangeover = _previousIndex != _currentIndex;

            //---
            _currentIndex = Mathlight.Magazine(_currentIndex, 0, _capacity - 1);
            return _cartridges[_currentIndex];
        }
    }
}