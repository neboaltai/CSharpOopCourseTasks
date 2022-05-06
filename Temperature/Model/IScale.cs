namespace Temperature.Model
{
    public interface IScale
    {
        double ConvertFromCelsius(double celsiusDegrees);

        double ConvertToCelsius(double degrees);
    }
}
