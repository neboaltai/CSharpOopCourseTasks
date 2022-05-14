using Temperature.Model.Scales;

namespace Temperature.Model
{
    public class TemperatureConverter : ITemperatureConverter
    {
        public double Convert(IScale inputScale, IScale outputScale, double degrees)
        {
            return outputScale.ConvertFromCelsius(inputScale.ConvertToCelsius(degrees));
        }
    }
}