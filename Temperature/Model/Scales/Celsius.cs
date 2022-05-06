namespace Temperature.Model.Scales
{
    class Celsius : IScale
    {
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
