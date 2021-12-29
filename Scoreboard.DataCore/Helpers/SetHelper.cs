using System.Collections.Generic;
using Scoreboard.DataCore.Enums;
using Scoreboard.DataCore.Models;

namespace Scoreboard.DataCore.Helpers
{
    public static class SetHelper
    {
        public static PlayerSide HasWinner(Set set, MatchType matchType, int playedSeconds)
        {
            if (matchType.IsTimedMatch)
            {
                int? matchTimeInSeconds = matchType.MatchTime * 60;
                if (playedSeconds > matchTimeInSeconds)
                {
                    if (set.TeamLeftScore > set.TeamRightScore)
                    {
                        return PlayerSide.Left;
                    }
                    else if (set.TeamRightScore > set.TeamLeftScore)
                    {
                        return PlayerSide.Right;
                    }
                    return PlayerSide.None;
                }
                return PlayerSide.None;
            }

            if (set.TeamLeftScore > set.TeamRightScore)
            {
                if (set.TeamLeftScore >= matchType.ScorePerSetToWin)
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
                if (set.TeamRightScore >= matchType.ScorePerSetToWin)
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

            List<Set> sets = matchSummary.Sets;
            Set currentSet = sets[sets.Count - 1];

            if (currentSet.SetWinnerId.HasValue)
            {
                return PlayerSide.None;
            }

            int playerFirstService = matchSummary.Match.PlayerFirstServiceId;
            MatchType matchType = matchSummary.MatchType;
            List<int> playersInMatch = new List<int>
            {
                matchSummary.Match.PlayerLeftId,
                matchSummary.Match.PlayerRightId
            };

            if (matchSummary.Match.PlayerLeftId2.HasValue)
            {
                playersInMatch.Add(matchSummary.Match.PlayerLeftId2.Value);
                playersInMatch.Add(matchSummary.Match.PlayerRightId2.Value);
            }

            int positionFirstServicePlayer = playersInMatch.IndexOf(playerFirstService);
            int playerFirstServeThisSet = playersInMatch[(positionFirstServicePlayer + currentSet.SetNumber - 1) % playersInMatch.Count];
            int positionFirstServicePlayerThisSet = playersInMatch.IndexOf(playerFirstServeThisSet);

            if (currentSet.TeamLeftScore > matchType.ScorePerSetToWin || currentSet.TeamRightScore > matchType.ScorePerSetToWin)
            {
                int totalServicesUntilSuddenDeath = matchType.ScorePerSetToWin * 2 / matchType.ServiceChangeEveryNumberOfServices;
                int startPlayerDuringSuddenDeath = playersInMatch[(positionFirstServicePlayerThisSet + totalServicesUntilSuddenDeath - (totalServicesUntilSuddenDeath == 0 ? 0 : 1)) % playersInMatch.Count];
                int numberOfPointsDuringSuddenDeath = currentSet.TeamLeftScore + currentSet.TeamRightScore - matchType.ScorePerSetToWin * 2;

                int numberOfServiceTurns = numberOfPointsDuringSuddenDeath / matchType.ServiceChangeOnShootOutPer;
                int playerToServe = playersInMatch[(startPlayerDuringSuddenDeath + numberOfServiceTurns - 1) % playersInMatch.Count];
                if (playersInMatch.IndexOf(playerToServe) % 2 == 0)
                {
                    return PlayerSide.Left;
                }
                else
                {
                    return PlayerSide.Right;
                }
            }
            else if (currentSet.TeamLeftScore == 0 && currentSet.TeamRightScore == 0)
            {
                if (playersInMatch.IndexOf(playerFirstServeThisSet) % 2 == 0)
                {
                    return PlayerSide.Left;
                }
                else
                {
                    return PlayerSide.Right;
                }
            }
            else
            {
                int numberOfServiceTurns = (currentSet.TeamRightScore + currentSet.TeamLeftScore) / matchType.ServiceChangeEveryNumberOfServices;
                if (numberOfServiceTurns == 0)
                {
                    int playerToServeFirst = playersInMatch[positionFirstServicePlayer];
                    if (playersInMatch.IndexOf(playerToServeFirst) % 2 == 0)
                    {
                        return PlayerSide.Left;
                    }
                    else
                    {
                        return PlayerSide.Right;
                    }
                }
                int playerToServe = playersInMatch[(positionFirstServicePlayerThisSet + numberOfServiceTurns - 1) % playersInMatch.Count];
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
