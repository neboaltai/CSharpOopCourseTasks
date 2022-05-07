namespace Temperature.Model
{
    public interface ITemperatureConverter
    {
        IScale[] Scales { get; }

        double Convert(IScale inputScale, IScale outputScale, double degrees);
    }
}
