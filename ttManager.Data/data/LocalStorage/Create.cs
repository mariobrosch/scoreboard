using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using ttManager.Data.models;

namespace ttManager.Data.data.LocalStorage
{
    class Create
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

            var newEntryId = 1;
            if (allEntries.Count > 0)
            {
                switch (table)
                {
                    case "Players":
                        newEntryId = (((List<Player>)allEntries).OrderBy(x => x.Id).Last()).Id + 1;
                        break;
                    case "Matches":
                        newEntryId = (((List<Match>)allEntries).OrderBy(x => x.Id).Last()).Id + 1;
                        break;
                    case "MatchTypes":
                        newEntryId = (((List<MatchType>)allEntries).OrderBy(x => x.Id).Last()).Id + 1;
                        break;
                    case "Games":
                        newEntryId = (((List<Game>)allEntries).OrderBy(x => x.Id).Last()).Id + 1;
                        break;
                    case "SinglePlayerGames":
                        newEntryId = (((List<SinglePlayerGame>)allEntries).OrderBy(x => x.Id).Last()).Id + 1;
                        break;
                    case "Settings":
                        newEntryId = (((List<Setting>)allEntries).OrderBy(x => x.Id).Last()).Id + 1;
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
                case "Games":
                    newEntry = JsonConvert.DeserializeObject<Game>(data);
                    newEntry.Id = newEntryId; 
                    break;
                case "SinglePlayerGames":
                    newEntry = JsonConvert.DeserializeObject<SinglePlayerGame>(data);
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
