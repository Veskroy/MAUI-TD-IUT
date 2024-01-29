using System.Collections.ObjectModel;

namespace TP1
{
    public partial class App : Application
    {
        public static ObservableCollection<string> NumérosAppelés { get; set; } = new ObservableCollection<string>();
        public const string NUMEROS_APPELES = "numerosAppelés";

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnSleep()
        {
            string numerosConcatener = string.Join(";", NumérosAppelés);

            Preferences.Set(NUMEROS_APPELES, numerosConcatener);
        }

        protected override void OnStart()
        {
            if (Preferences.ContainsKey(NUMEROS_APPELES))
            {
                string numerosConcatener = Preferences.Get(NUMEROS_APPELES, string.Empty);

                string[] numerosArray = numerosConcatener.Split(';');

                foreach (string numero in numerosArray)
                {
                    NumérosAppelés.Add(numero);
                }
            }
        }
    }
}
