using System.Text;
using Cyprom.PokemonMasterTrainer.Controls;
using Cyprom.PokemonMasterTrainer.Domain;

namespace Cyprom.PokemonMasterTrainer.Data.Helpers
{
    public static class QueryBuilder
    {
        public static string BuildInsertBoardStateQuery(BoardState state)
        {
            var query = new StringBuilder();
            query.Append("INSERT INTO BoardState (Chips, Players, OrderOfPlay");
            if (state.InCatchProcess != null)
            {
                query.Append(", InCatchProcess");
            }
            if (state.BallToCatchWith != null)
            {
                query.Append(", BallToCatchWith");
            }
            if (state.Challenger != null)
            {
                query.Append(", Challenger");
            }
            if (state.Target != null)
            {
                query.Append(", Target");
            }
            if (state.EliteTrainer != null)
            {
                query.Append(", EliteTrainer");
            }
            if (state.InBattle != null)
            {
                query.Append(", InBattle");
            }
            query.Append(", ActivePlayerIndex, TeamRocket, FirstBonusUsed, Items, Events, OnLoadMethod, OnLoadMethodParameters, OnLoadMessage) VALUES (@Chips, @Players, @OrderOfPlay");
            if (state.InCatchProcess != null)
            {
                query.Append(", @InCatchProcess");
            }
            if (state.BallToCatchWith != null)
            {
                query.Append(", @BallToCatchWith");
            }
            if (state.Challenger != null)
            {
                query.Append(", @Challenger");
            }
            if (state.Target != null)
            {
                query.Append(", @Target");
            }
            if (state.EliteTrainer != null)
            {
                query.Append(", @EliteTrainer");
            }
            if (state.InBattle != null)
            {
                query.Append(", @InBattle");
            }
            query.Append(", @ActivePlayerIndex, @TeamRocket, @FirstBonusUsed, @Items, @Events, @OnLoadMethod, @OnLoadMethodParameters, @OnLoadMessage)");
            return query.ToString();
        }

        public static string BuildInsertPlayerQuery(Player player)
        {
            var query = new StringBuilder();
            query.Append("INSERT INTO Player (Name, Trainer, Pokemon, Cards, SortType, SortKey, OnCinnabarIsland, UnderInvestigation, Flying");
            if (player.ActivePokemon != null)
            {
                query.Append(", ActivePokemon");
            }
            query.Append(", VisitedPlaces, PlayerType");
            if (player.Space != null)
            {
                query.Append(", Space");
            }
            query.Append(") VALUES (@Name, @Trainer, @Pokemon, @Cards, @SortType, @SortKey, @OnCinnabarIsland, @UnderInvestigation, @Flying");
            if (player.ActivePokemon != null)
            {
                query.Append(", @ActivePokemon");
            }
            query.Append(", @VisitedPlaces, @PlayerType");
            if (player.Space != null)
            {
                query.Append(", @Space");
            }
            query.Append(")");
            return query.ToString();
        }

        public static string BuildInsertChipQuery(Chip chip)
        {
            return @"INSERT INTO Chip
                     (Number, X, Y, Flipped, KnockedOut, BonusDamage, Enabled)
                     VALUES
                     (@Number, @X, @Y, @Flipped, @KnockedOut, @BonusDamage, @Enabled)";
        }

        public static string BuildInsertSpaceQuery(Space space)
        {
            return @"INSERT INTO Space
                     (Id, Visible)
                     VALUES
                     (@Id, @Visible)";
        }

        public static string BuildInsertCatchSpaceQuery(CatchSpace space)
        {
            var query = new StringBuilder();
            query.Append("INSERT INTO CatchSpace (Id");
            if (space.AdjacentChip != null)
            {
                query.Append(", AdjacentChip");
            }
            query.Append(") VALUES (@Id");
            if (space.AdjacentChip != null)
            {
                query.Append(", @AdjacentChip");
            }
            query.Append(")");
            return query.ToString();
        }

        public static string BuildInsertTrainerQuery(Trainer trainer)
        {
            return @"INSERT INTO Trainer
                     (DefaultName, X, Y)
                     VALUES
                     (@DefaultName, @X, @Y)";
        }
    }
}