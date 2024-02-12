using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxeLibrary;
using TaxeLibrary.ViewModel;

namespace TestTaxeLibrary
{
    [TestClass]
    public class UnitTestVMCalculTaxe
    {
        [DataTestMethod]
        [DataRow(1.7523, "1,75 %")]
        [DataRow(22.3890, "22,39 %")]
        [DataRow(15.3, "15,30 %")]
        [DataRow(12.99890, "13,00 %")]
        public void TestTauxTaxe(double taxe, string affichage)
        {
            VMCalculTaxe vm = new VMCalculTaxe();
            vm.TauxTaxe = taxe;
            Assert.AreEqual(vm.TauxTaxeAffiché, affichage);
        }

    }
}
