using System;

using UnityEngine;

namespace Snaplight
{
    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public class VNamingAttribute : PropertyAttribute
    {
        public string Text;
        public string TextProperty;
        public int Size;
        public bool IsBold;

        public VNamingAttribute(object text)
        {
            Text = text.ToString();
            Size = 12;
            IsBold = true;
        }

        public VNamingAttribute(string text)
        {
            Text = text;
            Size = 12;
            IsBold = true;
        }

        public VNamingAttribute(string text, string textProperty)
        {
            Text = text;
            TextProperty = textProperty;
            Size = 12;
            IsBold = true;
        }

        public VNamingAttribute(string text, int size)
        {
            Text = text;
            Size = size;
            IsBold = true;
        }

        public VNamingAttribute(string text, string textProperty, int size)
        {
            Text = text;
            TextProperty = textProperty;
            Size = size;
            IsBold = true;
        }

        public VNamingAttribute(string text, bool isBold)
        {
            Text = text;
            Size = 12;
            IsBold = isBold;
        }

        public VNamingAttribute(string text, string textProperty, bool isBold)
        {
            Text = text;
            TextProperty = textProperty;
            Size = 12;
            IsBold = isBold;
        }

        public VNamingAttribute(string text, int size, bool isBold)
        {
            Text = text;
            Size = size;
            IsBold = isBold;
        }

        public VNamingAttribute(string text, string textProperty, int size, bool isBold)
        {
            Text = text;
            TextProperty = textProperty;
            Size = size;
            IsBold = isBold;
        }
    }
}