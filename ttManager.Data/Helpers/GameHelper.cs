using System.Collections.Generic;
using ttManager.Data.enums;
using ttManager.Data.models;

namespace ttManager.Data.Helpers
{
    public static class GameHelper
    {
        public static PlayerSide HasWinner(Game game, MatchType matchType)
        {
            if (game.TeamLeftScore > game.TeamRightScore)
            {
                if (game.TeamLeftScore >= matchType.ScorePerGameToWin)
                {
                    if (game.TeamLeftScore > game.TeamRightScore + (matchType.NeedTwoPointsDifferenceToWin ? 1 : 0))
                    {
                        return PlayerSide.Left;
                    }
                }
                return PlayerSide.None;
            }

            if (game.TeamRightScore > game.TeamLeftScore)
            {
                if (game.TeamRightScore >= matchType.ScorePerGameToWin)
                {
                    if (game.TeamRightScore > game.TeamLeftScore + (matchType.NeedTwoPointsDifferenceToWin ? 1 : 0))
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

            var games = matchSummary.Games;
            var currentGame = games[games.Count - 1];

            if (currentGame.GameWinnerId.HasValue)
            {
                return PlayerSide.None;
            }

            var playerFirstService = matchSummary.Match.PlayerFirstServiceId;
            var matchType = matchSummary.MatchType;
            var playersInGame = new List<int>
            {
                matchSummary.Match.PlayerLeftId,
                matchSummary.Match.PlayerRightId
            };

            if (matchSummary.Match.PlayerLeftId2.HasValue)
            {
                playersInGame.Add(matchSummary.Match.PlayerLeftId2.Value);
                playersInGame.Add(matchSummary.Match.PlayerRightId2.Value);
            }

            var positionFirstServicePlayer = playersInGame.IndexOf(playerFirstService);
            var playerFirstServeThisGame = playersInGame[(positionFirstServicePlayer + currentGame.GameNumber - 1) % playersInGame.Count];
            var positionFirstServicePlayerThisGame = playersInGame.IndexOf(playerFirstServeThisGame);

            if (currentGame.TeamLeftScore > matchType.ScorePerGameToWin || currentGame.TeamRightScore > matchType.ScorePerGameToWin)
            {
                var totalServicesUntilSuddenDeath = matchType.ScorePerGameToWin * 2 / matchType.ServiceChangeEveryNumberOfServices;
                var startPlayerDuringSuddenDeath = playersInGame[(positionFirstServicePlayerThisGame + totalServicesUntilSuddenDeath - 1) % playersInGame.Count];
                var numberOfPointsDuringSuddenDeath = currentGame.TeamLeftScore + currentGame.TeamRightScore - matchType.ScorePerGameToWin * 2;

                int numberOfServiceTurns = numberOfPointsDuringSuddenDeath / matchType.ServiceChangeOnShootOutPer;
                var playerToServe = playersInGame[(startPlayerDuringSuddenDeath + numberOfServiceTurns - 1) % playersInGame.Count];
                if (playersInGame.IndexOf(playerToServe) % 2 == 0)
                {
                    return PlayerSide.Left;
                }
                else
                {
                    return PlayerSide.Right;
                }
            }
            else if (currentGame.TeamLeftScore == 0 && currentGame.TeamRightScore ==0)
            {
                if (playersInGame.IndexOf(playerFirstServeThisGame) % 2 == 0)
                {
                    return PlayerSide.Left;
                }
                else
                {
                    return PlayerSide.Right;
                }
            } else
            {
                int numberOfServiceTurns = (currentGame.TeamRightScore + currentGame.TeamLeftScore) / matchType.ServiceChangeEveryNumberOfServices;
                if (numberOfServiceTurns == 0)
                {
                    var playerToServeFirst = playersInGame[positionFirstServicePlayer];
                    if (playersInGame.IndexOf(playerToServeFirst) % 2 == 0)
                    {
                        return PlayerSide.Left;
                    }
                    else
                    {
                        return PlayerSide.Right;
                    }
                }
                var playerToServe = playersInGame[(positionFirstServicePlayerThisGame + numberOfServiceTurns - 1) % playersInGame.Count];
                if (playersInGame.IndexOf(playerToServe) % 2 == 0)
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
