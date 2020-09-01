using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Consommation_Affaires;

namespace Consommation_Tests
{
    [TestClass]
    public class AppareilTests
    {
        Appareil ampoule, plinthe;

        // Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            ampoule = new Appareil("Ampoule 100 Watts", 100);
            plinthe = new Appareil("Plinthe chauffante", 1000);
        }

        [TestMethod]
        public void Appareil_TestCreation()
        {
            Assert.AreEqual(100, ampoule.PuissanceWatts);
            Assert.AreEqual(1000, plinthe.PuissanceWatts);
            Assert.AreEqual("Ampoule 100 Watts", ampoule.Nom);
            Assert.AreEqual("Plinthe chauffante", plinthe.Nom);
        }

        [TestMethod]
        public void Appareil_TestCalculs()
        {
            Assert.AreEqual(0.1, ampoule.calculerPuissanceKW(), 0.001);
            Assert.AreEqual(1.0, plinthe.calculerPuissanceKW(), 0.001);
        }

    }
}
