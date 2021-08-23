using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using ttManager.Data.enums;
using ttManager.Data.models;
using static ttManager.Data.data.Filter;

namespace ttManager.Data.data.requests
{
    public static class GameData
    {
        private const string tableName = "Games";

        public static List<Game> Get()
        {
            return Get("", "");
        }

        public static Game Get(int key)
        {
            return Get(key.ToString()).First();
        }

        public static List<Game> Get(FilterObject filter)
        {
            return Get("", CreateFilter(filter));
        }

        public static List<Game> Get(string key, string filter = "")
        {
            string games = GetData(key, filter);

            return JsonConvert.DeserializeObject<List<Game>>(games);
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

        public static Game Create(Game game)
        {
            var data = JsonConvert.SerializeObject(game);
            var gameId = RequestHandler.MakeRequest(HttpMethods.POST, tableName, "", "", data);
            var newGame = GetData(gameId);
            return JsonConvert.DeserializeObject<List<Game>>(newGame).First();
        }

        public static bool Update(Game game)
        {
            var data = JsonConvert.SerializeObject(game);
            return RequestHandler.MakeRequest(HttpMethods.PUT, tableName, game.Id, "", data) != "0";
        }

        public static bool Update(int gameId, string property, string value)
        {
            var game = JsonConvert.DeserializeObject<List<Game>>(GetData(gameId)).First();
            game.SetProperty(property, value);
            return Update(game);
        }

        public static List<Game> GetByMatch(int id)
        {
            var filter = new FilterObject
            {
                Column = "MatchId",
                Value = id.ToString()
            };
            return Get(filter);
        }
    }
}
