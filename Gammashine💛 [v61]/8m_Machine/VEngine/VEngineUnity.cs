using UnityEngine;

namespace Snaplight.VisualizationEngine
{
    public static partial class VEngine
    {
        public static void WriteLog()
        {
            Debug.Log(WriteLine());
        }

        public static void WriteLog(object info)
        {
            Debug.Log(WriteLine(info));
        }
    }
}
