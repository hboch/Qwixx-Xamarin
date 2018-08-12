using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qwixx;

namespace Qwixx.Tests
{
    [TestClass]
    public class SpielfeldTests
    {
        [TestMethod]
        public void Konstruktor_Erzeugt_4_Farbige_Reihen_mit_12_Boxes_Und_Fehlversuche_Reihe_Mit_4_Boxes()
        {
            var spielfeld = new Spielfeld();

            Assert.AreEqual(4, spielfeld.AnkreuzFelderSpielfarbe.Count);

            Assert.AreEqual(12, spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot].GetLength(0));
            Assert.AreEqual(12, spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Gelb].GetLength(0));
            Assert.AreEqual(12, spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Gruen].GetLength(0));
            Assert.AreEqual(12, spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Blau].GetLength(0));

            Assert.IsInstanceOfType(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][0], typeof(AnkreuzFeldAugenzahl));
            Assert.IsInstanceOfType(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][10], typeof(AnkreuzFeldAugenzahl));
            Assert.IsInstanceOfType(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Gelb][1], typeof(AnkreuzFeldAugenzahl));
            Assert.IsInstanceOfType(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Gelb][9], typeof(AnkreuzFeldAugenzahl));
            Assert.IsInstanceOfType(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Gruen][2], typeof(AnkreuzFeldAugenzahl));
            Assert.IsInstanceOfType(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Gruen][8], typeof(AnkreuzFeldAugenzahl));
            Assert.IsInstanceOfType(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Blau][0], typeof(AnkreuzFeldAugenzahl));
            Assert.IsInstanceOfType(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Blau][10], typeof(AnkreuzFeldAugenzahl));

            Assert.IsFalse(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][10].IstSchloss, "Rot vorletztes Feld sollte IstSchloss=false sein");
            Assert.IsTrue(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][11].IstSchloss, "Rot letztes Feld sollte IstSchloss=true sein");
            Assert.IsTrue(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Gelb][11].IstSchloss, "Gelb letztes Feld sollte IstSchloss=true sein");
            Assert.IsTrue(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Gruen][11].IstSchloss, "Grün letztes Feld sollte IstSchloss=true sein");
            Assert.IsTrue(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Blau][11].IstSchloss, "Blau letztes Feld sollte IstSchloss=true sein");

            Assert.AreEqual(4, spielfeld.AnkreuzFelderFehlversuche.GetLength(0));
            Assert.IsInstanceOfType(spielfeld.AnkreuzFelderFehlversuche[0], typeof(AnkreuzFeld));
            Assert.IsInstanceOfType(spielfeld.AnkreuzFelderFehlversuche[3], typeof(AnkreuzFeld));
        }
        [TestMethod]
        public void ErmittleAnzeigeAugenzahl_When_Spielfarbe_Rot_Augenzahl_2_Returns_2()
        {
            //Arrange
            var spielfeld = new Spielfeld();

            //Act
            var result = spielfeld.ErmittleAnzeigeAugenzahl(Spielfarbe.Rot, 2, Spielfeld.AnzahlFelderJeSpielfarbe);

            //Assert
            Assert.AreEqual("2", result);
        }
        [TestMethod]
        public void ErmittleAnzeigeAugenzahl_When_Spielfarbe_Blau_Augenzahl_2_Returns_12()
        {
            //Arrange
            var spielfeld = new Spielfeld();

            //Act
            var result = spielfeld.ErmittleAnzeigeAugenzahl(Spielfarbe.Blau, 2, Spielfeld.AnzahlFelderJeSpielfarbe);
            //Assert
            Assert.AreEqual("12", result);

            //Act
            result = spielfeld.ErmittleAnzeigeAugenzahl(Spielfarbe.Blau, 6, Spielfeld.AnzahlFelderJeSpielfarbe);
            //Assert
            Assert.AreEqual("8", result);

            //Act
            result = spielfeld.ErmittleAnzeigeAugenzahl(Spielfarbe.Blau, 7, Spielfeld.AnzahlFelderJeSpielfarbe);
            //Assert
            Assert.AreEqual("7", result);

            //Act
            result = spielfeld.ErmittleAnzeigeAugenzahl(Spielfarbe.Blau, 8, Spielfeld.AnzahlFelderJeSpielfarbe);
            //Assert
            Assert.AreEqual("6", result);

            //Act
            result = spielfeld.ErmittleAnzeigeAugenzahl(Spielfarbe.Blau, 12, Spielfeld.AnzahlFelderJeSpielfarbe);
            //Assert
            Assert.AreEqual("2", result);
        }

    }

}
