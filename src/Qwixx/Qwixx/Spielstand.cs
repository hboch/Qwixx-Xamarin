using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Qwixx
{
    public class Spielstand
    {
        public int SummeRot { get; private set; }
        public int SummeGelb { get; private set; }
        public int SummeGruen { get; private set; }
        public int SummeBlau { get; private set; }
        public int SummeFehlversuche { get; private set; }
        public int SummeGesamt { get; private set; }

        public Spielstand SpielstandBerechnen(Spielfeld spielfeld)
        {
            Spielstand result = new Spielstand()
            {
                SummeRot = SummeBerechnen(spielfeld, Spielfarbe.Rot),
                SummeGelb = SummeBerechnen(spielfeld, Spielfarbe.Gelb),
                SummeGruen = SummeBerechnen(spielfeld, Spielfarbe.Gruen),
                SummeBlau = SummeBerechnen(spielfeld, Spielfarbe.Blau),
                SummeFehlversuche = SummeBerechnenFehlversuche(spielfeld)
            };

            //GesamtSumme ist die Summe aller Farben- und Fehlversuchsummen:
            result.SummeGesamt = result.SummeRot + result.SummeGelb + result.SummeGruen + result.SummeBlau - result.SummeFehlversuche;

            return result;
        }

        public int SummeBerechnen(Spielfeld spielfeld, Spielfarbe spielfarbe)
        {
            int[] anzahlKreuzeZuPunkten = { 0, 1, 3, 6, 10, 15, 21, 28, 36, 45, 55, 66, 78 };
            int result;

            int anzahlKreuze = spielfeld.AnkreuzFelderSpielfarbe[spielfarbe].Where((box) => box.IstAngekreuzt).Count();

            result = anzahlKreuzeZuPunkten[anzahlKreuze];
            return result;
        }

        public int SummeBerechnenFehlversuche(Spielfeld spielfeld)
        {
            int minusPunkteJeFehlversuch = 5;
            int result = 0;

            int anzahlKreuze = spielfeld.AnkreuzFelderFehlversuche.Where((box) => box.IstAngekreuzt).Count();

            result = minusPunkteJeFehlversuch * anzahlKreuze;
            return result;
        }
    }
}
