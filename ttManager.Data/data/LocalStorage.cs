using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using ttManager.Data.enums;
using ttManager.Data.models;

namespace ttManager.Data.data
{
    class LocalStorage
    {
        private static readonly string localStoragePath = ConfigurationManager.AppSettings["localStoragePath"];

        internal static string MakeRequest(HttpMethods method, string table, string key, string filter, string data)
        {

            var filePath = Path.Combine(localStoragePath, table + ".json");
            if (!File.Exists(filePath))
            {
                if (!Directory.Exists(localStoragePath))
                {
                    Directory.CreateDirectory(localStoragePath);
                }
                File.WriteAllText(filePath, "[]");
            }
            var fileContent = File.ReadAllText(filePath);

            switch (method)
            {
                case HttpMethods.GET:
                    if (string.IsNullOrEmpty(key) && string.IsNullOrEmpty(filter))
                    {
                        return fileContent;
                    }
                    return PerformGetRequest(fileContent, table, key, filter);
                case HttpMethods.POST:
                    string newId;
                    var newPostContent = PerformPostRequest(fileContent, table, data, out newId);
                    File.WriteAllText(filePath, newPostContent);
                    return newId;
                case HttpMethods.PUT:
                    string isUpdated;
                    var newPutContent = PerformPutRequest(fileContent, table, key, data, out isUpdated);
                    File.WriteAllText(filePath, newPutContent);
                    return isUpdated;
                case HttpMethods.DELETE:
                    string removeCount;
                    var newDeleteContent = PerformDeleteRequest(fileContent, table, key, filter, out removeCount);
                    File.WriteAllText(filePath, newDeleteContent);
                    return removeCount;
            }
            return "";
        }

        internal static string PerformGetRequest(string fileContent, string table, string key, string filter)
        {
            switch (table)
            {
                case "Players":
                    var allPlayers = JsonConvert.DeserializeObject<List<Player>>(fileContent);
                    var playerSelection = new List<Player>();

                    if (!string.IsNullOrEmpty(key))
                    {
                        playerSelection = allPlayers.Where(p => p.Id == int.Parse(key)).ToList();
                    }
                    else
                    {
                        var filterObject = Filter.Deserialize(filter);

                        foreach (Player player in allPlayers)
                        {
                            var value = player.GetType().GetProperty(filterObject.Column).GetValue(player, null);
                            if (value.ToString() == filterObject.Value)
                            {
                                playerSelection.Add(player);
                            }
                        }
                    }
                    return JsonConvert.SerializeObject(playerSelection);
                case "Matches":
                    var allMatches = JsonConvert.DeserializeObject<List<Match>>(fileContent);
                    var matchSelection = new List<Match>();

                    if (!string.IsNullOrEmpty(key))
                    {
                        matchSelection = allMatches.Where(m => m.Id == int.Parse(key)).ToList();
                    }
                    else
                    {
                        var filterObject = Filter.Deserialize(filter);

                        foreach (Match match in allMatches)
                        {
                            var value = match.GetType().GetProperty(filterObject.Column).GetValue(match, null);
                            if (filterObject.Value == "ISNULL")
                            {
                                if (value == null)
                                {
                                    matchSelection.Add(match);
                                }
                            } else if (value.ToString() == filterObject.Value)
                            {
                                matchSelection.Add(match);
                            }
                        }
                    }
                    return JsonConvert.SerializeObject(matchSelection);
                case "MatchTypes":
                    var allMatchTypes = JsonConvert.DeserializeObject<List<MatchType>>(fileContent);
                    var matchTypeSelection = new List<MatchType>();

                    if (!string.IsNullOrEmpty(key))
                    {
                        matchTypeSelection = allMatchTypes.Where(m => m.Id == int.Parse(key)).ToList();
                    }
                    else
                    {
                        var filterObject = Filter.Deserialize(filter);

                        foreach (MatchType matchType in allMatchTypes)
                        {
                            var value = matchType.GetType().GetProperty(filterObject.Column).GetValue(matchType, null);
                            if (value.ToString() == filterObject.Value)
                            {
                                matchTypeSelection.Add(matchType);
                            }
                        }
                    }
                    return JsonConvert.SerializeObject(matchTypeSelection);
                case "Games":
                    var allGames = JsonConvert.DeserializeObject<List<Game>>(fileContent);
                    var gameSelection = new List<Game>();

                    if (!string.IsNullOrEmpty(key))
                    {
                        gameSelection = allGames.Where(g => g.Id == int.Parse(key)).ToList();
                    }
                    else
                    {
                        var filterObject = Filter.Deserialize(filter);

                        foreach (Game game in allGames)
                        {
                            var value = game.GetType().GetProperty(filterObject.Column).GetValue(game, null);
                            if (value.ToString() == filterObject.Value)
                            {
                                gameSelection.Add(game);
                            }
                        }
                    }
                    return JsonConvert.SerializeObject(gameSelection);
            }

            return "";
        }

        internal static string PerformPostRequest(string fileContent, string table, string data, out string newId)
        {
            newId = "0";
            switch (table)
            {
                case "Players":
                    var allPlayers = JsonConvert.DeserializeObject<List<Player>>(fileContent);
                    var newPlayerId = 1;
                    if (allPlayers.Count > 0)
                    {
                        newPlayerId = allPlayers.OrderBy(p => p.Id).Last().Id + 1;
                    }

                    var newPlayer = JsonConvert.DeserializeObject<Player>(data);
                    newPlayer.Id = newPlayerId;
                    allPlayers.Add(newPlayer);
                    newId = newPlayerId.ToString();
                    return JsonConvert.SerializeObject(allPlayers);
                case "Matches":
                    var allMatches = JsonConvert.DeserializeObject<List<Match>>(fileContent);
                    var newMatchId = 1;
                    if (allMatches.Count > 0)
                    {
                        newMatchId = allMatches.OrderBy(m => m.Id).Last().Id + 1;
                    }

                    var newMatch = JsonConvert.DeserializeObject<Match>(data);
                    newMatch.Id = newMatchId;
                    allMatches.Add(newMatch);
                    newId = newMatchId.ToString();
                    return JsonConvert.SerializeObject(allMatches);
                case "MatchTypes":
                    var allMatchTypes = JsonConvert.DeserializeObject<List<MatchType>>(fileContent);
                    var newMatchTypeId = 1;
                    if (allMatchTypes.Count > 0)
                    {
                        newMatchTypeId = allMatchTypes.OrderBy(m => m.Id).Last().Id + 1;
                    }

                    var newMatchType = JsonConvert.DeserializeObject<MatchType>(data);
                    newMatchType.Id = newMatchTypeId;
                    allMatchTypes.Add(newMatchType);
                    newId = newMatchTypeId.ToString();
                    return JsonConvert.SerializeObject(allMatchTypes);
                case "Games":
                    var allGames = JsonConvert.DeserializeObject<List<Game>>(fileContent);
                    var newGameId = 1;
                    if (allGames.Count > 0)
                    {
                        newGameId = allGames.OrderBy(g => g.Id).Last().Id + 1;
                    }

                    var newGame = JsonConvert.DeserializeObject<Game>(data);
                    newGame.Id = newGameId;
                    allGames.Add(newGame);
                    newId = newGameId.ToString();
                    return JsonConvert.SerializeObject(allGames);
            }
            return "";
        }

        internal static string PerformPutRequest(string fileContent, string table, string key, string data, out string isUpdated)
        {
            isUpdated = "0";
            switch (table)
            {
                case "Players":
                    var allPlayers = JsonConvert.DeserializeObject<List<Player>>(fileContent);
                    var playerToUpdate = allPlayers.FirstOrDefault(p => p.Id == Int32.Parse(key));
                    if (playerToUpdate == null) { }
                    else
                    {
                        var index = allPlayers.IndexOf(playerToUpdate);

                        if (index != -1)
                        {
                            isUpdated = "1";
                            var updatedPlayer = JsonConvert.DeserializeObject<Player>(data);
                            allPlayers[index] = updatedPlayer;
                        }
                    }
                    return JsonConvert.SerializeObject(allPlayers);
                case "Matches":
                    var allMatches = JsonConvert.DeserializeObject<List<Match>>(fileContent);
                    var matchToUpdate = allMatches.FirstOrDefault(m => m.Id == Int32.Parse(key));
                    if (matchToUpdate == null) { }
                    else
                    {
                        var index = allMatches.IndexOf(matchToUpdate);

                        if (index != -1)
                        {
                            isUpdated = "1";
                            var updatedMatch = JsonConvert.DeserializeObject<Match>(data);
                            allMatches[index] = updatedMatch;
                        }
                    }
                    return JsonConvert.SerializeObject(allMatches);
                case "MatchTypes":
                    var allMatchTypes = JsonConvert.DeserializeObject<List<MatchType>>(fileContent);
                    var matchTypeToUpdate = allMatchTypes.FirstOrDefault(m => m.Id == Int32.Parse(key));
                    if (matchTypeToUpdate == null) { }
                    else
                    {
                        var index = allMatchTypes.IndexOf(matchTypeToUpdate);

                        if (index != -1)
                        {
                            isUpdated = "1";
                            var updatedMatchType = JsonConvert.DeserializeObject<MatchType>(data);
                            allMatchTypes[index] = updatedMatchType;
                        }
                    }
                    return JsonConvert.SerializeObject(allMatchTypes);
                case "Games":
                    var allGames = JsonConvert.DeserializeObject<List<Game>>(fileContent);
                    var gameToUpdate = allGames.FirstOrDefault(p => p.Id == Int32.Parse(key));
                    if (gameToUpdate == null) { }
                    else
                    {
                        var index = allGames.IndexOf(gameToUpdate);

                        if (index != -1)
                        {
                            isUpdated = "1";
                            var updatedGame = JsonConvert.DeserializeObject<Game>(data);
                            allGames[index] = updatedGame;
                        }
                    }
                    return JsonConvert.SerializeObject(allGames);
            }
            return "";
        }

        internal static string PerformDeleteRequest(string fileContent, string table, string key, string filter, out string removeCount)
        {
            removeCount = "0";
            var filterObject = Filter.Deserialize(filter);

            switch (table)
            {
                case "Players":
                    var allPlayers = JsonConvert.DeserializeObject<List<Player>>(fileContent);
                    var newPlayers = new List<Player>();
                    foreach (var player in allPlayers)
                    {
                        if (!string.IsNullOrEmpty(key))
                        {
                            if (player.Id.ToString() != key)
                            {
                                newPlayers.Add(player);
                            }
                        }
                        else
                        {
                            var value = player.GetType().GetProperty(filterObject.Column).GetValue(player, null);
                            if (value.ToString() != filterObject.Value)
                            {
                                newPlayers.Add(player);
                            }
                        }
                    }
                    removeCount = (allPlayers.Count - newPlayers.Count).ToString();
                    return JsonConvert.SerializeObject(newPlayers);
                case "Matches":
                    var allMatches = JsonConvert.DeserializeObject<List<Match>>(fileContent);
                    var newMatches = new List<Match>();
                    foreach (var match in allMatches)
                    {
                        if (!string.IsNullOrEmpty(key))
                        {
                            if (match.Id.ToString() != key)
                            {
                                newMatches.Add(match);
                            }
                        }
                        else
                        {
                            var value = match.GetType().GetProperty(filterObject.Column).GetValue(match, null);
                            if (value.ToString() != filterObject.Value)
                            {
                                newMatches.Add(match);
                            }
                        }
                    }
                    removeCount = (allMatches.Count - newMatches.Count).ToString();
                    return JsonConvert.SerializeObject(newMatches);
                case "MatchTypes":
                    var allMatchTypes = JsonConvert.DeserializeObject<List<MatchType>>(fileContent);
                    var newMatchTypes = new List<MatchType>();
                    foreach (var matchType in allMatchTypes)
                    {
                        if (!string.IsNullOrEmpty(key))
                        {
                            if (matchType.Id.ToString() != key)
                            {
                                newMatchTypes.Add(matchType);
                            }
                        }
                        else
                        {
                            var value = matchType.GetType().GetProperty(filterObject.Column).GetValue(matchType, null);
                            if (value.ToString() != filterObject.Value)
                            {
                                newMatchTypes.Add(matchType);
                            }
                        }
                    }
                    removeCount = (allMatchTypes.Count - newMatchTypes.Count).ToString();
                    return JsonConvert.SerializeObject(newMatchTypes);
                case "Games":
                    var allGames = JsonConvert.DeserializeObject<List<Game>>(fileContent);
                    var newGames = new List<Game>();
                    foreach (var game in allGames)
                    {
                        if (!string.IsNullOrEmpty(key))
                        {
                            if (game.Id.ToString() != key)
                            {
                                newGames.Add(game);
                            }
                        }
                        else
                        {
                            var value = game.GetType().GetProperty(filterObject.Column).GetValue(game, null);
                            if (value.ToString() != filterObject.Value)
                            {
                                newGames.Add(game);
                            }
                        }
                    }
                    removeCount = (allGames.Count - newGames.Count).ToString();
                    return JsonConvert.SerializeObject(newGames);
            }
            return "";
        }
    }
}
