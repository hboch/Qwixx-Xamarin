using Xamarin.Forms;

namespace Qwixx
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var qwixxPage = new QwixxPage();
            var qwixxBc = new QwixxBc();

            var integration = new Integration(qwixxPage, qwixxBc);
            integration.Start();

            MainPage = qwixxPage;

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
