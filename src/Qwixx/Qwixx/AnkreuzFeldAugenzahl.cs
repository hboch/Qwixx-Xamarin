namespace Qwixx
{
    public class AnkreuzFeldAugenzahl : AnkreuzFeld
    {
        private int _augenzahl;
        public int Augenzahl
        {
            get { return _augenzahl; }
            private set { _augenzahl = value; }
        }

        private string _anzeigeAugenZahl;
        public string AnzeigeAugenZahl
        {
            get { return _anzeigeAugenZahl; }
            private set { _anzeigeAugenZahl = value; }
        }

        private bool _istSchloss;
        public bool IstSchloss
        {
            get { return _istSchloss; }
            private set { _istSchloss = value; }
        }

        public AnkreuzFeldAugenzahl(int augenZahl, string anzeigeAugenZahl, bool istSchloss)
        {
            Augenzahl = augenZahl;
            IstSchloss = istSchloss;
            AnzeigeAugenZahl = anzeigeAugenZahl;
        }
    }
}
