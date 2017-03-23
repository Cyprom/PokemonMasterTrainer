using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cyprom.PokemonMasterTrainer.Business.Managers;

namespace Cyprom.PokemonMasterTrainer.UserInterface.Helpers
{
    public static class MessageHelper
    {
        public static DialogResult ShowMessage(string message, string title, bool bot, MessageBoxButtons buttons = MessageBoxButtons.OK)
        {
            if (bot)
            {
                var parent = new Form();
                Task.Delay(TimeSpan.FromMilliseconds(ConfigurationManager.Instance().AISpeed)).ContinueWith(task => parent.Close(), TaskScheduler.FromCurrentSynchronizationContext());
                return MessageBox.Show(parent, message, title, buttons);
            }
            return MessageBox.Show(message, title, buttons);
        }
    }
}
