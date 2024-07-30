using System;

using UnityEngine;

using Snaplight.Controllable;

namespace Snaplight.Origamma
{
    [Serializable]
    public struct Timedata<T> : IRegularModulable, IShuttable
        where T : IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
    {
        // IControllable
        public TimedataControllable Controllable;
        public ControlTypemodel PlaybackTypemodel;
        public OvertimeTypemodel OvertimeTypemodel;
        public CountdownTypemodel CountdownTypemodel;

        // Serializable
        public float Limit;

        internal float Timer;

        // Property
        internal readonly int IntegerTimer => (int)Timer;
        internal readonly float Percent => Timer >= Limit ? 1 : Timer / Limit;
        internal readonly float Countdown => Timer >= Limit ? 0 : Limit - Timer;
        internal readonly float IntegerCountdown => (int)Countdown;
        internal readonly float CountdownPercent => Timer >= Limit ? 0 : (Limit - Timer) / Limit;
        internal readonly bool IsTimeover => Controllable is TimedataControllable.Finishing or TimedataControllable.Aftereffect;

        // Variable
        private CountdownTypemodel _playmode;

        private Func<float> _timehash;

        public CountdownTypemodel Playmode
        {
            get { return _playmode; }
            set
            {
                _playmode = value;

                _timehash = Playmode switch
                {
                    CountdownTypemodel.Deltatime => () => Time.deltaTime,
                    CountdownTypemodel.Unscaled => () => Time.unscaledDeltaTime,
                    CountdownTypemodel.Realtime => () => Time.time - Time.realtimeSinceStartup,
                    CountdownTypemodel.Platform => () => DateTime.Now.Second,
                    _ => () => 0f,
                };
            }
        }

        // Serializable

        public enum FXMode { Slowdown, Sharp, Acute, Lightfast, Elastic, Bounce, Exponential, Circular }
        public enum FXVariation { Start, Late, Edges }

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

        public void Collection()
        {
            throw new NotImplementedException();
        }

        public void Elimination()
        {
            throw new NotImplementedException();
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
