using Cyprom.PokemonMasterTrainer.UserInterface.Loading;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Cyprom.PokemonMasterTrainer.UserInterface
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SplashScreen.Start();
            Thread.Sleep(1000);
            var home = new Home();
            SplashScreen.Stop();
            Application.Run(home);
        }
    }
}
