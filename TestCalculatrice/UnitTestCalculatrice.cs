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
                int v = RND.Next(0, 10); // random
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

    }
}            