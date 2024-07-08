using System;
using System.Collections.Generic;

using UnityEngine;

using Snaplight.Folds;
using Snaplight.VisualizationEngine;

namespace Snaplight
{
    //public class Poolight : AbstractPoolight<GameObject, PoolData>
    //{
    //    // Variables
    //    public enum Mode { }

    //    public override void Collection(PoolData data)
    //    {
    //        for (int i = 0; i < data.Underload; i++)
    //        {
    //            data.ArrayPrefabricates.Add(UnityEngine.Object.Instantiate(data.Prefabricated));
    //            data.ArrayPrefabricates[i].SetActive(false);
    //            data.QueueWaitingPrefabricates.Enqueue(data.ArrayPrefabricates[i]);
    //        }

    //        Snapshot(data);
    //    }

    //    public override GameObject Instantiate(PoolData data)
    //    {
    //        if (data.QueueWaitingPrefabricates.Count == 0) throw new Exception(VEngine.Name(this, "Empty GameObject"));

    //        data.QueueActivatingPrefabricates.Enqueue(data.QueueWaitingPrefabricates.Peek());
    //        GameObject go = data.QueueWaitingPrefabricates.Dequeue();

    //        if (data.Transform == null)
    //        {
    //            go.transform.position = Vector3.zero;
    //            go.transform.rotation = Quaternion.identity;
    //        }
    //        else
    //        {
    //            go.transform.position = data.Transform.position;
    //            go.transform.localScale = data.Transform.localScale;
    //            go.transform.rotation = data.Transform.rotation;
    //        }

    //        go.SetActive(true);

    //        data.CurrentPrefabricates = go;

    //        return go;
    //    }

    //    public override void Destroy(PoolData data)
    //    {
    //        if (data.QueueActivatingPrefabricates.Count == 0) return;

    //        data.QueueWaitingPrefabricates.Enqueue(data.QueueActivatingPrefabricates.Peek());
    //        GameObject go = data.QueueActivatingPrefabricates.Dequeue();

    //        data.DestroyTimeover.Playback();
    //        if (!data.DestroyTimeover.IsFinish) return;

    //        go.transform.position = data.Mirror.Transform.position;
    //        go.transform.localScale = data.Mirror.Transform.localScale;
    //        go.transform.rotation = data.Mirror.Transform.rotation;

    //        go.SetActive(false);

    //        if (go.activeSelf) data.DestroyTimeover.Zeroing();

    //        data.QueueWaitingPrefabricates.Enqueue(data.QueueActivatingPrefabricates.Dequeue());
    //    }

    //    public GameObject Current(PoolData data)
    //    {
    //        if (data.CurrentPrefabricates == null) throw new Exception(VEngine.Name(this, "The method <Instantiate()> has never been called"));

    //        return data.CurrentPrefabricates;
    //    }

    //    public override void Elimination(PoolData data)
    //    {
    //        data.CurrentPrefabricates = null;
    //        data.QueueWaitingPrefabricates.Clear();
    //        data.QueueActivatingPrefabricates.Clear();
    //    }

    //    public override void Snapshot(PoolData data)
    //    {
    //        data.Mirror = data;
    //    }

    //    public override PoolData Recover(PoolData data)
    //    {
    //        return data.Mirror;
    //    }

    //    public override string ToString()
    //    {
    //        return $"{VEngine.Name(this)}";
    //    }
    //}
}