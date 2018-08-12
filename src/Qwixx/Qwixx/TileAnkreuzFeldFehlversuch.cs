using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Qwixx
{
    public class TileAnkreuzFeldFehlversuch
    {
        public readonly int FeldIndex;

        public TileAnkreuzFeldFehlversuch(int feldIndex, bool istAngekreuzt, bool istNichtAnkreuzbar)
        {
            FeldIndex = feldIndex;

            string textLabel = "";

            if (istAngekreuzt)
            {
                textLabel = "X";
            }

            Label label = new Label
            {
                Text = textLabel,
                BackgroundColor = Color.White,
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            };

            AbsoluteLayout.SetLayoutFlags(label, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(label,
                new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            TileContentView = new ContentView
            {
                Content = new Frame
                {
                    BackgroundColor = Color.LightGray,
                    Padding = new Thickness(5, 5, 5, 5),

                    Content = new AbsoluteLayout
                    {
                        Padding = new Thickness(0),
                        BackgroundColor = Color.White,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand,

                        Children = { label }
                    }
                }
            };
            // Don't let touch pass us by.
            TileContentView.BackgroundColor = Color.Transparent;

            // Add TileView to dictionary for obtaining Tile from TileView
            Dictionary.Add(TileContentView, this);
        }
        public static Dictionary<View, TileAnkreuzFeldFehlversuch> Dictionary { get; } = new Dictionary<View, TileAnkreuzFeldFehlversuch>();
        public View TileContentView { private set; get; }
    }
}