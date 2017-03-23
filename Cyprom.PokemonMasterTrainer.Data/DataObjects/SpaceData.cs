namespace Cyprom.PokemonMasterTrainer.Data.DataObjects
{
    public class SpaceData
    {
        public int Id { get; set; }
        public bool Visible { get; set; }

        public SpaceData(object id, object visible)
        {
            Id = (int)id;
            Visible = (bool)visible;
        }
    }
}
