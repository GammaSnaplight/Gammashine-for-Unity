using UnityEditor;
using UnityEngine;

using Snaplight;

[CustomPropertyDrawer(typeof(VSliderAttribute))]
public class MinMaxSliderAttributeDrawer : PropertyDrawer
{
    private string _typeInfo;
    string _afterLabelInfo;
    private float _value;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        VSliderAttribute minMaxAttribute = (VSliderAttribute)attribute;

        EditorGUI.BeginProperty(position, label, property);

        EditorGUI.LabelField(position, label, EditorStyles.boldLabel);

        if (_value >= minMaxAttribute.MaxValue)
        {
            _afterLabelInfo = $"{_typeInfo}: [MAX]";
        }
        else if (_value <= minMaxAttribute.MinValue)
        {
            _afterLabelInfo = $"{_typeInfo}: [MIN]";
        }
        else
        {
            _afterLabelInfo = $"{_typeInfo}: [{minMaxAttribute.MinValue}  ~  {minMaxAttribute.MaxValue}]";
        }

        Rect valueRect = new (position.x + EditorGUIUtility.labelWidth, position.y, position.width - EditorGUIUtility.labelWidth, position.height);
        Vector2 labelSize = GUI.skin.label.CalcSize(new GUIContent(_afterLabelInfo));

        float offsetWidth = labelSize.x;

        Rect afterLabelPosition = new(position.x + position.width - offsetWidth, position.y, offsetWidth, position.height);

        EditorGUI.LabelField(afterLabelPosition, new GUIContent(_afterLabelInfo));


        if (property.propertyType == SerializedPropertyType.Float)
        {
            _typeInfo = "float";

            _value = EditorGUILayout.Slider(property.floatValue, minMaxAttribute.MinValue, minMaxAttribute.MaxValue);
            
            if (minMaxAttribute.Graduation != 0)
            {
                _value = Mathlight.Graduate(_value, minMaxAttribute.Graduation);
            }

            property.floatValue = Mathlight.MinMax(_value, minMaxAttribute.MinValue, minMaxAttribute.MaxValue);
        }
        else if (property.propertyType == SerializedPropertyType.Integer)
        {
            _typeInfo = minMaxAttribute.MaxValue switch
            {
                255 => "byte",
                127 when minMaxAttribute.MinValue == -128 => "sbyte",
                _ => "int",
            };
            _value = EditorGUILayout.IntSlider(property.intValue, (int)minMaxAttribute.MinValue, (int)minMaxAttribute.MaxValue);

            _value = Mathlight.Graduate(_value, minMaxAttribute.Graduation);
            property.intValue = (int)Mathlight.MinMax(_value, minMaxAttribute.MinValue, minMaxAttribute.MaxValue);
        }
        else
        {
            EditorGUI.PropertyField(position, property, label);
        }

        EditorGUI.EndProperty();
    }
}
