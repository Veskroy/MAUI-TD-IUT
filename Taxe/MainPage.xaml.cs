using Microsoft.Maui.Controls;
using System.Net;

namespace Taxe
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            entPrix.TextChanged += (sender, e) => calculer();
            slTauxTaxe.ValueChanged += (sender, e) => calculer();
        }

        private void calculer()
        {
            double tauxTaxe = slTauxTaxe.Value / 100.0;
            lblTauxTaxe.Text = slTauxTaxe.Value.ToString("F2")+" %";
            if (double.TryParse(entPrix.Text, out double prix))
            {
                if (!swTaxeIncluse.IsToggled)
                {
                    double taxe = prix * tauxTaxe;
                    lblTotal.Text = (prix + taxe).ToString("F2");
                    lblTaxe.Text = taxe.ToString("F2");
                }
                else
                {

                    lblTotal.Text = entPrix.Text;
                    lblTaxe.Text = (prix * tauxTaxe / (1 + tauxTaxe)).ToString("F2");
                }
            }     
        }

       /* private async void entPrix_TextChanged(object sender, TextChangedEventArgs e)
        {
        Autre Methode pour inplementer le textchange
        }*/
    }

}
