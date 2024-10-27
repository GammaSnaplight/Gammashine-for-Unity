using System;
using System.Collections.Generic;

using UnityEngine;

using UObject = UnityEngine.Object;

public static class GameObjectEX
{
    public static void RemoveComponent<T>(this GameObject go) where T : Component
    {   
        if (go.TryGetComponent(out T component))
        {
            UObject.Destroy(component);
        }
        else throw new NullReferenceException();
    }

    public static List<T> Childs<T>(this GameObject go)
    {
        List<T> gameObjects = new(go.transform.childCount);

        for (int i = 0; i < go.transform.childCount; i++)
        {
            gameObjects.Add(go.transform.GetChild(i).GetComponent<T>());
        }

        return gameObjects;
    }

    public static void RenamingEnumeration<T>(this GameObject go, string rename, bool isIndexFirstNumber = false)
    {
        List<GameObject> gameObjects = go.Childs<GameObject>();

        int index = 0;

        if (isIndexFirstNumber) index++;

        for (int i = 0; i < go.transform.childCount; i++)
        {
            gameObjects[i].transform.GetChild(i).name = $"{rename}: {i + index}";
        }
    }
}
