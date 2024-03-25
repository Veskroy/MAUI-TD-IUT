using Fichier.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fichier.ViewModel
{
    public class VMListCitations
    {
        private readonly ListCitations listCitations = new ListCitations();
        private ObservableCollection<VMCitation>? vmList = null;
        public IList<VMCitation> Citations { 
            get 
            { 
                if (vmList == null)
                {
                    vmList = new ObservableCollection<VMCitation>();
                    foreach (var cit in listCitations.Citations)
                    {
                        vmList.Add(new VMCitation(cit));
                    }
                }
                return vmList;
            } 
            private set { } 
        }
    }
}
