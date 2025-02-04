﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TaxeLibrary.ViewModel
{
    public class VMCalculTaxe : INotifyPropertyChanged
    {
        private CalculTaxe _cTaxe = new CalculTaxe();

        private bool _entréeTTC;
        public bool EntréeTTC { 
            get 
            {return _entréeTTC;}

            set
            {
                if (this._entréeTTC != value)
                {
                    _entréeTTC = value;
                    NotifyPropertyChanged(nameof(PrixAffiché));
                    NotifyPropertyChanged(nameof(Taxe));
                }

            }
        }
        public string PrixEntré 
        {
            get 
            {
                if (_cTaxe.PrixHT == 0.0 && _cTaxe.PrixTTC == 0.0)
                {
                    return "";
                }
                else if (EntréeTTC)
                {
                    // prixTTC
                    return _cTaxe.PrixTTC.ToString();

                }
                else
                {
                    // pritHT
                    return _cTaxe.PrixHT.ToString();

                }
            }
            set
            {
                if (this.PrixEntré != value)
                {

                    if (!double.TryParse(value, out double numericValue))
                    {
                        value = "0";
                        
                    }
                    if (EntréeTTC)
                    {
                        // prixTTC
                        _cTaxe.PrixTTC = Convert.ToDouble(value);
                    }
                    else
                    {
                        // pritHT
                        _cTaxe.PrixHT = Convert.ToDouble(value);

                    }
                    NotifyPropertyChanged(nameof(Taxe));
                    NotifyPropertyChanged(nameof(PrixAffiché));
                    NotifyPropertyChanged(nameof(PrixEntré));

                }

            }
        }

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
                    NotifyPropertyChanged(nameof(Taxe));
                    NotifyPropertyChanged(nameof(PrixAffiché));
                }              
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

        public string PrixAffiché
        {
            get {
                string result = string.Format("{0:C}", _cTaxe.PrixTTC);
                return result;
            }
             private set{ }
        }

        public string Taxe
        {
            get
            {
                string result = string.Format("{0:C}", _cTaxe.Taxe);
                return result;
            }
            private set { }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string member = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(member));
        }

    }
}
