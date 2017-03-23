using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using Cyprom.PokemonMasterTrainer.Controls;
using Cyprom.PokemonMasterTrainer.Data.DataObjects;
using Cyprom.PokemonMasterTrainer.Data.Helpers;
using Cyprom.PokemonMasterTrainer.Data.Interfaces;
using Cyprom.PokemonMasterTrainer.Data.Loaders;
using Cyprom.PokemonMasterTrainer.Data.Properties;
using Cyprom.PokemonMasterTrainer.Domain;
using Cyprom.PokemonMasterTrainer.Enums;

namespace Cyprom.PokemonMasterTrainer.Data
{
    public class GameRepository : IRepository
    {
        private static IRepository instance;

        public static IRepository Instance()
        {
            if (instance == null)
            {
                instance = new GameRepository();
            }
            return instance;
        }

        public bool SaveGameAvailable()
        {
            bool saveGameAvailable;
            using (var connection = new SqlCeConnection(Settings.Default.GameDatabaseConnectionString))
            {
                connection.Open();
                var command = new SqlCeCommand("SELECT COUNT(*) FROM BoardState", connection);
                saveGameAvailable = (int)command.ExecuteScalar() > 0;
                connection.Close();
            }
            return saveGameAvailable;
        }

        public void Save(BoardState state)
        {
            ClearAll();

            var chips = state.PinkChips.Concat(state.GreenChips).Concat(state.BlueChips).Concat(state.RedChips).Concat(state.YellowChips).ToList();

            using (var connection = new SqlCeConnection(Settings.Default.GameDatabaseConnectionString))
            {
                connection.Open();
                var command = new SqlCeCommand(QueryBuilder.BuildInsertBoardStateQuery(state), connection);
                command.Parameters.AddWithValue("Chips", string.Join(TechnicalConstants.LIST_DELIMITER.ToString(), chips.Select(chip => chip.Number)));
                command.Parameters.AddWithValue("Players", string.Join(TechnicalConstants.LIST_DELIMITER.ToString(), state.Players.Select(player => player.Name)));
                command.Parameters.AddWithValue("OrderOfPlay", string.Join(TechnicalConstants.LIST_DELIMITER.ToString(), state.OrderOfPlay.Select(order => order.Item1.Name + TechnicalConstants.TUPLE_DELIMITER + order.Item2)));
                if (state.InCatchProcess != null)
                {
                    command.Parameters.AddWithValue("InCatchProcess", state.InCatchProcess.Number);
                }
                if (state.BallToCatchWith != null)
                {
                    command.Parameters.AddWithValue("BallToCatchWith", state.BallToCatchWith.Id);
                }
                if (state.Challenger != null)
                {
                    command.Parameters.AddWithValue("Challenger", state.Challenger.Name);
                }
                if (state.Target != null)
                {
                    command.Parameters.AddWithValue("Target", state.Target.Name);
                }
                if (state.EliteTrainer != null)
                {
                    command.Parameters.AddWithValue("EliteTrainer", state.EliteTrainer.Trainer);
                }
                if (state.InBattle != null)
                {
                    command.Parameters.AddWithValue("InBattle", (state.InBattle.Item1.Number + TechnicalConstants.TUPLE_DELIMITER.ToString() + state.InBattle.Item2.Number));
                }
                command.Parameters.AddWithValue("ActivePlayerIndex", state.ActivePlayerIndex);
                command.Parameters.AddWithValue("TeamRocket", state.TeamRocket);
                command.Parameters.AddWithValue("FirstBonusUsed", state.FirstBonusUsed);
                command.Parameters.AddWithValue("Items", string.Join(TechnicalConstants.LIST_DELIMITER.ToString(), state.ItemCards.Select(card => card.Id)));
                command.Parameters.AddWithValue("Events", string.Join(TechnicalConstants.LIST_DELIMITER.ToString(), state.EventCards.Select(card => card.Id)));
                command.Parameters.AddWithValue("OnLoadMethod", state.OnLoadMethod);
                command.Parameters.AddWithValue("OnLoadMethodParameters", ObjectSerializer.Serialize(state.OnLoadMethodParameters));
                command.Parameters.AddWithValue("OnLoadMessage", state.OnLoadMessage);
                command.ExecuteNonQuery();
                connection.Close();
            }

            Save(chips);
            Save(state.Players);
            Save(state.Spaces);
        }

        private static void Save(IEnumerable<Player> players)
        {
            var chips = new List<Chip>();
            var trainers = new List<Trainer>();
            using (var connection = new SqlCeConnection(Settings.Default.GameDatabaseConnectionString))
            {
                connection.Open();
                foreach (var player in players)
                {
                    var command = new SqlCeCommand(QueryBuilder.BuildInsertPlayerQuery(player), connection);
                    command.Parameters.AddWithValue("Name", player.Name);
                    command.Parameters.AddWithValue("Trainer", player.Trainer.DefaultName);
                    command.Parameters.AddWithValue("Pokemon", string.Join(TechnicalConstants.LIST_DELIMITER.ToString(), player.Pokemon.Select(pokemon => pokemon.Number)));
                    command.Parameters.AddWithValue("Cards", string.Join(TechnicalConstants.LIST_DELIMITER.ToString(), player.Items.Select(item => item.Id)));
                    command.Parameters.AddWithValue("SortType", (int)player.SortType);
                    command.Parameters.AddWithValue("SortKey", (int)player.SortKey);
                    command.Parameters.AddWithValue("OnCinnabarIsland", player.OnCinnabarIsland);
                    command.Parameters.AddWithValue("UnderInvestigation", player.UnderInvestigation);
                    command.Parameters.AddWithValue("Flying", player.Flying);
                    if (player.ActivePokemon != null)
                    {
                        command.Parameters.AddWithValue("ActivePokemon", player.ActivePokemon.Number);
                    }
                    command.Parameters.AddWithValue("VisitedPlaces", string.Join(TechnicalConstants.LIST_DELIMITER.ToString(), player.VisitedPlaces.Select(space => space.Id)));
                    command.Parameters.AddWithValue("PlayerType", (int)player.PlayerType);
                    if (player.Space != null)
                    {
                        command.Parameters.AddWithValue("Space", player.Space.Id);
                    }
                    command.ExecuteNonQuery();
                    chips.AddRange(player.Pokemon);
                    trainers.Add(player.Trainer);
                }
                connection.Close();
            }
            Save(chips);
            Save(trainers);
        }

        private static void Save(IEnumerable<Chip> chips)
        {
            using (var connection = new SqlCeConnection(Settings.Default.GameDatabaseConnectionString))
            {
                connection.Open();
                foreach (var chip in chips)
                {
                    var command = new SqlCeCommand(QueryBuilder.BuildInsertChipQuery(chip), connection);
                    command.Parameters.AddWithValue("Number", chip.Number);
                    command.Parameters.AddWithValue("X", chip.Location.X);
                    command.Parameters.AddWithValue("Y", chip.Location.Y);
                    command.Parameters.AddWithValue("Flipped", chip.Flipped);
                    command.Parameters.AddWithValue("KnockedOut", chip.KnockedOut);
                    command.Parameters.AddWithValue("BonusDamage", chip.BonusDamage);
                    command.Parameters.AddWithValue("Enabled", chip.Clickable);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        private static void Save(IEnumerable<Space> spaces)
        {
            var adjacentChips = new List<Chip>();
            using (var connection = new SqlCeConnection(Settings.Default.GameDatabaseConnectionString))
            {
                connection.Open();

                foreach (var space in spaces)
                {
                    var command = new SqlCeCommand(QueryBuilder.BuildInsertSpaceQuery(space), connection);
                    command.Parameters.AddWithValue("Id", space.Id);
                    command.Parameters.AddWithValue("Visible", space.Visible);
                    command.ExecuteNonQuery();
                    
                    var catchSpace = space as CatchSpace;
                    if (catchSpace != null)
                    {
                        command = new SqlCeCommand(QueryBuilder.BuildInsertCatchSpaceQuery(catchSpace), connection);
                        command.Parameters.AddWithValue("Id", catchSpace.Id);
                        if (catchSpace.AdjacentChip != null)
                        {
                            command.Parameters.AddWithValue("AdjacentChip", catchSpace.AdjacentChip.Number);
                        }
                        command.ExecuteNonQuery();
                        if (catchSpace.AdjacentChip != null)
                        {
                            adjacentChips.Add(catchSpace.AdjacentChip);
                        }
                    }
                }
                connection.Close();
            }
            Save(adjacentChips);
        }

        private static void Save(IEnumerable<Trainer> trainers)
        {
            using (var connection = new SqlCeConnection(Settings.Default.GameDatabaseConnectionString))
            {
                connection.Open();
                foreach (var trainer in trainers)
                {
                    var command = new SqlCeCommand(QueryBuilder.BuildInsertTrainerQuery(trainer), connection);
                    command.Parameters.AddWithValue("DefaultName", trainer.DefaultName);
                    command.Parameters.AddWithValue("X", trainer.Location.X);
                    command.Parameters.AddWithValue("Y", trainer.Location.Y);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public BoardState Load(bool updateFromDatabase)
        {
            return updateFromDatabase ? LoadUpdatedBoardState() : LoadNewBoardState();
        }

        private static BoardState LoadNewBoardState()
        {
            var boardState = new BoardState
            {
                PinkChips = ChipLoader.LoadChips(Rarity.Pink),
                GreenChips = ChipLoader.LoadChips(Rarity.Green),
                BlueChips = ChipLoader.LoadChips(Rarity.Blue),
                RedChips = ChipLoader.LoadChips(Rarity.Red),
                YellowChips = ChipLoader.LoadChips(Rarity.Yellow),
                ItemCards = CardLoader.LoadItems(),
                EventCards = CardLoader.LoadEvents()
            };

            var spaceLoad = SpaceLoader.LoadSpaces();
            boardState.Spaces = spaceLoad.Item1;
            boardState.PalletTown = spaceLoad.Item2;
            boardState.CinnabarIsland = spaceLoad.Item3;
            boardState.IndigoArrival = spaceLoad.Item4;
            
            boardState.EliteTrainers = EliteLoader.LoadElites();

            return boardState;
        }

        private BoardState LoadUpdatedBoardState()
        {
            CardLoader.ResetIds();
            var chips = ChipLoader.LoadChips(Rarity.None);
            var spaces = SpaceLoader.LoadSpaces();
            var trainers = TrainerLoader.LoadTrainers();
            var items = CardLoader.LoadItems();
            var events = CardLoader.LoadEvents();
            var elites = EliteLoader.LoadElites();

            var boardStateData = LoadBoardState();
            var catchSpaceData = LoadCatchSpaces();
            var chipData = LoadChips();
            var playerData = LoadPlayers();
            var spaceData = LoadSpaces();
            var trainerData = LoadTrainers();

            UpdateTrainers(trainers, trainerData);
            UpdateChips(chips, chipData);
            UpdateSpaces(spaces, spaceData, catchSpaceData, chips);

            var players = CreatePlayers(playerData, trainers, chips, items, spaces.Item1);

            return CreateBoardState(boardStateData, chips, items, events, players, spaces, elites);
        }

        private static BoardStateData LoadBoardState()
        {
            BoardStateData saved;
            using (var connection = new SqlCeConnection(Settings.Default.GameDatabaseConnectionString))
            {
                connection.Open();
                var command = new SqlCeCommand("SELECT TOP 1 * FROM BoardState", connection);
                var reader = command.ExecuteReader();
                reader.Read();
                saved = new BoardStateData(
                    reader["Players"],
                    reader["OrderOfPlay"],
                    reader["InCatchProcess"],
                    reader["BallToCatchWith"],
                    reader["Challenger"],
                    reader["Target"],
                    reader["EliteTrainer"],
                    reader["InBattle"],
                    reader["ActivePlayerIndex"],
                    reader["TeamRocket"],
                    reader["FirstBonusUsed"],
                    reader["Chips"],
                    reader["Items"],
                    reader["Events"],
                    reader["OnLoadMethod"],
                    reader["OnLoadMethodParameters"],
                    reader["OnLoadMessage"]);
                connection.Close();
            }
            return saved;
        }

        private static List<PlayerData> LoadPlayers()
        {
            var saved = new List<PlayerData>();
            using (var connection = new SqlCeConnection(Settings.Default.GameDatabaseConnectionString))
            {
                connection.Open();
                var command = new SqlCeCommand("SELECT * FROM Player", connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    saved.Add(new PlayerData(
                        reader["Name"],
                        reader["Trainer"],
                        reader["Pokemon"],
                        reader["Cards"],
                        reader["SortType"],
                        reader["SortKey"],
                        reader["OnCinnabarIsland"],
                        reader["UnderInvestigation"],
                        reader["Flying"],
                        reader["ActivePokemon"],
                        reader["VisitedPlaces"],
                        reader["PlayerType"],
                        reader["Space"]));
                }
                connection.Close();
            }
            return saved;
        }

        private static List<ChipData> LoadChips()
        {
            var saved = new List<ChipData>();
            using (var connection = new SqlCeConnection(Settings.Default.GameDatabaseConnectionString))
            {
                connection.Open();
                var command = new SqlCeCommand("SELECT * FROM Chip", connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    saved.Add(new ChipData(
                        reader["Number"],
                        reader["X"],
                        reader["Y"],
                        reader["Flipped"],
                        reader["KnockedOut"],
                        reader["BonusDamage"],
                        reader["Enabled"]));
                }
                connection.Close();
            }
            return saved;
        }

        private static List<SpaceData> LoadSpaces()
        {
            var saved = new List<SpaceData>();
            using (var connection = new SqlCeConnection(Settings.Default.GameDatabaseConnectionString))
            {
                connection.Open();
                var command = new SqlCeCommand("SELECT * FROM Space", connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    saved.Add(new SpaceData(
                        reader["Id"],
                        reader["Visible"]));
                }
                connection.Close();
            }
            return saved;
        }

        public List<CatchSpaceData> LoadCatchSpaces()
        {
            var saved = new List<CatchSpaceData>();
            using (var connection = new SqlCeConnection(Settings.Default.GameDatabaseConnectionString))
            {
                connection.Open();
                var command = new SqlCeCommand("SELECT * FROM CatchSpace", connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    saved.Add(new CatchSpaceData(
                        reader["Id"],
                        reader["AdjacentChip"]));
                }
                connection.Close();
            }
            return saved;
        }

        private static List<TrainerData> LoadTrainers()
        {
            var saved = new List<TrainerData>();
            using (var connection = new SqlCeConnection(Settings.Default.GameDatabaseConnectionString))
            {
                connection.Open();
                var command = new SqlCeCommand("SELECT * FROM Trainer", connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    saved.Add(new TrainerData(
                        reader["DefaultName"],
                        reader["X"],
                        reader["Y"]));
                }
                connection.Close();
            }
            return saved;
        }

        private static BoardState CreateBoardState(BoardStateData boardStateData, List<Chip> chips, List<Card> items, IEnumerable<Card> events,
            List<Player> players, Tuple<List<Space>, Space, Space, Space> spaces, List<Elite> eliteTrainers)
        {
            var boardChips = boardStateData.Chips.Select(saved => chips.Single(chip => chip.Number == saved)).ToList();
            var state = new BoardState
            {
                PinkChips = boardChips.Where(chip => chip.Rarity == Rarity.Pink).ToList(),
                GreenChips = boardChips.Where(chip => chip.Rarity == Rarity.Green).ToList(),
                BlueChips = boardChips.Where(chip => chip.Rarity == Rarity.Blue).ToList(),
                RedChips = boardChips.Where(chip => chip.Rarity == Rarity.Red).ToList(),
                YellowChips = boardChips.Where(chip => chip.Rarity == Rarity.Yellow).ToList(),
                ItemCards = boardStateData.Items.Select(saved => items.Single(card => card.Id == saved)).ToList(),
                EventCards = boardStateData.Events.Select(saved => events.Single(card => card.Id == saved)).ToList(),
                Players = boardStateData.Players.Select(saved => players.Single(player => player.Name == saved)).ToList(),
                EliteTrainers = eliteTrainers,
                Spaces = spaces.Item1,
                PalletTown = spaces.Item2,
                CinnabarIsland = spaces.Item3,
                IndigoArrival = spaces.Item4,
                OrderOfPlay = boardStateData.OrderOfPlay.Select(tuple => new Tuple<Player, int>(players.Single(player => player.Name == tuple.Item1), tuple.Item2)).ToList(),
                InCatchProcess = chips.SingleOrDefault(chip => chip.Number == boardStateData.InCatchProcess),
                BallToCatchWith = items.SingleOrDefault(item => item.Id == boardStateData.BallToCatchWith),
                Challenger = players.SingleOrDefault(player => player.Name == boardStateData.Challenger),
                Target = players.SingleOrDefault(player => player.Name == boardStateData.Target),
                EliteTrainer = eliteTrainers.SingleOrDefault(elite => elite.Trainer == boardStateData.EliteTrainer),
                InBattle = boardStateData.InBattle != null ? new Tuple<Chip, Chip>(chips.SingleOrDefault(chip => chip.Number == boardStateData.InBattle.Item1), chips.SingleOrDefault(chip => chip.Number == boardStateData.InBattle.Item2)) : null,
                ActivePlayerIndex = boardStateData.ActivePlayerIndex,
                TeamRocket = boardStateData.TeamRocket,
                FirstBonusUsed = boardStateData.FirstBonusUsed,
                GameStarted = true,
                OnLoadMethod = boardStateData.OnLoadMethod,
                OnLoadMethodParameters = ObjectSerializer.Deserialize(boardStateData.OnLoadMethodParameters, players, chips, items, eliteTrainers),
                OnLoadMessage = boardStateData.OnLoadMessage
            };
            if (state.EliteTrainer != null)
            {
                state.EliteTrainers.Remove(state.EliteTrainer);
                state.EliteTrainers.Insert(0, state.EliteTrainer);
            }
            return state;
        }

        public List<Player> CreatePlayers(List<PlayerData> playerData, List<Trainer> trainers, List<Chip> chips, List<Card> items, List<Space> spaces)
        {
            return playerData.Select(saved => new Player(saved.Name, saved.PlayerType, trainers.Single(trainer => trainer.DefaultName == saved.Trainer))
            {
                Pokemon = chips.Where(chip => saved.Pokemon.Contains(chip.Number)).ToList(),
                Items = items.Where(item => saved.Cards.Contains(item.Id)).ToList(),
                SortKey = saved.SortKey,
                SortType = saved.SortType,
                OnCinnabarIsland = saved.OnCinnabarIsland,
                UnderInvestigation = saved.UnderInvestigation,
                Flying = saved.Flying,
                ActivePokemon = chips.SingleOrDefault(chip => chip.Number == saved.ActivePokemon),
                VisitedPlaces = spaces.Where(space => saved.VisitedPlaces.Contains(space.Id)).Select(space => space as CityTown).ToList(),
                Space = spaces.SingleOrDefault(space => space.Id == saved.Space)
            }).ToList();
        }

        private static void UpdateChips(IEnumerable<Chip> chips, List<ChipData> chipData)
        {
            foreach (var chip in chips)
            {
                var saved = chipData.SingleOrDefault(data => data.Number == chip.Number);
                if (saved != null)
                {
                    chip.Location = saved.Location;
                    chip.Flipped = saved.Flipped;
                    chip.KnockedOut = saved.KnockedOut;
                    chip.BonusDamage = saved.BonusDamage;
                    chip.Clickable = saved.Clickable;
                }
            }
        }

        private static void UpdateSpaces(Tuple<List<Space>, Space, Space, Space> spaces, List<SpaceData> spaceData, IEnumerable<CatchSpaceData> catchSpaceData, ICollection<Chip> chips)
        {
            foreach (var space in spaces.Item1)
            {
                space.Visible = spaceData.Single(data => data.Id == space.Id).Visible;
                var catchSpace = space as CatchSpace;
                if (catchSpace != null)
                {
                    var single = chips.Single(chip => chip.Number == catchSpaceData.Single(data => data.Id == catchSpace.Id).AdjacentChip);
                    catchSpace.AdjacentChip = single;
                }
            }
        }

        private static void UpdateTrainers(IEnumerable<Trainer> trainers, List<TrainerData> trainerData)
        {
            foreach (var trainer in trainers)
            {
                var saved = trainerData.SingleOrDefault(data => data.DefaultName == trainer.DefaultName);
                if (saved != null)
                {
                    trainer.Location = saved.Location;
                }
            }
        }
        
        public void ClearAll()
        {
            using (var connection = new SqlCeConnection(Settings.Default.GameDatabaseConnectionString))
            {
                connection.Open();
                var command = new SqlCeCommand("DELETE FROM BoardState", connection);
                command.ExecuteNonQuery();
                command = new SqlCeCommand("DELETE FROM CatchSpace", connection);
                command.ExecuteNonQuery();
                command = new SqlCeCommand("DELETE FROM Chip", connection);
                command.ExecuteNonQuery();
                command = new SqlCeCommand("DELETE FROM Player", connection);
                command.ExecuteNonQuery();
                command = new SqlCeCommand("DELETE FROM Space", connection);
                command.ExecuteNonQuery();
                command = new SqlCeCommand("DELETE FROM Trainer", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
