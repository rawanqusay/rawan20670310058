using Microsoft.Maui.Controls;
using System;

namespace rawan20670310058
{
    public partial class RenkSecici : ContentPage
    {
        public RenkSecici()
        {
            InitializeComponent();
        }


        private void ColorSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            
            int red = (int)RedSlider.Value;
            int green = (int)GreenSlider.Value;
            int blue = (int)BlueSlider.Value;

            ColorBox.BackgroundColor = Color.FromRgb(red, green, blue);

    
            string renkKodu = $"#{red:X2}{green:X2}{blue:X2}";

            ColorCodeLabel.Text = $"Renk Kodu: {renkKodu}";
        }

        
        private async void CopyColorButton_Clicked(object sender, EventArgs e)
        {
            string renkKodu = ColorCodeLabel.Text;
            await Clipboard.SetTextAsync(renkKodu);
            await DisplayAlert("Kopyalandı", $"Renk kodu kopyalandı: {renkKodu}", "Tamam");
        }

        
        private void RandomColorButton_Clicked(object sender, EventArgs e)
        {
            Random random = new Random();
            int red = random.Next(0, 256);
            int green = random.Next(0, 256);
            int blue = random.Next(0, 256);

            
            RedSlider.Value = red;
            GreenSlider.Value = green;
            BlueSlider.Value = blue;

            ColorBox.BackgroundColor = Color.FromRgb(red, green, blue);

            
            string renkKodu = $"#{red:X2}{green:X2}{blue:X2}";
            ColorCodeLabel.Text = $"Renk Kodu: {renkKodu}";
        }
    }
}
