using System.Text.RegularExpressions;

namespace TP1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void entNuméro_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex exp = new Regex(@"0[1-9](\.?[0-9]{2}){4}");
            butAppeler.IsEnabled = exp.IsMatch(entNuméro.Text);
        }

        private async void butAppeler_Clicked(object sender, EventArgs e)
        {
            if (PhoneDialer.Default.IsSupported)
            {
                //(App.Current as App).NumérosAppelés.Add(entNuméro.Text);
                App.NumérosAppelés.Add(entNuméro.Text);
                PhoneDialer.Default.Open(entNuméro.Text);
            }
            else
            {
                await DisplayAlert("Interface manquante",
                "L'interface 'Appel téléphonique' n'est pas disponible sur cette plateforme", "Ok");
            }
        }
    }

}
