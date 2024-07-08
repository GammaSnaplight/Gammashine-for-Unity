using System;

using UnityEngine;

using Snaplight.Folds;
using Snaplight.VisualizationEngine;

namespace Snaplight
{
    [Serializable]
    public class Timelight : IModulable, IPlayable
    {
        // IModulable
        public enum TimelightControllable { Starting, Playback, Shutdown, Finishing, Waiting }
        public TimelightControllable Controllable { get; set; }

        public enum PairwiseTimelightControllable { First, Second }

        // Serializable
        [field: SerializeField] public float Limit { get; private set; }
        public float Timer { get; private set; }
        public float Percent => Timer >= Limit ? 1 : Timer / Limit;
        public float Countdown => Timer >= Limit ? 0 : Limit - Timer;
        public float CountdownPercent => Timer >= Limit ? 0 : (Limit - Timer) / Limit;
        public float FXSlowdownStart => Limit == 0 ? Timer : Percent * Percent;
        public float FXSlowdownLate => Limit == 0 ? Timer : -1 * (Percent * (Percent - 2));
        public float FXSlowdownEdges => Limit == 0 ? Timer : Percent < 0.5f ? 2 * Percent * Percent : -1 + ((4 - (2 * Percent)) * Percent);
        public float FXSharpStart => Limit == 0 ? Timer : Percent * Percent * Percent;
        public float FXSharpLate => Limit == 0 ? Timer : 1 - Mathf.Pow(1 - Percent, 3);
        public float FXSharpEdges => Limit == 0 ? Timer : Percent < 0.5f ? 4 * Percent * Percent * Percent : 1 - Mathf.Pow(-2 * Percent + 2, 3) / 2;
        public float FXAcuteStart => Limit == 0 ? Timer : Mathf.Pow(Percent, 4);
        public float FXAcuteLate => Limit == 0 ? Timer : 1 - Mathf.Pow(1 - Percent, 4);
        public float FXAcuteEdges => Limit == 0 ? Timer : Percent < 0.5f ? 4 * Mathf.Pow(2 * Percent, 4) : 1 - Mathf.Pow(-2 * Percent + 2, 4) / 2;
        public float FXElasticStart => Limit == 0 ? Timer : Mathf.Pow(2, 10 * Percent - 10) * Mathf.Sin((Percent * 10 - 10.75f) * ((2 * Mathf.PI) / 3));
        public float FXElasticLate => Limit == 0 ? Timer : 1 - Mathf.Pow(2, -10 * Percent) * Mathf.Sin((Percent * 10 - 0.75f) * ((2 * Mathf.PI) / 3));
        public float FXElasticEdges => Limit == 0 ? Timer : Percent < 0.5f ? -(Mathf.Pow(2, 20 * Percent - 10) * Mathf.Sin((20 * Percent - 11.125f) * ((2 * Mathf.PI) / 4.5f))) / 2 : (Mathf.Pow(2, -20 * Percent + 10) * Mathf.Sin((20 * Percent - 11.125f) * ((2 * Mathf.PI) / 4.5f))) / 2 + 1;
        public float FXBounceStart => Limit == 0 ? Timer : 1 - Mathlight.Bounce(1 - Percent);
        public float FXBounceLate => Limit == 0 ? Timer : Mathlight.Bounce(Percent);
        public float FXBounceEdges => Limit == 0 ? Timer : Percent < 0.5f ? (1 - Mathlight.Bounce(1 - 2 * Percent)) / 2 : (1 + Mathlight.Bounce(2 * Percent - 1)) / 2;
        public float FXLightfastStart => Limit == 0 ? Timer : Mathf.Pow(Percent, 4);
        public float FXLightfastLate => Limit == 0 ? Timer : 1 - Mathf.Pow(1 - Percent, 4);
        public float FXLightfastEdges => Limit == 0 ? Timer : Percent < 0.5f ? 8 * Mathf.Pow(Percent, 4) : 1 - Mathf.Pow(-2 * Percent + 2, 4) / 2;
        public float FXExponentialStart => Limit == 0 ? Timer : Mathf.Pow(2, 10 * Percent - 10);
        public float FXExponentialLate => Limit == 0 ? Timer : 1 - Mathf.Pow(2, -10 * Percent);
        public float FXExponentialEdges => Limit == 0 ? Timer : Percent < 0.5f ? Mathf.Pow(2, 20 * Percent - 10) / 2 : (2 - Mathf.Pow(2, -20 * Percent + 10)) / 2;
        public float FXCircularStart => Limit == 0 ? Timer : 1 - Mathf.Sqrt(1 - Mathf.Pow(Percent, 2));
        public float FXCircularLate => Limit == 0 ? Timer : Mathf.Sqrt(1 - Mathf.Pow(Percent - 1, 2));
        public float FXCircularEdges => Limit == 0 ? Timer : Percent < 0.5f ? (1 - Mathf.Sqrt(1 - Mathf.Pow(2 * Percent, 2))) / 2 : (Mathf.Sqrt(1 - Mathf.Pow(-2 * Percent + 2, 2)) + 1) / 2;
        public bool IsFinish => Controllable == TimelightControllable.Finishing;

        // Variables
        public enum PlayableMode { Time, Unscaled, Realtime }
        public PlayableMode Playmode
        {
            get { return _playmode; }
            set
            {
                _playmode = value;
                PlaybackMode();
            }
        }

        private PlayableMode _playmode;

        private Func<float> _timehash;

        private float _initialLimitValue;

        public Timelight()
        {
            Limit = 1;
            Timer = 0;

            Collection();
        }

        public Timelight(float limit)
        {
            Limit = limit;
            Timer = 0;

            Collection();
        }

        public Timelight(float limit, float shiftTime)
        {
            Limit = limit;
            Timer = shiftTime;

            Collection();
        }

        public void Collection()
        {
            Playmode = PlayableMode.Time;
            Controllable = TimelightControllable.Playback;

            _initialLimitValue = Limit;
        }

        public static void Zeroing(params Timelight[] timedatas)
        {
            foreach (Timelight value in timedatas)
            {
                value.Zeroing();
            }
        }

        public static PairwiseTimelightControllable PairwiseTimeover(Timelight first, Timelight second)
        {
            second.Controllable = TimelightControllable.Shutdown;

            first.Playback();
            second.Playback();

            if (first.Controllable == TimelightControllable.Finishing)
            {
                second.Controllable = TimelightControllable.Playback;
                first.Controllable = TimelightControllable.Shutdown;

                return PairwiseTimelightControllable.Second;
            }
            else if (second.Controllable == TimelightControllable.Finishing)
            {
                first.Controllable = TimelightControllable.Playback;
                second.Controllable = TimelightControllable.Shutdown;

                return PairwiseTimelightControllable.First;
            }
            else return PairwiseTimelightControllable.First;
        }

        public void Zeroing()
        {
            Timer = 0;
            Controllable = TimelightControllable.Waiting;
        }

        public void Mode(PlayableMode mode = PlayableMode.Time)
            => Playmode = mode;

        public void Playback()
        {
            if (Controllable == TimelightControllable.Playback) Timer += _timehash();

            if (Timer >= Limit) Controllable = TimelightControllable.Finishing;
        }

        public void Shutdown()
        {
            Controllable = TimelightControllable.Shutdown;
        }

        public void Continue()
        {
            if (Controllable == TimelightControllable.Shutdown) Controllable = TimelightControllable.Playback;
        }
        public void Breaking()
        {
            Shutdown();
            Zeroing();
        }

        public void Waiting()
        {
            
        }

        public void Shift(float t)
        {
            if (Timer >= Limit) Timer = Limit;
            else Timer += t;
        }

        public void AddLimit(float limit) => Limit += limit;
        public void NewLimit(float limit) => Limit = limit;
        public void RecoveryLimit() => Limit = _initialLimitValue;

        public void Elimination()
        {

        }

        private void PlaybackMode()
        {
            _timehash = Playmode switch
            {
                PlayableMode.Time => () => Time.deltaTime,
                PlayableMode.Unscaled => () => Time.unscaledDeltaTime,
                PlayableMode.Realtime => () => Time.time - Time.realtimeSinceStartup,
                _ => () => 0f,
            };
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
            return $"Controllable: {Controllable} | Timer: {Timer} | Percent: {Mathf.FloorToInt(Percent * 100)}% | Countdown: {Countdown}";
        }

        public static bool operator <(Timelight timedata, float value) => timedata.Timer < value;
        public static bool operator >(Timelight timedata, float value) => timedata.Timer > value;
        public static bool operator <=(Timelight timedata, float value) => timedata.Timer <= value;
        public static bool operator >=(Timelight timedata, float value) => timedata.Timer >= value;
        public static bool operator ==(Timelight timedata, float value) => timedata.Timer == value;
        public static bool operator !=(Timelight timedata, float value) => timedata.Timer != value;

        public static implicit operator Timelight(float limit) => new(limit);
    }
}