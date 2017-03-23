using System;

namespace Cyprom.PokemonMasterTrainer.Domain
{
    public class BotEventArgs : EventArgs
    {
        public object Argument { get; set; }
    }
}
