using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Scoreboard.Data.enums;
using Scoreboard.Data.models;
using static Scoreboard.Data.data.Filter;

namespace Scoreboard.Data.data.requests
{
    public static class SetData
    {
        private const string tableName = "Sets";

        public static List<Set> Get()
        {
            return Get("", "");
        }

        public static Set Get(int key)
        {
            return Get(key.ToString()).First();
        }

        public static List<Set> Get(FilterObject filter)
        {
            return Get("", CreateFilter(filter));
        }

        public static List<Set> Get(string key, string filter = "")
        {
            string sets = GetData(key, filter);

            return JsonConvert.DeserializeObject<List<Set>>(sets);
        }

        private static string GetData(int key, string filter = "")
        {
            return GetData(key.ToString(), filter);
        }

        private static string GetData(string key, string filter = "")
        {
            return RequestHandler.MakeRequest(HttpMethods.GET, tableName, key, filter);
        }

        public static int Delete(string key, string filter = "")
        {
            string numberOfRowsDeleted = RequestHandler.MakeRequest(HttpMethods.DELETE, tableName, key, filter);
            return int.Parse(numberOfRowsDeleted);
        }

        public static Set Create(Set set)
        {
            var data = JsonConvert.SerializeObject(set);
            var setId = RequestHandler.MakeRequest(HttpMethods.POST, tableName, "", "", data);
            var newSet = GetData(setId);
            return JsonConvert.DeserializeObject<List<Set>>(newSet).First();
        }

        public static bool Update(Set set)
        {
            var data = JsonConvert.SerializeObject(set);
            return RequestHandler.MakeRequest(HttpMethods.PUT, tableName, set.Id, "", data) != "0";
        }

        public static bool Update(int setId, string property, string value)
        {
            var set = JsonConvert.DeserializeObject<List<Set>>(GetData(setId)).First();
            set.SetProperty(property, value);
            return Update(set);
        }

        public static List<Set> GetByMatch(int id)
        {
            var filter = new FilterObject
            {
                Column = "MatchId",
                Value = id.ToString()
            };
            return Get(filter);
        }
    }
}
