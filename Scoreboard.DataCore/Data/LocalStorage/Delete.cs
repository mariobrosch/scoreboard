using Newtonsoft.Json;
using System.Collections.Generic;
using Scoreboard.DataCore.Models;

namespace Scoreboard.DataCore.Data.LocalStorage
{
    internal class Delete
    {
        private const string defaultReturnValue = "";
        internal static string Perform(string fileContent, string table, string key, string filter, out string removeCount)
        {
            removeCount = "0";

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

            FilterObject filterObject = Filter.Deserialize(filter);
            List<dynamic> returnList = new List<dynamic>();

            foreach (dynamic entry in allEntries)
            {
                if (!string.IsNullOrEmpty(key))
                {
                    if (entry.Id.ToString() != key)
                    {
                        returnList.Add(entry);
                    }
                }
                else
                {
                    dynamic value = entry.GetType().GetProperty(filterObject.Column).GetValue(entry, null);
                    if (value.ToString() != filterObject.Value)
                    {
                        returnList.Add(entry);
                    }
                }
            }
            removeCount = (allEntries.Count - returnList.Count).ToString();
            return JsonConvert.SerializeObject(returnList);
        }

    }
}
