using Newtonsoft.Json;
using System.Collections.Generic;
using ttManager.Data.models;

namespace ttManager.Data.data.LocalStorage
{
    class Delete
    {
        internal static string Perform(string fileContent, string table, string key, string filter, out string removeCount)
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
                case "SinglePlayerGames":
                    var allSpGames = JsonConvert.DeserializeObject<List<SinglePlayerGame>>(fileContent);
                    var newSpGames = new List<SinglePlayerGame>();
                    foreach (var game in allSpGames)
                    {
                        if (!string.IsNullOrEmpty(key))
                        {
                            if (game.Id.ToString() != key)
                            {
                                newSpGames.Add(game);
                            }
                        }
                        else
                        {
                            var value = game.GetType().GetProperty(filterObject.Column).GetValue(game, null);
                            if (value.ToString() != filterObject.Value)
                            {
                                newSpGames.Add(game);
                            }
                        }
                    }
                    removeCount = (allSpGames.Count - newSpGames.Count).ToString();
                    return JsonConvert.SerializeObject(newSpGames);
                case "Settings":
                    var allSettings = JsonConvert.DeserializeObject<List<Setting>>(fileContent);
                    var newSettings = new List<Setting>();
                    foreach (var setting in allSettings)
                    {
                        if (!string.IsNullOrEmpty(key))
                        {
                            if (setting.Id.ToString() != key)
                            {
                                newSettings.Add(setting);
                            }
                        }
                        else
                        {
                            var value = setting.GetType().GetProperty(filterObject.Column).GetValue(setting, null);
                            if (value.ToString() != filterObject.Value)
                            {
                                newSettings.Add(setting);
                            }
                        }
                    }
                    removeCount = (allSettings.Count - newSettings.Count).ToString();
                    return JsonConvert.SerializeObject(newSettings);
            }
            return "";
        }

    }
}
