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
            
            double principal = Convert.ToDouble(PrincipalEntry.Text);
            double annualInterestRate = Convert.ToDouble(InterestRateEntry.Text); 
            int months = Convert.ToInt32(MonthsEntry.Text); 

            
            double kkdf = 0;
            double bsmv = 0;

       
            switch (LoanTypePicker.SelectedItem.ToString())
            {
                case "Konut":
                    kkdf = 0;
                    bsmv = 0;
                    break;
                case "Ihtiyac":
                    kkdf = 0.15; 
                    bsmv = 0.16;
                    break;
                case "Ticari":
                    kkdf = 0.06; 
                    bsmv = 0.15; 
                    break;
                case "Taşıt":
                    kkdf = 0.15; 
                    bsmv = 0.05; 
                    break;
                default:
                    DisplayAlert("Hata", "Geçersiz kredi türü seçildi!", "Tamam");
                    return;
            }

           
            double monthlyInterestRate = annualInterestRate / 100 / 12;

            double brutFaiz = monthlyInterestRate * (1 + kkdf + bsmv);

          
            double monthlyPayment = (principal * brutFaiz) / (1 - Math.Pow(1 + brutFaiz, -months));

            
            double totalPayment = monthlyPayment * months;
            double totalInterest = totalPayment - principal;

            MonthlyPaymentLabel.Text = $"Aylık Taksit: {monthlyPayment.ToString("C")}";
            TotalPaymentLabel.Text = $"Toplam Ödeme: {totalPayment.ToString("C")}";
            TotalInterestLabel.Text = $"Toplam Faiz: {totalInterest.ToString("C")}";
        }
    }
}
