using UnityEngine;
using UnityEditor;

using Snaplight.Extension;
using System;

namespace Snaplight
{
    [CustomPropertyDrawer(typeof(VMeAttribute))]
    public class MeAttributeDrawer : DecoratorDrawer, IDisposable
    {
        private GUIStyle _gui;
        private GUIStyle _background;

        public override void OnGUI(Rect position)
        {
            _gui = new GUIStyle
            {
                fontSize = 14,
                fontStyle = FontStyle.Bold,
                normal = { textColor = Colorful.MangoMelody }
            };

            _background = new GUIStyle();
            _background.normal.background = EditorGUIEX.CreateColorBox(new EditorGUI(), 20, 20, Colorful.Mix(Colorful.MangoMelody, 1, 5));

            VMeAttribute me = (VMeAttribute)attribute;

            EditorGUILayout.Space(10);

            EditorGUILayout.BeginVertical(_background);

            EditorGUILayout.LabelField($"◆ {me.Name}", _gui);

            EditorGUILayout.EndVertical();
        }

        public override float GetHeight()
        {
            return base.GetHeight() * 1.75f;
        }

        public void Dispose()
        {
            
        }
    }
}