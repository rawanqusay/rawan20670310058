namespace rawan20670310058
{
    public partial class KrediHesaplama : ContentPage
    {
        public KrediHesaplama()
        {
            InitializeComponent();
        }

        private void HesaplamaButton_Clicked(object sender, EventArgs e)
        {
            // Kullanıcıdan alınan veriler
            double principal = Convert.ToDouble(PrincipalEntry.Text); // Kredi tutarı
            double annualInterestRate = Convert.ToDouble(InterestRateEntry.Text); // Yıllık faiz oranı
            int months = Convert.ToInt32(MonthsEntry.Text); // Vade (aylık)

            // KKDF ve BSMV oranları
            double kkdf = 0;
            double bsmv = 0;

            // Kredi türüne göre KKDF ve BSMV oranlarını belirleme
            switch (LoanTypePicker.SelectedItem.ToString())
            {
                case "Konut":
                    kkdf = 0;
                    bsmv = 0;
                    break;
                case "Ihtiyac":
                    kkdf = 0.15; // %15 KKDF
                    bsmv = 0.16; // %16 BSMV
                    break;
                case "Ticari":
                    kkdf = 0.06; // %6 KKDF
                    bsmv = 0.15; // %15 BSMV
                    break;
                case "Taşıt":
                    kkdf = 0.15; // %15 KKDF
                    bsmv = 0.05; // %5 BSMV
                    break;
                default:
                    DisplayAlert("Hata", "Geçersiz kredi türü seçildi!", "Tamam");
                    return;
            }

            // Yıllık faiz oranını aylık faiz oranına çevirme
            double monthlyInterestRate = annualInterestRate / 100 / 12;

            // Brüt faiz oranını hesaplama (KKDF ve BSMV dahil)
            double brutFaiz = monthlyInterestRate * (1 + kkdf + bsmv);

            // Aylık taksit hesaplama
            double monthlyPayment = (principal * brutFaiz) / (1 - Math.Pow(1 + brutFaiz, -months));

            // Toplam ödeme ve toplam faiz hesaplama
            double totalPayment = monthlyPayment * months;
            double totalInterest = totalPayment - principal;

            // Sonuçları ekranda gösterme
            MonthlyPaymentLabel.Text = $"Aylık Taksit: {monthlyPayment.ToString("C")}";
            TotalPaymentLabel.Text = $"Toplam Ödeme: {totalPayment.ToString("C")}";
            TotalInterestLabel.Text = $"Toplam Faiz: {totalInterest.ToString("C")}";
        }
    }
}
