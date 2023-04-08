using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter14
{
    public class Thermostat
    {
        //public Action<float>? OnTemperatureChanged { get; set; }

        public class TemperatureArgs : System.EventArgs
        {
            public TemperatureArgs(float newTemperature)
            {
                NewTemperature = newTemperature;
            }

            public float NewTemperature { get; set; }
        }

        public event EventHandler<TemperatureArgs> OnTemperatureChanged = delegate { };

        private float _CurrentTemperature;
        public float CurrentTemperature
        {
            get { return _CurrentTemperature; }
            set
            {
                if (_CurrentTemperature != value)
                {
                    _CurrentTemperature = value;

                    OnTemperatureChanged?.Invoke(this,new TemperatureArgs(value));
                }

            }
        }
    }
}
