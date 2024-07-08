using Snaplight;

using System;

namespace Snaplight.Gammachine.EffXs
{
    public sealed class EffXsData
    {
        // IFolds
        public float GlobalizationValueModifier { get; set; }
        public bool Selector { get; set; }

        // Callback
        public event Action Selected;

        // Variables
        public Timelight timedata;
        public string Name;
        public float Percent;


        public bool CheckoutSelector()
        {
            Selected?.Invoke();

            return Selector;
        }
    }
}