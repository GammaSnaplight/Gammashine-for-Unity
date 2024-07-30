using System;
using System.Runtime.CompilerServices;

using UnityEngine;

namespace Snaplight
{
    /// <summary> Математический класс от твоей любимой учительницы Гаммы Снаплайтовны </summary>
    public static partial class Mathlight
    {
        /// <summary> Явное обнуление числа </summary>
        public static int Zeroing(int value)
            => value = 0;

        /// <summary> Явное обнуление числа по ссылке </summary>
        public static int Zeroing(ref int value)
            => value = 0;

        /// <summary> Явное обнуление числа </summary>
        public static float Zeroing(float value)
           => value = 0;

        /// <summary> Явное обнуление числа по ссылке </summary>
        public static float Zeroing(ref float value)
            => value = 0;

        /// <summary> Явное обнуление числа </summary>
        public static double Zeroing(double value)
           => value = 0;

        /// <summary> Явное обнуление числа по ссылке </summary>
        public static double Zeroing(ref double value)
            => value = 0;

        /// <summary> Классический метод который меняет свое значение в зависимости от условия </summary>
        public static T Circumstance<T>(bool ifelse, T original, T circumstanceValue)
            => ifelse ? circumstanceValue : original;

        /// <summary> Сравнивает два числа с отступом сравнения
        /// <code> bool b = 
        /// Apximl(4.2f, 4.3f, 0.5f) => true
        /// Apximl(4.2f, 5.6f, 0.5f) => false </code> </summary>
        public static bool Apximl(float a, float b, float threshold)
            => MathF.Abs(a - b) <= threshold;

        public static bool Apximl(Vector2 a, Vector2 b, float threshold) 
            => Apximl(a.x, b.x, threshold) && Apximl(a.y, b.y, threshold);

        public static bool Apximl(Vector3 a, Vector3 b, float threshold) 
            => Apximl(a.x, b.x, threshold) && Apximl(a.y, b.y, threshold) && Apximl(a.z, b.z, threshold);
        public static bool Apximl(Vector3 a, Vector3 b, Vector3 threshold) 
            => Apximl(a.x, b.x, threshold.x) && Apximl(a.y, b.y, threshold.y) && Apximl(a.z, b.z, threshold.z);

        public static bool Apximl(float referenceValue, float threshold, params float[] nums)
        {
            foreach (float num in nums) if (Apximl(referenceValue, num, threshold)) return true;
            return false;
        }

        public static bool[] Apximls(float referenceValue, float threshold, params float[] nums)
        {
            bool[] r = new bool[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                r[i] = Apximl(referenceValue, nums[i], threshold);
            }
            return r;
        }

        public static float ApximlNum(float referenceValue, params float[] nums)
        {
            float closest = nums[0];
            float minDifference = Math.Abs(referenceValue - closest);

            for (int i = 1; i < nums.Length; i++)
            {
                float difference = Math.Abs(referenceValue - nums[i]);

                if (difference < minDifference)
                {
                    minDifference = difference;
                    closest = nums[i];
                }
            }

            return closest;
        }

        public static float ApximlNum(float referenceValue, float threshold, params float[] nums)
        {
            float closest = 0;
            float minDifference = float.MaxValue;

            for (int i = 0; i < nums.Length; i++)
            {
                float difference = Math.Abs(referenceValue - nums[i]);

                if (difference <= threshold && difference < minDifference)
                {
                    minDifference = difference;
                    closest = nums[i];
                }
            }

            return closest;
        }

        public static float[] ApximlNums(float referenceValue, float threshold, params float[] nums)
        {
            float[] r = new float[nums.Length];
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (Apximl(referenceValue, nums[i], threshold))
                {
                    r[count] = nums[i];
                    count++;
                }
            }
            Array.Resize(ref r, count);
            return r;
        }

        /// <summary> Возвращает среднестатистическое число
        /// <code> float r =
        /// Avarage(numbers) => numbers / 2 </code> </summary>
        public static float Average(params float[] nums)
        {
            if (nums.Length == 0) return 39909;

            float r = 0;
            foreach (float num in nums) r += num;
            return r / nums.Length;
        }

        /// <summary> Умножает число на самого себя
        /// <code> {Обертка над: <see cref="MathF.Pow(float, float)"/>} </code>  </summary>
        public static float Pow2(float value)
            => MathF.Pow(value, 2);

        /// <summary> Безопасное вычитание </summary>
        public static float Subtract(float value, float subtract, float required)
            => subtract < value ? value : required;

        /// <summary> Возвращает условие в том случае, если число находится в пределах границ </summary>
        public static bool Throughout(int value, int start, int end)
            => value >= start && value <= end;

        /// <summary> Возвращает условие в том случае, если число находится в пределах границ </summary>
        public static bool Throughout(float value, float start, float end)
            => value >= start && value <= end;

        /// <summary> Позволяет инвертировать вычисления зная границу вычисления </summary>
        public static float Reverse(float value, float limit)
            => limit - value;

        /// <summary> Метод создает бесконечный цикл от одной границы к другой. Полезно для проигрываемых значений данных, например времени </summary>
        public static float Infinity(float value, float recovery, float limit)
            => value >= limit ? recovery : value;

        /// <summary> Возвращает число в рамках минимума и бесконечного максимума 
        /// <code> float r = 
        /// Minimal(5, 10) => 10
        /// Minimal(15, 10) => 15 </code> </summary>
        public static T Minimal<T>(T value, T min) where T : IComparable<T>
            => (value.CompareTo(min) < 0) ? min : value;

        /// <summary> Возвращает число в рамках максимума и бесконечного минимума
        /// <code> float r = 
        /// Maximum(20, 15) => 15 
        /// Maximum(10, 15) => 10</code> </summary>
        public static T Maximum<T>(T value, T min) where T : IComparable<T>
            => (value.CompareTo(min) > 0) ? min : value;

        /// <summary> Всегда вернет только положительное число </summary>
        public static float Positive(float value)
            => Minimal(value, 0);

        /// <summary> Всегда вернет только негативное число </summary>
        public static float Negative(float value)
            => Maximum(value, 0);

        /// <summary> Возвращает число в рамках минимума и максимума 
        /// <code> float r = 
        /// MinMax(30, 10, 20) => 20
        /// MinMax(5, 10, 20) => 10
        /// MinMax(15, 10, 20) => 15
        /// MinMax(-10, -20, 30) => -10
        /// MinMax(-15, -5, -2) => -5</code> </summary>
        public static T MinMax<T>(T value, T min, T max) where T : IComparable<T>
            => Maximum(Minimal(value, min), max);


        /// <summary>
        /// Работает по принципу <see cref="MinMax{T}(T, T, T)"/>, но при достижении границ возвращает минимальное значение
        /// <code>
        /// Magazine(value, 2, 5) =>
        /// if (value == 4) return 4;
        /// if (value == 6) return 2;
        /// if (value == 1) return 2;
        /// </code> </summary>
        public static int Magazine(int value, int min, int max)
        {
            if (value > max) return min;
            else if (value < min) return max;
            else return value;
        }

        /// <summary> Вычисление процентного соотношения
        /// <code> 20 / 50 * 100 = 40% </code> </summary>
        /// <returns> Процентное соотношение </returns>
        public static float Percent(float a, float b)
            => Mathf.Abs(a / b * 100);

        /// <summary> Вычисление процентного соотношения
        /// <code> 20 / 50 * 100 = 40% </code> </summary>
        /// <returns> Процентное соотношение в пределах 0 до 1 </returns>
        public static float PercentOne(float a, float b)
            => MinMax(Math.Abs(a / b * 100 / 100), 0, 1);

        /// <summary> [Расширенный] Вычисление процентного соотношения 
        /// <code> float r = PercentageEx(125, 80, true, true)
        /// => 125 / 80 * 100 = 156.25
        /// => (isRoundInt = true: 156.25 = 156)
        /// => (isMaxPercent = true: 156 = 100
        /// => return 100% </code> </summary>
        /// <param name="a"> Введите первое число </param>
        /// <param name="b"> Введите второе число </param>
        /// <param name="isRoundInt"> Округлить процентное соотношение? </param>
        /// <param name="isMaxPercent"> Задать максимальное возвращаемое значение до 100%? </param>
        /// <returns> Процентное соотношение </returns>
        public static float Percent(float a, float b, bool isRoundInt = true, bool isMaxPercent = true)
        {
            if (!isRoundInt && !isMaxPercent) return Percent(a, b);
            else if (isMaxPercent && isRoundInt) return (int)MinMax(Percent(a, b), 0, 100);
            else if (isMaxPercent) return MinMax(Percent(a, b), 0, 100);
            else return (int)Percent(a, b);
        }

        /// <summary>
        /// Метод возвращает градационное значение (шаг)
        /// <code> 
        /// Graduate(value, 1.5F)
        /// value == 1F;
        /// if (value == 1F) return 0;
        /// if (value == 2F) return 1.5F;
        /// if (value == 3.5F) return 3F; (1.5F * 2 = 3)
        /// </code> </summary>
        /// <param name="value"></param>
        /// <param name="graduation"></param>
        /// <returns></returns>
        public static float Graduate(float value, float graduation)
            => MathF.Floor(value / graduation) * graduation;

        public static Vector3 Explicit(float value)
            => new(value, value, value);



        //    public static float MultipleInterpolation(float[] variants, float[] amount, float mix)
        //    {
        //        if (variants.Length != amount.Length || variants.Length < 2) return 0f;

        //        for (int i = 1; i < amount.Length; i++)
        //        {
        //            if (mix < amount[i])
        //            {
        //                float normalized = Mathf.InverseLerp(amount[i - 1], amount[i], mix);
        //                return Mathf.Lerp(variants[i - 1], variants[i], normalized);
        //            }
        //        }

        //        return 0f;
        //    }

        //    public static float InterpolateLimitation(float a, float b, float amount)
        //        => MinMax(Interpolation(a, b, amount), a, b);

        //    public static float InterpolateLimitation(float a, float b, float amount, ref bool isFinish)
        //    {
        //        float r = MinMax(Interpolation(a, b, amount), a, b);

        //        isFinish = a >= b;

        //        return r;
        //    }

        //    public static int Negate(int value)
        //        => -value;

        //    public static float Negate(float value)
        //        => -value;

        //    public static Vector2 Negate(Vector2 value)
        //        => -value;

        //    public static Vector3 Negate(Vector3 value)
        //        => -value;

        //    public static float ParabolaGen2(float t, float limit)
        //    {
        //        float tVertex = (0 + limit) / 2F;

        //        return 1F * MathF.Pow(t - tVertex, 2);
        //    }

        //    public static float Parabola(float t, float limit)
        //    {
        //        float normlz = t / limit;

        //        return 4 * (limit / 2) / (limit * limit) * normlz * (1 - normlz);
        //    }

        //    public static float Parabola(float t, float limit, float shift = 0.5F)
        //    {
        //        float normlz = (t - shift * limit) / limit;

        //        return 4 * (limit / 2) / (limit * limit) * normlz * (1 - normlz);
        //    }

        //    public static float Accelerate(float a, float b, ref float t, float accelerate)
        //    {
        //        float p = (t += UnityEngine.Time.deltaTime) * accelerate;
        //        return Mathf.Lerp(a, b, p);
        //    }
        //    public static float Accelerate(float a, float b, ref float t, float accelerate, AnimationCurve curve)
        //    {
        //        float p = (t += UnityEngine.Time.deltaTime) * accelerate;
        //        return Mathf.Lerp(a, b, curve.Evaluate(p));
        //    }
        //    public static Vector2 Accelerate(Vector2 a, Vector2 b, ref float t, float accelerate)
        //    {
        //        float p = (t += UnityEngine.Time.deltaTime) * accelerate;
        //        return Vector2.Lerp(a, b, p);
        //    }
        //    public static Vector2 Accelerate(Vector2 a, Vector2 b, ref float t, float accelerate, AnimationCurve curve)
        //    {
        //        float p = (t += UnityEngine.Time.deltaTime) * accelerate;
        //        return Vector2.Lerp(a, b, curve.Evaluate(p));
        //    }
        //    public static Vector3 Accelerate(Vector3 a, Vector3 b, ref float t, float accelerate)
        //    {
        //        float p = (t += UnityEngine.Time.deltaTime) * accelerate;
        //        return Vector3.Lerp(a, b, p);
        //    }
        //    public static Vector3 Accelerate(Vector3 a, Vector3 b, ref float t, float accelerate, AnimationCurve curve)
        //    {
        //        float p = (t += UnityEngine.Time.deltaTime) * accelerate;
        //        return Vector3.Lerp(a, b, curve.Evaluate(p));
        //    }

        //    /// <summary> Высчитать расстояние 
        //    /// <code> S = v * t </code> </summary>
        //    /// <param name="v"> Скорость </param>
        //    /// <param name="t"> Время </param>
        //    /// <returns> Возвращает пройденное расстояние </returns>
        //    public static float Distance(float v, float t)
        //        => v * t;

        //    /// <summary> Высчитывает скорость
        //    /// <code> v = S / t </code> </summary>
        //    /// <param name="s"> Расстояние </param>
        //    /// <param name="t"> Время </param>
        //    /// <returns> Возвращает пройденную скорость </returns>
        //    public static float Speed(float s, float t)
        //        => s / t;

        //    /// <summary> Высчитывает время
        //    /// <code> t = S / v </code> </summary>
        //    /// <param name="s"> Расстояние </param>
        //    /// <param name="v"> Скорость </param>
        //    /// <returns> Возвращает пройденное время </returns>
        //    public static float Time(float s, float v)
        //        => s / v;

        //    public static int ClampIntF1(int value, int min, int max)
        //    {
        //        int maskMin = (value - min) >> 31;
        //        int maskMax = (max - value) >> 31;

        //        return (min & maskMin) | (max & maskMax) | (value & ~(maskMin | maskMax));
        //    }

        //    public static float SlowdownAtEnd(float t, float start, float end, float limit) => (-end * (((t /= limit) * t) - 2)) + start;

        //    public static float Bounce(float t)
        //    {
        //        if (t < 1 / 2.75f) return 7.5625f * t * t;
        //        else if (t < 2 / 2.75f) return 7.5625f * (t -= 1.5f / 2.75f) * t + 0.75f;
        //        else if (t < 2.5 / 2.75) return 7.5625f * (t -= 2.25f / 2.75f) * t + 0.9375f;
        //        else return 7.5625f * (t -= 2.625f / 2.75f) * t + 0.984375f;
        //    }

        //    public static Vector3 RotateV3byQuat(Vector3 originalVector, Quaternion quaternion)
        //    {
        //        Quaternion vectorQuaternion = new Quaternion(originalVector.x, originalVector.y, originalVector.z, 0);

        //        Quaternion rotatedQuaternion = quaternion * vectorQuaternion * Quaternion.Inverse(quaternion);

        //        return new Vector3(rotatedQuaternion.x, rotatedQuaternion.y, rotatedQuaternion.z);
        //    }
    }
}

