using Fichier.ViewModel;

namespace Fichier
{
    public partial class MainPage : ContentPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();
            IList<VMCitation>? liste = (Application.Current as App)?.Citations;
            LblCount.Text = (liste is null ? "???" : liste.Count.ToString()) + " citations";
            BtnDisplay.Text = "Afficher les citations";
            BtnDisplay.IsEnabled = true;
        }
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnDisplay_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new ListePage());
        }
    }

}
