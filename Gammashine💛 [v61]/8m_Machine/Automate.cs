using Snaplight;
using Snaplight.Gen3;

using System;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;

public static class Automate
{
    public static List<T> Gathering<T>(object obj)
    {
        List<T> r = new();
        Type type = obj.GetType();

        foreach (FieldInfo field in type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
        {
            if (field.FieldType == typeof(T)) r.Add((T)field.GetValue(obj));
        }

        return r;
    }

    public static List<IMasterable<IManifoldable<IModulable>>> Masterminds<T>(List<GameObject> gameObjects)
        where T : IMasterable<IManifoldable<IModulable>>
    {
        List<IMasterable<IManifoldable<IModulable>>> minds = new();

        foreach (GameObject go in gameObjects)
        {
            Component[] components = go.GetComponents<Component>();

            foreach (Component component in components)
            {
                Type componentType = component.GetType();
                Type interfaceType = typeof(IMasterable<IManifoldable<IModulable>>);

                if (interfaceType.IsAssignableFrom(componentType))
                {
                    IMasterable<IManifoldable<IModulable>> mind = (IMasterable<IManifoldable<IModulable>>)component;

                    minds.Add(mind);
                }
            }
        }

        return minds;
    }
}
