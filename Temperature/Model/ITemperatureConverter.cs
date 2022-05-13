namespace Temperature.Model
{
    public interface ITemperatureConverter
    {
        double Convert(IScale inputScale, IScale outputScale, double degrees);
    }
}
