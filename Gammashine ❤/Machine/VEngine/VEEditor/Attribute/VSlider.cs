using System;

using UnityEngine;

[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
public class VSliderAttribute : PropertyAttribute
{
    public float MinValue;
    public float MaxValue;
    public float Graduation;

    public VSliderAttribute()
    {
        MinValue = 0;
        MaxValue = 1;
        Graduation = 0;
    }
    public VSliderAttribute(float maxValue)
    {
        MinValue = 0;
        MaxValue = maxValue;
        Graduation = 0;
    }
    public VSliderAttribute(float minValue, float maxValue, float graduation = 0.01F)
    {
        MinValue = minValue;
        MaxValue = maxValue;
        Graduation = graduation;
    }
}
