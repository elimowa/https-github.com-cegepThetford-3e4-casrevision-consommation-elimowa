using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Consommation_Affaires;
using System.Collections.Generic;

namespace Consommation_Tests
{
    [TestClass]
    public class ResidenceTests
    {
        Residence maison;
        Appareil ampoule, plinthe;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            maison = new Residence(0.0616m);
            ampoule = new Appareil("Ampoule 100 Watts", 100);
            plinthe = new Appareil("Plinthe chauffante", 1000);
            maison.ajouterUtilisation(600, ampoule);
            maison.ajouterUtilisation(90, plinthe);
        }

        [TestMethod]
        public void Residence_TestCreation()
        {
            Assert.AreEqual(0.0616m, maison.CoutKWh);
            Assert.AreEqual(2, maison.Utilisations.Count);
        }
        [TestMethod]
        public void Residence_TestCalculs()
        {
            Assert.AreEqual(2.5, maison.calculerConsommationTotale(), 0.001);
            Assert.AreEqual(0.154m, maison.calculerCoutConsommation());
        }
        [TestMethod]
        public void Residence_TestExtraction()
        {
            List<Appareil> extraction = maison.extraireAppareils(0.0);
            Assert.IsNotNull(extraction);
            Assert.AreEqual(2, extraction.Count);
            Assert.IsTrue(extraction.Contains(plinthe));
            Assert.IsTrue(extraction.Contains(ampoule));

            extraction = maison.extraireAppareils(1.25);
            Assert.IsNotNull(extraction);
            Assert.AreEqual(2, extraction.Count);
            Assert.IsTrue(extraction.Contains(plinthe));
            Assert.IsTrue(extraction.Contains(ampoule));

            extraction = maison.extraireAppareils(2.0);
            Assert.IsNotNull(extraction);
            Assert.AreEqual(1, extraction.Count);
            Assert.IsTrue(extraction.Contains(ampoule));

            extraction = maison.extraireAppareils(11.0);
            Assert.IsNotNull(extraction);
            Assert.AreEqual(0, extraction.Count);

            maison.ajouterUtilisation(60, plinthe);
            extraction = maison.extraireAppareils(1.0);
            Assert.IsNotNull(extraction);
            Assert.AreEqual(2, extraction.Count);
            Assert.IsTrue(extraction.Contains(ampoule));
            Assert.IsTrue(extraction.Contains(plinthe));

            extraction = maison.extraireAppareils(1.25);
            Assert.IsNotNull(extraction);
            Assert.AreEqual(2, extraction.Count);
            Assert.IsTrue(extraction.Contains(ampoule));
            Assert.IsTrue(extraction.Contains(plinthe));

            extraction = maison.extraireAppareils(0.5);
            Assert.IsNotNull(extraction);
            Assert.AreEqual(2, extraction.Count);
            Assert.IsTrue(extraction.Contains(ampoule));
            Assert.IsTrue(extraction.Contains(plinthe));

            extraction = maison.extraireAppareils(3);
            Assert.IsNotNull(extraction);
            Assert.AreEqual(1, extraction.Count);
            Assert.IsTrue(extraction.Contains(ampoule));
        }
    }
}
