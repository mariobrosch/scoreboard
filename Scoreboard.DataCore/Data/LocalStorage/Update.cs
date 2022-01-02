using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Scoreboard.DataCore.Models;
using Scoreboard.DataCore.Enums;

namespace Scoreboard.DataCore.Data.LocalStorage
{
    internal class Update
    {
        private const string defaultReturnValue = "";

        internal static string Perform(string fileContent, ModelType table, string key, string data, out string isUpdated)
        {
            isUpdated = "0";
            dynamic allEntries;

            if (string.IsNullOrEmpty(key))
            {
                return defaultReturnValue;
            }

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

            dynamic entryToUpdate;

            if (allEntries.Count == 0)
            {
                return defaultReturnValue;
            }

            switch (table)
            {
                case ModelType.Players:
                    entryToUpdate = ((List<Player>)allEntries).FirstOrDefault(x => x.Id == int.Parse(key));
                    break;
                case ModelType.Matches:
                    entryToUpdate = ((List<Match>)allEntries).FirstOrDefault(x => x.Id == int.Parse(key));
                    break;
                case ModelType.MatchTypes:
                    entryToUpdate = ((List<MatchType>)allEntries).FirstOrDefault(x => x.Id == int.Parse(key));
                    break;
                case ModelType.Sets:
                    entryToUpdate = ((List<Set>)allEntries).FirstOrDefault(x => x.Id == int.Parse(key));
                    break;
                case ModelType.SinglePlayerMatches:
                    entryToUpdate = ((List<SinglePlayerMatch>)allEntries).FirstOrDefault(x => x.Id == int.Parse(key));
                    break;
                case ModelType.Settings:
                    entryToUpdate = ((List<Setting>)allEntries).FirstOrDefault(x => x.Id == int.Parse(key));
                    break;
                case ModelType.Tournaments:
                    entryToUpdate = ((List<Tournament>)allEntries).FirstOrDefault(x => x.Id == int.Parse(key));
                    break;
                case ModelType.TournamentPlayers:
                    entryToUpdate = ((List<TournamentPlayer>)allEntries).FirstOrDefault(x => x.Id == int.Parse(key));
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
                    case ModelType.Players:
                        updatedEntry = JsonConvert.DeserializeObject<Player>(data);
                        break;
                    case ModelType.Matches:
                        updatedEntry = JsonConvert.DeserializeObject<Match>(data);
                        break;
                    case ModelType.MatchTypes:
                        updatedEntry = JsonConvert.DeserializeObject<MatchType>(data);
                        break;
                    case ModelType.Sets:
                        updatedEntry = JsonConvert.DeserializeObject<Set>(data);
                        break;
                    case ModelType.SinglePlayerMatches:
                        updatedEntry = JsonConvert.DeserializeObject<SinglePlayerMatch>(data);
                        break;
                    case ModelType.Settings:
                        updatedEntry = JsonConvert.DeserializeObject<Setting>(data);
                        break;
                    case ModelType.Tournaments:
                        updatedEntry = JsonConvert.DeserializeObject<Tournament>(data);
                        break;
                    case ModelType.TournamentPlayers:
                        updatedEntry = JsonConvert.DeserializeObject<TournamentPlayer>(data);
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
