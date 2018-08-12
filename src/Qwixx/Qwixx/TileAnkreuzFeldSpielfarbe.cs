using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Qwixx
{
    public class TileAnkreuzFeldSpielfarbe
    {
        public readonly Spielfarbe Spielfarbe;
        public readonly int Augenzahl;

        public TileAnkreuzFeldSpielfarbe(AnkreuzFeldAugenzahl ankreuzFeldAugenzahl, Spielfarbe spielfarbe)
        {
            this.Augenzahl = ankreuzFeldAugenzahl.Augenzahl;
            this.Spielfarbe = spielfarbe;

            string textLabelX = "";
            string textLabel = ankreuzFeldAugenzahl.AnzeigeAugenZahl.ToString();

            if (ankreuzFeldAugenzahl.IstSchloss)
            {
                if (ankreuzFeldAugenzahl.IstAngekreuzt)
                {
                    textLabel = "\uD83D\uDD12";
                }
                else
                {
                    textLabel = "\uD83D\uDD13";
                }
            }

            Color labelTextColor = Color.Black;
            if (ankreuzFeldAugenzahl.IstAngekreuzt)
            {
                labelTextColor = Color.LightGray ;

                int anzahlZeichenAnzeigeAugenzahl = ankreuzFeldAugenzahl.AnzeigeAugenZahl.ToString().Length;
                int anzahlSpaces = (anzahlZeichenAnzeigeAugenzahl > 0) ? anzahlZeichenAnzeigeAugenzahl - 1 : 0;
                string spaces = new String(' ', anzahlSpaces);
                textLabelX = spaces + "X";
            }
            else if (ankreuzFeldAugenzahl.IstNichtAnkreuzbar)
            {
                //textLabel = "";
                labelTextColor = Color.LightGray;

                textLabelX = "";
            }
            Label label = new Label
            {
                Text = textLabel,
                TextColor = labelTextColor,
                BackgroundColor = Color.White,
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            };
            AbsoluteLayout.SetLayoutFlags(label, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(label,
                new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            Label labelX = new Label
            {
                Text = textLabelX,
                TextColor = Color.LightSlateGray,
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            };
            AbsoluteLayout.SetLayoutFlags(labelX, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(labelX,
                new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            Color backgroundColor = Color.White;
            if (spielfarbe == Spielfarbe.Rot) backgroundColor = Color.Red;
            if (spielfarbe == Spielfarbe.Gelb) backgroundColor = Color.Yellow;
            if (spielfarbe == Spielfarbe.Gruen) backgroundColor = Color.Green;
            if (spielfarbe == Spielfarbe.Blau) backgroundColor = Color.SkyBlue;

            TileContentView = new ContentView
            {
                //Padding = new Thickness(0, 0, 0, 0),
                //Margin = new Thickness(0, 0, 0, 0),
                //VerticalOptions = LayoutOptions.CenterAndExpand,
                //HorizontalOptions = LayoutOptions.CenterAndExpand,

                Content = new Frame
                {
                    BackgroundColor = backgroundColor,
                    Padding = new Thickness(5, 5, 5, 5),
                    //Margin = new Thickness(0, 0, 0, 0),
                    //VerticalOptions = LayoutOptions.Center,
                    //HorizontalOptions = LayoutOptions.Center,

                    Content = new AbsoluteLayout
                    {
                        Padding = new Thickness(0),
                        BackgroundColor = Color.White,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand,

                        Children = { label, labelX }
                    }
                }
            };
            // Don't let touch pass us by.
            TileContentView.BackgroundColor = Color.Transparent;

            // Add TileView to dictionary for obtaining Tile from TileView
            Dictionary.Add(TileContentView, this);
        }
        public static Dictionary<View, TileAnkreuzFeldSpielfarbe> Dictionary { get; } = new Dictionary<View, TileAnkreuzFeldSpielfarbe>();
        public View TileContentView { private set; get; }
    }
}