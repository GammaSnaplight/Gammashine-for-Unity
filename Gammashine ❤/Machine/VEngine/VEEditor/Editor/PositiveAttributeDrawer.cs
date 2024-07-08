using UnityEditor;
using UnityEngine;

using Snaplight;

[CustomPropertyDrawer(typeof(PositiveAttribute))]
public class PositiveAttributeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        PositiveAttribute positiveAttribute = (PositiveAttribute)attribute;

        EditorGUI.BeginProperty(position, label, property);

        if (property.propertyType == SerializedPropertyType.Float)
        {
            float value = EditorGUI.FloatField(position, label, property.floatValue);
            value = Mathlight.Positive(value);
            property.floatValue = value;
        }
        else if (property.propertyType == SerializedPropertyType.Integer)
        {
            int value = EditorGUI.IntField(position, label, property.intValue);
            value = Mathlight.Positive(value);
            property.intValue = value;
        }
        else
        {
            EditorGUI.PropertyField(position, property, label);
        }

        EditorGUI.EndProperty();
    }
}
