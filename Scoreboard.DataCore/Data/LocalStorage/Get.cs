using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Scoreboard.DataCore.Models;
using Scoreboard.DataCore.Enums;

namespace Scoreboard.DataCore.Data.LocalStorage
{
    internal class Get
    {
        private const string defaultReturnValue = "[]";

        internal static string Perform(string fileContent, ModelType table, string key, string filter)
        {
            if (string.IsNullOrEmpty(key) && string.IsNullOrEmpty(filter))
            {
                return fileContent;
            }

            dynamic allEntries;

            switch (table)
            {
                case ModelType.Players:
                    allEntries = JsonConvert.DeserializeObject<List<Player>>(fileContent);
                    break;
                case ModelType.Matches:
                    allEntries = JsonConvert.DeserializeObject<List<Match>>(fileContent);
                    break;
                case ModelType.MatchTypes:
                    allEntries = JsonConvert.DeserializeObject<List<MatchType>>(fileContent);
                    break;
                case ModelType.Sets:
                    allEntries = JsonConvert.DeserializeObject<List<Set>>(fileContent);
                    break;
                case ModelType.SinglePlayerMatches:
                    allEntries = JsonConvert.DeserializeObject<List<SinglePlayerMatch>>(fileContent);
                    break;
                case ModelType.Settings:
                    allEntries = JsonConvert.DeserializeObject<List<Setting>>(fileContent);
                    break;
                case ModelType.Tournaments:
                    allEntries = JsonConvert.DeserializeObject<List<Tournament>>(fileContent);
                    break;
                case ModelType.TournamentPlayers:
                    allEntries = JsonConvert.DeserializeObject<List<TournamentPlayer>>(fileContent);
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
                    case ModelType.Players:
                        return DataParser.SaveListToJsonString(((List<Player>)allEntries).Where(x => x.Id == int.Parse(key)).ToList());
                    case ModelType.Matches:
                        return DataParser.SaveListToJsonString(((List<Match>)allEntries).Where(x => x.Id == int.Parse(key)).ToList());
                    case ModelType.MatchTypes:
                        return DataParser.SaveListToJsonString(((List<MatchType>)allEntries).Where(x => x.Id == int.Parse(key)).ToList());
                    case ModelType.Sets:
                        return DataParser.SaveListToJsonString(((List<Set>)allEntries).Where(x => x.Id == int.Parse(key)).ToList());
                    case ModelType.SinglePlayerMatches:
                        return DataParser.SaveListToJsonString(((List<SinglePlayerMatch>)allEntries).Where(x => x.Id == int.Parse(key)).ToList());
                    case ModelType.Settings:
                        return DataParser.SaveListToJsonString(((List<Setting>)allEntries).Where(x => x.Id == int.Parse(key)).ToList());
                    case ModelType.Tournaments:
                        return DataParser.SaveListToJsonString(((List<Tournament>)allEntries).Where(x => x.Id == int.Parse(key)).ToList());
                    case ModelType.TournamentPlayers:
                        return DataParser.SaveListToJsonString(((List<TournamentPlayer>)allEntries).Where(x => x.Id == int.Parse(key)).ToList());
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
                else if (value != null && value.ToString() == filterObject.Value)
                {
                    entrySelection.Add(entry);
                }
            }

            return JsonConvert.SerializeObject(entrySelection);
        }

    }
}
