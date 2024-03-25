using Fichier.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fichier.ViewModel
{
    public class VMCitation
    {
        private readonly Citation Citation = new Citation();
        public string Auteur { 
            get 
            {
                return Citation.Auteur;
            } 
            set
            {
                if (Citation.Auteur != value)
                {
                    Citation.Auteur = value;
                    Auteur = value;
                }
            }
        }
        public String Texte {
            get
            {
                return Citation.Texte;
            }
            set
            {
                if (Citation.Texte != value)
                {
                    Citation.Texte = value;
                    Texte = value;
                }
            }
        }

        public VMCitation()
        {
            Auteur = "Albert Einstein";
            Texte = "Deux choses sont infinies : l'Univers et la bêtise humaine. Mais en ce qui concerne l'Univers, je n'en ai pas encore acquis la certitude absolue.";
        }

        public VMCitation(Citation Citation)
        {
            this.Citation = Citation;
        }
    }
}
