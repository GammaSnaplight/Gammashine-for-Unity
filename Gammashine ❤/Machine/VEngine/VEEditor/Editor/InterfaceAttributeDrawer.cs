using System;

using UnityEngine;
using UnityEditor;

namespace Snaplight
{
    [CustomPropertyDrawer(typeof(VInterfaceAttribute))]
    public class InterfaceAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            VInterfaceAttribute interfaceAttribute = attribute as VInterfaceAttribute;
           Type targetType = interfaceAttribute.TargetType;

            if (property.propertyType == SerializedPropertyType.ObjectReference)
            {
                UnityEngine.Object targetObject = property.objectReferenceValue;
                if (targetObject != null && !targetType.IsInstanceOfType(targetObject))
                {
                    property.objectReferenceValue = null;
                }

                EditorGUI.BeginChangeCheck();
                UnityEngine.Object value = EditorGUI.ObjectField(position, label, property.objectReferenceValue, typeof(UnityEngine.Object), true);

                if (EditorGUI.EndChangeCheck())
                {
                    if (value != null && targetType.IsInstanceOfType(value))
                    {
                        property.objectReferenceValue = value;
                    }
                    else
                    {
                        property.objectReferenceValue = null;
                    }
                }
            }
            else
            {
                EditorGUI.LabelField(position, label, new GUIContent("Use Interface only on fields of type UnityEngine.Object"));
            }
        }
    }
}
