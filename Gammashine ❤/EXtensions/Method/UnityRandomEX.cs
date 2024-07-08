using System.Collections.Generic;

using UnityEngine;

namespace Snaplight.Extension
{
    public static class UnityRandomEX
    {
        public static float RangeQuaternion
            => Random.Range(0, 361);

        public static int RangeElements<T>(ICollection<T> item)
            => Random.Range(0, item.Count);

        public static int RangeAnd(int a, int b) 
            => Random.Range(0, 101) <= 50 ? a : b;

        //public static int RangeAnd(params int[] nums)
        //{
        //    float average = 100 / nums.Length;
        //    float random = Random.Range(0, 101);
        //    float result = 100 - random
            
        //}

        public static float RangeAnd(float a, float b)
            => Random.Range(0, 101) <= 50 ? a : b;

        public static bool Percent(int chance)
            => Random.Range(0, 101) <= chance;

        public static int Range(int max)
            => Random.Range(0, max + 1);

        public static float Range(float max)
            => Random.Range(0, max + 1);
    }
}
