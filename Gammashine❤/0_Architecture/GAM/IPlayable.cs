using System;

namespace Snaplight
{
    public interface IPlayable
    {
        public void Playback();
    }

    public interface IAutomatePlayable : IPlayable { }
}