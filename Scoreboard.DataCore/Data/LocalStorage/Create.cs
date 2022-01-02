using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Scoreboard.DataCore.Models;
using Scoreboard.DataCore.Enums;

namespace Scoreboard.DataCore.Data.LocalStorage
{
    internal class Create
    {
        private const string defaultReturnValue = "";

        internal static string Perform(string fileContent, ModelType table, string data, out string newId)
        {
            newId = "0";
            dynamic allEntries;

            if (string.IsNullOrEmpty(data))
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

            int newEntryId = 1;
            if (allEntries.Count > 0)
            {
                switch (table)
                {
                    case ModelType.Players:
                        newEntryId = ((List<Player>)allEntries).OrderBy(x => x.Id).Last().Id + 1;
                        break;
                    case ModelType.Matches:
                        newEntryId = ((List<Match>)allEntries).OrderBy(x => x.Id).Last().Id + 1;
                        break;
                    case ModelType.MatchTypes:
                        newEntryId = ((List<MatchType>)allEntries).OrderBy(x => x.Id).Last().Id + 1;
                        break;
                    case ModelType.Sets:
                        newEntryId = ((List<Set>)allEntries).OrderBy(x => x.Id).Last().Id + 1;
                        break;
                    case ModelType.SinglePlayerMatches:
                        newEntryId = ((List<SinglePlayerMatch>)allEntries).OrderBy(x => x.Id).Last().Id + 1;
                        break;
                    case ModelType.Settings:
                        newEntryId = ((List<Setting>)allEntries).OrderBy(x => x.Id).Last().Id + 1;
                        break;
                    case ModelType.Tournaments:
                        newEntryId = ((List<Tournament>)allEntries).OrderBy(x => x.Id).Last().Id + 1;
                        break;
                    case ModelType.TournamentPlayers:
                        newEntryId = ((List<TournamentPlayer>)allEntries).OrderBy(x => x.Id).Last().Id + 1;
                        break;
                    default:
                        return defaultReturnValue;
                }
            }

            dynamic newEntry;
            switch (table)
            {
                case ModelType.Players:
                    newEntry = JsonConvert.DeserializeObject<Player>(data);
                    newEntry.Id = newEntryId;
                    break;
                case ModelType.Matches:
                    newEntry = JsonConvert.DeserializeObject<Match>(data);
                    newEntry.Id = newEntryId;
                    break;
                case ModelType.MatchTypes:
                    newEntry = JsonConvert.DeserializeObject<MatchType>(data);
                    newEntry.Id = newEntryId;
                    break;
                case ModelType.Sets:
                    newEntry = JsonConvert.DeserializeObject<Set>(data);
                    newEntry.Id = newEntryId;
                    break;
                case ModelType.SinglePlayerMatches:
                    newEntry = JsonConvert.DeserializeObject<SinglePlayerMatch>(data);
                    newEntry.Id = newEntryId;
                    break;
                case ModelType.Tournaments:
                    newEntry = JsonConvert.DeserializeObject<Tournament>(data);
                    newEntry.Id = newEntryId;
                    break;
                case ModelType.TournamentPlayers:
                    newEntry = JsonConvert.DeserializeObject<TournamentPlayer>(data);
                    newEntry.Id = newEntryId;
                    break;
                case ModelType.Settings:
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
