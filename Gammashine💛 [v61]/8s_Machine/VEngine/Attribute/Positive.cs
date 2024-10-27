using System;

using UnityEngine;

[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
public class PositiveAttribute : PropertyAttribute
{
    public PositiveAttribute()
    {
        
    }
}
