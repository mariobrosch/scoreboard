using Newtonsoft.Json;
using System;
using Scoreboard.DataCore.Data.Requests;

namespace Scoreboard.DataCore.Models
{
    public class Match
    {
        public int Id { get; set; }
        public int PlayerLeftId { get; set; }
        public int? PlayerLeftId2 { get; set; }
        public int PlayerRightId { get; set; }
        public int? PlayerRightId2 { get; set; }
        public int PlayerFirstServiceId { get; set; }
        public int MatchTypeId { get; set; }
        public string MatchDate { get; set; }
        public int PlayTimeSeconds { get; set; }
        public int? WinnerId { get; set; }
        public int? WinnerId2 { get; set; }
        [JsonIgnore]
        public DateTime MatchDateParsed
        {
            get
            {
                if (DateTime.TryParse(MatchDate, out DateTime dateValue))
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
                MatchDate = value.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        [JsonIgnore]
        public string MatchDescription
        {
            get
            {
                // TODO Fix for 2vs2
                string leftPlayer = PlayerData.Get(PlayerLeftId).Name;
                string rightPlayer = PlayerData.Get(PlayerRightId).Name;

                if (PlayerLeftId2.HasValue)
                {
                    leftPlayer += "+" + PlayerData.Get(PlayerLeftId2.Value).Name;
                    rightPlayer += "+" + PlayerData.Get(PlayerRightId2.Value).Name;
                }

                return leftPlayer + " vs " + rightPlayer;
            }
        }
    }
}
