using System.Threading;
using System.Windows.Forms;

namespace Cyprom.PokemonMasterTrainer.UserInterface.Loading
{
    public partial class SplashScreen : Form
    {
        private static SplashScreen splash;

        private delegate void CloseDelegate();

        public SplashScreen()
        {
            InitializeComponent();
        }

        public static void Start()
        {
            if (splash == null)
            {
                var thread = new Thread(ShowForm) { IsBackground = true };
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
        }

        private static void ShowForm()
        {
            splash = new SplashScreen();
            Application.Run(splash);
        }

        public static void Stop()
        {
            splash.Invoke(new CloseDelegate(CloseFormInternal));
        }

        private static void CloseFormInternal()
        {
            splash.Close();
        }
    }
}
