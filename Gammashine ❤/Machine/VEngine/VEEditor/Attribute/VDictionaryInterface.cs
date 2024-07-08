using System;

using UnityEngine;

namespace Snaplight
{
    public class VDictionaryInterfaceAttribute : PropertyAttribute
    {
        public Type TargetType;

        public VDictionaryInterfaceAttribute(Type targetType)
        {
            TargetType = targetType;
        }
    }
}
