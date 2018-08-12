using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qwixx;

namespace Qwixx.Tests
{
    [TestClass]
    public class SpielstandTests
    {
        [TestMethod]
        public void SummeBerechnen_When_Spielfeld_Ohne_Kreuze_Should_Return_0()
        {
            //Arrange
            Spielfeld spielfeld = new Spielfeld();

            Spielstand spielstand = new Spielstand();

            //Act
            var result = spielstand.SummeBerechnen(spielfeld, Spielfarbe.Rot);

            //Assert
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void SummeBerechnen_When_Spielfeld_Mit_1_Kreuz_In_Reihe_Rot_Should_Return_1()
        {
            //Arrange
            Spielfeld spielfeld = new Spielfeld();
            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][2].IstAngekreuzt = true;

            Spielstand spielstand = new Spielstand();

            //Act
            var result = spielstand.SummeBerechnen(spielfeld, Spielfarbe.Rot);

            //Assert
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void SummeBerechnen_When_Spielfeld_Mit_2_Kreuzen_In_Reihe_Rot_Should_Return_3()
        {
            //Arrange
            Spielfeld spielfeld = new Spielfeld();
            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][0].IstAngekreuzt = true;
            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][2].IstAngekreuzt = true;

            Spielstand spielstand = new Spielstand();

            //Act
            var result = spielstand.SummeBerechnen(spielfeld, Spielfarbe.Rot);

            //Assert
            Assert.AreEqual(3, result);
        }
        [TestMethod]
        public void SummeBerechnen_When_Spielfeld_Mit_11_Kreuzen_In_Reihe_Blau_Should_Return_66()
        {
            //Arrange
            Spielfeld spielfeld = new Spielfeld();
            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Blau][0].IstAngekreuzt = true;
            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Blau][1].IstAngekreuzt = true;
            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Blau][2].IstAngekreuzt = true;
            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Blau][3].IstAngekreuzt = true;
            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Blau][4].IstAngekreuzt = true;
            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Blau][5].IstAngekreuzt = true;
            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Blau][6].IstAngekreuzt = true;
            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Blau][7].IstAngekreuzt = true;
            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Blau][8].IstAngekreuzt = true;
            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Blau][9].IstAngekreuzt = true;
            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Blau][10].IstAngekreuzt = true;

            Spielstand spielstand = new Spielstand();

            //Act
            var result = spielstand.SummeBerechnen(spielfeld, Spielfarbe.Blau);

            //Assert
            Assert.AreEqual(66, result);
        }
        [TestMethod]
        public void SpielstandBerechnen_When_Keine_Kreuze_Should_Return_Spielstand_Mit_Gesamtsumme_0()
        {
            //Arrange
            Spielfeld spielfeld = new Spielfeld();

            Spielstand spielstand = new Spielstand();

            //Act
            Spielstand result = spielstand.SpielstandBerechnen(spielfeld);

            //Assert
            Assert.AreEqual(0, result.SummeGesamt);
        }
        [TestMethod]
        public void SpielstandBerechnen_When_Spielfeld_Mit_4_Kreuzen_In_Reihe_Blau_Should_Return_Spielstand_Mit_Gesamtsumme_10()
        {
            //Arrange
            Spielfeld spielfeld = new Spielfeld();
            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Blau][1].IstAngekreuzt = true;
            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Blau][3].IstAngekreuzt = true;
            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Blau][5].IstAngekreuzt = true;
            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Blau][7].IstAngekreuzt = true;

            Spielstand spielstand = new Spielstand();

            //Act
            Spielstand result = spielstand.SpielstandBerechnen(spielfeld);

            //Assert
            Assert.AreEqual(10, result.SummeGesamt);
        }
        [TestMethod]
        public void SpielstandBerechnen_When_Spielfeld_Mit_4_Kreuzen_In_Jeder_Farbreihe_Should_Return_Spielstand_Mit_Gesamtsumme_40()
        {
            //Arrange
            Spielfeld spielfeld = new Spielfeld();
            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][1].IstAngekreuzt = true;
            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][3].IstAngekreuzt = true;
            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][5].IstAngekreuzt = true;
            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][7].IstAngekreuzt = true;

            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Gelb][1].IstAngekreuzt = true;
            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Gelb][3].IstAngekreuzt = true;
            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Gelb][5].IstAngekreuzt = true;
            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Gelb][7].IstAngekreuzt = true;

            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Gruen][1].IstAngekreuzt = true;
            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Gruen][3].IstAngekreuzt = true;
            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Gruen][5].IstAngekreuzt = true;
            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Gruen][7].IstAngekreuzt = true;

            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Blau][1].IstAngekreuzt = true;
            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Blau][3].IstAngekreuzt = true;
            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Blau][5].IstAngekreuzt = true;
            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Blau][7].IstAngekreuzt = true;

            Spielstand spielstand = new Spielstand();

            //Act
            Spielstand result = spielstand.SpielstandBerechnen(spielfeld);

            //Assert
            Assert.AreEqual(40, result.SummeGesamt);
        }
        [TestMethod]
        public void SpielstandBerechnen_When_Spielfeld_Mit_1_Kreuz_In_Jeder_Farbreihe_Und_2_Fehlversuchen_Should_Return_Spielstand_Mit_Gesamtsumme_Minus_6()
        {
            //Arrange
            Spielfeld spielfeld = new Spielfeld();
            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][1].IstAngekreuzt = true;
            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Gelb][3].IstAngekreuzt = true;
            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Gruen][5].IstAngekreuzt = true;
            spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Blau][7].IstAngekreuzt = true;

            spielfeld.AnkreuzFelderFehlversuche[1].IstAngekreuzt = true;
            spielfeld.AnkreuzFelderFehlversuche[3].IstAngekreuzt = true;

            Spielstand spielstand = new Spielstand();

            //Act
            Spielstand result = spielstand.SpielstandBerechnen(spielfeld);

            //Assert
            Assert.AreEqual(-6, result.SummeGesamt);
        }

    }
}