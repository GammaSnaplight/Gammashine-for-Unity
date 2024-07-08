using System;
using System.Collections.Generic;

using UnityEditor;

using UnityEngine;

namespace Snaplight
{
    ///// <summary>
    ///// Сериализуемый словарь для обычного использования в Unity с отображаемым инспектором 
    ///// </summary>
    ///// <typeparam name="Key">Ключ</typeparam>
    ///// <typeparam name="Value">Значение</typeparam>
    //[Serializable]
    //public class VisualizationDictionary<Key, Value> : ISerializationCallbackReceiver
    //{
    //    [SerializeField] private List<Key> _keys = new();
    //    [SerializeField] private List<Value> _values = new();

    //    public Dictionary<Key, Value> Dictionary = new();

    //    public void OnAfterDeserialize()
    //    {
    //        Dictionary.Clear();

    //        for (int i = 0; i < _keys.Count;  i++)
    //        {
    //            Dictionary[_keys[i]] = _values[i];
    //        }
    //    }
    //    public void OnBeforeSerialize()
    //    {
    //        if (EditorApplication.isPlaying)
    //        {
    //            Debug.Log("A");
    //            _keys.Clear();
    //            _values.Clear();

    //            foreach (KeyValuePair<Key, Value> item in Dictionary)
    //            {
    //                _keys.Add(item.Key);
    //                _values.Add(item.Value);
    //            }
    //        }
    //    }
    //}
}
