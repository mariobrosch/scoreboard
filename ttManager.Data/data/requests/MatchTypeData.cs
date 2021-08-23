using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using ttManager.Data.enums;
using ttManager.Data.models;
using static ttManager.Data.data.Filter;

namespace ttManager.Data.data.requests
{
    public static class MatchTypeData
    {
        private const string tableName = "MatchTypes";

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
            var data = JsonConvert.SerializeObject(matchType);
            var matchTypeId = RequestHandler.MakeRequest(HttpMethods.POST, tableName, "", "", data);
            var newMatchType = GetData(matchTypeId);
            return JsonConvert.DeserializeObject<List<MatchType>>(newMatchType).First();
        }
        public static bool Update(MatchType matchType)
        {
            var data = JsonConvert.SerializeObject(matchType);
            return RequestHandler.MakeRequest(HttpMethods.PUT, tableName, matchType.Id, "", data) != "0";
        }

        public static bool Update(int matchTypeId, string property, string value)
        {
            var matchType = JsonConvert.DeserializeObject<List<MatchType>>(GetData(matchTypeId)).First();
            matchType.SetProperty(property, value);
            return Update(matchType);
        }
        private static List<MatchType> FilterRemoved(List<MatchType> matchTypes, bool displayRemoved)
        {
            if (displayRemoved)
            {
                return matchTypes;
            }
            return matchTypes?.Where(mt => mt.IsRemoved == false).ToList();
        }
    }
}
