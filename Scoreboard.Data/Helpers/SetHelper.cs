using System.Collections.Generic;
using Scoreboard.Data.enums;
using Scoreboard.Data.models;

namespace Scoreboard.Data.Helpers
{
    public static class SetHelper
    {
        public static PlayerSide HasWinner(Set set, MatchType matchType)
        {
            if (set.TeamLeftScore > set.TeamRightScore)
            {
                if (set.TeamLeftScore >= matchType.ScorePerMatchToWin)
                {
                    if (set.TeamLeftScore > set.TeamRightScore + (matchType.NeedTwoPointsDifferenceToWin ? 1 : 0))
                    {
                        return PlayerSide.Left;
                    }
                }
                return PlayerSide.None;
            }

            if (set.TeamRightScore > set.TeamLeftScore)
            {
                if (set.TeamRightScore >= matchType.ScorePerMatchToWin)
                {
                    if (set.TeamRightScore > set.TeamLeftScore + (matchType.NeedTwoPointsDifferenceToWin ? 1 : 0))
                    {
                        return PlayerSide.Right;
                    }
                }
                return PlayerSide.None;
            }

            return PlayerSide.None;
        }

        public static PlayerSide GetPlayerToServe(MatchSummary matchSummary)
        {
            if (matchSummary.Winner.HasValue)
            {
                return PlayerSide.None;
            }

            var sets = matchSummary.Sets;
            var currentSet = sets[sets.Count - 1];

            if (currentSet.SetWinnerId.HasValue)
            {
                return PlayerSide.None;
            }

            var playerFirstService = matchSummary.Match.PlayerFirstServiceId;
            var matchType = matchSummary.MatchType;
            var playersInMatch = new List<int>
            {
                matchSummary.Match.PlayerLeftId,
                matchSummary.Match.PlayerRightId
            };

            if (matchSummary.Match.PlayerLeftId2.HasValue)
            {
                playersInMatch.Add(matchSummary.Match.PlayerLeftId2.Value);
                playersInMatch.Add(matchSummary.Match.PlayerRightId2.Value);
            }

            var positionFirstServicePlayer = playersInMatch.IndexOf(playerFirstService);
            var playerFirstServeThisSet = playersInMatch[(positionFirstServicePlayer + currentSet.SetNumber - 1) % playersInMatch.Count];
            var positionFirstServicePlayerThisSet = playersInMatch.IndexOf(playerFirstServeThisSet);

            if (currentSet.TeamLeftScore > matchType.ScorePerMatchToWin || currentSet.TeamRightScore > matchType.ScorePerMatchToWin)
            {
                var totalServicesUntilSuddenDeath = matchType.ScorePerMatchToWin * 2 / matchType.ServiceChangeEveryNumberOfServices;
                var startPlayerDuringSuddenDeath = playersInMatch[(positionFirstServicePlayerThisSet + totalServicesUntilSuddenDeath - 1) % playersInMatch.Count];
                var numberOfPointsDuringSuddenDeath = currentSet.TeamLeftScore + currentSet.TeamRightScore - matchType.ScorePerMatchToWin * 2;

                int numberOfServiceTurns = numberOfPointsDuringSuddenDeath / matchType.ServiceChangeOnShootOutPer;
                var playerToServe = playersInMatch[(startPlayerDuringSuddenDeath + numberOfServiceTurns - 1) % playersInMatch.Count];
                if (playersInMatch.IndexOf(playerToServe) % 2 == 0)
                {
                    return PlayerSide.Left;
                }
                else
                {
                    return PlayerSide.Right;
                }
            }
            else if (currentSet.TeamLeftScore == 0 && currentSet.TeamRightScore ==0)
            {
                if (playersInMatch.IndexOf(playerFirstServeThisSet) % 2 == 0)
                {
                    return PlayerSide.Left;
                }
                else
                {
                    return PlayerSide.Right;
                }
            } else
            {
                int numberOfServiceTurns = (currentSet.TeamRightScore + currentSet.TeamLeftScore) / matchType.ServiceChangeEveryNumberOfServices;
                if (numberOfServiceTurns == 0)
                {
                    var playerToServeFirst = playersInMatch[positionFirstServicePlayer];
                    if (playersInMatch.IndexOf(playerToServeFirst) % 2 == 0)
                    {
                        return PlayerSide.Left;
                    }
                    else
                    {
                        return PlayerSide.Right;
                    }
                }
                var playerToServe = playersInMatch[(positionFirstServicePlayerThisSet + numberOfServiceTurns - 1) % playersInMatch.Count];
                if (playersInMatch.IndexOf(playerToServe) % 2 == 0)
                {
                    return PlayerSide.Right;
                }
                else
                {
                    return PlayerSide.Left;
                }
            }
        }
    }
}
