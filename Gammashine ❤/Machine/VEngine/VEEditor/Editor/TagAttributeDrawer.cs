using UnityEngine;
using UnityEditor;

using Snaplight.Snaplight;

namespace Snaplight
{
    [CustomPropertyDrawer(typeof(VTagAttribute))]
    public class TagAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (attribute is VTagAttribute tagAttribute)
            {
                string[] strings = TagAttributeData.Data[tagAttribute.Index];

                int index = Mathf.Max(0, System.Array.IndexOf(strings, property.stringValue));

                index = EditorGUI.Popup(position, label.text, index, strings);

                property.stringValue = strings[index];
            }
        }
    }
}