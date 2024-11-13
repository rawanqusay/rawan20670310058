namespace rawan20670310058;

public partial class VucutKitleIndexi : ContentPage
{
    public VucutKitleIndexi()
    {
        InitializeComponent();
    }

    private void CalculateButton_Clicked1(object sender, EventArgs e)
    {
        double weight = Convert.ToDouble(WeightEntry.Text);
        double height = Convert.ToDouble(HeightEntry.Text) / 100;

        double vki = weight / (height * height);

        string status;
        if (vki < 16)
            status = "İleri Düzeyde Zayıf";
        else if (vki >= 16 && vki <= 16.99)
            status = "Orta Düzeyde Zayıf";
        else if (vki >= 17 && vki <= 18.49)
            status = "Hafif Düzeyde Zayıf";
        else if (vki >= 18.50 && vki <= 24.9)
            status = "Normal Kilo";
        else if (vki >= 25 && vki <= 29.99)
            status = "Hafif Şişman / Fazla Kilolu";
        else if (vki >= 30 && vki <= 34.99)
            status = "1. Derecede Obez";
        else if (vki >= 35 && vki <= 39.99)
            status = "2. Derecede Obez";
        else
            status = "3. Derecede Obez";

        VkiLabel.Text = $"VKI: {vki:F2}";
        StatusLabel.Text = $"Durum: {status}";
    }

    private void WeightSlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        WeightEntry.Text = e.NewValue.ToString();
    }

    private void HeightSlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        HeightEntry.Text = e.NewValue.ToString();
    }

    private void WeightEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (double.TryParse(WeightEntry.Text, out double weight))
        {
            WeightSlider.Value = weight;
        }
    }

    private void HeightEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (double.TryParse(HeightEntry.Text, out double height))
        {
            HeightSlider.Value = height;
        }
    }
}
