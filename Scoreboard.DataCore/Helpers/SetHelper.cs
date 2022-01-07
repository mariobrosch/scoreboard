using System.Collections.Generic;
using Scoreboard.DataCore.Data.Requests;
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
            // Match finished? No player to serve
            if (matchSummary.Winner.HasValue)
            {
                return PlayerSide.None;
            }

            List<Set> sets = SetData.GetByMatch(matchSummary.Match.Id);
            Set currentSet = sets[sets.Count - 1];
            int numberOfSets = sets.Count;

            if (currentSet.SetWinnerId.HasValue)
            {
                return PlayerSide.None;
            }

            // Put the players of the in the service order
            var playerServiceOrder = new List<int>
            {
                matchSummary.Match.PlayerFirstServiceId
            };
            if (matchSummary.Match.PlayerLeftId == matchSummary.Match.PlayerFirstServiceId) // Only check for first player on a side, second player never starts a match
            {
                playerServiceOrder.Add(matchSummary.Match.PlayerRightId);
                if (matchSummary.Match.PlayerLeftId2.HasValue)
                {
                    playerServiceOrder.Add(matchSummary.Match.PlayerLeftId2.Value);
                    playerServiceOrder.Add(matchSummary.Match.PlayerRightId2.Value);
                }
            }
            else
            {
                playerServiceOrder.Add(matchSummary.Match.PlayerLeftId);
                if (matchSummary.Match.PlayerLeftId2.HasValue)
                {
                    playerServiceOrder.Add(matchSummary.Match.PlayerRightId2.Value);
                    playerServiceOrder.Add(matchSummary.Match.PlayerLeftId2.Value);
                }
            }
            var numberOfPlayers = playerServiceOrder.Count;

            // Add players in the shifted order for each set to simplify logic
            if (numberOfSets > 1)
            {
                for (int setNumber = 1; setNumber <= numberOfSets; setNumber++)
                {
                    // First set we already have, because thats the basis playerorderlist
                    if (setNumber == 1)
                    {
                        continue;
                    }
                    for (int playerNumber = 1; playerNumber <= numberOfPlayers; playerNumber++)
                    {
                        // Shift the position per set, so the first set 1st player to serve, Second set 2nd player
                        var playerPositionInList = playerNumber + (setNumber);
                        // Position can be higher than the number of player. Third set with 2 players needs adjustment
                        playerPositionInList %= numberOfPlayers;

                        playerServiceOrder.Add(playerServiceOrder[playerPositionInList]);
                    }
                }
            }

            // Get the players to serve for the current set
            var playerServiceOrderThisSet = new List<int>();
            for (int playerNumber = 1; playerNumber <= numberOfPlayers; playerNumber++)
            {
                playerServiceOrderThisSet.Add(playerServiceOrder[((numberOfSets - 1) * numberOfPlayers) + (playerNumber - 1)]);
            }

            // Set the first player to serve this set if not available yet
            if (!currentSet.PlayerFirstServiceId.HasValue)
            {
                currentSet.PlayerFirstServiceId = playerServiceOrderThisSet[0];
                SetData.Update(currentSet);
            }

            // Both players above or equal score to win? => Sudden Death!
            if (currentSet.TeamLeftScore > matchSummary.MatchType.ScorePerSetToWin && currentSet.TeamRightScore > matchSummary.MatchType.ScorePerSetToWin)
            {
                int totalServicesUntilSuddenDeath = matchSummary.MatchType.ScorePerSetToWin * 2 / matchSummary.MatchType.ServiceChangeEveryNumberOfServices;
                int numberOfPointsDuringSuddenDeath = currentSet.TeamLeftScore + currentSet.TeamRightScore - matchSummary.MatchType.ScorePerSetToWin * 2;
                int numberOfServiceTurnsDuringSuddenDeath = numberOfPointsDuringSuddenDeath /  matchSummary.MatchType.ServiceChangeOnShootOutPer;
                int totalNumberOfServiceChangesThisSet = numberOfServiceTurnsDuringSuddenDeath + totalServicesUntilSuddenDeath;

                int playerToServe = playerServiceOrderThisSet[(totalNumberOfServiceChangesThisSet % numberOfPlayers)];
                return GetPlayerSideForPlayer(matchSummary.Match, playerToServe);
            }
            // No score this set so far
            else if (currentSet.TeamLeftScore == 0 && currentSet.TeamRightScore == 0)
            {
                return GetPlayerSideForPlayer(matchSummary.Match, currentSet.PlayerFirstServiceId.Value);
            }
            else
            {
                int numberOfServiceTurns = (currentSet.TeamRightScore + currentSet.TeamLeftScore) / matchSummary.MatchType.ServiceChangeEveryNumberOfServices;
                if (numberOfServiceTurns == 0)
                {
                    return GetPlayerSideForPlayer(matchSummary.Match, currentSet.PlayerFirstServiceId.Value);
                }

                int playerToServe = playerServiceOrderThisSet[(numberOfServiceTurns) % numberOfPlayers];
                return GetPlayerSideForPlayer(matchSummary.Match, playerToServe);
            }
        }

        private static PlayerSide GetPlayerSideForPlayer(Match match, int playerId)
        {
            if (playerId == match.PlayerLeftId || (match.PlayerLeftId2.HasValue && match.PlayerLeftId2.Value == playerId))
            {
                return PlayerSide.Left;
            }

            return PlayerSide.Right;
        }
    }
}
