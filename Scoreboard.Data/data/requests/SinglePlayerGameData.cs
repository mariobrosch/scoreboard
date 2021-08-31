using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Scoreboard.Data.enums;
using Scoreboard.Data.models;
using static Scoreboard.Data.data.Filter;

namespace Scoreboard.Data.data.requests
{
    public static class SinglePlayerGameData
    {
        private const string tableName = "SinglePlayerGames";

        public static List<SinglePlayerGame> Get()
        {
            return Get("", "");
        }

        public static SinglePlayerGame Get(int key)
        {
            return Get(key.ToString()).First();
        }

        public static List<SinglePlayerGame> Get(FilterObject filter)
        {
            return Get("", CreateFilter(filter));
        }

        public static List<SinglePlayerGame> Get(string key, string filter = "")
        {
            string singlePlayerGames = GetData(key, filter);

            return JsonConvert.DeserializeObject<List<SinglePlayerGame>>(singlePlayerGames);
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

        public static SinglePlayerGame Create(SinglePlayerGame singlePlayerGame)
        {
            var data = JsonConvert.SerializeObject(singlePlayerGame);
            var singlePlayerGameId = RequestHandler.MakeRequest(HttpMethods.POST, tableName, "", "", data);
            var newSinglePlayerGame = GetData(singlePlayerGameId);
            return JsonConvert.DeserializeObject<List<SinglePlayerGame>>(newSinglePlayerGame).First();
        }

        public static bool Update(SinglePlayerGame singlePlayerGame)
        {
            var data = JsonConvert.SerializeObject(singlePlayerGame);
            return RequestHandler.MakeRequest(HttpMethods.PUT, tableName, singlePlayerGame.Id, "", data) != "0";
        }

        public static bool Update(int singlePlayerGameId, string property, string value)
        {
            var singlePlayerGame = JsonConvert.DeserializeObject<List<SinglePlayerGame>>(GetData(singlePlayerGameId)).First();
            singlePlayerGame.SetProperty(property, value);
            return Update(singlePlayerGame);
        }

        public static List<SinglePlayerGame> GetForPlayer(int playerId)
        {
            var filter = new FilterObject
            {
                Column = "PlayerId",
                Value = playerId.ToString()
            };
            return Get(filter);
        }
    }
}
