using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Input;
using CarApp.Models;

namespace CarApp.Views
{
    public partial class MainWindow : Window
    {
        private Car _car = new Car("Default", "Model");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SetCar_Click(object? sender, RoutedEventArgs e)
        {
            var colorBox = this.FindControl<TextBox>("ColorInput");
            var modelBox = this.FindControl<TextBox>("ModelInput");
            var carInfoText = this.FindControl<TextBlock>("CarInfo");

            string color = colorBox?.Text ?? "Unknown";
            string model = modelBox?.Text ?? "Unknown";

            _car = new Car(color, model);

            if (carInfoText != null)
                carInfoText.Text = $"Car: {_car.Color} {_car.Model}";
        }

        private void Drive_Click(object? sender, RoutedEventArgs e)
        {
            var distanceBox = this.FindControl<TextBox>("DistanceInput");
            var resultText = this.FindControl<TextBlock>("ResultOutput");

            if (_car == null || distanceBox == null || resultText == null)
            {
                if (resultText != null)
                    resultText.Text = "Please set a car first!";
                return;
            }

            if (int.TryParse(distanceBox.Text, out int distance))
            {
                _car.Drive(distance);
                resultText.Text = $"Remaining fuel: {_car.DriveWithReturn(distance):F1}%";
            }
            else
            {
                resultText.Text = "Please enter a valid distance!";
            }
        }

        private void TextBox_KeyUp(object? sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) // Check if the Enter key is pressed
            {
                var textBox = sender as TextBox;
                if (textBox == null) return;

                // If Enter is pressed in DistanceInput, trigger Drive_Click
                if (textBox.Name == "DistanceInput")
                {
                    Drive_Click(this, new RoutedEventArgs());
                }
                // If Enter is pressed in ColorInput or ModelInput, trigger SetCar_Click
                else if (textBox.Name == "ColorInput" || textBox.Name == "ModelInput")
                {
                    SetCar_Click(this, new RoutedEventArgs());
                }
            }
        }
    }
}
