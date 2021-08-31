using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Scoreboard.Data.models;

namespace Scoreboard.Data.data.LocalStorage
{
    class Get
    {
        private const string defaultReturnValue = "[]";

        internal static string Perform(string fileContent, string table, string key, string filter)
        {
            if (string.IsNullOrEmpty(key) && string.IsNullOrEmpty(filter))
            {
                return fileContent;
            }

            dynamic allEntries;

            switch (table) {
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

            if (allEntries.Count == 0)
            {
                return defaultReturnValue;
            }

            if (!string.IsNullOrEmpty(key))
            {
                switch (table)
                {
                    case "Players":
                        return DataParser.SaveListToJsonString(((List<Player>)allEntries).Where(x => x.Id == int.Parse(key)).ToList());
                    case "Matches":
                        return DataParser.SaveListToJsonString(((List<Match>)allEntries).Where(x => x.Id == int.Parse(key)).ToList());
                    case "MatchTypes":
                        return DataParser.SaveListToJsonString(((List<MatchType>)allEntries).Where(x => x.Id == int.Parse(key)).ToList());
                    case "Games":
                        return DataParser.SaveListToJsonString(((List<Game>)allEntries).Where(x => x.Id == int.Parse(key)).ToList());
                    case "SinglePlayerGames":
                        return DataParser.SaveListToJsonString(((List<SinglePlayerGame>)allEntries).Where(x => x.Id == int.Parse(key)).ToList());
                    case "Settings":
                        return DataParser.SaveListToJsonString(((List<Setting>)allEntries).Where(x => x.Id == int.Parse(key)).ToList());
                    default:
                        return defaultReturnValue;
                }
            }

            var filterObject = Filter.Deserialize(filter);
            var entrySelection = new List<dynamic>();

            foreach (var entry in allEntries)
            {
                var value = entry.GetType().GetProperty(filterObject.Column).GetValue(entry, null);
                if (filterObject.Value == "ISNULL" && value == null)
                {
                    entrySelection.Add(entry);
                }
                else if (value.ToString() == filterObject.Value)
                {
                    entrySelection.Add(entry);
                }
            }

            return JsonConvert.SerializeObject(entrySelection);
        }

    }
}
