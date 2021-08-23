using Newtonsoft.Json;
using System;

namespace ttManager.Data.models
{
    public class SinglePlayerGame
    {
        public int Id { get; set; }
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
