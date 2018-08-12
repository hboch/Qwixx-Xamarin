//using System;
//using System.Collections.Generic;
//using System.Text;
//using Xamarin.Forms;

//namespace Qwixx
//{
//    public class ButtonAnkreuzFeldSpielfarbe : Button
//    {
//        public AnkreuzFeldAugenzahl AnkreuzFeldAugenzahl { get; private set; }
//        public Spielfarbe Spielfarbe { get; private set; }

//        public ButtonAnkreuzFeldSpielfarbe(AnkreuzFeldAugenzahl ankreuzFeldAugenzahl, Spielfarbe spielfarbe)
//        {
//            this.AnkreuzFeldAugenzahl = ankreuzFeldAugenzahl;
//            this.Spielfarbe = spielfarbe;
            
//            string textLabelX = "";
//            string textLabel = ankreuzFeldAugenzahl.AnzeigeAugenZahl.ToString();

//            if (ankreuzFeldAugenzahl.IstSchloss)
//            {
//                if (ankreuzFeldAugenzahl.IstAngekreuzt)
//                {
//                    textLabel = "\uD83D\uDD12";
//                }
//                else
//                {
//                    textLabel = "\uD83D\uDD13";
//                }
//            }

//            if (ankreuzFeldAugenzahl.IstAngekreuzt)
//            {
//                int anzahlZeichenAnzeigeAugenzahl = ankreuzFeldAugenzahl.AnzeigeAugenZahl.ToString().Length;
//                int anzahlSpaces = (anzahlZeichenAnzeigeAugenzahl > 0) ? anzahlZeichenAnzeigeAugenzahl - 1 : 0;
//                string spaces = new String(' ', anzahlSpaces);
//                textLabelX = spaces + "X";
//            }
//            else if (ankreuzFeldAugenzahl.IstNichtAnkreuzbar)
//            {
//                textLabel = "";
//                textLabelX = "";
//            }

//            Text = textLabel;
//            FontAttributes = FontAttributes.Bold;
//            //Margin = new Thickness(0, 0, 0, 0);
            

            
//            //Label labelX = new Label
//            //{
//            //    Text = textLabelX,
//            //    FontAttributes = FontAttributes.Bold,
//            //    TextColor = Color.SlateGray
//            //};

//            Color backgroundColor = Color.White;
//            if (spielfarbe == Spielfarbe.Rot) backgroundColor = Color.Red;
//            if (spielfarbe == Spielfarbe.Gelb) backgroundColor = Color.Yellow;
//            if (spielfarbe == Spielfarbe.Gruen) backgroundColor = Color.Green;
//            if (spielfarbe == Spielfarbe.Blau) backgroundColor = Color.SkyBlue;

//            BackgroundColor = backgroundColor;
//            //BorderColor = backgroundColor;
//            //BorderWidth = 5;
//            //BackgroundColor = Color.White;          
//            TextColor = Color.White;
//            Image = "cross-black.png";           
//        }
//    }
//}
