using System;

using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

namespace Snaplight.Extension
{
    public static class EXditor
    {
        public static void LayoutHorizontal(Action method)
        {
            EditorGUILayout.BeginHorizontal();

            method?.Invoke();

            EditorGUILayout.EndHorizontal();
        }

        public static void LayoutVertical(Action method)
        {
            EditorGUILayout.BeginVertical();

            method?.Invoke();

            EditorGUILayout.EndVertical();
        }

        public static void LayoutVerticalOutHorizontalBackground(Action method, int widht, int heingt, Color color)
        {
            GUIStyle background = new();
            background.normal.background = Background(widht, heingt, color);

            EditorGUILayout.BeginVertical(background);

            EditorGUILayout.BeginHorizontal();

            method?.Invoke();

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.EndVertical();
        }

        public static Texture2D Background(int width, int height, Color color)
        {
            Color32 col32 = color;
            Color32[] pix = new Color32[width * height];

            for (int i = 0; i < pix.Length; i++) pix[i] = col32;

            Texture2D result = new(width, height);

            result.SetPixels32(pix);
            result.Apply();

            return result;
        }
    }
}
#endif
