using System;

using UnityEngine;

namespace Snaplight
{
    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public class VMeAttribute : PropertyAttribute 
    {
        public string Name;

        public VMeAttribute(string name)
        {
            Name = name;
        }
    }
}