using System;
using System.Collections.Generic;
using System.Text;

namespace Qwixx
{
    public class Spielfeld
    {
        public const int AnzahlSpielfarben = 4;
        public const int AnzahlFelderJeSpielfarbe = 12;
        public const int AnzahlFelderFehlversuche = 4;
        public const int AugenzahlFeldSchloss = 13;

        public IDictionary<Spielfarbe, AnkreuzFeldAugenzahl[]> AnkreuzFelderSpielfarbe { get; }
        public AnkreuzFeld[] AnkreuzFelderFehlversuche { get; }

        public Spielfeld()
        {
            AnkreuzFelderSpielfarbe = new Dictionary<Spielfarbe, AnkreuzFeldAugenzahl[]>
            {
                [Spielfarbe.Rot] = new AnkreuzFeldAugenzahl[AnzahlFelderJeSpielfarbe],
                [Spielfarbe.Gelb] = new AnkreuzFeldAugenzahl[AnzahlFelderJeSpielfarbe],
                [Spielfarbe.Gruen] = new AnkreuzFeldAugenzahl[AnzahlFelderJeSpielfarbe],
                [Spielfarbe.Blau] = new AnkreuzFeldAugenzahl[AnzahlFelderJeSpielfarbe]
            };
            ErzeugeSpielfarbeAnkreuzFelder(Spielfarbe.Rot);
            ErzeugeSpielfarbeAnkreuzFelder(Spielfarbe.Gelb);
            ErzeugeSpielfarbeAnkreuzFelder(Spielfarbe.Gruen);
            ErzeugeSpielfarbeAnkreuzFelder(Spielfarbe.Blau);

            AnkreuzFelderFehlversuche = ErzeugeAnkreuzFelderFehlversuche();
        }

        private void ErzeugeSpielfarbeAnkreuzFelder(Spielfarbe spielfarbe)
        {
            int[] indexZuAugenZahl = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            int ankreuzFeldAugenzahlIndex;
            string anzeigeAugenZahl;

            for (int i = 0; i < AnzahlFelderJeSpielfarbe - 1; i++)
            {
                ankreuzFeldAugenzahlIndex = indexZuAugenZahl[i];
                anzeigeAugenZahl = ErmittleAnzeigeAugenzahl(spielfarbe, ankreuzFeldAugenzahlIndex, AnzahlFelderJeSpielfarbe);

                AnkreuzFelderSpielfarbe[spielfarbe][i] = new AnkreuzFeldAugenzahl(indexZuAugenZahl[i], anzeigeAugenZahl, istSchloss: false);
            }

            //Das letztes Feld jeder Reihe als Schloss markieren 
            anzeigeAugenZahl = ErmittleAnzeigeAugenzahl(spielfarbe, indexZuAugenZahl[AnzahlFelderJeSpielfarbe - 1], AnzahlFelderJeSpielfarbe);
            AnkreuzFelderSpielfarbe[spielfarbe][AnzahlFelderJeSpielfarbe - 1] = new AnkreuzFeldAugenzahl(indexZuAugenZahl[AnzahlFelderJeSpielfarbe - 1], anzeigeAugenZahl, istSchloss: true);
        }

        public string ErmittleAnzeigeAugenzahl(Spielfarbe spielfarbe, int ankreuzFeldAugenzahlIndex, int anzahlFelderJeSpielfarbe)
        {
            string anzeigeAugenZahl;
            if (spielfarbe == Spielfarbe.Gruen || spielfarbe == Spielfarbe.Blau)
            {
                int gedrehteAugenzahl = (Math.Abs(ankreuzFeldAugenzahlIndex - anzahlFelderJeSpielfarbe) + 2);
                anzeigeAugenZahl = gedrehteAugenzahl.ToString();
            }
            else
            {
                anzeigeAugenZahl = ankreuzFeldAugenzahlIndex.ToString();
            }

            return anzeigeAugenZahl;
        }

        private AnkreuzFeld[] ErzeugeAnkreuzFelderFehlversuche()
        {
            AnkreuzFeld[] ankreuzFelderFehlversuche;

            ankreuzFelderFehlversuche = new AnkreuzFeld[AnzahlFelderFehlversuche];

            for (int i = 0; i < AnzahlFelderFehlversuche; i++)
            {
                ankreuzFelderFehlversuche[i] = new AnkreuzFeld();
            }

            return ankreuzFelderFehlversuche;
        }
    }
}
