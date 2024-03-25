using Fichier.ViewModel;

namespace Fichier
{
    public partial class App : Application
    {
        private readonly VMListCitations vmList = new VMListCitations();
        public IList<VMCitation> Citations {
            get
            { 
                return vmList.Citations;
            }
            private set { Citations = value; } }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }
    }
}
