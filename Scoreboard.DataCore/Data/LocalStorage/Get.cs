using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Scoreboard.DataCore.Models;

namespace Scoreboard.DataCore.Data.LocalStorage
{
    internal class Get
    {
        private const string defaultReturnValue = "[]";

        internal static string Perform(string fileContent, string table, string key, string filter)
        {
            if (string.IsNullOrEmpty(key) && string.IsNullOrEmpty(filter))
            {
                return fileContent;
            }

            dynamic allEntries;

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
                    case "Sets":
                        return DataParser.SaveListToJsonString(((List<Set>)allEntries).Where(x => x.Id == int.Parse(key)).ToList());
                    case "SinglePlayerMatches":
                        return DataParser.SaveListToJsonString(((List<SinglePlayerMatch>)allEntries).Where(x => x.Id == int.Parse(key)).ToList());
                    case "Settings":
                        return DataParser.SaveListToJsonString(((List<Setting>)allEntries).Where(x => x.Id == int.Parse(key)).ToList());
                    default:
                        return defaultReturnValue;
                }
            }

            FilterObject filterObject = Filter.Deserialize(filter);
            List<dynamic> entrySelection = new List<dynamic>();

            foreach (dynamic entry in allEntries)
            {
                dynamic value = entry.GetType().GetProperty(filterObject.Column).GetValue(entry, null);
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
