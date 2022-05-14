namespace Temperature.Model.Scales
{
    class CelsiusScale : IScale
    {
        public string Name => "Celsius";

        public double ConvertFromCelsius(double celsiusDegrees)
        {
            return celsiusDegrees;
        }

        public double ConvertToCelsius(double celsiusDegrees)
        {
            return celsiusDegrees;
        }
    }
}
