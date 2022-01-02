using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Scoreboard.DataCore.Enums;
using Scoreboard.DataCore.Models;
using static Scoreboard.DataCore.Data.Filter;

namespace Scoreboard.DataCore.Data.Requests
{
    public static class TournamentData
    {
        private const ModelType tableName = ModelType.Tournaments;

        public static List<Tournament> Get()
        {
            return Get("", "");
        }

        public static Tournament Get(int key)
        {
            return Get(key.ToString()).First();
        }

        public static List<Tournament> Get(FilterObject filter)
        {
            return Get("", CreateFilter(filter));
        }

        public static List<Tournament> Get(string key, string filter = "")
        {
            string tournaments = GetData(key.ToString(), filter);

            return JsonConvert.DeserializeObject<List<Tournament>>(tournaments);
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

        public static Tournament Create(Tournament tournament)
        {
            string data = JsonConvert.SerializeObject(tournament);
            string tournamentId = RequestHandler.MakeRequest(HttpMethods.POST, tableName, "", "", data);
            string newTournament = GetData(tournamentId);
            return JsonConvert.DeserializeObject<List<Tournament>>(newTournament).First();
        }
        public static bool Update(Tournament tournament)
        {
            string data = JsonConvert.SerializeObject(tournament);
            return RequestHandler.MakeRequest(HttpMethods.PUT, tableName, tournament.Id, "", data) != "0";
        }
        public static bool Update(int tournamentId, string property, string value)
        {
            Tournament tournament = JsonConvert.DeserializeObject<List<Tournament>>(GetData(tournamentId)).First();
            tournament.SetProperty(property, value);
            return Update(tournament);
        }

        public static List<Tournament> GetForPlayer(int playerId)
        {
            List<TournamentPlayer> tournamentPlayers = TournamentPlayerData.GetForPlayer(playerId);

            List<Tournament> tournaments = new List<Tournament>();

            foreach(TournamentPlayer tp in tournamentPlayers)
            {
                var tournament = Get(tp.TournamentId);
                if (tournaments.Find(t=>t.Id == tournament.Id) == null)
                {
                    tournaments.Add(tournament);
                }
            }

            return tournaments;
        }
    }
}
