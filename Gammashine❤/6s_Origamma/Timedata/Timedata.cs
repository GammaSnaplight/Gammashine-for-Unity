using System;

using Snaplight.Controllable;

using UnityEngine;

namespace Snaplight.Origamma
{
    public partial struct Timedata : ITimemodel<float>
    {
        // ITimemodel
        public float Timer { get; set; }
        public float Limit { get; set; }

        // Controllable
        public TimedataControllable Controllable;
        public ControlTypemodel PlaybackTypemodel;
        public OvertimeTypemodel OvertimeTypemodel;
        public CountdownTypemodel CountdownTypemodel;

        // Serializable
        internal readonly float Percent => Timer >= Limit ? 1 : Timer / Limit;
        internal readonly float Countdown => Timer >= Limit ? 0 : Limit - Timer;
        internal readonly float CountdownPercent => Timer >= Limit ? 0 : (Limit - Timer) / Limit;
        internal readonly bool IsTimeover => Controllable is TimedataControllable.Finishing or TimedataControllable.Aftereffect;

        // Variable
        private CountdownTypemodel _playmode;

        private Func<float> _timehash;

        public CountdownTypemodel Playmode
        {
            readonly get { return _playmode; }
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

        //===
        public Timedata(float limit)
        {
            Controllable = TimedataControllable.Waiting;
            PlaybackTypemodel = ControlTypemodel.Automate;
            OvertimeTypemodel = OvertimeTypemodel.Stopdown;
            CountdownTypemodel = CountdownTypemodel.Deltatime;

            _timehash = () => 0;
            _playmode = CountdownTypemodel;

            Timer = 0;
            Limit = limit;
        }

        //===
        public readonly void Collection()
        {
            
        }

        public void Zeroing()
        {
            Timer = 0;
            Controllable = TimedataControllable.Waiting;
        }

        public  void Playback()
        {
            if (Controllable == TimedataControllable.Shutdown) return;

            if (Timer == 0) Controllable = TimedataControllable.Starting;

            if (PlaybackTypemodel == ControlTypemodel.Automate && Controllable != TimedataControllable.Finishing && Controllable != TimedataControllable.Aftereffect)
            {
                Controllable = TimedataControllable.Playback;
                Timer += _timehash();
            }

            if (PlaybackTypemodel == ControlTypemodel.Manual && Controllable != TimedataControllable.Finishing && Controllable != TimedataControllable.Aftereffect)
            {
                if (Controllable == TimedataControllable.Playback) Timer += _timehash();
            }

            if (Controllable == TimedataControllable.Finishing) Controllable = TimedataControllable.Aftereffect;
            if (Timer >= Limit && Controllable != TimedataControllable.Aftereffect) Controllable = TimedataControllable.Finishing;

            if (Timer >= Limit)
            {
                if (OvertimeTypemodel == OvertimeTypemodel.Stopdown)
                {
                    Timer = Limit;
                }
                if (OvertimeTypemodel == OvertimeTypemodel.Loopback)
                {
                    Timer = 0;
                }
                if (OvertimeTypemodel == OvertimeTypemodel.Unrestricted)
                {
                    Timer += _timehash();
                }
                if (OvertimeTypemodel == OvertimeTypemodel.PingPong)
                {
                    if (Timer >= Limit ) Timer -= _timehash();
                    if (Timer <= 0) Timer += _timehash();
                }
            }
        }

        public void Shutdown()
        {
            Controllable = TimedataControllable.Shutdown;
        }

        public void Continue()
        {
            Controllable = TimedataControllable.Playback;
        }

        public void Elimination()
        {
            
        }

        //===
        public override readonly string ToString()
        {
            if (PlaybackTypemodel == ControlTypemodel.Automate)
            {
                return $"[AUTO] Controllable: {Controllable} | Timer: {Timer} | Percent: {(float)(Percent * 100)}% | Countdown: {Countdown}";
            }
            else return $"Controllable: {Controllable} | Timer: {Timer} | Percent: {(float)(Percent * 100)}% | Countdown: {Countdown}";
        }

        public override readonly bool Equals(object obj)
        {
            return obj is Timedata;
        }

        public override readonly int GetHashCode()
        {
            HashCode hash = new();
            hash.Add(Timer);
            hash.Add(Limit);
            hash.Add(Controllable);
            hash.Add(PlaybackTypemodel);
            hash.Add(OvertimeTypemodel);
            hash.Add(CountdownTypemodel);
            hash.Add(Percent);
            hash.Add(Countdown);
            hash.Add(CountdownPercent);
            hash.Add(IsTimeover);
            hash.Add(_playmode);
            hash.Add(_timehash);
            hash.Add(Playmode);
            return hash.ToHashCode();
        }

        //===
        public static bool operator <(Timedata timedata, float value) => timedata.Timer < value;
        public static bool operator >(Timedata timedata, float value) => timedata.Timer > value;
        public static bool operator <=(Timedata timedata, float value) => timedata.Timer <= value;
        public static bool operator >=(Timedata timedata, float value) => timedata.Timer >= value;
        public static bool operator ==(Timedata timedata, float value) => timedata.Timer == value;
        public static bool operator !=(Timedata timedata, float value) => timedata.Timer != value;

        //===
        public static implicit operator Timedata(float limit) => new(limit);
    }
}
