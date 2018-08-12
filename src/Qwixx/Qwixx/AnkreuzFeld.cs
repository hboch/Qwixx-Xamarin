namespace Qwixx
{
    public class AnkreuzFeld
    {
        private bool _istAngekreuzt = false;
        public bool IstAngekreuzt
        {
            get { return _istAngekreuzt; }
            set { _istAngekreuzt = value; }
        }

        private bool _istNichtAnkreuzbar = false;
        public bool IstNichtAnkreuzbar
        {
            get { return _istNichtAnkreuzbar; }
            set { _istNichtAnkreuzbar = value; }
        }

        public bool IstAnkreuzbar => !IstNichtAnkreuzbar;
    }
}
