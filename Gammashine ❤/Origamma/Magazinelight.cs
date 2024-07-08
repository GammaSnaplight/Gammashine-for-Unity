using System;
using System.Linq;
using System.Collections.Generic;

using UnityEngine;

namespace Snaplight
{
    [Serializable]
    public class Magazinelight<T>
    {
        public T Cartridge { get; private set; }
        [SerializeField] private List<T> _cartridges;
        [SerializeField] private int _currentIndex;

        public event Action Recalculated;

        public int Count => _cartridges.Count;

        public Magazinelight(params T[] cartridges)
        {
            foreach (T cartridge in cartridges)
            {
                _cartridges.Add(cartridge);
            }

            Cartridge = _cartridges.First();
        }

        public void Initial() 
            => Cartridge = _cartridges[_currentIndex];

        public void Initial(int initialRecalculation)
        {
            _currentIndex = initialRecalculation;
            Cartridge = _cartridges[initialRecalculation];
        }

        public T This()
            => _cartridges[_currentIndex];

        public int Index()
            => _currentIndex;

        public T Previous()
        {
            _currentIndex--;
            _currentIndex = Mathlight.Magazine(_currentIndex, 0, _cartridges.Count - 1);
            return Cartridge = _cartridges[_currentIndex];
        }

        public T Recalculation()
        {
            Recalculated?.Invoke();

            _currentIndex++;
            _currentIndex = Mathlight.Magazine(_currentIndex, 0, _cartridges.Count - 1);
            return Cartridge = _cartridges[_currentIndex];
        }
    }
}