using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Scoreboard.DataCore.Enums;
using Scoreboard.DataCore.Models;
using static Scoreboard.DataCore.Data.Filter;

namespace Scoreboard.DataCore.Data.Requests
{
    public static class MatchData
    {
        private const string tableName = "Matches";

        public static List<Match> Get()
        {
            return Get("", "");
        }

        public static Match Get(int key)
        {
            return Get(key.ToString()).First();
        }

        public static List<Match> Get(FilterObject filter)
        {
            return Get("", CreateFilter(filter));
        }

        public static List<Match> Get(string key, string filter = "")
        {
            string matches = GetData(key.ToString(), filter);

            return JsonConvert.DeserializeObject<List<Match>>(matches);
        }

        private static string GetData(int key, string filter = "")
        {
            return GetData(key, filter);
        }

        private static string GetData(string key, string filter = "")
        {
            return RequestHandler.MakeRequest(HttpMethods.GET, tableName, key, filter);
        }

        public static int Delete(string key, string filter = "")
        {
            string numberOfRowsDeleted = RequestHandler.MakeRequest(HttpMethods.DELETE, tableName, key, filter);
            return int.Parse(numberOfRowsDeleted);
        }

        public static List<Match> GetForMatchType(int matchTypeId)
        {
            FilterObject filter = new FilterObject
            {
                Column = "MatchTypeId",
                Value = matchTypeId.ToString()
            };
            return Get(filter);
        }

        public static Match Create(Match match)
        {
            string data = JsonConvert.SerializeObject(match);
            string matchId = RequestHandler.MakeRequest(HttpMethods.POST, tableName, "", "", data);
            string newMatch = GetData(matchId);
            return JsonConvert.DeserializeObject<List<Match>>(newMatch).First();
        }
        public static bool Update(Match match)
        {
            string data = JsonConvert.SerializeObject(match);
            return RequestHandler.MakeRequest(HttpMethods.PUT, tableName, match.Id, "", data) != "0";
        }
        public static bool Update(int matchId, string property, string value)
        {
            Match match = JsonConvert.DeserializeObject<List<Match>>(GetData(matchId)).First();
            match.SetProperty(property, value);
            return Update(match);
        }

        public static List<Match> GetForPlayer(int playerId)
        {
            FilterObject filter = new FilterObject
            {
                Column = "PlayerLeftId",
                Value = playerId.ToString()
            };
            List<Match> matchesWhereLeftPlayer = Get(filter);
            filter.Column = "PlayerRightId";
            List<Match> matchesWhereRightPlayer = Get(filter);

            matchesWhereLeftPlayer.AddRange(matchesWhereRightPlayer);

            return matchesWhereLeftPlayer;
        }
    }
}
