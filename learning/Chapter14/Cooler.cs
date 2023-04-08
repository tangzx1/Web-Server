using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter14
{
    public class Cooler
    {
        public float Temperature { get; set; }

        public void OnTemperatureChanged(float newTemperature)
        {
            if (newTemperature > Temperature)
            {
                Console.WriteLine("Cooler On");
            }
            else
            {
                Console.WriteLine("Cooler Off");
            }
        }


    }
}
