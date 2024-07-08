using System;
using System.Reflection;

using UnityEngine;

public static class Mirrorlight
{
    public static void Mirror(object sourceA, object destinationB)
    {
        if (sourceA == null )
        {
            Debug.LogError($"CopyData() произошла ошибка. Данные (source) имеют NULL");
        }
        else if (destinationB == null)
        {
            Debug.LogError($"CopyData() произошла ошибка. Данные (destination) имеют NULL");
        }

        Type sourceType = sourceA.GetType();
        Type destinationType = destinationB.GetType();

        MemberInfo[] sourceMembers = sourceType.GetMembers(BindingFlags.Public | BindingFlags.Instance);

        foreach (MemberInfo member in sourceMembers)
        {
            if (member is FieldInfo sourceField)
            {
                FieldInfo destinationField = destinationType.GetField(sourceField.Name, BindingFlags.Public | BindingFlags.Instance);
                if (destinationField != null)
                {
                    object value = sourceField.GetValue(sourceA);
                    destinationField.SetValue(destinationB, value);
                }
            }
            else if (member is PropertyInfo sourceProperty)
            {
                PropertyInfo destinationProperty = destinationType.GetProperty(sourceProperty.Name, BindingFlags.Public | BindingFlags.Instance);
                if (destinationProperty != null && destinationProperty.CanWrite)
                {
                    object value = sourceProperty.GetValue(sourceA);
                    destinationProperty.SetValue(destinationB, value);
                }
            }
        }
    }
}
