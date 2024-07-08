using System;

namespace Snaplight
{
    /// <summary>
    /// ˜˜˜˜˜˜ ˜˜˜˜˜˜˜˜˜˜˜˜ ˜˜˜˜˜˜ ˜˜˜ ˜˜˜˜˜˜˜˜˜˜˜ ˜˜˜˜˜˜˜ ˜ ˜˜˜ ˜˜˜˜˜˜ ˜˜˜˜˜˜˜˜˜˜
    /// </summary>
    public enum ModuleUndertaking { Playback, Shutdown }

    /// <summary>
    /// ˜˜˜˜˜˜ ˜˜˜˜˜˜˜˜˜˜˜˜ ˜˜˜˜˜˜ ˜˜˜ ˜˜˜˜˜˜˜˜˜˜˜ ˜˜˜˜˜˜˜˜˜˜˜˜˜˜˜ ˜˜˜˜˜˜, ˜˜˜ ˜˜˜˜˜ ˜˜˜˜˜˜˜ ˜˜˜˜˜˜˜˜ ˜ ˜˜˜˜˜˜ ˜˜˜˜˜˜˜˜˜ ˜˜˜˜˜˜˜˜˜˜ ˜˜˜˜˜˜˜ ˜˜˜˜˜˜ ˜˜˜˜˜˜
    /// </summary>
    public enum ModuleLiabilities { Underlow, Regular, Highly, Superior, Extreme }

    public interface IUndertaking
    {
        public ModuleUndertaking Undertaking { get; set; }
    }

    public interface ILiabilities
    {
        public ModuleLiabilities Liabilities { get; set; }
    }

    public interface IControllable<T>
        where T : Enum
    {
        public T Controllable { get; set; }
    }

    public interface IAlternatable<T>
        where T : Enum
    {
        public T Alternatable { get; set; }
    }

    public interface IThemselfable<T>
        where T : Enum
    {
        public T Selfable { get; set; }
    }

    public interface IModulableMarkout
    {

    }

    public interface IModulable : IElementable, IEliminatable, IModulableMarkout
    {

    }

    public interface IUniversalModulable : IModulable, IUndertaking, ILiabilities
    {

    }

    public interface IPlayableModulable : IUniversalModulable, IPlayable
    {

    }

    public interface ISuperModulable<TData, KControllable> : ISuperElementable<TData>, IEliminatable<TData>, IControllable<KControllable>, IUndertaking, ILiabilities, IModulableMarkout
        where TData : IFoldables
        where KControllable : Enum
    {

    }

    public interface IBrillianceModulable<TReturn, KData, JControllable, HAlternative> : IBrillianceElementable<TReturn, KData>, IEliminatable<KData>, IControllable<JControllable>, IAlternatable<HAlternative>, IUndertaking, ILiabilities, IModulableMarkout
        where KData : IFoldables
        where JControllable : Enum
        where HAlternative : Enum
    {

    }
}