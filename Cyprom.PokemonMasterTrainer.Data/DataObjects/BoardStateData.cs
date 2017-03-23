using System;
using System.Collections.Generic;
using System.Linq;

namespace Cyprom.PokemonMasterTrainer.Data.DataObjects
{
    public class BoardStateData
    {
        public List<string> Players { get; set; }
        public List<Tuple<string, int>> OrderOfPlay { get; set; }
        public int InCatchProcess { get; set; }
        public int BallToCatchWith { get; set; }
        public string Challenger { get; set; }
        public string Target { get; set; }
        public string EliteTrainer { get; set; }
        public Tuple<int, int> InBattle { get; set; }
        public int ActivePlayerIndex { get; set; }
        public bool TeamRocket { get; set; }
        public bool FirstBonusUsed { get; set; }
        public List<int> Chips { get; set; }
        public List<int> Items { get; set; }
        public List<int> Events { get; set; }
        public string OnLoadMethod { get; set; }
        public string OnLoadMethodParameters { get; set; }
        public string OnLoadMessage { get; set; }

        public BoardStateData(object players, object orderOfPlay, object inCatchProcess, object ballToCatchWith,
            object challenger, object target, object eliteTrainer, object inBattle, object activePlayerIndex,
            object teamRocket, object firstBonusUsed, object chips, object items, object events, object onLoadMethod,
            object onLoadMethodParameters, object onLoadMessage)
        {
            Players = string.IsNullOrWhiteSpace((string)players) ? new List<string>() : ((string)players).Split(TechnicalConstants.LIST_DELIMITER).ToList();
            OrderOfPlay = new List<Tuple<string, int>>();
            if (!string.IsNullOrWhiteSpace((string)orderOfPlay))
            {
                var order = ((string)orderOfPlay).Split(TechnicalConstants.LIST_DELIMITER);
                foreach (var tupleSplit in order.Select(tuple => tuple.Split(TechnicalConstants.TUPLE_DELIMITER)))
                {
                    OrderOfPlay.Add(new Tuple<string, int>(tupleSplit.First(), int.Parse(tupleSplit.Last())));
                }
            }
            InCatchProcess = inCatchProcess.GetType() != typeof(DBNull) ? (int)inCatchProcess : -1;
            BallToCatchWith = ballToCatchWith.GetType() != typeof(DBNull) ? (int)ballToCatchWith : -1;
            Challenger = challenger.GetType() != typeof(DBNull) ? (string)challenger : null;
            Target = target.GetType() != typeof(DBNull) ? (string)target : null;
            EliteTrainer = eliteTrainer.GetType() != typeof(DBNull) ? (string)eliteTrainer : null;
            if (inBattle.GetType() != typeof(DBNull))
            {
                var battleSplit = ((string)inBattle).Split(TechnicalConstants.TUPLE_DELIMITER).Select(int.Parse).ToList();
                InBattle = new Tuple<int, int>(battleSplit.First(), battleSplit.Last());
            }
            else
            {
                InBattle = null;
            }
            ActivePlayerIndex = (int)activePlayerIndex;
            TeamRocket = (bool)teamRocket;
            FirstBonusUsed = (bool)firstBonusUsed;
            Chips = string.IsNullOrWhiteSpace((string)chips) ? new List<int>() : ((string)chips).Split(TechnicalConstants.LIST_DELIMITER).Select(int.Parse).ToList();
            Items = ((string)items).Split(TechnicalConstants.LIST_DELIMITER).Select(int.Parse).ToList();
            Events = ((string)events).Split(TechnicalConstants.LIST_DELIMITER).Select(int.Parse).ToList();
            OnLoadMethod = (string)onLoadMethod;
            OnLoadMethodParameters = (string)onLoadMethodParameters;
            OnLoadMessage = (string)onLoadMessage;
        }
    }
}
