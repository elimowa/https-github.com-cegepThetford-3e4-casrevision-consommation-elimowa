using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Consommation_Affaires;

namespace Consommation_Tests
{
    [TestClass()]
    public class UtilisationTests
    {
        Appareil app1, app2;
        Utilisation ampoule1, ampoule2, plinthe;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            app1 = new Appareil("Ampoule 100 Watts", 100);
            app2 = new Appareil("Plinthe chauffante", 1000);
            ampoule1 = new Utilisation(600, app1);
            ampoule2 = new Utilisation(90, app1);
            plinthe = new Utilisation(60, app2);
        }


        [TestMethod()]
        public void Utilisation_TestCreation()
        {
            Assert.AreEqual(10.0, ampoule1.NbHeures, 0.001);
            Assert.IsNotNull(ampoule1.Appareil);
            Assert.AreEqual(app1, ampoule1.Appareil);
        }

        [TestMethod()]
        public void Utilisation_TestCalculs()
        {
            Assert.AreEqual(1.0, ampoule1.calculerConsommation(), 0.001);
            Assert.AreEqual(0.15, ampoule2.calculerConsommation(), 0.001);
            Assert.AreEqual(1.0, plinthe.calculerConsommation(), 0.001);
        }
    }
}
