using System;
using System.Windows.Forms;
using Temperature.Model;
using Temperature.Model.Scales;

namespace Temperature
{
    public partial class MainForm : Form
    {
        private readonly ITemperatureConverter temperatureConverter;

        private readonly IScale[] scales;

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(ITemperatureConverter temperatureConverter, IScale[] scales) : this()
        {
            this.temperatureConverter = temperatureConverter;

            this.scales = scales;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            fromScaleList.Items.AddRange(scales);

            toScaleList.Items.AddRange(scales);

            fromScaleList.DisplayMember = "Name";
            toScaleList.DisplayMember = "Name";

            fromScaleList.SelectedIndex = 0;
            toScaleList.SelectedIndex = 0;
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            try
            {
                double temperature = Convert.ToDouble(enterTemperatureField.Text);
                resultLabel.Text = $"{temperatureConverter.Convert(fromScaleList.SelectedItem as IScale, toScaleList.SelectedItem as IScale, temperature):f02} {toScaleList.Text.Substring(0, 1)}";
            }
            catch (FormatException)
            {
                MessageBox.Show("Temperature must be a number", "Error");
            }
        }

        private void swapButton_Click(object sender, EventArgs e)
        {
            IScale scale = (IScale)fromScaleList.SelectedItem;

            fromScaleList.SelectedItem = toScaleList.SelectedItem;

            toScaleList.SelectedItem = scale;
        }

        private void fromScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            enterTemperatureLabel.Text = "Enter temperature in " + fromScaleList.Text + ":";

            IScale toScale = (IScale)toScaleList.SelectedItem;

            toScaleList.Items.Clear();

            foreach (IScale scale in scales)
            {
                if (scale != fromScaleList.SelectedItem)
                {
                    toScaleList.Items.Add(scale);
                }
            }

            if (toScale != fromScaleList.SelectedItem)
            {
                toScaleList.SelectedItem = toScale;
            }
            else
            {
                toScaleList.SelectedIndex = 0;
            }
        }
    }
}
