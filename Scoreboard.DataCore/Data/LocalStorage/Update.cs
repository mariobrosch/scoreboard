using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Scoreboard.DataCore.Models;

namespace Scoreboard.DataCore.Data.LocalStorage
{
    internal class Update
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
                case "Sets":
                    allEntries = JsonConvert.DeserializeObject<List<Set>>(fileContent);
                    break;
                case "SinglePlayerMatches":
                    allEntries = JsonConvert.DeserializeObject<List<SinglePlayerMatch>>(fileContent);
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
                case "Sets":
                    entryToUpdate = ((List<Set>)allEntries).FirstOrDefault(x => x.Id == int.Parse(key));
                    break;
                case "SinglePlayerMatches":
                    entryToUpdate = ((List<SinglePlayerMatch>)allEntries).FirstOrDefault(x => x.Id == int.Parse(key));
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

            dynamic index = allEntries.IndexOf(entryToUpdate);

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
                    case "Sets":
                        updatedEntry = JsonConvert.DeserializeObject<Set>(data);
                        break;
                    case "SinglePlayerMatches":
                        updatedEntry = JsonConvert.DeserializeObject<SinglePlayerMatch>(data);
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
