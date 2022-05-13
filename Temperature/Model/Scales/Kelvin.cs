namespace Temperature.Model.Scales
{
    class Kelvin : IScale
    {
        public string Name
        {
            get
            {
                return "Kelvin";
            }
        }

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
