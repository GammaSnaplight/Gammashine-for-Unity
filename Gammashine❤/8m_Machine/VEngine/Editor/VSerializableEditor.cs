using UnityEngine;
using UnityEditor;
using System.Linq;

[CustomPropertyDrawer(typeof(VInterfaceAttribute))]
public class SerializeInterfaceDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        var interfaceType = fieldInfo.FieldType;
        if (property.objectReferenceValue != null)
        {
            // Проверяем, является ли объект ScriptableObject и реализует ли нужный интерфейс
            if (!(property.objectReferenceValue is ScriptableObject scriptableObject) || !interfaceType.IsAssignableFrom(scriptableObject.GetType()))
            {
                property.objectReferenceValue = null;
            }
        }

        property.objectReferenceValue = EditorGUI.ObjectField(position, label, property.objectReferenceValue, typeof(ScriptableObject), false);

        EditorGUI.EndProperty();
    }
}