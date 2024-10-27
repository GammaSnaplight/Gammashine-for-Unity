using System;
using System.Linq;
using System.Runtime.CompilerServices;

using UnityEngine;

using Snaplight;

namespace Snaplight.VisualizationEngine
{
    public static partial class VEngine
    {
        public static string Auto([CallerFilePath] string path = "", [CallerLineNumber] int line = 0, [CallerMemberName] string method = "")
            => $"{path} : ({line}) {method}";

        public static string WriteLine()
            => $"{Auto()} - MEOW!";

        public static string WriteLine(object info)
            => $"{Auto()} - {info}";
    }
}
