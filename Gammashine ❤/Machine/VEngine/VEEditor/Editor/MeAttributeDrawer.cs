using UnityEngine;
using UnityEditor;

using Snaplight.Extension;

namespace Snaplight
{
    [CustomPropertyDrawer(typeof(VMeAttribute))]
    public class MeAttributeDrawer : DecoratorDrawer    
    {
        private GUIStyle _gui = new();

        public override void OnGUI(Rect position)
        {
            _gui.fontSize = 14;
            _gui.fontStyle = FontStyle.Bold;
            _gui.normal.textColor = Colorlight.MangoMelody;

            VMeAttribute me = (VMeAttribute)attribute;

            GUIStyle background = new();
            background.normal.background = EditorGUIEX.CreateColorBox(new EditorGUI(), 20, 20, Colorlight.Mix(Colorlight.MangoMelody, 1, 4));

            EditorGUILayout.Space(10);

            EditorGUILayout.BeginVertical(background);

            EditorGUILayout.LabelField($"◆ {me.Name}", _gui);

            EditorGUILayout.EndVertical();
        }

        public override float GetHeight()
        {
            return base.GetHeight() * 1.75F;
        }
    }
}