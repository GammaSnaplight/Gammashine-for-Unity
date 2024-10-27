using UnityEditor;
using UnityEngine;

using Snaplight;

[CustomPropertyDrawer(typeof(VLimitAttribute))]
public class MinMaxAttributeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        VLimitAttribute minMaxAttribute = (VLimitAttribute)attribute;

        EditorGUI.BeginProperty(position, label, property);

        if (property.propertyType == SerializedPropertyType.Float)
        {
            float value = EditorGUI.FloatField(position, label, property.floatValue);
            property.floatValue = Mathlight.MinMax(value, minMaxAttribute.MinValue, minMaxAttribute.MaxValue);
        }
        else if (property.propertyType == SerializedPropertyType.Integer)
        {
            int value = EditorGUI.IntField(position, label, property.intValue);
            property.intValue = (int)Mathlight.MinMax(value, minMaxAttribute.MinValue, minMaxAttribute.MaxValue);
        }
        else
        {
            EditorGUI.PropertyField(position, property, label);
        }

        EditorGUI.EndProperty();
    }
}