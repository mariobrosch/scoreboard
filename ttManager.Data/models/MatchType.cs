﻿using Newtonsoft.Json;

namespace ttManager.Data.models
{
    public class MatchType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int Removed { get; set; }
        public int NumberOfGamesToWin { get; set; }
        public int ScorePerGameToWin { get; set; }
        public int ServiceChangeEveryNumberOfServices { get; set; }
        public int TwoPointsDifferenceToWin { get; set; }
        public int ServiceChangeOnShootOutPer { get; set; }
        public int AvailableForTwoVsTwo { get; set; }
        [JsonIgnore]
        public bool IsRemoved
        {
            get
            {
                return Removed == 1;
            }
            set
            {
                Removed = value ? 1 : 0;
            }
        }
        [JsonIgnore]
        public bool NeedTwoPointsDifferenceToWin
        {
            get
            {
                return TwoPointsDifferenceToWin == 1;
            }
            set
            {
                TwoPointsDifferenceToWin = value ? 1 : 0;
            }
        }
        [JsonIgnore]
        public bool IsAvailableForTwoVsTwo {
            get
            {
                return AvailableForTwoVsTwo == 1;
            }
            set
            {
                AvailableForTwoVsTwo = value ? 1 : 0;
            }
        }
    }
}