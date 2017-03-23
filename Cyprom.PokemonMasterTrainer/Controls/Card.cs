using System.Drawing;
using System.Windows.Forms;
using Cyprom.PokemonMasterTrainer.Enums;

namespace Cyprom.PokemonMasterTrainer.Controls
{
    public sealed class Card : TransparentControl
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Image Picture { get; set; }
        public DeckType DeckType { get; set; }
        public CardType CardType { get; set; }

        public Card(int id, string title, Image picture, DeckType deckType, CardType cardType)
        {
            Id = id;
            Title = title;
            Picture = picture;
            DeckType = deckType;
            CardType = cardType;
            Cursor = Cursors.Hand;
            Location = new Point(0, 0);
            Size = new Size(TechnicalConstants.CARD_WIDTH, TechnicalConstants.CARD_HEIGHT);
            Enabled = false;
        }

        protected override Image ImageToDraw()
        {
            return Picture;
        }

        // Id is the unique identifier for a card
        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
