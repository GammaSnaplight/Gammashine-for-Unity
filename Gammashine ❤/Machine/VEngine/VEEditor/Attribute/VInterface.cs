using System;

using UnityEngine;

namespace Snaplight
{
    public class VInterfaceAttribute : PropertyAttribute
    {
        public Type TargetType;

        public VInterfaceAttribute(Type targetType)
        {
            TargetType = targetType;
        }
    }
}
