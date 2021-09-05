using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Scoreboard.DataCore.Enums;
using Scoreboard.DataCore.Models;
using static Scoreboard.DataCore.Data.Filter;

namespace Scoreboard.DataCore.Data.Requests
{
    public static class SinglePlayerMatchData
    {
        private const string tableName = "SinglePlayerMatches";

        public static List<SinglePlayerMatch> Get()
        {
            return Get("", "");
        }

        public static SinglePlayerMatch Get(int key)
        {
            return Get(key.ToString()).First();
        }

        public static List<SinglePlayerMatch> Get(FilterObject filter)
        {
            return Get("", CreateFilter(filter));
        }

        public static List<SinglePlayerMatch> Get(string key, string filter = "")
        {
            string singlePlayerMatches = GetData(key, filter);

            return JsonConvert.DeserializeObject<List<SinglePlayerMatch>>(singlePlayerMatches);
        }

        private static string GetData(int key, string filter = "")
        {
            return GetData(key.ToString(), filter);
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

        public static SinglePlayerMatch Create(SinglePlayerMatch singlePlayerMatch)
        {
            string data = JsonConvert.SerializeObject(singlePlayerMatch);
            string singlePlayerMatchId = RequestHandler.MakeRequest(HttpMethods.POST, tableName, "", "", data);
            string newSinglePlayerMatch = GetData(singlePlayerMatchId);
            return JsonConvert.DeserializeObject<List<SinglePlayerMatch>>(newSinglePlayerMatch).First();
        }

        public static bool Update(SinglePlayerMatch singlePlayerMatch)
        {
            string data = JsonConvert.SerializeObject(singlePlayerMatch);
            return RequestHandler.MakeRequest(HttpMethods.PUT, tableName, singlePlayerMatch.Id, "", data) != "0";
        }

        public static bool Update(int singlePlayerMatchId, string property, string value)
        {
            SinglePlayerMatch singlePlayerMatch = JsonConvert.DeserializeObject<List<SinglePlayerMatch>>(GetData(singlePlayerMatchId)).First();
            singlePlayerMatch.SetProperty(property, value);
            return Update(singlePlayerMatch);
        }

        public static List<SinglePlayerMatch> GetForPlayer(int playerId)
        {
            FilterObject filter = new FilterObject
            {
                Column = "PlayerId",
                Value = playerId.ToString()
            };
            return Get(filter);
        }
    }
}
