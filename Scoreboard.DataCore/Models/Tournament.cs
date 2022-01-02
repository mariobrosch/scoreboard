using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Scoreboard.DataCore.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        public string TournamentDate { get; set; }
        public List<TournamentMatch> MatchSchema { get; set; }
        public int MatchTypeId { get; set; }    
        [JsonIgnore]
        public DateTime TournamentDateParsed
        {
            get
            {
                if (DateTime.TryParse(TournamentDate, out DateTime dateValue))
                {
                    return dateValue;
                }
                else
                {
                    return DateTime.MinValue;
                }
            }
            set
            {
                TournamentDate = value.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        public int? WinnerId { get; set; }
    }

    public class TournamentMatch
    {
        public int MatchSequence { get; set; }
        public int MatchId { get; set; }
        public int PlayerLeftId { get; set; }
        public Boolean IsFinale { get; set; }
        public int PlayerRightId { get; set; }
        [JsonIgnore]
        public Player PlayerLeft { get; set; }
        [JsonIgnore] 
        public Player PlayerRight { get; set; }
        [JsonIgnore]
        public Match MatchData
        {
            get
            {
                return Data.Requests.MatchData.Get(MatchId);
            }
        }
    }
}
