using System;
using System.Windows.Forms;
using Temperature.Model;
using Temperature.Model.Scales;

namespace Temperature
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IScale[] scales = { new CelsiusScale(), new KelvinScale(), new FahrenheitScale() };

            ITemperatureConverter temperatureConverter = new TemperatureConverter();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(temperatureConverter, scales));
        }
    }
}
