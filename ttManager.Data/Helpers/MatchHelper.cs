using System;
using System.Linq;
using ttManager.Data.data.requests;
using ttManager.Data.enums;
using ttManager.Data.models;

namespace ttManager.Data.Helpers
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

            matchSummary.Games = GameData.GetByMatch(match.Id).OrderBy(m => m.GameNumber).ToList();

            var gamesLeft = 0;
            var gamesRight = 0;
            var text = "";

            foreach (var game in matchSummary.Games)
            {
                if (game.GameWinnerId != null)
                {
                    if (game.GameWinnerId == match.PlayerLeftId)
                    {
                        gamesLeft++;
                        text += game.TeamLeftScore + "* - " + game.TeamRightScore + "\r\n";
                    }
                    else
                    {
                        gamesRight++;
                        text += game.TeamLeftScore + " - " + game.TeamRightScore + "*\r\n";
                    }

                }
                else
                {
                    text += game.TeamLeftScore + " - " + game.TeamRightScore + "\r\n";
                }
            }

            matchSummary.MatchType = MatchTypeData.Get(match.MatchTypeId);
            matchSummary.GamesSummary = text;
            matchSummary.Standings = gamesLeft + "-" + gamesRight;
            matchSummary.MatchDate = match.MatchDate;
            matchSummary.Match = match;
            return matchSummary;
        }

        public static PlayerSide HasMatchWinner(MatchSummary matchSummary)
        {
            var games = matchSummary.Games;
            var gamesWonLeft = Convert.ToInt32(matchSummary.Standings.Split('-')[0]);
            var gamesWonRight = Convert.ToInt32(matchSummary.Standings.Split('-')[1]);

            var totalGamesPlayed = gamesWonLeft + gamesWonRight;
            if (totalGamesPlayed == games.Count 
                && gamesWonLeft != matchSummary.MatchType.NumberOfGamesToWin 
                && gamesWonRight != matchSummary.MatchType.NumberOfGamesToWin)
            {
                return PlayerSide.None;
            }

            gamesWonLeft = 0;
            gamesWonRight = 0;
            foreach(Game game in games)
            {
                if (game.GameWinnerId != null)
                {
                    if (game.GameWinnerId == matchSummary.Match.PlayerLeftId) // We don't need a check for second player
                    {
                        gamesWonLeft++;
                    }
                    else
                    {
                        gamesWonRight++;
                    }
                }
                // in theory game winner should already be filled in before we start this method
                else
                {
                    switch (GameHelper.HasWinner(game, matchSummary.MatchType))
                    {
                        case PlayerSide.Left:
                            gamesWonLeft++;
                            break;
                        case PlayerSide.Right:
                            gamesWonRight++;
                            break;
                    }
                }
            }

            if (gamesWonLeft >= matchSummary.MatchType.NumberOfGamesToWin)
            {
                return PlayerSide.Left;
            } else if (gamesWonRight >= matchSummary.MatchType.NumberOfGamesToWin)
            {
                return PlayerSide.Right;
            }
            return PlayerSide.None;
        }
    }
}
