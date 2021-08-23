using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using ttManager.Data.models;

namespace ttManager.Data.data.LocalStorage
{
    class Get
    {
        internal static string Perform(string fileContent, string table, string key, string filter)
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
                            }
                            else if (value.ToString() == filterObject.Value)
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
                case "SinglePlayerGames":
                    var allSpGames = JsonConvert.DeserializeObject<List<SinglePlayerGame>>(fileContent);
                    var spGameSelection = new List<SinglePlayerGame>();

                    if (!string.IsNullOrEmpty(key))
                    {
                        spGameSelection = allSpGames.Where(g => g.Id == int.Parse(key)).ToList();
                    }
                    else
                    {
                        var filterObject = Filter.Deserialize(filter);

                        foreach (SinglePlayerGame game in allSpGames)
                        {
                            var value = game.GetType().GetProperty(filterObject.Column).GetValue(game, null);
                            if (value.ToString() == filterObject.Value)
                            {
                                spGameSelection.Add(game);
                            }
                        }
                    }
                    return JsonConvert.SerializeObject(spGameSelection);
                case "Settings":
                    var allSettings = JsonConvert.DeserializeObject<List<Setting>>(fileContent);
                    var settingSelection = new List<Setting>();

                    if (!string.IsNullOrEmpty(key))
                    {
                        settingSelection = allSettings.Where(s => s.Id == int.Parse(key)).ToList();
                    }
                    else
                    {
                        var filterObject = Filter.Deserialize(filter);

                        foreach (var setting in allSettings)
                        {
                            var value = setting.GetType().GetProperty(filterObject.Column).GetValue(setting, null);
                            if (value.ToString() == filterObject.Value)
                            {
                                settingSelection.Add(setting);
                            }
                        }
                    }
                    return JsonConvert.SerializeObject(settingSelection);
            }

            return "";
        }

    }
}
