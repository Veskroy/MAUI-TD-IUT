using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxeLibrary.ViewModel
{
    internal class VMCalculTaxe
    {
        private CalculTaxe _cTaxe = new CalculTaxe();

        public double TauxTaxe;
        public string TauxTaxeAffichée
        {
            get
            {
                /*return (TauxTaxe * 100).ToString() string.Format()*/
            }
            private set
            {

            }
        }
    }
}
