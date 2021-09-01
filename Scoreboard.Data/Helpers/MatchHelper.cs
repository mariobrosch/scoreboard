using System;
using System.Linq;
using Scoreboard.Data.data.requests;
using Scoreboard.Data.enums;
using Scoreboard.Data.models;

namespace Scoreboard.Data.Helpers
{
    public static class MatchHelper
    {
        public static MatchSummary GetMatchSummary(Match match)
        {
            MatchSummary matchSummary = new MatchSummary();

            var playerLeft = PlayerData.Get(match.PlayerLeftId);
            var playerRight = PlayerData.Get(match.PlayerRightId);
            Player playerLeft2;
            Player playerRight2;

            matchSummary.TeamLeft = playerLeft.Name;
            matchSummary.TeamRight = playerRight.Name;

            if (match.PlayerLeftId2.HasValue)
            {
                playerLeft2 = PlayerData.Get(match.PlayerLeftId2.Value);
                playerRight2 = PlayerData.Get(match.PlayerRightId2.Value);
                matchSummary.TeamLeft += "+" + playerLeft2.Name;
                matchSummary.TeamRight += "+" + playerRight2.Name;
            }

            matchSummary.Sets = SetData.GetByMatch(match.Id).OrderBy(m => m.SetNumber).ToList();

            var setsLeft = 0;
            var setsRight = 0;
            var text = "";

            foreach (var set in matchSummary.Sets)
            {
                if (set.SetWinnerId != null)
                {
                    if (set.SetWinnerId == match.PlayerLeftId)
                    {
                        setsLeft++;
                        text += set.TeamLeftScore + "* - " + set.TeamRightScore + "\r\n";
                    }
                    else
                    {
                        setsRight++;
                        text += set.TeamLeftScore + " - " + set.TeamRightScore + "*\r\n";
                    }

                }
                else
                {
                    text += set.TeamLeftScore + " - " + set.TeamRightScore + "\r\n";
                }
            }

            matchSummary.MatchType = MatchTypeData.Get(match.MatchTypeId);
            matchSummary.SetsSummary = text;
            matchSummary.Standings = setsLeft + "-" + setsRight;
            matchSummary.MatchDate = match.MatchDate;
            matchSummary.Match = match;
            return matchSummary;
        }

        public static PlayerSide HasMatchWinner(MatchSummary matchSummary)
        {
            var sets = matchSummary.Sets;
            var setsWonLeft = Convert.ToInt32(matchSummary.Standings.Split('-')[0]);
            var setsWonRight = Convert.ToInt32(matchSummary.Standings.Split('-')[1]);

            var totalSetsPlayed = setsWonLeft + setsWonRight;
            if (totalSetsPlayed == sets.Count 
                && setsWonLeft != matchSummary.MatchType.NumberOfSetsToWin 
                && setsWonRight != matchSummary.MatchType.NumberOfSetsToWin)
            {
                return PlayerSide.None;
            }

            setsWonLeft = 0;
            setsWonRight = 0;
            foreach(Set set in sets)
            {
                if (set.SetWinnerId != null)
                {
                    if (set.SetWinnerId == matchSummary.Match.PlayerLeftId) // We don't need a check for second player
                    {
                        setsWonLeft++;
                    }
                    else
                    {
                        setsWonRight++;
                    }
                }
                // in theory set winner should already be filled in before we start this method
                else
                {
                    switch (SetHelper.HasWinner(set, matchSummary.MatchType))
                    {
                        case PlayerSide.Left:
                            setsWonLeft++;
                            break;
                        case PlayerSide.Right:
                            setsWonRight++;
                            break;
                    }
                }
            }

            if (setsWonLeft >= matchSummary.MatchType.NumberOfSetsToWin)
            {
                return PlayerSide.Left;
            } else if (setsWonRight >= matchSummary.MatchType.NumberOfSetsToWin)
            {
                return PlayerSide.Right;
            }
            return PlayerSide.None;
        }
    }
}
