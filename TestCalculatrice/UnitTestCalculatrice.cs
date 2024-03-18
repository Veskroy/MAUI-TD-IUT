using CalculatriceLibrary;

namespace TestCalculatrice
{
    [TestClass]
    public class UnitTest1
    {
        public static Random RND = new();
        [TestMethod]
        public void TestOperandesThrowArgumentOutOfRange()
        {
            Calculatrice calc = new();
            calc.AddDigit(1);
            string res = "1";
            for (int _ = 0; _ < 100; ++_)
            {
                int v = RND.Next(-100, 100); // random
                if (v >= 0 && v <= 9)
                {
                    calc.AddDigit(v);
                    res += v.ToString();
                    Assert.AreEqual(res, calc.Opérations);
                }
                else
                {
                    Assert.ThrowsException<ArgumentOutOfRangeException>(() => { calc.AddDigit(v); });
                }
            }
        }
        [TestMethod]
        public void TestOperandes()
        {
            // tests aléatoires
            Calculatrice calc = new();
            for (int _ = 0; _ < 100; ++_)
            {
                calc.Reset();
                calc.AddDigit(0);
                Assert.IsTrue(Math.Abs(calc.Résultat) < 1e-5, $"Le résultat ({calc.Résultat}) devrait être nul !");
                Assert.AreEqual("0", calc.Opérations);
                calc.AddDigit(0);
                Assert.IsTrue(Math.Abs(calc.Résultat) < 1e-5, $"Le résultat ({calc.Résultat}) devrait être nul !");
                Assert.AreEqual("0", calc.Opérations);
                double res = 0.0;
                for (int __ = 0; __ < 5; __++)
                {
                    int digit = RND.Next(0, 10);
                    res = res * 10.0 + digit;
                    calc.AddDigit(digit);
                    Assert.IsTrue(Math.Abs(calc.Résultat - res) < 1e-5,
                     $"Le résultat {calc.Résultat} devrait être égal à {res}");
                    Assert.AreEqual(((int)res).ToString(), calc.Opérations);
                }
            }
        }

        [TestMethod]
        public void TestOperateurs()
        {
            // Premier test : 0 0 + 0 2 * 0 0 - 0 4
            // Test de la gestion des 0
            Calculatrice calc = new Calculatrice();
            Assert.IsFalse(calc.AddDigit(0));
            Assert.AreEqual("0", calc.Opérations);
            Assert.IsFalse(calc.AddDigit(0));
            Assert.AreEqual("0", calc.Opérations);
            calc.AddOperator(Opération.ADDITIONNER);
            Assert.AreEqual("0+", calc.Opérations);
            Assert.IsTrue(Math.Abs(calc.Résultat) < 1e-5, $"Le résultat {calc.Résultat} devrait être égal à 0");
            Assert.IsTrue(calc.AddDigit(0));
            Assert.AreEqual("0+0", calc.Opérations);
            Assert.IsTrue(Math.Abs(calc.Résultat) < 1e-5, $"Le résultat {calc.Résultat} devrait être égal à 0");
            Assert.IsTrue(calc.AddDigit(2));
            Assert.AreEqual("0+2", calc.Opérations);
            Assert.IsTrue(Math.Abs(calc.Résultat - 2) < 1e-5, $"Le résultat {calc.Résultat} devrait être égal à 2");
            calc.AddOperator(Opération.MULTIPLIER);
            Assert.AreEqual("0+2*", calc.Opérations);
            Assert.IsTrue(Math.Abs(calc.Résultat - 2) < 1e-5, $"Le résultat {calc.Résultat} devrait être égal à 2");
            Assert.IsTrue(calc.AddDigit(0));
            Assert.AreEqual("0+2*0", calc.Opérations);
            Assert.IsTrue(Math.Abs(calc.Résultat) < 1e-5, $"Le résultat {calc.Résultat} devrait être égal à 0");
            Assert.IsFalse(calc.AddDigit(0));
            Assert.AreEqual("0+2*0", calc.Opérations);
            Assert.IsTrue(Math.Abs(calc.Résultat) < 1e-5, $"Le résultat {calc.Résultat} devrait être égal à 0");
            calc.AddOperator(Opération.SOUSTRAIRE);
            Assert.AreEqual("0+2*0-", calc.Opérations);
            Assert.IsTrue(Math.Abs(calc.Résultat) < 1e-5, $"Le résultat {calc.Résultat} devrait être égal à 0");
            Assert.IsTrue(calc.AddDigit(0));
            Assert.AreEqual("0+2*0-0", calc.Opérations);
            Assert.IsTrue(Math.Abs(calc.Résultat) < 1e-5, $"Le résultat {calc.Résultat} devrait être égal à 0");
            Assert.IsTrue(calc.AddDigit(4));
            Assert.AreEqual("0+2*0-4", calc.Opérations);
            Assert.IsTrue(Math.Abs(calc.Résultat + 4) < 1e-5, $"Le résultat {calc.Résultat} devrait être égal à -4");
            calc.Reset();
            // Test de la gestion des opérateurs
            calc.AddDigit(5);
            calc.AddDigit(4);
            Assert.AreEqual("54", calc.Opérations);
            Assert.IsTrue(Math.Abs(calc.Résultat - 54) < 1e-5, $"Le résultat {calc.Résultat} devrait être égal à 54");
            calc.AddOperator(Opération.ADDITIONNER);
            Assert.AreEqual("54+", calc.Opérations);
            Assert.IsTrue(Math.Abs(calc.Résultat - 54) < 1e-5, $"Le résultat {calc.Résultat} devrait être égal à 54");
            calc.AddOperator(Opération.SOUSTRAIRE);
            Assert.AreEqual("54-", calc.Opérations);
            Assert.IsTrue(Math.Abs(calc.Résultat - 54) < 1e-5, $"Le résultat {calc.Résultat} devrait être égal à 54");
            calc.AddOperator(Opération.DIVISER);
            Assert.AreEqual("54/", calc.Opérations);
            Assert.IsTrue(Math.Abs(calc.Résultat - 54) < 1e-5, $"Le résultat {calc.Résultat} devrait être égal à 54");
            calc.AddOperator(Opération.MULTIPLIER);
            Assert.AreEqual("54*", calc.Opérations);
            Assert.IsTrue(Math.Abs(calc.Résultat - 54) < 1e-5, $"Le résultat {calc.Résultat} devrait être égal à 54");
            calc.AddOperator(Opération.MULTIPLIER);
            Assert.AreEqual("54*", calc.Opérations);
            Assert.IsTrue(Math.Abs(calc.Résultat - 54) < 1e-5, $"Le résultat {calc.Résultat} devrait être égal à 54");
        }

    }
}            