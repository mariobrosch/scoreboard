using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using ttManager.Data.enums;
using ttManager.Data.models;
using static ttManager.Data.data.Filter;

namespace ttManager.Data.data.requests
{
    public static class PlayerData
    {
        private const string tableName = "Players";

        public static List<Player> Get(bool displayRemoved = false)
        {
            return Get("", "", displayRemoved);
        }

        public static Player Get(int key)
        {
            return Get(key.ToString(), "", true).First();
        }

        public static List<Player> Get(FilterObject filter)
        {
            return Get("", CreateFilter(filter), true);
        }

        public static List<Player> Get(string key, string filter = "", bool displayRemoved = false)
        {
            string players = GetData(key, filter);
            return FilterRemoved(JsonConvert.DeserializeObject<List<Player>>(players), displayRemoved);
        }

        private static string GetData(int key, string filter = "")
        {
            return GetData(key.ToString(), filter);
        }
        
        private static string GetData(string key, string filter = "")
        {
            return RequestHandler.MakeRequest(HttpMethods.GET, tableName, key, filter);
        }

        public static int Delete()
        {
            return Delete("", "");
        }

        public static int Delete(int key)
        {
            return Delete(key.ToString(), "");
        }

        public static int Delete(FilterObject filter)
        {
            return Delete("", CreateFilter(filter));
        }

        public static int Delete(string key, string filter = "")
        {
            string numberOfRowsDeleted = RequestHandler.MakeRequest(HttpMethods.DELETE, tableName, key, filter);
            return int.Parse(numberOfRowsDeleted);
        }

        public static Player Create(Player player)
        {
            var data = JsonConvert.SerializeObject(player);
            var playerId = RequestHandler.MakeRequest(HttpMethods.POST, tableName, "", "", data);
            var newPlayer = GetData(playerId);
            return JsonConvert.DeserializeObject<List<Player>>(newPlayer).First();
        }

        public static bool Update(Player player)
        {
            var data = JsonConvert.SerializeObject(player);
            return RequestHandler.MakeRequest(HttpMethods.PUT, tableName, player.Id, "", data) != "0";
        }

        public static bool Update(int playerId, string property, string value)
        {
            var player = JsonConvert.DeserializeObject<List<Player>>(GetData(playerId)).First();
            player.SetProperty(property, value);
            return Update(player);
        }

        private static List<Player> FilterRemoved(List<Player> players, bool displayRemoved)
        {
            if (displayRemoved)
            {
                return players;
            }
            return players?.Where(p => p.IsRemoved == false).ToList();
        }
    }
}
