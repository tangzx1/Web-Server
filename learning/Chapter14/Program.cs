// See https://aka.ms/new-console-template for more information

using Chapter14;

Thermostat thermostat = new();
Heater heater = new()
{
    Temperature = 60
};
Cooler cooler = new()
{
    Temperature = 80
};
string temperature;

thermostat.OnTemperatureChanged += heater.OnTemperatureChanged;

thermostat.OnTemperatureChanged += (newTemperature) =>
{
    throw new InvalidCastException();
};

thermostat.OnTemperatureChanged += cooler.OnTemperatureChanged;

Console.WriteLine("Enter Temperature");
temperature = Console.ReadLine();
thermostat.CurrentTemperature = int.Parse(temperature);

//Action<float> delegate1;
//Action<float> delegate2;
//Action<float>? delegate3;

//delegate1= heater.OnTemperatureChanged;
//delegate2 = cooler.OnTemperatureChanged;
//delegate3 = delegate1;
//delegate3 += delegate2;
//delegate3(90);

//delegate3-=delegate1;
//delegate3!(30);

Console.ReadKey();
