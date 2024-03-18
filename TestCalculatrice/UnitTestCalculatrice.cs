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
                    Assert.AreEqual(res, calc.Op�rations);
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
            // tests al�atoires
            Calculatrice calc = new();
            for (int _ = 0; _ < 100; ++_)
            {
                calc.Reset();
                calc.AddDigit(0);
                Assert.IsTrue(Math.Abs(calc.R�sultat) < 1e-5, $"Le r�sultat ({calc.R�sultat}) devrait �tre nul !");
                Assert.AreEqual("0", calc.Op�rations);
                calc.AddDigit(0);
                Assert.IsTrue(Math.Abs(calc.R�sultat) < 1e-5, $"Le r�sultat ({calc.R�sultat}) devrait �tre nul !");
                Assert.AreEqual("0", calc.Op�rations);
                double res = 0.0;
                for (int __ = 0; __ < 5; __++)
                {
                    int digit = RND.Next(0, 10);
                    res = res * 10.0 + digit;
                    calc.AddDigit(digit);
                    Assert.IsTrue(Math.Abs(calc.R�sultat - res) < 1e-5,
                     $"Le r�sultat {calc.R�sultat} devrait �tre �gal � {res}");
                    Assert.AreEqual(((int)res).ToString(), calc.Op�rations);
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
            Assert.AreEqual("0", calc.Op�rations);
            Assert.IsFalse(calc.AddDigit(0));
            Assert.AreEqual("0", calc.Op�rations);
            calc.AddOperator(Op�ration.ADDITIONNER);
            Assert.AreEqual("0+", calc.Op�rations);
            Assert.IsTrue(Math.Abs(calc.R�sultat) < 1e-5, $"Le r�sultat {calc.R�sultat} devrait �tre �gal � 0");
            Assert.IsTrue(calc.AddDigit(0));
            Assert.AreEqual("0+0", calc.Op�rations);
            Assert.IsTrue(Math.Abs(calc.R�sultat) < 1e-5, $"Le r�sultat {calc.R�sultat} devrait �tre �gal � 0");
            Assert.IsTrue(calc.AddDigit(2));
            Assert.AreEqual("0+2", calc.Op�rations);
            Assert.IsTrue(Math.Abs(calc.R�sultat - 2) < 1e-5, $"Le r�sultat {calc.R�sultat} devrait �tre �gal � 2");
            calc.AddOperator(Op�ration.MULTIPLIER);
            Assert.AreEqual("0+2*", calc.Op�rations);
            Assert.IsTrue(Math.Abs(calc.R�sultat - 2) < 1e-5, $"Le r�sultat {calc.R�sultat} devrait �tre �gal � 2");
            Assert.IsTrue(calc.AddDigit(0));
            Assert.AreEqual("0+2*0", calc.Op�rations);
            Assert.IsTrue(Math.Abs(calc.R�sultat) < 1e-5, $"Le r�sultat {calc.R�sultat} devrait �tre �gal � 0");
            Assert.IsFalse(calc.AddDigit(0));
            Assert.AreEqual("0+2*0", calc.Op�rations);
            Assert.IsTrue(Math.Abs(calc.R�sultat) < 1e-5, $"Le r�sultat {calc.R�sultat} devrait �tre �gal � 0");
            calc.AddOperator(Op�ration.SOUSTRAIRE);
            Assert.AreEqual("0+2*0-", calc.Op�rations);
            Assert.IsTrue(Math.Abs(calc.R�sultat) < 1e-5, $"Le r�sultat {calc.R�sultat} devrait �tre �gal � 0");
            Assert.IsTrue(calc.AddDigit(0));
            Assert.AreEqual("0+2*0-0", calc.Op�rations);
            Assert.IsTrue(Math.Abs(calc.R�sultat) < 1e-5, $"Le r�sultat {calc.R�sultat} devrait �tre �gal � 0");
            Assert.IsTrue(calc.AddDigit(4));
            Assert.AreEqual("0+2*0-4", calc.Op�rations);
            Assert.IsTrue(Math.Abs(calc.R�sultat + 4) < 1e-5, $"Le r�sultat {calc.R�sultat} devrait �tre �gal � -4");
            calc.Reset();
            // Test de la gestion des op�rateurs
            calc.AddDigit(5);
            calc.AddDigit(4);
            Assert.AreEqual("54", calc.Op�rations);
            Assert.IsTrue(Math.Abs(calc.R�sultat - 54) < 1e-5, $"Le r�sultat {calc.R�sultat} devrait �tre �gal � 54");
            calc.AddOperator(Op�ration.ADDITIONNER);
            Assert.AreEqual("54+", calc.Op�rations);
            Assert.IsTrue(Math.Abs(calc.R�sultat - 54) < 1e-5, $"Le r�sultat {calc.R�sultat} devrait �tre �gal � 54");
            calc.AddOperator(Op�ration.SOUSTRAIRE);
            Assert.AreEqual("54-", calc.Op�rations);
            Assert.IsTrue(Math.Abs(calc.R�sultat - 54) < 1e-5, $"Le r�sultat {calc.R�sultat} devrait �tre �gal � 54");
            calc.AddOperator(Op�ration.DIVISER);
            Assert.AreEqual("54/", calc.Op�rations);
            Assert.IsTrue(Math.Abs(calc.R�sultat - 54) < 1e-5, $"Le r�sultat {calc.R�sultat} devrait �tre �gal � 54");
            calc.AddOperator(Op�ration.MULTIPLIER);
            Assert.AreEqual("54*", calc.Op�rations);
            Assert.IsTrue(Math.Abs(calc.R�sultat - 54) < 1e-5, $"Le r�sultat {calc.R�sultat} devrait �tre �gal � 54");
            calc.AddOperator(Op�ration.MULTIPLIER);
            Assert.AreEqual("54*", calc.Op�rations);
            Assert.IsTrue(Math.Abs(calc.R�sultat - 54) < 1e-5, $"Le r�sultat {calc.R�sultat} devrait �tre �gal � 54");
        }

    }
}            