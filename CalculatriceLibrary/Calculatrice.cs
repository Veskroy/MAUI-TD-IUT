using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CalculatriceLibrary
{
    public class Calculatrice
    {
        public string Opérations { get;  private set; }
        public double Résultat { get; private set; }
        private Dictionary<Opération, string> dictionnaire;
        private bool _opérateur = false;
        private bool _unique_0 = true;
        public Calculatrice()
        {
            dictionnaire = new()
            {
                { Opération.ADDITIONNER, "+"},
                { Opération.MULTIPLIER, "*"},
                { Opération.DIVISER, "/"},
                { Opération.SOUSTRAIRE, "-"}
            };
            Opérations = "0";
            Résultat = 0.0;
        }

        public bool AddDigit(int digit)
        {
            if (digit < 0 || digit > 9)
            {
                throw new ArgumentOutOfRangeException($"{digit} n'est pas compris  entre 0 et 9 ");
            }
            if (digit == 0)
            {
                if (_opérateur == true)
                {
                    Opérations += "0";
                    _unique_0 = true;
                    _opérateur = false;
                    DataTable dta = new DataTable();
                    Résultat = double.Parse(dta.Compute(Opérations, null).ToString() ?? "0.0");
                    return true;
                }
                else if (_unique_0 == true)
                {
                    return false;
                }
                else
                {
                    Opérations += "0";
                    DataTable dta = new DataTable();
                    Résultat = double.Parse(dta.Compute(Opérations, null).ToString() ?? "0.0");
                    return true;
                }
            }
            if (_unique_0 == true)
            {
                Opérations = Opérations.Substring(0, Opérations.Length - 1) + digit.ToString();
            }
            else
            {
                Opérations += digit.ToString();
            }
            _opérateur = false;
            DataTable dt = new DataTable();
            Résultat = double.Parse(dt.Compute(Opérations,null).ToString() ?? "0.0");
            _unique_0 = false;
            return true;
        }
        public void AddOpérateur(Opération operateur) 
        {
            _unique_0 = false;
            if (_opérateur ==true)
            {
                Opérations = Opérations.Substring(0, Opérations.Length - 1) + dictionnaire[operateur];
            }
            else { Opérations += dictionnaire[operateur];
            }
            _opérateur = true;
               
        }

        public void Reset()
        {
            _opérateur = false;
            _unique_0 = true;
            Opérations = "0";
            Résultat = 0.0;
        }

      
    }

    public enum Opération
    {
        ADDITIONNER = 0,
        SOUSTRAIRE = 1, 
        MULTIPLIER = 2, 
        DIVISER = 3
    }
}
