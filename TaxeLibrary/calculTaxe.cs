using System;

namespace TaxeLibrary
{
    public class CalculTaxe
    {
        private double _tauxTaxe = 0.2;
        private double _taxe;
        private double _prixHT;
        private double _prixTTC;

        public double TauxTaxe
        {
            get { return _tauxTaxe; }
            set
            {
                if (Math.Abs(_tauxTaxe - value) > 1e-5)
                {
                    _taxe = Math.Round(value * _prixHT, 2);
                    _prixTTC = Math.Round(value + _taxe, 2);
                    _tauxTaxe = Math.Round(value, 4);
                }
            }
        }

        public double Taxe
        {
            get { return _taxe; }
            private set { _taxe = value; }
        }

        public double PrixHT
        {
            get { return _prixHT; }
            set
            {
                _prixHT = Math.Round(value, 2); 
                _taxe = Math.Round(_tauxTaxe * value, 2); 
                //_taxe = _tauxTaxe * value; 
                _prixTTC = Math.Round(value + _taxe, 2); 
            }
        }

        public double PrixTTC
        {
            get { return _prixTTC; }
            set
            {
                _prixTTC = Math.Round(value, 2); 
                _taxe = Math.Round(value * _tauxTaxe / (1 + _tauxTaxe), 2); 
                _prixHT = Math.Round(value - _taxe, 2); 
            }
        }
    }
}
