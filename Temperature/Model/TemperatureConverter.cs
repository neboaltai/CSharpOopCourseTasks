using Temperature.Model.Scales;

namespace Temperature.Model
{
    public class TemperatureConverter : ITemperatureConverter
    {
        public IScale[] Scales { get; }

        public TemperatureConverter(IScale[] scales)
        {
            Scales = scales;
        }

        public double Convert(IScale inputScale, IScale outputScale, double degrees)
        {
            if (inputScale is Celsius)
            {
                if (outputScale is Celsius)
                {
                    return degrees;
                }

                return outputScale.ConvertFromCelsius(degrees);
            }

            if (outputScale is Celsius)
            {
                return inputScale.ConvertToCelsius(degrees);
            }

            return outputScale.ConvertFromCelsius(inputScale.ConvertToCelsius(degrees));
        }
    }
}
