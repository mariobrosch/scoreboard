using Scoreboard.DataCore.Data.Requests;
using Scoreboard.DataCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Scoreboard.DataCore.Helpers
{
    public class TournamentHelper
    {
        public static List<TournamentMatch> GetTournamentSchema(List<Player> selectedPlayers)
        {
            int[,] rawSchema;
            var schema = new List<TournamentMatch>();
            if (selectedPlayers == null)
            {
                return schema;
            }

            if (selectedPlayers.Count % 2 == 0)
            {
                rawSchema = GenerateRoundRobinEven(selectedPlayers.Count);
            }
            else
            {
                rawSchema = GenerateRoundRobinOdd(selectedPlayers.Count);
            }

            var counter = 1;
            for (int round = 0; round <= rawSchema.GetUpperBound(1); round++)
            {
                for (int team = 0; team < selectedPlayers.Count; team++)
                {
                    if (rawSchema[team, round] == BYE)
                    {
                        // do nothing
                    }
                    else if (team < rawSchema[team, round])
                    {
                        var playerLeft = selectedPlayers[team];
                        var playerRight = selectedPlayers[rawSchema[team, round]];
                        var tm = new TournamentMatch()
                        {
                            MatchSequence = counter,
                            PlayerLeftId = playerLeft.Id,
                            PlayerLeft = playerLeft,
                            PlayerRightId = playerRight.Id,
                            PlayerRight = playerRight
                        };
                        counter++;
                        schema.Add(tm);
                    }
                }
            }

            return schema;
        }

        private const int BYE = -1;

        private static void RotateArray(int[] teams)
        {
            int tmp = teams[teams.Length - 1];
            Array.Copy(teams, 0, teams, 1, teams.Length - 1);
            teams[0] = tmp;
        }

        private static int[,] GenerateRoundRobinEven(int num_teams)
        {
            // Generate the result for one fewer teams.
            int[,] results = GenerateRoundRobinOdd(num_teams - 1);

            // Copy the results into a bigger array,
            // replacing the byes with the extra team.
            int[,] results2 = new int[num_teams, num_teams - 1];
            for (int team = 0; team < num_teams - 1; team++)
            {
                for (int round = 0; round < num_teams - 1; round++)
                {
                    if (results[team, round] == BYE)
                    {
                        // Change the bye to the new team.
                        results2[team, round] = num_teams - 1;
                        results2[num_teams - 1, round] = team;
                    }
                    else
                    {
                        results2[team, round] = results[team, round];
                    }
                }
            }

            return results2;
        }

        private static int[,] GenerateRoundRobinOdd(int num_teams)
        {
            int n2 = (int)((num_teams - 1) / 2);
            int[,] results = new int[num_teams, num_teams];

            // Initialize the list of teams.
            int[] teams = new int[num_teams];
            for (int i = 0; i < num_teams; i++) teams[i] = i;

            // Start the rounds.
            for (int round = 0; round < num_teams; round++)
            {
                for (int i = 0; i < n2; i++)
                {
                    int team1 = teams[n2 - i];
                    int team2 = teams[n2 + i + 1];
                    results[team1, round] = team2;
                    results[team2, round] = team1;
                }

                // Set the team with the bye.
                results[teams[0], round] = BYE;

                // Rotate the array.
                RotateArray(teams);
            }

            return results;
        }

        public static TournamentMatch GetFinaleForTournament(Tournament tournament, List<Player> playersInTournament)
        {
            var matchesForTournament = MatchData.GetForTournament(tournament.Id);
            var tournamentMatch = new TournamentMatch
            {
                IsFinale = true
            };

            var tournamentStats = new List<StatsModel>();

            foreach (var player in playersInTournament)
            {

                var statsModel = new StatsModel
                {
                    KeyId = player.Id,
                    KeyValue = player.Name,
                };
                var matchesForPlayerForTournament = matchesForTournament.FindAll(m => m.PlayerLeftId == player.Id || m.PlayerRightId == player.Id);
                statsModel.ValueAsInt = matchesForPlayerForTournament.FindAll(mp => mp.WinnerId == player.Id).Count;
                
                foreach(var m in matchesForPlayerForTournament)
                {
                    var isLeftPlayer = m.PlayerLeftId == player.Id;
                    var sets = SetData.GetByMatch(m.Id);
                    var pointsTotal = 0;
                    foreach(var set in sets)
                    {
                        if (isLeftPlayer)
                        {
                            pointsTotal = pointsTotal + set.TeamLeftScore - set.TeamRightScore;
                        } else
                        {
                            pointsTotal = pointsTotal - set.TeamLeftScore + set.TeamRightScore;
                        }
                    }
                    statsModel.ValueAsDecimal = pointsTotal;
                }

                tournamentStats.Add(statsModel);
            }

            var orderedStats = tournamentStats.OrderByDescending(ts => ts.ValueAsInt).ThenByDescending(ts => ts.ValueAsDecimal).ToArray();

            var left = orderedStats[0];
            var right = orderedStats[1];

            tournamentMatch.IsFinale = true;
            tournamentMatch.PlayerLeftId = left.KeyId;
            tournamentMatch.PlayerRightId = right.KeyId;

            return tournamentMatch;
        }
    }
}
