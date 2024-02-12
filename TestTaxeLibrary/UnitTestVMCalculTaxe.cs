using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private SortedSet<string> _properties;
        [TestInitialize]
        public void InitializeTest()
        {
            _properties = new SortedSet<string>();
        }
        private void PropertyChanged(object e, PropertyChangedEventArgs arg)
        {
            _properties.Add(arg.PropertyName);
        }
        [TestMethod]
        public void TestTauxTaxeNotifyPropertyChangedTauxTaxeAffiché()
        {
            VMCalculTaxe vm = new VMCalculTaxe();
            vm.PropertyChanged += PropertyChanged;
            vm.TauxTaxe = 20.4;
            Assert.IsTrue(_properties.Contains("TauxTaxeAffiché"),
            "La propriété TauxTaxe doit notifier le changement de la propriété TauxTaxeAffiché");
            _properties.Clear();
            vm.TauxTaxe = 20.4;
            Assert.IsFalse(_properties.Contains("TauxTaxeAffiché"),
            "Lorsque la valeur de TauxTaxe n'est pas modifiée, le setter ne doit pas notifier le changement de la propriété TauxTaxeAffiché");
        }

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
