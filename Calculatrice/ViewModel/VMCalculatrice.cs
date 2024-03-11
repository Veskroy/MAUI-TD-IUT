using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CalculatriceLibrary;
using Calc = CalculatriceLibrary.Calculatrice;

namespace Calculatrice.ViewModel
{
    internal class VMCalculatrice : INotifyPropertyChanged
    {
        private Calc calculatrice;
        public double Résultat {  
            get
            {
                return calculatrice.Résultat;
            }
            private set
            {
                Résultat = calculatrice.Résultat;
            }
        }
        public string Opération {
            get
            {
                return calculatrice.Opérations;
            }
            private set
            {
                Opération = calculatrice.Opérations;
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand AddDigitCommand { get; set; }
        public ICommand AddOperatorCommand { get; set; }

        private void NotifyPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
