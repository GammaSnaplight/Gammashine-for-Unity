using System;
using System.Collections.Generic;

using UnityEngine;

using Snaplight.Folds;
using Snaplight.VisualizationEngine;

namespace Snaplight
{
    //public class MultiplePoolight : AbstractPoolight<GameObject, MultiplePoolData>
    //{
    //    public enum Mode { }

    //    public override void Collection(MultiplePoolData data)
    //    {
    //        for (int i = 0; i < data.Prefabricates.Count; i++)
    //        {
    //            for (int j = 0; j < data.Underload; j++)
    //            {
    //                data.BoxPrefabricates[i].Add(UnityEngine.Object.Instantiate(data.Prefabricates[i]));
    //                data.BoxPrefabricates[i][j].SetActive(false);

    //            }
    //        }

    //        Snapshot(data);
    //    }

    //    public override GameObject Instantiate(MultiplePoolData data)
    //    {
    //        return new();
    //    }

    //    public override void Destroy(MultiplePoolData data)
    //    {
            
    //    }

    //    public override void Elimination(MultiplePoolData data)
    //    {
            
    //    }

    //    public override void Snapshot(MultiplePoolData data)
    //    {
    //        data.Mirror = data;
    //    }

    //    public override MultiplePoolData Recover(MultiplePoolData data)
    //    {
    //        return data;
    //    }
    //}
}