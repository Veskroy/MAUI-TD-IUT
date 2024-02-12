using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TaxeLibrary.ViewModel
{
<<<<<<< HEAD
    public class VMCalculTaxe : INotifyPropertyChanged
    {
        private CalculTaxe _cTaxe = new CalculTaxe();

        public double TauxTaxe
        {
            get
            {
                return _cTaxe.TauxTaxe * 100;
            }
            set
            {
                double _v = value / 100;
                if (Math.Abs(_v - _cTaxe.TauxTaxe) > 1e-7)
                {
                    _cTaxe.TauxTaxe = _v;
                    NotifyPropertyChanged(nameof(TauxTaxeAffiché));
                }
=======
    public class VMCalculTaxe
    {
        private CalculTaxe _cTaxe = new CalculTaxe();

        public double TauxTaxe 
        {
            get
            {
                return _cTaxe.TauxTaxe*100;
            }
            set
            {
                _cTaxe.TauxTaxe = value/100;
               
>>>>>>> 11fc6e4e6755eb8666ea881c8dcf7152c2122c84
            }
        }
        public string TauxTaxeAffiché
        {
            get
            {
                string s = string.Format("{0:F2} %", TauxTaxe);
                return s;
            }
            private set
            {

            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string member = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(member));
        }

    }
}
