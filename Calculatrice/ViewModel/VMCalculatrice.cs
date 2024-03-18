using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CalculatriceLibrary;
using Calc = CalculatriceLibrary.Calculatrice;

namespace Calculatrice.ViewModel
{
    public class VMCalculatrice : INotifyPropertyChanged
    {
        private Calc calculatrice;
        public ICommand AddDigitCommand { get; set; }
        public ICommand AddOperatorCommand { get; set; }
        public ICommand ResetCommand { get; set; }
        public ICommand EqualCommand { get; set; }

        public double Résultat { get => calculatrice.Résultat; }
        public string Opérations { get => calculatrice.Opérations;}


        public VMCalculatrice() 
        {
            calculatrice = new Calc() ;
            AddDigitCommand = new Command<int>(AddDigit);
            AddOperatorCommand = new Command<string>(AddOperator);
            ResetCommand = new Command(Reset);
            EqualCommand = new Command(Equal);

        }

        public void AddDigit(int digit)
        {
            bool change = calculatrice.AddDigit(digit);
            if (change)
            {
                this.NotifyPropertyChanged(nameof(Opérations));
                this.NotifyPropertyChanged(nameof(Résultat));
            }
        }

        public void AddOperator(string @operator)
        {

            Opération operation;
            switch (@operator)
            {
                case "+":
                    operation = Opération.ADDITIONNER;
                    break;
                case "-":
                    operation = Opération.SOUSTRAIRE;
                    break;
                case "*":
                    operation = Opération.MULTIPLIER;
                    break;
                case "/":
                    operation = Opération.DIVISER;
                    break;
                default:
                    throw new ArgumentException("Opérateur non valide");
            }

            calculatrice.AddOperator(operation);
            this.NotifyPropertyChanged(nameof(Opérations));
        }

        public void Reset()
        {
            calculatrice.Reset();
            NotifyPropertyChanged(nameof(Opérations));
            this.NotifyPropertyChanged(nameof(Résultat));
        }

        public void Equal ()
        {
            calculatrice.Opérations = calculatrice.Résultat.ToString("F2",System.Globalization.CultureInfo.InvariantCulture);
            NotifyPropertyChanged(nameof(Opérations));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
