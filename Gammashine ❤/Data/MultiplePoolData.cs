using System;
using System.Collections.Generic;

using UnityEngine;

namespace Snaplight.Folds
{
    [Serializable]
    public class MultiplePoolData : IFoldables
    {
        // IFoldables
        public float GlobalizationVariable { get; set; }

        // Serializable
        public List<GameObject> Prefabricates;
        public Transform Transform;

        public Timelight DestroyTimeover;

        [VLimit(1, 1000)] public int Underload;
        [VLimit(1, 100)] public int HotLoad;
        [VLimit(1, 1000)] public int Limits;

        [HideInInspector] public List<List<GameObject>> BoxPrefabricates = new();

        [HideInInspector] public Queue<GameObject> QueueActivatingPrefabricates = new();
        [HideInInspector] public Queue<GameObject> QueueWaitingPrefabricates = new();

        [HideInInspector] public MultiplePoolData Mirror = new();

        public T Variability<T>(T value)
        {
            return default;
        }
    }
}
