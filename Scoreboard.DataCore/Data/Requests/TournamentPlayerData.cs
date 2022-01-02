using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Scoreboard.DataCore.Enums;
using Scoreboard.DataCore.Models;
using static Scoreboard.DataCore.Data.Filter;

namespace Scoreboard.DataCore.Data.Requests
{
    public static class TournamentPlayerData
    {
        private const ModelType tableName = ModelType.TournamentPlayers;

        public static List<TournamentPlayer> Get()
        {
            return Get("", "");
        }

        public static TournamentPlayer Get(int key)
        {
            return Get(key.ToString()).First();
        }

        public static List<TournamentPlayer> Get(FilterObject filter)
        {
            return Get("", CreateFilter(filter));
        }

        public static List<TournamentPlayer> Get(string key, string filter = "")
        {
            string tournamentPlayers = GetData(key.ToString(), filter);

            return JsonConvert.DeserializeObject<List<TournamentPlayer>>(tournamentPlayers);
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

        public static TournamentPlayer Create(TournamentPlayer tournamentPlayers)
        {
            string data = JsonConvert.SerializeObject(tournamentPlayers);
            string tournamentPlayerId = RequestHandler.MakeRequest(HttpMethods.POST, tableName, "", "", data);
            string newTournamentPlayer = GetData(tournamentPlayerId);
            return JsonConvert.DeserializeObject<List<TournamentPlayer>>(newTournamentPlayer).First();
        }
        public static bool Update(TournamentPlayer tournamentPlayer)
        {
            string data = JsonConvert.SerializeObject(tournamentPlayer);
            return RequestHandler.MakeRequest(HttpMethods.PUT, tableName, tournamentPlayer.Id, "", data) != "0";
        }

        public static bool Update(int tournamentPlayerId, string property, string value)
        {
            TournamentPlayer tournamentPlayer = JsonConvert.DeserializeObject<List<TournamentPlayer>>(GetData(tournamentPlayerId)).First();
            tournamentPlayer.SetProperty(property, value);
            return Update(tournamentPlayer);
        }

        public static List<TournamentPlayer> GetForPlayer(int playerId)
        {
            FilterObject filter = new FilterObject
            {
                Column = "PlayerId",
                Value = playerId.ToString()
            };
            List<TournamentPlayer> tournamentPlayers = Get(filter);

            return tournamentPlayers;
        }
    }
}
