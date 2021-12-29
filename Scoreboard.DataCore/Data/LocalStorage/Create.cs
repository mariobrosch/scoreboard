using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Scoreboard.DataCore.Models;

namespace Scoreboard.DataCore.Data.LocalStorage
{
    internal class Create
    {
        private const string defaultReturnValue = "";

        internal static string Perform(string fileContent, string table, string data, out string newId)
        {
            newId = "0";
            dynamic allEntries;

            if (string.IsNullOrEmpty(data))
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

            int newEntryId = 1;
            if (allEntries.Count > 0)
            {
                switch (table)
                {
                    case "Players":
                        newEntryId = ((List<Player>)allEntries).OrderBy(x => x.Id).Last().Id + 1;
                        break;
                    case "Matches":
                        newEntryId = ((List<Match>)allEntries).OrderBy(x => x.Id).Last().Id + 1;
                        break;
                    case "MatchTypes":
                        newEntryId = ((List<MatchType>)allEntries).OrderBy(x => x.Id).Last().Id + 1;
                        break;
                    case "Sets":
                        newEntryId = ((List<Set>)allEntries).OrderBy(x => x.Id).Last().Id + 1;
                        break;
                    case "SinglePlayerMatches":
                        newEntryId = ((List<SinglePlayerMatch>)allEntries).OrderBy(x => x.Id).Last().Id + 1;
                        break;
                    case "Settings":
                        newEntryId = ((List<Setting>)allEntries).OrderBy(x => x.Id).Last().Id + 1;
                        break;
                    default:
                        return defaultReturnValue;
                }
            }

            dynamic newEntry;
            switch (table)
            {
                case "Players":
                    newEntry = JsonConvert.DeserializeObject<Player>(data);
                    newEntry.Id = newEntryId;
                    break;
                case "Matches":
                    newEntry = JsonConvert.DeserializeObject<Match>(data);
                    newEntry.Id = newEntryId;
                    break;
                case "MatchTypes":
                    newEntry = JsonConvert.DeserializeObject<MatchType>(data);
                    newEntry.Id = newEntryId;
                    break;
                case "Sets":
                    newEntry = JsonConvert.DeserializeObject<Set>(data);
                    newEntry.Id = newEntryId;
                    break;
                case "SinglePlayerMatches":
                    newEntry = JsonConvert.DeserializeObject<SinglePlayerMatch>(data);
                    newEntry.Id = newEntryId;
                    break;
                case "Settings":
                    newEntry = JsonConvert.DeserializeObject<Setting>(data);
                    newEntry.Id = newEntryId;
                    break;
                default:
                    return defaultReturnValue;
            }

            allEntries.Add(newEntry);
            newId = newEntryId.ToString();
            return JsonConvert.SerializeObject(allEntries);
        }

    }
}
