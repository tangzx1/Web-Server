using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter14
{
    public class Heater
    {
        public float Temperature { get; set; }

        public void OnTemperatureChanged(float newTemperature)
        {
            if (newTemperature > Temperature)
            {
                Console.WriteLine("Heater Off");
            }
            else
            {
                Console.WriteLine("Heater On");
            }
        }
    }
}
