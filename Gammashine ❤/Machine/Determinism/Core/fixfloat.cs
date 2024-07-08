using System;
using System.Runtime.CompilerServices;

namespace Snaplight.Determinism.FixedFLoat
{
    public struct fixfloat
    {
        private int rawFloatValue;

        private const int fractionalBits = 16;
        private const int multiplier = 1 << fractionalBits; // 2^16

        public fixfloat(int integerPart, int fractionalPart) =>
            rawFloatValue = (integerPart << fractionalBits) + fractionalPart;

        public fixfloat(float floatValue) => rawFloatValue = (int)(floatValue * multiplier);

        public float ExplFloat() => (float)rawFloatValue / multiplier;

        public static fixfloat ExplFloat(float value) => new((int)(value * multiplier));


        public static fixfloat operator + (fixfloat a, fixfloat b) => new(a.rawFloatValue + b.rawFloatValue);

        public static fixfloat operator - (fixfloat a, fixfloat b) => new(a.rawFloatValue - b.rawFloatValue);

        public static fixfloat operator * (fixfloat a, fixfloat b) => new((a.rawFloatValue * b.rawFloatValue) >> fractionalBits);

        public static fixfloat operator / (fixfloat a, fixfloat b) => new((a.rawFloatValue << fractionalBits) / b.rawFloatValue);

        public static bool operator < (fixfloat a, fixfloat b) => a.rawFloatValue < b.rawFloatValue;
        public static bool operator > (fixfloat a, fixfloat b) => a.rawFloatValue > b.rawFloatValue;
        public static bool operator >= (fixfloat a, fixfloat b) => a.rawFloatValue >= b.rawFloatValue;
        public static bool operator <= (fixfloat a, fixfloat b) => a.rawFloatValue <= b.rawFloatValue;
        public static bool operator == (fixfloat a, fixfloat b) => a.rawFloatValue == b.rawFloatValue;
        public static bool operator != (fixfloat a, fixfloat b) => a.rawFloatValue != b.rawFloatValue;

        public static bool operator < (fixfloat a, float b) => a.ExplFloat() < b;
        public static bool operator > (fixfloat a, float b) => a.ExplFloat() > b;
        public static bool operator >= (fixfloat a, float b) => a.ExplFloat() >= b;
        public static bool operator <= (fixfloat a, float b) => a.ExplFloat() <= b;
        public static bool operator == (fixfloat a, float b) => a.ExplFloat() == b;
        public static bool operator != (fixfloat a, float b) => a.ExplFloat() != b;

        public static bool operator < (float a, fixfloat b) => a < b.ExplFloat();
        public static bool operator > (float a, fixfloat b) => a > b.ExplFloat();
        public static bool operator >= (float a, fixfloat b) => a >= b.ExplFloat();
        public static bool operator <= (float a, fixfloat b) => a <= b.ExplFloat();
        public static bool operator == (float a, fixfloat b) => a == b.ExplFloat();
        public static bool operator != (float a, fixfloat b) => a != b.ExplFloat();


        public static implicit operator fixfloat(int value) => new(value, 0);
    }
}
