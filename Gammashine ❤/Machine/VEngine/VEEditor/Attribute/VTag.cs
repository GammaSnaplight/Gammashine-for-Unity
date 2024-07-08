using System.Collections.Generic;

using UnityEngine;

namespace Snaplight
{
    public class VTagAttribute : PropertyAttribute
    {
        public int Index;

        public VTagAttribute(int index)
        {
            Index = index;
        }
    }

    namespace Snaplight
    {
        public static class TagAttributeData
        {
            public static List<string[]> Data = new()
            {
                new string[]
                { 
                    "MenuPlayback",
                    "MenuExit",
                    "",
                    "Settings", 
                    "SettingsVolumeChange", 
                    "SettingsQualityChange",
                    "",
                    "GameplayPlayback",
                    "GameplayPause", 
                    "GameplayContinue",
                    "GameplayExit",
                    "",
                    "AutoManeuverLeft",
                    "AutoManeuverRight",
                    "ApplicationQuit",
                    "ContinueTagout",
                    "Answer1",
                    "Answer2",
                    "Answer3",
                    "Answer4",
                    "Answer5",
                    "Answer6",
                },
                new string[]
                {
                    "Non",
                    "ApplicationQuit",
                    "",
                    "Menu → ShareRecord",
                    "Menu → Settings",
                    "Menu → Purchase",
                    "Menu → ShortInstruction",
                    "",
                    "ShortInstruction → Instruction",
                    "ShortInstruction → Gameplay",
                    "",
                    "Instruction → ShortInstruction",
                    "",
                    "SettingsVolumeNext",
                    "SettingsVolumePreview",
                    "SettingsQualityNext",
                    "SettingsQualityPreview",
                    "Settings → Menu",
                    "",
                    "GameplayPause",
                    "GameplayContinue",
                    "Gameplay → Menu",
                    "",
                    "AutomobileLeftManeuver",
                    "AutomobileRightManeuver",
                },
            };
        }
    }
}