using System;
using System.Collections.Generic;

using Snaplight.VisualizationEngine;

namespace Snaplight.Gammachine.EffXs
{
    public abstract class EffXs
    {
        public EffXs()
        {
            Collection();
        }

        public string Naming => $"[Machine-Module] - {VEngine.NameClass(this)}";

        private Dictionary<string, EffXsData> _dataXs;
        private Queue<EffXsData> _queueXs;

        public void Collection()
        {
            _dataXs = new();
            _queueXs = new();
        }

        public void Elimination()
        {
            _dataXs.Clear();
            _queueXs.Clear();
        }

        public string Write(bool full)
        {
            return Naming;
        }

        public void Append()
        {

        }

        public void Remove()
        {

        }

        public abstract EffXs Tag(string tag);

        public abstract EffXs Playback();

        public abstract EffXs Shutdown();

        public abstract EffXs Continue();

        public abstract EffXs Breaking();

        public abstract EffXs Starting();

        public abstract EffXs Updating();

        public abstract EffXs Finishing();

        public abstract EffXs Percent(float percent);

        public abstract EffXs Percent(int percent);

        public abstract EffXs Time(Timelight timedata);

        public abstract void Destiny();

    }
}