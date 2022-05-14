namespace Temperature.Model.Scales
{
    public interface IScale
    {
        string Name { get; }

        double ConvertFromCelsius(double celsiusDegrees);

        double ConvertToCelsius(double degrees);
    }
}
