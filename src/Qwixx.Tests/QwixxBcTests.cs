using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qwixx;

namespace Qwixx.Tests
{
    [TestClass]
    public class QwixxBcTests
    {
        [TestMethod]
        public void ErmittleSpielfarbeAnkreuzfeldIndex_When_Augenzahl_2_Returns_0()
        {
            //Arrange
            QwixxBc qwixxBc = new QwixxBc();
            //Act
            int result = qwixxBc.ErmittleSpielfarbeAnkreuzfeldIndex(2);
            //Assert
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void ErmittleSpielfarbeAnkreuzfeldIndex_When_Augenzahl_12_Returns_10()
        {
            //Arrange
            QwixxBc qwixxBc = new QwixxBc();
            //Act
            int result = qwixxBc.ErmittleSpielfarbeAnkreuzfeldIndex(12);
            //Assert
            Assert.AreEqual(10, result);
        }
        [TestMethod]
        public void ErmittleSpielfarbeAnkreuzfeldIndex_When_Augenzahl_13_Returns_11()
        {
            //Arrange
            QwixxBc qwixxBc = new QwixxBc();
            //Act
            int result = qwixxBc.ErmittleSpielfarbeAnkreuzfeldIndex(13);
            //Assert
            Assert.AreEqual(11, result);
        }
        [TestMethod]
        public void SpielfarbeWurf_When_Spielfarbe_Rot_Und_Augenzahl_12_Should_Set_AnkreuzFeld_IstAngekreuzt_True()
        {
            //Arrange
            QwixxBc qwixxBc = new QwixxBc();
            //Act
            Spielfeld spielfeld = qwixxBc.SpielfarbeWurf(Spielfarbe.Rot, 12);
            //Assert
            Assert.IsTrue(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][10].IstAngekreuzt);
        }
        [TestMethod]
        public void SpielfarbeWurf_When_Spielfarbe_Rot_Und_Augenzahl_6_Should_Set_AnkreuzFeld_Und_Felder_Links_Davon_IstNichtAngekreuzbar_True()
        {
            //Arrange
            QwixxBc qwixxBc = new QwixxBc();
            //Act
            Spielfeld spielfeld = qwixxBc.SpielfarbeWurf(Spielfarbe.Rot, 6);
            //Assert
            Assert.IsTrue(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][4].IstAngekreuzt, "Rot[4] IstAngekreuzt sollte true sein.");
            Assert.IsTrue(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][4].IstNichtAnkreuzbar, "Rot[4] IstNichtAnkreuzbar sollte true sein.");
            Assert.IsFalse(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][3].IstAngekreuzt, "Rot[3] IstAngekreuzt sollte false sein.");
            Assert.IsTrue(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][3].IstNichtAnkreuzbar, "Rot[3] IstNichtAnkreuzbar sollte true sein.");
            Assert.IsFalse(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][2].IstAngekreuzt, "Rot[2] IstAngekreuzt sollte false sein.");
            Assert.IsTrue(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][2].IstNichtAnkreuzbar, "Rot[2] IstNichtAnkreuzbar sollte true sein.");
            Assert.IsFalse(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][1].IstAngekreuzt, "Rot[1] IstAngekreuzt sollte false sein.");
            Assert.IsTrue(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][1].IstNichtAnkreuzbar, "Rot[1] IstNichtAnkreuzbar sollte true sein.");
            Assert.IsFalse(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][0].IstAngekreuzt, "Rot[0] IstAngekreuzt sollte false sein.");
            Assert.IsTrue(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][0].IstNichtAnkreuzbar, "Rot[0] IstNichtAnkreuzbar sollte true sein.");
        }
        [TestMethod]
        public void SpielfarbeWurf_When_Spielfarbe_Rot_Und_Augenzahl_3_Und_Augenzahl_6_Angekreuzt_Should_Nicht_Aendern_IstAngekreuzt_Oder_IstNichtAngekreuzbar()
        {
            //Arrange
            QwixxBc qwixxBc = new QwixxBc();
            //Act
            Spielfeld spielfeld = qwixxBc.SpielfarbeWurf(Spielfarbe.Rot, 6);
            spielfeld = qwixxBc.SpielfarbeWurf(Spielfarbe.Rot, 3);
            //Assert
            Assert.IsTrue(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][4].IstAngekreuzt, "Rot[4] IstAngekreuzt sollte true sein.");
            Assert.IsTrue(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][4].IstNichtAnkreuzbar, "Rot[4] IstNichtAnkreuzbar sollte true sein.");
            Assert.IsFalse(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][3].IstAngekreuzt, "Rot[3] IstAngekreuzt sollte false sein.");
            Assert.IsTrue(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][3].IstNichtAnkreuzbar, "Rot[3] IstNichtAnkreuzbar sollte true sein.");
            Assert.IsFalse(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][2].IstAngekreuzt, "Rot[2] IstAngekreuzt sollte false sein.");
            Assert.IsTrue(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][2].IstNichtAnkreuzbar, "Rot[2] IstNichtAnkreuzbar sollte true sein.");
            Assert.IsFalse(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][1].IstAngekreuzt, "Rot[1] IstAngekreuzt sollte false sein.");
            Assert.IsTrue(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][1].IstNichtAnkreuzbar, "Rot[1] IstNichtAnkreuzbar sollte true sein.");
            Assert.IsFalse(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][0].IstAngekreuzt, "Rot[0] IstAngekreuzt sollte false sein.");
            Assert.IsTrue(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][0].IstNichtAnkreuzbar, "Rot[0] IstNichtAnkreuzbar sollte true sein.");
        }
        [TestMethod]
        public void IstFeldAnkreuzbar_When_Neues_Spiel_Should_Alle_Felder_Ausser_Schloss_Ankreuzbar()
        {
            //Arrange
            QwixxBc qwixxBc = new QwixxBc();

            //Act
            Spielfeld spielfeld = qwixxBc.NeuesSpiel();

            //Assert
            //Alle Felder ausser dem Letzten (= Schloss Feld) sollten ankreuzbar sein:
            for (int i = 0; i < Spielfeld.AnzahlFelderJeSpielfarbe - 1; i++)
            {
                Assert.IsTrue(qwixxBc.IstFeldAnkreuzbar(spielfeld, Spielfarbe.Rot, i), "Rot[" + i.ToString() + "] sollte ankreuzbar sein.");
            }
            //Schloss Feld sollte nicht ankreuzbar sein:
            Assert.IsFalse(qwixxBc.IstFeldAnkreuzbar(spielfeld, Spielfarbe.Rot, Spielfeld.AnzahlFelderJeSpielfarbe - 1), "Rot[Schloss] sollte nicht ankreuzbar sein.");
        }
        [TestMethod]
        public void IstFeldAnkreuzbar_When_SpielfarbeWurf_Rot_6_Should_Felder_Nach_6_Ausser_Schloss_Ankreuzbar()
        {
            //Arrange
            QwixxBc qwixxBc = new QwixxBc();
            //Act
            Spielfeld spielfeld = qwixxBc.SpielfarbeWurf(Spielfarbe.Rot, 6);
            //spielfeld = qwixxBc.SpielfarbeWurf(Spielfarbe.Rot, 3);

            //Assert
            //Alle Felder ausser dem Letzten (= Schloss Feld) sollten ankreuzbar sein:
            for (int i = 5; i < Spielfeld.AnzahlFelderJeSpielfarbe - 1; i++)
            {
                Assert.IsTrue(qwixxBc.IstFeldAnkreuzbar(spielfeld, Spielfarbe.Rot, i), "Rot[" + i.ToString() + "] sollte ankreuzbar sein.");
            }
            //Alle Felder ausser dem Letzten (= Schloss Feld) sollten ankreuzbar sein:
            for (int i = 0; i < 5; i++)
            {
                Assert.IsFalse(qwixxBc.IstFeldAnkreuzbar(spielfeld, Spielfarbe.Rot, i), "Rot[" + i.ToString() + "] sollte nicht ankreuzbar sein.");
            }
            //Schloss Feld sollte nicht ankreuzbar sein:
            Assert.IsFalse(qwixxBc.IstFeldAnkreuzbar(spielfeld, Spielfarbe.Rot, Spielfeld.AnzahlFelderJeSpielfarbe - 1), "Rot[Schloss] sollte nicht ankreuzbar sein.");
        }
        [TestMethod]
        public void IstFeldAnkreuzbar_When_5_Kreuze_In_Einer_Farbreihe_Should_Feld_Schloss_Ankreuzbar()
        {
            //Arrange
            QwixxBc qwixxBc = new QwixxBc();
            //Act
            Spielfeld spielfeld = qwixxBc.SpielfarbeWurf(Spielfarbe.Rot, 3);
            spielfeld = qwixxBc.SpielfarbeWurf(Spielfarbe.Rot, 6);
            spielfeld = qwixxBc.SpielfarbeWurf(Spielfarbe.Rot, 7);
            spielfeld = qwixxBc.SpielfarbeWurf(Spielfarbe.Rot, 8);
            spielfeld = qwixxBc.SpielfarbeWurf(Spielfarbe.Rot, 9);

            //Assert
            //Schloss Feld sollte ankreuzbar sein:
            Assert.IsTrue(qwixxBc.IstFeldAnkreuzbar(spielfeld, Spielfarbe.Rot, Spielfeld.AnzahlFelderJeSpielfarbe - 1), "Rot[Schloss] sollte bei 5 Kreuzen ankreuzbar sein.");            
        }
        [TestMethod]
        public void IstFeldAnkreuzbar_When_Mehr_Als_5_Kreuze_In_Einer_Farbreihe_Should_Feld_Schloss_Ankreuzbar()
        {
            //Arrange
            QwixxBc qwixxBc = new QwixxBc();
            //Act
            Spielfeld spielfeld = qwixxBc.SpielfarbeWurf(Spielfarbe.Rot, 3);
            spielfeld = qwixxBc.SpielfarbeWurf(Spielfarbe.Rot, 6);
            spielfeld = qwixxBc.SpielfarbeWurf(Spielfarbe.Rot, 7);
            spielfeld = qwixxBc.SpielfarbeWurf(Spielfarbe.Rot, 8);
            spielfeld = qwixxBc.SpielfarbeWurf(Spielfarbe.Rot, 9);
            spielfeld = qwixxBc.SpielfarbeWurf(Spielfarbe.Rot, 10);

            //Assert
            //Schloss Feld sollte ankreuzbar sein:
            Assert.IsTrue(qwixxBc.IstFeldAnkreuzbar(spielfeld, Spielfarbe.Rot, Spielfeld.AnzahlFelderJeSpielfarbe - 1), "Rot[Schloss] sollte bei mehr als 5 Kreuzen ankreuzbar sein.");
        }
        [TestMethod]
        public void IstFeldAnkreuzbar_When_Mehr_Als_5_Kreuze_In_Einer_Farbreihe_Should_Feld_Schloss_In_Anderer_Farbreihe_Nicht_Ankreuzbar()
        {
            //Arrange
            QwixxBc qwixxBc = new QwixxBc();
            //Act
            Spielfeld spielfeld = qwixxBc.SpielfarbeWurf(Spielfarbe.Rot, 3);
            spielfeld = qwixxBc.SpielfarbeWurf(Spielfarbe.Rot, 6);
            spielfeld = qwixxBc.SpielfarbeWurf(Spielfarbe.Rot, 7);
            spielfeld = qwixxBc.SpielfarbeWurf(Spielfarbe.Rot, 8);
            spielfeld = qwixxBc.SpielfarbeWurf(Spielfarbe.Rot, 9);
            spielfeld = qwixxBc.SpielfarbeWurf(Spielfarbe.Rot, 10);

            //Assert
            //Schloss Feld sollte ankreuzbar sein:
            Assert.IsFalse(qwixxBc.IstFeldAnkreuzbar(spielfeld, Spielfarbe.Blau, Spielfeld.AnzahlFelderJeSpielfarbe - 1), "Blau[Schloss] sollte bei mehr als 5 roten Kreuzen nicht ankreuzbar sein.");
        }
        [TestMethod]
        public void NeuesSpiel_When_Vorher_Spielfarbe_Blau_Und_Augenzahl_6_Should_Set_IstAngekreutzt_Und_IstNichtAngekreuzbar_False()
        {
            //Arrange
            QwixxBc qwixxBc = new QwixxBc();
            //Act
            Spielfeld spielfeld = qwixxBc.SpielfarbeWurf(Spielfarbe.Gelb, 6);
            spielfeld = qwixxBc.NeuesSpiel();
            //Assert
            for (int i = 0; i < 11; i++)
            {
                Assert.IsFalse(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Gelb][i].IstAngekreuzt, "Gelb[" + i.ToString() + "] IstAngekreuzt sollte false sein.");
                Assert.IsFalse(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Gelb][i].IstNichtAnkreuzbar, "Gelb[" + i.ToString() + "] IstNichtAnkreuzbar sollte false sein.");
            }
        }
        [TestMethod]
        public void NeuesSpiel_When_Vorher_SpielfarbeWurf_Blau_Und_Augenzahl_6__Und_Nachher_Rot_Und_6_Should_Set_IstAngekreutzt_Und_IstNichtAngekreuzbar_Nur_Für_Rot()
        {
            //Arrange
            QwixxBc qwixxBc = new QwixxBc();
            //Act
            Spielfeld spielfeld = qwixxBc.SpielfarbeWurf(Spielfarbe.Gelb, 6);
            spielfeld = qwixxBc.NeuesSpiel();
            spielfeld = qwixxBc.SpielfarbeWurf(Spielfarbe.Rot, 6);
            //Assert
            //Für Gelb ist nichts gesetzt:
            for (int i = 0; i < 11; i++)
            {
                Assert.IsFalse(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Gelb][i].IstAngekreuzt, "Gelb[" + i.ToString() + "] IstAngekreuzt sollte false sein.");
                Assert.IsFalse(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Gelb][i].IstNichtAnkreuzbar, "Gelb[" + i.ToString() + "] IstNichtAnkreuzbar sollte false sein.");
            }

            //Für Rot ist teilweise gesetzt:
            Assert.IsTrue(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][4].IstAngekreuzt, "Rot[4] IstAngekreuzt sollte true sein.");
            Assert.IsTrue(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][4].IstNichtAnkreuzbar, "Rot[4] IstNichtAnkreuzbar sollte true sein.");
            Assert.IsFalse(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][3].IstAngekreuzt, "Rot[3] IstAngekreuzt sollte false sein.");
            Assert.IsTrue(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][3].IstNichtAnkreuzbar, "Rot[3] IstNichtAnkreuzbar sollte true sein.");
            Assert.IsFalse(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][2].IstAngekreuzt, "Rot[2] IstAngekreuzt sollte false sein.");
            Assert.IsTrue(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][2].IstNichtAnkreuzbar, "Rot[2] IstNichtAnkreuzbar sollte true sein.");
            Assert.IsFalse(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][1].IstAngekreuzt, "Rot[1] IstAngekreuzt sollte false sein.");
            Assert.IsTrue(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][1].IstNichtAnkreuzbar, "Rot[1] IstNichtAnkreuzbar sollte true sein.");
            Assert.IsFalse(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][0].IstAngekreuzt, "Rot[0] IstAngekreuzt sollte false sein.");
            Assert.IsTrue(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][0].IstNichtAnkreuzbar, "Rot[0] IstNichtAnkreuzbar sollte true sein.");
        }
        [TestMethod]
        public void NeuesSpiel_When_Vorher_Spielfarbe_Blau_Augenzahl_6_Und_1_Fehlversuch_Should_Set_IstAngekreutzt_Und_IstNichtAngekreuzbar_False()
        {
            //Arrange
            QwixxBc qwixxBc = new QwixxBc();
            //Act
            Spielfeld spielfeld = qwixxBc.SpielfarbeWurf(Spielfarbe.Gelb, 6);
            spielfeld = qwixxBc.Fehlversuch(0);
            spielfeld = qwixxBc.NeuesSpiel();
            //Assert
            for (int i = 0; i < 11; i++)
            {
                Assert.IsFalse(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Gelb][i].IstAngekreuzt, "Gelb[" + i.ToString() + "] IstAngekreuzt sollte false sein.");
                Assert.IsFalse(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Gelb][i].IstNichtAnkreuzbar, "Gelb[" + i.ToString() + "] IstNichtAnkreuzbar sollte false sein.");
            }
            for (int i = 0; i < 4; i++)
            {
                Assert.IsFalse(spielfeld.AnkreuzFelderFehlversuche[i].IstAngekreuzt, "Fehlversuch[" + i.ToString() + "] IstAngekreuzt sollte false sein.");
                Assert.IsFalse(spielfeld.AnkreuzFelderFehlversuche[i].IstNichtAnkreuzbar, "Fehlversuch[" + i.ToString() + "] IstNichtAnkreuzbar sollte false sein.");
            }
        }
        [TestMethod]
        public void NeuesSpiel_When_Vorher_Spielfarbe_Blau_Augenzahl_6_Und_2_Fehlversuche_Und_Nachher_1_Fehlversuch_Should_Set_IstAngekreutzt_Und_IstNichtAngekreuzbar_False()
        {
            //Arrange
            QwixxBc qwixxBc = new QwixxBc();
            //Act
            Spielfeld spielfeld = qwixxBc.SpielfarbeWurf(Spielfarbe.Gelb, 6);
            spielfeld = qwixxBc.Fehlversuch(0);
            spielfeld = qwixxBc.Fehlversuch(1);
            spielfeld = qwixxBc.NeuesSpiel();
            spielfeld = qwixxBc.Fehlversuch(0);
            //Assert
            for (int i = 0; i < 11; i++)
            {
                Assert.IsFalse(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Gelb][i].IstAngekreuzt, "Gelb[" + i.ToString() + "] IstAngekreuzt sollte false sein.");
                Assert.IsFalse(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Gelb][i].IstNichtAnkreuzbar, "Gelb[" + i.ToString() + "] IstNichtAnkreuzbar sollte false sein.");
            }
            for (int i = 1; i < 4; i++)
            {
                Assert.IsFalse(spielfeld.AnkreuzFelderFehlversuche[i].IstAngekreuzt, "Fehlversuch[" + i.ToString() + "] IstAngekreuzt sollte false sein.");
                Assert.IsFalse(spielfeld.AnkreuzFelderFehlversuche[i].IstNichtAnkreuzbar, "Fehlversuch[" + i.ToString() + "] IstNichtAnkreuzbar sollte false sein.");
            }
            Assert.IsTrue(spielfeld.AnkreuzFelderFehlversuche[0].IstAngekreuzt, "Fehlversuch[0] IstAngekreuzt sollte true sein.");
            Assert.IsFalse(spielfeld.AnkreuzFelderFehlversuche[0].IstNichtAnkreuzbar, "Fehlversuch[0] IstNichtAnkreuzbar sollte false sein.");
        }
        [TestMethod]
        public void Fehlversuch_When_Fehlversuch_FeldIndex_0_Should_Set_IstAngekreutzt_True()
        {
            //Arrange
            QwixxBc qwixxBc = new QwixxBc();
            //Act
            Spielfeld spielfeld = qwixxBc.Fehlversuch(0);
            //Assert
            for (int i = 0; i < 11; i++)
            {
                Assert.IsFalse(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][i].IstAngekreuzt, "Rot[" + i.ToString() + "] IstAngekreuzt sollte false sein.");
                Assert.IsFalse(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Gelb][i].IstAngekreuzt, "Gelb[" + i.ToString() + "] IstAngekreuzt sollte false sein.");
                Assert.IsFalse(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Rot][i].IstNichtAnkreuzbar, "Rot[" + i.ToString() + "] IstNichtAnkreuzbar sollte false sein.");
                Assert.IsFalse(spielfeld.AnkreuzFelderSpielfarbe[Spielfarbe.Gelb][i].IstNichtAnkreuzbar, "Gelb[" + i.ToString() + "] IstNichtAnkreuzbar sollte false sein.");
            }
            for (int i = 1; i < 4; i++)
            {
                Assert.IsFalse(spielfeld.AnkreuzFelderFehlversuche[i].IstAngekreuzt, "Fehlversuch[" + i.ToString() + "] IstAngekreuzt sollte false sein.");
                Assert.IsFalse(spielfeld.AnkreuzFelderFehlversuche[i].IstNichtAnkreuzbar, "Fehlversuch[" + i.ToString() + "] IstNichtAnkreuzbar sollte false sein.");
            }
            Assert.IsTrue(spielfeld.AnkreuzFelderFehlversuche[0].IstAngekreuzt, "Fehlversuch[0] IstAngekreuzt sollte true sein.");
            Assert.IsFalse(spielfeld.AnkreuzFelderFehlversuche[0].IstNichtAnkreuzbar, "Fehlversuch[0] IstNichtAnkreuzbar sollte false sein.");
        }


    }

}
