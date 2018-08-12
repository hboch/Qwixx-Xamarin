using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Qwixx
{
    public class QwixxBc
    {
        private Spielfeld _spielfeld;
        private Spielstand _spielstand;

        public QwixxBc()
        {
            _spielfeld = NeuesSpiel();
        }

        public Spielfeld NeuesSpiel()
        {
            //Spielfeld _spielfeld = new Spielfeld();

            _spielfeld = new Spielfeld();
            _spielstand = new Spielstand();

            return _spielfeld;
        }

        public Spielfeld SpielfarbeWurf(Spielfarbe spielfarbe, int augenZahl)
        {
            //Kreuze zu spielfarbe und wurf entsprechendes SpielfarbeAnkreuzFeld an
            int spielfarbeAnkreuzfeldIndex = ErmittleSpielfarbeAnkreuzfeldIndex(augenZahl);

            if (IstFeldAnkreuzbar(_spielfeld, spielfarbe, spielfarbeAnkreuzfeldIndex))
            {
                _spielfeld.AnkreuzFelderSpielfarbe[spielfarbe][spielfarbeAnkreuzfeldIndex].IstAngekreuzt = true;

                //Setzte alle SpielfarbeAnkreuzFelder links vom angekreuzten Feld auf nicht ankreuzbar
                for (int i = 0; i <= spielfarbeAnkreuzfeldIndex; i++)
                {
                    _spielfeld.AnkreuzFelderSpielfarbe[spielfarbe][i].IstNichtAnkreuzbar = true;
                }
            }
            return _spielfeld;
        }

        public bool IstFeldAnkreuzbar(Spielfeld spielfeld, Spielfarbe spielfarbe, int spielfarbeAnkreuzfeldIndex)
        {
            if (spielfeld.AnkreuzFelderSpielfarbe[spielfarbe][spielfarbeAnkreuzfeldIndex].IstAnkreuzbar)
            {
                if (spielfeld.AnkreuzFelderSpielfarbe[spielfarbe][spielfarbeAnkreuzfeldIndex].IstSchloss)
                {
                    if (spielfeld.AnkreuzFelderSpielfarbe[spielfarbe].Where(feld => feld.IstAngekreuzt).Count() >= 5)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public Spielfeld Fehlversuch(int feldIndex)
        {
            if (!_spielfeld.AnkreuzFelderFehlversuche[feldIndex].IstAngekreuzt)
            {
                _spielfeld.AnkreuzFelderFehlversuche[feldIndex].IstAngekreuzt = true;
            }
            return _spielfeld;
        }

        public int ErmittleSpielfarbeAnkreuzfeldIndex(int augenZahl)
        {
            int[] augenZahlZuIndex = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

            return Array.IndexOf(augenZahlZuIndex, augenZahl);
        }

        public Spielstand BerechneSpielstand()
        {
            Spielstand spielstand = _spielstand.SpielstandBerechnen(_spielfeld);
            return spielstand;
        }
    }
}
