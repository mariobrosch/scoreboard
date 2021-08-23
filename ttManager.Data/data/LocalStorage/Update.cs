using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using ttManager.Data.models;

namespace ttManager.Data.data.LocalStorage
{
    class Update
    {
        internal static string Perform(string fileContent, string table, string key, string data, out string isUpdated)
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
                case "SinglePlayerGames":
                    var allspGames = JsonConvert.DeserializeObject<List<SinglePlayerGame>>(fileContent);
                    var spGameToUpdate = allspGames.FirstOrDefault(p => p.Id == Int32.Parse(key));
                    if (spGameToUpdate == null) { }
                    else
                    {
                        var index = allspGames.IndexOf(spGameToUpdate);

                        if (index != -1)
                        {
                            isUpdated = "1";
                            var updatedGame = JsonConvert.DeserializeObject<SinglePlayerGame>(data);
                            allspGames[index] = updatedGame;
                        }
                    }
                    return JsonConvert.SerializeObject(allspGames);
                case "Settings":
                    var allSettings = JsonConvert.DeserializeObject<List<Setting>>(fileContent);
                    var settingToUpdate = allSettings.FirstOrDefault(s => s.Id == Int32.Parse(key));
                    if (settingToUpdate == null) { }
                    else
                    {
                        var index = allSettings.IndexOf(settingToUpdate);

                        if (index != -1)
                        {
                            isUpdated = "1";
                            var updatedSetting = JsonConvert.DeserializeObject<Setting>(data);
                            allSettings[index] = updatedSetting;
                        }
                    }
                    return JsonConvert.SerializeObject(allSettings);
            }
            return "";
        }

    }
}
