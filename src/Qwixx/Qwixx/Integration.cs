namespace Qwixx
{
    /// <summary>
    /// Klasse zur Integration von UI und Business Logik
    /// </summary>
    public class Integration
    {
        //UI
        private readonly QwixxPage _qwixxPage;
        //Business Logik
        private readonly QwixxBc _qwixxBc;

        /// <summary>
        /// Integriert Business Logik und UI durch verknüpfen der UI-Events mit den zugehörigen Business Logik Funktionen
        /// </summary>
        /// <param name="qwixxpage"></param>
        /// <param name="qwixxBc"></param>
        public Integration(QwixxPage qwixxpage, QwixxBc qwixxBc)
        {
            _qwixxPage = qwixxpage;
            _qwixxBc = qwixxBc;

            //wenn ein Ankreuzfeld in Spielfarbe im UI gekreuzt wird
            _qwixxPage.Tapped += (spielfarbe, augenzahl) =>
            {
                Spielfeld spielfeld = _qwixxBc.SpielfarbeWurf(spielfarbe, augenzahl);
                _qwixxPage.SetzeSpielfeld(spielfeld);

            };

            //wenn ein Ankreuzfeld für einen Fehlversuch im UI gekreuzt wird
            _qwixxPage.TappedAnkreuzFeldFehlversuch  += (feldindex) =>
            {
                Spielfeld spielfeld = _qwixxBc.Fehlversuch(feldindex);
                _qwixxPage.SetzeSpielfeld(spielfeld);

            };

            //wenn Berechnen im UI angeklickt wird
            _qwixxPage.Berechne += () =>
            {
                Spielstand spielstand = _qwixxBc.BerechneSpielstand();
                _qwixxPage.SetzeSpielstand(spielstand);
            };

            //wenn Neues Spiel im UI angeklickt wird
            _qwixxPage.NeuesSpiel += () =>
            {
                Start();
            };
        }

        /// <summary>
        /// Startet ein neues Spiel mit leerem Spielstand in der Business Logik und aktualisiert das UI
        /// </summary>
        public void Start()
        {
            Spielfeld spielfeld = _qwixxBc.NeuesSpiel();
            _qwixxPage.SetzeSpielfeld(spielfeld);

            Spielstand spielstand = _qwixxBc.BerechneSpielstand();
            _qwixxPage.SetzeSpielstand(spielstand);
        }
    }
}
