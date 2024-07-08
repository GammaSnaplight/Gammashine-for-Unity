using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

using UnityEngine;

using Snaplight;

namespace Snaplight.VisualizationEngine
{
    public static class VEngine
    {
        public static string NameClass<T>(T nameClass) where T : class
            => nameClass.GetType().Name;

        public static string NameMethod([CallerMemberName] string nameMethod = "")
            => $"{nameMethod}()";

        public static string Name<T>(T nameClass, [CallerMemberName] string nameMethod = "") where T : class
            => $"[{nameClass.GetType().Name} : {nameMethod}()]";

        public static void Write<T>(T nameClass, object info, [CallerMemberName] string nameMethod = "") where T : class
            => Debug.Log($"[{nameClass.GetType().Name} : {nameMethod}()] - {info}");

        public static void UnityWrite(object info) => Debug.Log(info);

        public static void UnityAutoWrite(string obj, object info)
        {
            Debug.Log($"{nameof(obj)}: {info}");
        }

        public static void UnityAutoWriteLowOptim(object info)
        {
            Type type = info.GetType();

            foreach (var fieldName in type.GetFields().Select(field => field.Name))
            {
                Debug.Log($"{fieldName}: {type.GetField(fieldName).GetValue(info)}");
            }
        }

        public static void UnityAutoWrite(params object[] info)
        {

        }
        public static void UnityWriteError(object info) => Debug.LogError($"ERROR: {info}");

        //public static void Write(object info) => Debug.Log(info);
        //public static void WriteError(object info) => Debug.LogError($"ERROR: {info}");
    }
}