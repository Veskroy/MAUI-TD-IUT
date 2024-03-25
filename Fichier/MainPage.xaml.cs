using Fichier.ViewModel;

namespace Fichier
{
    public partial class MainPage : ContentPage
    {
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            this.IsBusy = true;

            int? count = await Task<int?>.Run(() =>
            {
                return (Application.Current as App)?.Citations.Count;
            });

            LblCount.Text = count is null ? "???" : count.ToString() + " citations";
            BtnDisplay.IsEnabled = true;
            BtnDisplay.Text = "Afficher les citations";
            this.IsBusy = false;
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
