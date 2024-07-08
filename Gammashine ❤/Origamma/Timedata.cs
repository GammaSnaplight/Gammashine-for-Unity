using System;

using UnityEngine;

using Snaplight.Folds;
using Snaplight.VisualizationEngine;
using static Snaplight.Timelight;

namespace Snaplight
{
    [Serializable]
    public class Timedata : IControllable<Timedata.Control>, IPlayable, IShuttable
    {
        // IControllable
        public enum Control { Waiting, Starting, Playback, Shutdown, Finishing, Aftereffect }
        public enum PlaybackMode { Manual, Automate }
        public enum OvertimeMode { Stopdown, Loopback, Unrestricted }
        public enum TimeMode { Time, Unscaled, Realtime }

        public Control Controllable { get; set; }
        [VMe("Mode")]
        public PlaybackMode PlaybackModiable;
        public OvertimeMode OvertimeModiable;

        private TimeMode _playmode;

        public TimeMode Playmode
        {
            get { return _playmode; }
            set
            {
                _playmode = value;

                _timehash = Playmode switch
                {
                    TimeMode.Time => () => Time.deltaTime,
                    TimeMode.Unscaled => () => Time.unscaledDeltaTime,
                    TimeMode.Realtime => () => Time.time - Time.realtimeSinceStartup,
                    _ => () => 0f,
                };
            }
        }

        private Func<float> _timehash;

        // Serializable
        [VMe("Limitation")]
        public float Limit;

        [HideInInspector] public float Timer;
        [HideInInspector] public int IntegerTimer => (int)Timer;

        [HideInInspector] public bool IsTimeover => Controllable is Control.Finishing or Control.Aftereffect;

        public enum FXMode { Slowdown, Sharp, Acute, Lightfast, Elastic, Bounce, Exponential, Circular }
        public enum FXVariation { Start, Late, Edges }

        public float Percent => Timer >= Limit ? 1 : Timer / Limit;
        public float Countdown => Timer >= Limit ? 0 : Limit - Timer;
        public float CountdownPercent => Timer >= Limit ? 0 : (Limit - Timer) / Limit;

        public Timedata()
        {
            Playmode = TimeMode.Time;

            Controllable = Control.Waiting;
        }

        public Timedata(float limit)
        {
            Playmode = TimeMode.Time;

            Controllable = Control.Waiting;

            Limit = limit;
        }

        ~Timedata() { }

        public static float FX(Timedata timedata, FXMode mode, FXVariation variation)
        {
            float percent = timedata.Percent;
            float timer = timedata.Timer;
            float limit = timedata.Limit;

            return (mode, variation) switch
            {
                (FXMode.Slowdown, FXVariation.Start) => limit == 0 ? timer : percent * percent,
                (FXMode.Slowdown, FXVariation.Late) => limit == 0 ? timer : -1 * (percent * (percent - 2)),
                (FXMode.Slowdown, FXVariation.Edges) => limit == 0 ? timer : percent < 0.5f ? 2 * percent * percent : -1 + ((4 - (2 * percent)) * percent),

                (FXMode.Sharp, FXVariation.Start) => limit == 0 ? timer : percent * percent * percent,
                (FXMode.Sharp, FXVariation.Late) => limit == 0 ? timer : 1 - Mathf.Pow(1 - percent, 3),
                (FXMode.Sharp, FXVariation.Edges) => limit == 0 ? timer : percent < 0.5f ? 4 * percent * percent * percent : 1 - Mathf.Pow(-2 * percent + 2, 3) / 2,

                (FXMode.Acute, FXVariation.Start) => limit == 0 ? timer : Mathf.Pow(percent, 4),
                (FXMode.Acute, FXVariation.Late) => limit == 0 ? timer : 1 - Mathf.Pow(1 - percent, 4),
                (FXMode.Acute, FXVariation.Edges) => limit == 0 ? timer : percent < 0.5f ? 4 * Mathf.Pow(2 * percent, 4) : 1 - Mathf.Pow(-2 * percent + 2, 4) / 2,

                (FXMode.Lightfast, FXVariation.Start) => limit == 0 ? timer : Mathf.Pow(percent, 4),
                (FXMode.Lightfast, FXVariation.Late) => limit == 0 ? timer : 1 - Mathf.Pow(1 - percent, 4),
                (FXMode.Lightfast, FXVariation.Edges) => limit == 0 ? timer : percent < 0.5f ? 8 * Mathf.Pow(percent, 4) : 1 - Mathf.Pow(-2 * percent + 2, 4) / 2,

                (FXMode.Bounce, FXVariation.Start) => limit == 0 ? timer : 1 - Mathlight.Bounce(1 - percent),
                (FXMode.Bounce, FXVariation.Late) => limit == 0 ? timer : Mathlight.Bounce(percent),
                (FXMode.Bounce, FXVariation.Edges) => limit == 0 ? timer : percent < 0.5f ? (1 - Mathlight.Bounce(1 - 2 * percent)) / 2 : (1 + Mathlight.Bounce(2 * percent - 1)) / 2,

                (FXMode.Elastic, FXVariation.Start) => limit == 0 ? timer : Mathf.Pow(2, 10 * percent - 10) * Mathf.Sin((percent * 10 - 10.75f) * ((2 * Mathf.PI) / 3)),
                (FXMode.Elastic, FXVariation.Late) => limit == 0 ? timer : 1 - Mathf.Pow(2, -10 * percent) * Mathf.Sin((percent * 10 - 0.75f) * ((2 * Mathf.PI) / 3)),
                (FXMode.Elastic, FXVariation.Edges) => limit == 0 ? timer : percent < 0.5f ? -(Mathf.Pow(2, 20 * percent - 10) * Mathf.Sin((20 * percent - 11.125f) * ((2 * Mathf.PI) / 4.5f))) / 2 : (Mathf.Pow(2, -20 * percent + 10) * Mathf.Sin((20 * percent - 11.125f) * ((2 * Mathf.PI) / 4.5f))) / 2 + 1,

                (FXMode.Exponential, FXVariation.Start) => limit == 0 ? timer : Mathf.Pow(2, 10 * percent - 10),
                (FXMode.Exponential, FXVariation.Late) => limit == 0 ? timer : 1 - Mathf.Pow(2, -10 * percent),
                (FXMode.Exponential, FXVariation.Edges) => limit == 0 ? timer : percent < 0.5f ? Mathf.Pow(2, 20 * percent - 10) / 2 : (2 - Mathf.Pow(2, -20 * percent + 10)) / 2,

                (FXMode.Circular, FXVariation.Start) => limit == 0 ? timer : 1 - Mathf.Sqrt(1 - Mathf.Pow(percent, 2)),
                (FXMode.Circular, FXVariation.Late) => limit == 0 ? timer : Mathf.Sqrt(1 - Mathf.Pow(percent - 1, 2)),
                (FXMode.Circular, FXVariation.Edges) => limit == 0 ? timer : percent < 0.5f ? (1 - Mathf.Sqrt(1 - Mathf.Pow(2 * percent, 2))) / 2 : (Mathf.Sqrt(1 - Mathf.Pow(-2 * percent + 2, 2)) + 1) / 2,

                 _ => Constlight.ERROR
            };
        }

        public void Zeroing()
        {
            Timer = 0;
            Controllable = Control.Waiting;
        }

        public void Playback()
        {
            if (Controllable == Control.Shutdown) return;

            if (Timer == 0) Controllable = Control.Starting;

            if (PlaybackModiable == PlaybackMode.Automate && Controllable != Control.Finishing && Controllable != Control.Aftereffect)
            {
                Controllable = Control.Playback;
                Timer += _timehash();
            }

            if (PlaybackModiable == PlaybackMode.Manual && Controllable != Control.Finishing && Controllable != Control.Aftereffect)
            {
                if (Controllable == Control.Playback) Timer += _timehash();
            }

            if (Controllable == Control.Finishing) Controllable = Control.Aftereffect;
            if (Timer >= Limit && Controllable != Control.Aftereffect) Controllable = Control.Finishing;

            if (Timer >= Limit)
            {
                if (OvertimeModiable == OvertimeMode.Stopdown)
                {
                    Timer = Limit;
                }
                if (OvertimeModiable == OvertimeMode.Loopback)
                {
                    Timer = 0;
                }
                if (OvertimeModiable == OvertimeMode.Unrestricted)
                {
                    Timer += _timehash();
                }
            }
        }

        public void Shutdown()
        {
            Controllable = Control.Shutdown;
        }

        public void Continue()
        {
            if (Controllable == Control.Shutdown) Controllable = Control.Playback;
        }

        public void Breaking()
        {
            Shutdown();
            Zeroing();
        }

        public override bool Equals(object obj)
        {
            return obj is Timelight;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            if (PlaybackModiable == PlaybackMode.Automate)
            {
                return $"[AUTO] Controllable: {Controllable} | Timer: {Timer} | Percent: {Mathf.FloorToInt(Percent * 100)}% | Countdown: {Countdown}";
            }
            else return $"Controllable: {Controllable} | Timer: {Timer} | Percent: {Mathf.FloorToInt(Percent * 100)}% | Countdown: {Countdown}";
        }

        public static bool operator <(Timedata timedata, float value) => timedata.Timer < value;
        public static bool operator >(Timedata timedata, float value) => timedata.Timer > value;
        public static bool operator <=(Timedata timedata, float value) => timedata.Timer <= value;
        public static bool operator >=(Timedata timedata, float value) => timedata.Timer >= value;
        public static bool operator ==(Timedata timedata, float value) => timedata.Timer == value;
        public static bool operator !=(Timedata timedata, float value) => timedata.Timer != value;

        public static implicit operator Timedata(float limit) => new(limit);
    }
}
