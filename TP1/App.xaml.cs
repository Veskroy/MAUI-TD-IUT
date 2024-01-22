using System.Collections.ObjectModel;

namespace TP1
{
    public partial class App : Application
    {
        public static ObservableCollection<string> NumérosAppelés { get; set; } = new ObservableCollection<string>();
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
