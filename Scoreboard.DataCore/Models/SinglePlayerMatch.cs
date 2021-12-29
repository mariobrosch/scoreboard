using Newtonsoft.Json;
using System;

namespace Scoreboard.DataCore.Models
{
    public class SinglePlayerMatch
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int HighScore { get; set; }
        public string MatchDate { get; set; }
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
    }
}
