using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using ttManager.Data.models;

namespace ttManager.Data.data.LocalStorage
{
    class Update
    {
        private const string defaultReturnValue = "";

        internal static string Perform(string fileContent, string table, string key, string data, out string isUpdated)
        {
            isUpdated = "0";
            dynamic allEntries;

            if (string.IsNullOrEmpty(key))
            {
                return defaultReturnValue;
            }

            switch (table)
            {
                case "Players":
                    allEntries = JsonConvert.DeserializeObject<List<Player>>(fileContent);
                    break;
                case "Matches":
                    allEntries = JsonConvert.DeserializeObject<List<Match>>(fileContent);
                    break;
                case "MatchTypes":
                    allEntries = JsonConvert.DeserializeObject<List<MatchType>>(fileContent);
                    break;
                case "Games":
                    allEntries = JsonConvert.DeserializeObject<List<Game>>(fileContent);
                    break;
                case "SinglePlayerGames":
                    allEntries = JsonConvert.DeserializeObject<List<SinglePlayerGame>>(fileContent);
                    break;
                case "Settings":
                    allEntries = JsonConvert.DeserializeObject<List<Setting>>(fileContent);
                    break;
                default:
                    return defaultReturnValue;
            }

            dynamic entryToUpdate;

            if (allEntries.Count == 0)
            {
                return defaultReturnValue;
            }

            switch (table)
            {
                case "Players":
                    entryToUpdate = ((List<Player>)allEntries).FirstOrDefault(x => x.Id == int.Parse(key));
                    break;
                case "Matches":
                    entryToUpdate = ((List<Match>)allEntries).FirstOrDefault(x => x.Id == int.Parse(key));
                    break;
                case "MatchTypes":
                    entryToUpdate = ((List<MatchType>)allEntries).FirstOrDefault(x => x.Id == int.Parse(key));
                    break;
                case "Games":
                    entryToUpdate = ((List<Game>)allEntries).FirstOrDefault(x => x.Id == int.Parse(key));
                    break;
                case "SinglePlayerGames":
                    entryToUpdate = ((List<SinglePlayerGame>)allEntries).FirstOrDefault(x => x.Id == int.Parse(key));
                    break;
                case "Settings":
                    entryToUpdate = ((List<Setting>)allEntries).FirstOrDefault(x => x.Id == int.Parse(key));
                    break;
                default:
                    return defaultReturnValue;
            }

            if (entryToUpdate == null)
            {
                return defaultReturnValue;
            }

            var index = allEntries.IndexOf(entryToUpdate);

            if (index != -1)
            {
                isUpdated = "1";
                dynamic updatedEntry;
                switch (table)
                {
                    case "Players":
                        updatedEntry = JsonConvert.DeserializeObject<Player>(data);
                        break;
                    case "Matches":
                        updatedEntry = JsonConvert.DeserializeObject<Match>(data);
                        break;
                    case "MatchTypes":
                        updatedEntry = JsonConvert.DeserializeObject<MatchType>(data);
                        break;
                    case "Games":
                        updatedEntry = JsonConvert.DeserializeObject<Game>(data);
                        break;
                    case "SinglePlayerGames":
                        updatedEntry = JsonConvert.DeserializeObject<SinglePlayerGame>(data);
                        break;
                    case "Settings":
                        updatedEntry = JsonConvert.DeserializeObject<Setting>(data);
                        break;
                    default:
                        return defaultReturnValue;
                }
                allEntries[index] = updatedEntry;
                return DataParser.SaveListToJsonString(allEntries);
            }
            return defaultReturnValue;
        }
    }
}
