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

        // Slider değerleri değiştiğinde rengi güncelle
        private void ColorSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            // RGB değerlerini al
            int red = (int)RedSlider.Value;
            int green = (int)GreenSlider.Value;
            int blue = (int)BlueSlider.Value;

            // Renk kutusunu güncelle
            ColorBox.BackgroundColor = Color.FromRgb(red, green, blue);

            // Renk kodunu oluştur
            string renkKodu = $"#{red:X2}{green:X2}{blue:X2}";

            // Renk kodunu güncelle
            ColorCodeLabel.Text = $"Renk Kodu: {renkKodu}";
        }

        // Renk kodunu kopyala
        private async void CopyColorButton_Clicked(object sender, EventArgs e)
        {
            string renkKodu = ColorCodeLabel.Text;
            await Clipboard.SetTextAsync(renkKodu);
            await DisplayAlert("Kopyalandı", $"Renk kodu kopyalandı: {renkKodu}", "Tamam");
        }

        // Rastgele renk oluştur
        private void RandomColorButton_Clicked(object sender, EventArgs e)
        {
            Random random = new Random();
            int red = random.Next(0, 256);
            int green = random.Next(0, 256);
            int blue = random.Next(0, 256);

            // Slider değerlerini güncelle
            RedSlider.Value = red;
            GreenSlider.Value = green;
            BlueSlider.Value = blue;

            // Renk kutusunu güncelle
            ColorBox.BackgroundColor = Color.FromRgb(red, green, blue);

            // Renk kodunu oluştur
            string renkKodu = $"#{red:X2}{green:X2}{blue:X2}";
            ColorCodeLabel.Text = $"Renk Kodu: {renkKodu}";
        }
    }
}
