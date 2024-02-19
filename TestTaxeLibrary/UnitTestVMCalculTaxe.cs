using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
            CultureInfo.CurrentCulture = new CultureInfo("fr-FR");
        }
        [DataTestMethod]
        [DataRow("45,789", "45,79", "45,79 €", "$45.79")]
        [DataRow("12", "12", "12,00 €", "$12.00")]
        public void TestPrixAffiché(string prix, string prixArrondi, string prixFr, string prixEn)
        {
            VMCalculTaxe vm = new VMCalculTaxe();
            vm.TauxTaxe = 0.0; // Pour simplifier les calculs
                               // On suppose que la propriété PrixEntrée fonctionne !!
            vm.PrixEntré = prix;
            Assert.AreEqual(prixArrondi, vm.PrixEntré, "Problème avec la propriété PrixEntrée ??");
            // Format Français
            CultureInfo culture = new CultureInfo("fr-FR");
            CultureInfo.CurrentCulture = culture;
            Assert.AreEqual(prixFr, vm.PrixAffiché, "Problème avec le format français de la devise");
            // Format Américain
            culture = new CultureInfo("en-US");
            CultureInfo.CurrentCulture = culture;
            Assert.AreEqual(prixEn, vm.PrixAffiché, "Problème avec le format américain de la devise");
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

        [TestMethod]
        public void TestPrixEntré()
        {
            VMCalculTaxe vm = new VMCalculTaxe();
            vm.PrixEntré = "145,1";
            Assert.AreEqual("145,1", vm.PrixEntré);
            vm.PrixEntré = "0,0";
            Assert.AreEqual("", vm.PrixEntré);
            vm.PrixEntré = "15,45a";
            Assert.AreEqual("", vm.PrixEntré);
        }
        [DataTestMethod]
        [DataRow("100", 20.9, "20,90 €", "$20.90")]
        [DataRow("10", 20.9, "2,09 €", "$2.09")]
        [DataRow("1", 20.9, "0,21 €", "$0.21")]
        public void TestTaxe(string prix, double tauxTaxe, string taxeFr, string taxeEn)
        {
            VMCalculTaxe vm = new VMCalculTaxe();
            vm.TauxTaxe = tauxTaxe;
            vm.PrixEntré = prix;
            Assert.AreEqual(prix, vm.PrixEntré, "Problème avec la propriété PrixEntrée ??");
            // Format Français

            CultureInfo culture = new CultureInfo("fr-FR");
            CultureInfo.CurrentCulture = culture;
            Assert.AreEqual(taxeFr, vm.Taxe, "Problème avec le format français de la taxe");
            // Format Américain
            culture = new CultureInfo("en-US");
            CultureInfo.CurrentCulture = culture;
            Assert.AreEqual(taxeEn, vm.Taxe, "Problème avec le format américain de la taxe");
        }

    }
}
