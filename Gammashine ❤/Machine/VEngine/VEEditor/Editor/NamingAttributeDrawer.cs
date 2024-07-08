using UnityEditor;

using UnityEngine;

namespace Snaplight
{
    [CustomPropertyDrawer(typeof(VNamingAttribute))]
    public class NamingAttributeDrawer : PropertyDrawer
    {
        private GUIStyle _gui = new();

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            VNamingAttribute namingAttribute = (VNamingAttribute)attribute;

            _gui.fontSize = Mathlight.MinMax(namingAttribute.Size, 10, 24);

            if (namingAttribute.IsBold) _gui.fontStyle = FontStyle.Bold;
            else _gui.fontStyle = FontStyle.Normal;

            _gui.normal.textColor = Colorlight.MangoMelody;

            Rect labelRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
            if (namingAttribute.TextProperty == null) EditorGUI.LabelField(labelRect, new GUIContent($"▶ {namingAttribute.Text}"), _gui);
            else EditorGUI.LabelField(labelRect, namingAttribute.TextProperty, _gui);

            position.y += EditorGUIUtility.singleLineHeight;
            EditorGUI.PropertyField(position, property, label, true);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            VNamingAttribute namingAttribute = (VNamingAttribute)attribute;

            return EditorGUI.GetPropertyHeight(property) + EditorGUIUtility.singleLineHeight + namingAttribute.Size / 2;
        }
    }
}