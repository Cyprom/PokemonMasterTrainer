using Cyprom.PokemonMasterTrainer.Domain;

namespace Cyprom.PokemonMasterTrainer.Data.Interfaces
{
    public interface IRepository
    {
        bool SaveGameAvailable();
        void Save(BoardState state);
        BoardState Load(bool updateFromDatabase);
        void ClearAll();
    }
}
