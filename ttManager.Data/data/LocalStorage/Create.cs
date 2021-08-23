using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using ttManager.Data.models;

namespace ttManager.Data.data.LocalStorage
{
    class Create
    {
        internal static string Perform(string fileContent, string table, string data, out string newId)
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
                case "SinglePlayerGames":
                    var allSpGames = JsonConvert.DeserializeObject<List<SinglePlayerGame>>(fileContent);
                    var newSpGameId = 1;
                    if (allSpGames.Count > 0)
                    {
                        newSpGameId = allSpGames.OrderBy(g => g.Id).Last().Id + 1;
                    }

                    var newSpGame = JsonConvert.DeserializeObject<SinglePlayerGame>(data);
                    newSpGame.Id = newSpGameId;
                    allSpGames.Add(newSpGame);
                    newId = newSpGameId.ToString();
                    return JsonConvert.SerializeObject(allSpGames);
                case "Settings":
                    var allSettings = JsonConvert.DeserializeObject<List<Setting>>(fileContent);
                    var newSettingId = 1;
                    if (allSettings.Count > 0)
                    {
                        newSettingId = allSettings.OrderBy(s => s.Id).Last().Id + 1;
                    }

                    var newSetting = JsonConvert.DeserializeObject<Setting>(data);
                    newSetting.Id = newSettingId;
                    allSettings.Add(newSetting);
                    newId = newSettingId.ToString();
                    return JsonConvert.SerializeObject(allSettings);
            }
            return "";
        }

    }
}
