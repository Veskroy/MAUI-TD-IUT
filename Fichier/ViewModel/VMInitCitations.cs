using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fichier.ViewModel
{
    public class VMInitCitations : INotifyPropertyChanged
    {
        public MainPage? mainPage = null;
        public IList<VMCitation>? liste = null;
        public event PropertyChangedEventHandler? PropertyChanged;
        public string Count {
            get{
                if (liste == null)
                    return "???";
                else return liste.Count.ToString();
            }
            private set { } }
        public string ButtonText {
            get{
                if (liste == null)
                    return "Chargement des citations en cours…";
                else
                    return "Afficher les citations";
            }
            private set { } }
        public ICommand DisplayCommand { get; private set; }

        public VMInitCitations() 
        {
            DisplayCommand = new Command(DisplayListePage, CanDisplayListePage);
        }

        private void DisplayListePage()
        {
            if (mainPage != null)
                mainPage.DisplayListePage();
        }

        private bool CanDisplayListePage()
        {
            return liste != null;
        }

        private void NotifyPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public void Init(MainPage mainPage) 
        {
            this.mainPage = mainPage;
            Task.Run(() =>
            {
                this.liste = (Application.Current as App).Citations;
                NotifyPropertyChanged(nameof(Count));
                NotifyPropertyChanged(nameof(ButtonText));
                this.mainPage.Dispatcher.Dispatch(() =>
                {
                    (DisplayCommand as Command)?.ChangeCanExecute();
                });
            });
        }
    }
}
