using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Cyprom.PokemonMasterTrainer.Domain;
using Cyprom.PokemonMasterTrainer.Enums;

namespace Cyprom.PokemonMasterTrainer.Controls
{
    public class Space : TransparentControl
    {
        private readonly Image picture;

        protected readonly List<Player> players;

        public int Id { get; set; }
        public SpaceType SpaceType { get; set; } 
        public Rarity Color { get; set; }
        public List<Space> Neighbors { get; set; }

        public int Population
        {
            get
            {
                return players.Count;
            }
        }

        public Space(int id, Image picture, SpaceType spaceType, Rarity color, int horizontalPosition, int verticalPosition)
        {
            Id = id;
            this.picture = picture;
            Location = new Point(horizontalPosition, verticalPosition);
            SpaceType = spaceType;
            players = new List<Player>();
            Color = color;
            Neighbors = new List<Space>();
            Size = new Size(TechnicalConstants.SPACE_SIZE, TechnicalConstants.SPACE_SIZE);
            Cursor = Cursors.Hand;
            Visible = false;
        }

        public List<Space> CalculateAvailableSpaces(int roll)
        {
            return CalculateAvailableSpaces(roll, this, null);
        }

        private static List<Space> CalculateAvailableSpaces(int roll, Space current, Space previous)
        {
            var neighbors = GetAllowedNeighbors(current, previous);
            if (neighbors.Count == 0)
            {
                return new List<Space> { current };
            }
            if (roll <= 1)
            {
                var next = new List<Space>();
                foreach (var neighbor in neighbors)
                {
                    if (neighbor.Population > 0 && !(neighbor is CityTown))
                    {
                        next.AddRange(CalculateAvailableSpaces(roll, neighbor, current));
                    }
                    else
                    {
                        next.Add(neighbor);
                    }
                }
                return next;
            }
            var further = new List<Space>();
            foreach (var neighbor in neighbors)
            {
                further.AddRange(CalculateAvailableSpaces(roll - 1, neighbor, current));
            }
            return further;
        }

        private static List<Space> GetAllowedNeighbors(Space current, Space previous)
        {
            var neighbors = current.Neighbors.ToList();
            if (previous != null)
            {
                neighbors.Remove(previous);
            }
            return neighbors;
        }

        public virtual void AddPlayer(Player player)
        {
            if (!players.Any())
            {
                players.Add(player);
                player.Trainer.Location = Location;
                player.Trainer.Refresh();
            }
        }

        public virtual void RemovePlayer(Player player)
        {
            players.Remove(player);
        }

        protected override Image ImageToDraw()
        {
            return picture;
        }

        // Id is the unique identifier for an elite
        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
