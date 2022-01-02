using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Scoreboard.DataCore.Enums;
using Scoreboard.DataCore.Models;
using static Scoreboard.DataCore.Data.Filter;

namespace Scoreboard.DataCore.Data.Requests
{
    public static class MatchTypeData
    {
        private const ModelType tableName = ModelType.MatchTypes;

        public static List<MatchType> Get(bool displayRemoved = false)
        {
            return Get("", "", displayRemoved);
        }

        public static MatchType Get(int key)
        {
            return Get(key.ToString(), "", true).First();
        }

        public static List<MatchType> Get(FilterObject filter)
        {
            return Get("", CreateFilter(filter));
        }

        public static List<MatchType> Get(string key, string filter = "", bool displayRemoved = false)
        {
            string matchTypes = GetData(key, filter);

            return FilterRemoved(JsonConvert.DeserializeObject<List<MatchType>>(matchTypes), displayRemoved);
        }

        public static string GetData(int key, string filter = "")
        {
            return GetData(key.ToString(), filter);
        }

        public static string GetData(string key, string filter = "")
        {
            return RequestHandler.MakeRequest(HttpMethods.GET, tableName, key, filter);
        }

        public static int Delete(string key, string filter = "")
        {
            string numberOfRowsDeleted = RequestHandler.MakeRequest(HttpMethods.DELETE, tableName, key, filter);
            return int.Parse(numberOfRowsDeleted);
        }

        public static MatchType Create(MatchType matchType)
        {
            string data = JsonConvert.SerializeObject(matchType);
            string matchTypeId = RequestHandler.MakeRequest(HttpMethods.POST, tableName, "", "", data);
            string newMatchType = GetData(matchTypeId);
            return JsonConvert.DeserializeObject<List<MatchType>>(newMatchType).First();
        }
        public static bool Update(MatchType matchType)
        {
            string data = JsonConvert.SerializeObject(matchType);
            return RequestHandler.MakeRequest(HttpMethods.PUT, tableName, matchType.Id, "", data) != "0";
        }

        public static bool Update(int matchTypeId, string property, string value)
        {
            MatchType matchType = JsonConvert.DeserializeObject<List<MatchType>>(GetData(matchTypeId)).First();
            matchType.SetProperty(property, value);
            return Update(matchType);
        }
        private static List<MatchType> FilterRemoved(List<MatchType> matchTypes, bool displayRemoved)
        {
            return displayRemoved ? matchTypes : (matchTypes?.Where(mt => mt.IsRemoved == false).ToList());
        }
    }
}
