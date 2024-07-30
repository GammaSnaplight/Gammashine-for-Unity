using Snaplight;
using Snaplight.Gen3;

using UnityEngine;

public class Module : IMultipurposeModulable<ModuleData>
{
    public ModuleData Multipurpose { get; set; } = new();

    public void Collection()
    {
        Multipurpose.Undertaking = ModuleUndertaking.Playback;

        Debug.Log(Multipurpose.Undertaking);
    }
    public void Playback()
    {
        
    }

    public void Elimination()
    {
        
    }

}

public class ModuleData : IFoldables<ModuleData>
{
    public ModuleUndertaking Undertaking;
}