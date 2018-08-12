using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Qwixx
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QwixxPage : ContentPage
    {
        //Events zur Verarbeitung der UI-Aktionen in der Business Logik
        public event Action<Spielfarbe, int> Tapped;
        public event Action<int> TappedAnkreuzFeldFehlversuch;
        public event Action NeuesSpiel;
        public event Action Berechne;

        bool isBusy;

        public QwixxPage()
        {
            InitializeComponent();

            btnNeuesSpiel.Clicked += (o, e) => NeuesSpiel?.Invoke();
            btnBerechne.Clicked += (o, e) => Berechne?.Invoke();
            btnInfo.Clicked += OnInfoClicked;
        }

        /// <summary>
        /// Aktuelle Spielfeldinformationen in der UI darstellen
        /// </summary>
        /// <param name="spielfeld"></param>
        public void SetzeSpielfeld(Spielfeld spielfeld)
        {
            //Ankreuzfelder in Spielfarbe setzen
            int zeile = 0;
            foreach (var ankreuzFelderSpielfarbe in spielfeld.AnkreuzFelderSpielfarbe)
            {
                Spielfarbe spielfarbe = ankreuzFelderSpielfarbe.Key;

                int spalte = 0;
                foreach (var ankreuzFeld in ankreuzFelderSpielfarbe.Value)
                {
                    // Create the tile
                    TileAnkreuzFeldSpielfarbe tile = new TileAnkreuzFeldSpielfarbe(ankreuzFeld, spielfarbe);

                    // Add tap recognition.
                    TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += OnTileTappedAsync;
                    tile.TileContentView.GestureRecognizers.Add(tapGestureRecognizer);

                    gridAnkreuzFelderSpielfarben.Children.Add(tile.TileContentView, spalte, zeile);

                    spalte++;
                }
                zeile++;
            }

            //Ankreuzfelder der Fehlversuche setzen
            int spalteAnkreuzFeldFehlversuch = 0;
            foreach (var ankreuzFeld in spielfeld.AnkreuzFelderFehlversuche)
            {
                // Create the tile
                TileAnkreuzFeldFehlversuch tile = new TileAnkreuzFeldFehlversuch(spalteAnkreuzFeldFehlversuch, ankreuzFeld.IstAngekreuzt, ankreuzFeld.IstNichtAnkreuzbar);

                // Add tap recognition.
                TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += OnTileAnkreuzFeldFehlversuchTappedAsync;
                tile.TileContentView.GestureRecognizers.Add(tapGestureRecognizer);

                gridFehlversuche.Children.Add(tile.TileContentView, spalteAnkreuzFeldFehlversuch, 0);

                spalteAnkreuzFeldFehlversuch++;
            }
        }

        /// <summary>
        /// Setzt die Labels die den Spielstand anzeigen
        /// </summary>
        /// <param name="spielstand">enthält den aktuellen Spielstand</param>
        public void SetzeSpielstand(Spielstand spielstand)
        {
            SummeRot.Text = spielstand.SummeRot.ToString();
            SummeGelb.Text = spielstand.SummeGelb.ToString();
            SummeGruen.Text = spielstand.SummeGruen.ToString();
            SummeBlau.Text = spielstand.SummeBlau.ToString();
            SummeFehlversuche.Text = spielstand.SummeFehlversuche.ToString();
            SummeGesamt.Text = spielstand.SummeGesamt.ToString();
        }
        /// <summary>
        /// Eventverarbeitung wenn ein Ankreuzfeld in Spielfarbe getapped wurde
        /// </summary>
        /// <param name="sender">View der getapped wurde</param>
        /// <param name="e"></param>
        async void OnTileTappedAsync(object sender, EventArgs args)
        {
            if (isBusy)
                return;

            isBusy = true;

            //Ermitteln welches TileAnkreuzFeldSpielfarbe zum getappeden View gehört
            View tileView = (View)sender;
            TileAnkreuzFeldSpielfarbe tappedTile = TileAnkreuzFeldSpielfarbe.Dictionary[tileView];

            //Für User-Feedback Animation starten: Scale ContentView out and in
            await tappedTile.TileContentView.ScaleTo(1.5, 250, Easing.SinOut);
            await tappedTile.TileContentView.ScaleTo(1, 250, Easing.SinIn);

            Tapped?.Invoke(tappedTile.Spielfarbe, tappedTile.Augenzahl);

            isBusy = false;
        }
        /// <summary>
        /// Eventverarbeitung wenn ein Ankreuzfeld Fehlversuch getapped wurde
        /// </summary>
        /// <param name="sender">View der getapped wurde</param>
        /// <param name="e"></param>
        private async void OnTileAnkreuzFeldFehlversuchTappedAsync(object sender, EventArgs e)
        {
            if (isBusy)
                return;

            isBusy = true;

            //Ermitteln welches TileAnkreuzFeldFehlversuch zum getapped View gehört
            View tileView = (View)sender;
            TileAnkreuzFeldFehlversuch tappedTile = TileAnkreuzFeldFehlversuch.Dictionary[tileView];

            //Für User-Feedback Animation starten: Scale ContentView out and in
            await tappedTile.TileContentView.ScaleTo(1.5, 250, Easing.SinOut);
            await tappedTile.TileContentView.ScaleTo(1, 250, Easing.SinIn);

            //Ankreuzten des Feldes in der Business Logik verarbeiten
            TappedAnkreuzFeldFehlversuch?.Invoke(tappedTile.FeldIndex);

            isBusy = false;
        }

        /// <summary>
        /// Info Dialog anzeigen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void OnInfoClicked(object sender, EventArgs e)
        {
            //var action = await DisplayAlert("App-Info", "Elektronischer Spielblock für das Würfelspiel QWIXX", "OK");
            var action = await DisplayActionSheet("App-Info: Elektronischer Spielblock für das Würfelspiel QWIXX", "Schliessen", null, "", "Spielanleitung im Browser öffnen");
            if (action == "Spielanleitung im Browser öffnen")
            {
                Device.OpenUri(new Uri("https://www.brettspiele-magazin.de/qwixx/"));
            }
        }
    }
}