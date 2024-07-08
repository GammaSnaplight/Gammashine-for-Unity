using System;

using UnityEngine;

using Snaplight;

/// <summary> Математический класс с Особенными вычислениями </summary>
public static class UniqueMathlight
{
    public enum MassType { Mt, Kg, Lbs, Oz, St, Ct, Dkg, Gram, Mgram }

    /// <summary> Вычисляет PPI экрана (Пикселей на дюйм) 
    /// <code> sqrt(h * h + w * w) / inch => PPI </code> </summary>
    /// <param name="h"> Высота </param>
    /// <param name="w"> Ширина </param>
    /// <param name="inch"> Диагональ </param>
    /// <returns> Pixels per inch </returns>
    public static int PPI(float h, float w, float inch) =>
        _ = (int)(MathF.Sqrt(Mathlight.Pow2(h) + Mathlight.Pow2(w)) / inch);

    /// <summary> Метод конвертации веса и массы </summary>
    /// <param name="value"> Значение которое нужно конвертировать </param>
    /// <param name="mt1"> С какого типа конвертировать в качестве значения </param>
    /// <param name="mt2"> В какой тип конвертировать </param>
    /// <returns> Конвертированное значение </returns>
    public static float Mass(float value, MassType mt1 = MassType.Kg, MassType mt2 = MassType.Lbs)
    {
        return mt1 switch
        {
            MassType.Mt when mt2 == MassType.Kg => value * 1_000,
            MassType.Mt when mt2 == MassType.Lbs => value * 2_204.623F,
            MassType.Mt when mt2 == MassType.Oz => value * 35_273.96F,
            MassType.Mt when mt2 == MassType.St => value * 153.473F,
            MassType.Mt when mt2 == MassType.Ct => value * 5_000_000,
            MassType.Mt when mt2 == MassType.Dkg => value * 100_000,
            MassType.Mt when mt2 == MassType.Gram => value * 1_000_000,
            MassType.Mt when mt2 == MassType.Mgram => value * 1_000_000_000,

            MassType.Kg when mt2 == MassType.Mt => value / 1_000,
            MassType.Kg when mt2 == MassType.Lbs => value * 2.204623F,
            MassType.Kg when mt2 == MassType.Oz => value * 35.27396F,
            MassType.Kg when mt2 == MassType.St => value * 0.157473F,
            MassType.Kg when mt2 == MassType.Ct => value * 5_000,
            MassType.Kg when mt2 == MassType.Dkg => value * 100,
            MassType.Kg when mt2 == MassType.Gram => value * 1_000,
            MassType.Kg when mt2 == MassType.Mgram => value * 1_000_000,

            MassType.Lbs when mt2 == MassType.Mt => value * 0.000454F,
            MassType.Lbs when mt2 == MassType.Kg => value * 0.453592F,
            MassType.Lbs when mt2 == MassType.Oz => value * 16,
            MassType.Lbs when mt2 == MassType.St => value * 0.071429F,
            MassType.Lbs when mt2 == MassType.Ct => value * 2_267.962F,
            MassType.Lbs when mt2 == MassType.Dkg => value * 45.35924F,
            MassType.Lbs when mt2 == MassType.Gram => value * 453.5924F,
            MassType.Lbs when mt2 == MassType.Mgram => value * 453_592.4F,

            MassType.Oz when mt2 == MassType.Mt => value * 0.000028F,
            MassType.Oz when mt2 == MassType.Kg => value * 0.02835F,
            MassType.Oz when mt2 == MassType.Lbs => value * 0.0625F,
            MassType.Oz when mt2 == MassType.St => value * 0.004464F,
            MassType.Oz when mt2 == MassType.Ct => value * 141.7476F,
            MassType.Oz when mt2 == MassType.Dkg => value * 2.834952F,
            MassType.Oz when mt2 == MassType.Gram => value * 28.34952F,
            MassType.Oz when mt2 == MassType.Mgram => value * 28_349.52F,

            // TODO Доделать данный метод конвертации
            _ => value,
        };
    }
}
