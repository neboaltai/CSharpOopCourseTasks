using System;
using System.Windows.Forms;
using Temperature.Model;

namespace Temperature
{
    public partial class MainForm : Form
    {
        private readonly ITemperatureConverter temperatureConverter;

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(ITemperatureConverter temperatureConverter) : this()
        {
            this.temperatureConverter = temperatureConverter;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            fromScaleList.Items.AddRange(temperatureConverter.Scales);

            toScaleList.Items.AddRange(temperatureConverter.Scales);

            fromScaleList.SelectedIndex = 0;
            toScaleList.SelectedIndex = 0;
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            try
            {
                double temperature = Convert.ToDouble(enterTemperatureField.Text);
                resultLabel.Text = temperatureConverter.Convert(fromScaleList.SelectedItem as IScale, toScaleList.SelectedItem as IScale, temperature).ToString() + " " + toScaleList.Text.Substring(0, 1);
            }
            catch (FormatException)
            {
                MessageBox.Show("Temperature must be a number", "Error");
            }
        }

        private void swapButton_Click(object sender, EventArgs e)
        {
            string temp = fromScaleList.SelectedItem.ToString();

            fromScaleList.SelectedItem = toScaleList.SelectedItem;

            toScaleList.SelectedItem = temp;
        }

        private void fromScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            enterTemperatureLabel.Text = "Enter temperature in " + fromScaleList.Text + ":";

            toScaleList.Items.Clear();

            foreach (IScale scale in temperatureConverter.Scales)
            {
                if (scale != fromScaleList.SelectedItem)
                {
                    toScaleList.Items.Add(scale);
                }
            }

            toScaleList.SelectedIndex = 0;
        }
    }
}
