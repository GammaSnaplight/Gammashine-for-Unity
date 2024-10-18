using System;
using System.Globalization;

namespace Snaplight.Origamma
{
    public enum FXMode { Slowdown, Sharp, Acute, Lightfast, Elastic, Bounce, Exponential, Circular }
    public enum FXVariation { Start, Late, Edges }

    public partial interface ITimemodel<T> : IPlayableModulable
    {
        public static T UniversalFX(ITimemodel<T> timedata, FXMode mode, FXVariation variation)
        {
            float percent = ToFloat(timedata.Timer) / ToFloat(timedata.Limit);
            float timer = ToFloat(timedata.Timer);
            float limit = ToFloat(timedata.Limit);

            float result = (mode, variation) switch
            {
                (FXMode.Slowdown, FXVariation.Start) => MathlightFX.SlowdownStart(timer, percent, limit),
                (FXMode.Slowdown, FXVariation.Late) => MathlightFX.SlowdownLate(timer, percent, limit),
                (FXMode.Slowdown, FXVariation.Edges) => MathlightFX.SlowdownEdges(timer, percent, limit),

                (FXMode.Sharp, FXVariation.Start) => MathlightFX.SharpStart(timer, percent, limit),
                (FXMode.Sharp, FXVariation.Late) => MathlightFX.SharpLate(timer, percent, limit),
                (FXMode.Sharp, FXVariation.Edges) => MathlightFX.SharpEdges(timer, percent, limit),

                (FXMode.Acute, FXVariation.Start) => MathlightFX.AcuteStart(timer, percent, limit),
                (FXMode.Acute, FXVariation.Late) => MathlightFX.AcuteLate(timer, percent, limit),
                (FXMode.Acute, FXVariation.Edges) => MathlightFX.AcuteEdges(timer, percent, limit),

                (FXMode.Lightfast, FXVariation.Start) => MathlightFX.LightfastStart(timer, percent, limit),
                (FXMode.Lightfast, FXVariation.Late) => MathlightFX.LightfastLate(timer, percent, limit),
                (FXMode.Lightfast, FXVariation.Edges) => MathlightFX.LightfastEdges(timer, percent, limit),

                (FXMode.Bounce, FXVariation.Start) => MathlightFX.BounceStart(timer, percent, limit),
                (FXMode.Bounce, FXVariation.Late) => MathlightFX.BounceLate(timer, percent, limit),
                (FXMode.Bounce, FXVariation.Edges) => MathlightFX.BounceEdges(timer, percent, limit),

                (FXMode.Elastic, FXVariation.Start) => MathlightFX.ElasticStart(timer, percent, limit),
                (FXMode.Elastic, FXVariation.Late) => MathlightFX.ElasticLate(timer, percent, limit),
                (FXMode.Elastic, FXVariation.Edges) => MathlightFX.ElasticEdges(timer, percent, limit),

                (FXMode.Exponential, FXVariation.Start) => MathlightFX.ExponentialStart(timer, percent, limit),
                (FXMode.Exponential, FXVariation.Late) => MathlightFX.ExponentialLate(timer, percent, limit),
                (FXMode.Exponential, FXVariation.Edges) => MathlightFX.ExponentialEdges(timer, percent, limit),

                (FXMode.Circular, FXVariation.Start) => MathlightFX.CircularStart(timer, percent, limit),
                (FXMode.Circular, FXVariation.Late) => MathlightFX.CircularLate(timer, percent, limit),
                (FXMode.Circular, FXVariation.Edges) => MathlightFX.CircularEdges(timer, percent, limit),

                _ => 39909
            };

            return ToGeneric(result);
        }

        private static float ToFloat(T value)
            => Convert.ToSingle(value, CultureInfo.InvariantCulture);

        private static T ToGeneric(float value)
        {
            if (typeof(T) == typeof(int)) return (T)(object)Convert.ToInt32(value);
            else if (typeof(T) == typeof(float)) return (T)(object)value;
            else if (typeof(T) == typeof(double)) return (T)(object)Convert.ToDouble(value);
            else throw new InvalidOperationException("Unsupported type");
        }
    }
}
