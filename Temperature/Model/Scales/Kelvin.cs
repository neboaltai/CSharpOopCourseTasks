namespace Temperature.Model.Scales
{
    class Kelvin : IScale
    {
        public double ConvertFromCelsius(double celsiusDegrees)
        {
            return celsiusDegrees + 273.15;
        }

        public double ConvertToCelsius(double kelvinDegrees)
        {
            return kelvinDegrees - 273.15;
        }
    }
}
