using System;


namespace Snaplight
{
    public abstract class AbstractPoolight<TUniversal, KData, JControllable> : ISuperModulable<KData, JControllable>, IMemorable<KData>
        where KData : IFoldables
        where JControllable : Enum
    {
        public TUniversal Universal;

        public abstract ModuleUndertaking Undertaking { get; set; }
        public abstract ModuleLiabilities Liabilities { get; set; }
        public abstract JControllable Controllable { get; set; }

        public abstract KData Collection(KData data);
        public abstract KData Elimination();
        public abstract TUniversal Instantiate();
        public abstract void Destroy();
        public abstract void Snapshot(KData snapshot);
        public abstract KData Recover(KData snapshot);
    }
}