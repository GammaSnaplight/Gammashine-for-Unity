using UnityEditor;
using UnityEngine;

namespace Snaplight
{
    [CustomPropertyDrawer(typeof(VDictionaryInterfaceAttribute))]
    public class DictionaryInterfaceAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            VDictionaryInterfaceAttribute interfaceAttribute = attribute as VDictionaryInterfaceAttribute;
            System.Type targetType = interfaceAttribute.TargetType;

            if (property.propertyType == SerializedPropertyType.Generic)
            {
                EditorGUI.BeginChangeCheck();
                _ = EditorGUI.PropertyField(position, property, label, true);

                if (EditorGUI.EndChangeCheck())
                {
                    for (int i = 0; i < property.arraySize; i++)
                    {
                        SerializedProperty element = property.GetArrayElementAtIndex(i);
                        Object targetObject = element.objectReferenceValue;
                        if (targetObject != null && !targetType.IsInstanceOfType(targetObject))
                        {
                            element.objectReferenceValue = null;
                        }
                    }
                }
            }
            else
            {
                EditorGUI.LabelField(position, label, new GUIContent("Use InterfaceDictionary only on fields of type Dictionary"));
            }
        }
    }
}
