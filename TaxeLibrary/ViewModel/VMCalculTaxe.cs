using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxeLibrary.ViewModel
{
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
    }
}
