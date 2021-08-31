﻿using System.Collections.Generic;
using Scoreboard.Data.enums;

namespace Scoreboard.Data.models
{
    public class MatchSummary
    {
        public string TeamLeft { get; set; }
        public string TeamRight { get; set; }
        public string MatchDate { get; set; }
        public string Standings { get; set; }
        public PlayerSide? Winner { get; set; }
        public List<Game> Games { get; set; }
        public string GamesSummary { get; set; }
        public MatchType MatchType { get; internal set; }
        public Match Match { get; set; }
    }
}