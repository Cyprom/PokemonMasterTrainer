namespace Cyprom.PokemonMasterTrainer.Domain
{
    public class EvolutionTree
    {
        public int Id { get; set; }
        public int First { get; set; }
        public int Second { get; set; }
        public int? Third { get; set; }

        public EvolutionTree(int id, int first, int second)
        {
            Id = id;
            First = first;
            Second = second;
        }

        public EvolutionTree(int id, int first, int second, int third) : this(id, first, second)
        {
            Third = third;
        }

        public int PlaceInTree(int number)
        {
            if (First == number)
            {
                return 1;
            }
            if (Second == number)
            {
                return 2;
            }
            if (Third != null && Third == number)
            {
                return 3;
            }
            return 0;
        }

        public int Size
        {
            get
            {
                return Third != null ? 3 : 2;
            }
        }
    }
}
