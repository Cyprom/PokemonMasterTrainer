using System;

namespace Cyprom.PokemonMasterTrainer.Data.DataObjects
{
    public class CatchSpaceData
    {
        public int Id { get; set; }
        public int AdjacentChip { get; set; }

        public CatchSpaceData(object id, object adjacentChip)
        {
            Id = (int)id;
            AdjacentChip = adjacentChip.GetType() != typeof(DBNull) ? (int)adjacentChip : -1;
        }
    }
}
