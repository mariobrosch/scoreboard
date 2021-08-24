using System.Configuration;
using ttManager.Data.data.Rest;
using ttManager.Data.data.LocalStorage;
using ttManager.Data.enums;

namespace ttManager.Data
{
    public static class RequestHandler
    {
        private static readonly string dataLocation = ConfigurationManager.AppSettings["dataLocation"];

        public static string MakeRequest(HttpMethods method, string table, string key, string filter, string data = "")
        {
            switch (dataLocation)
            {
                case "http":
                    return Rest.MakeRestRequest(method, table, key, filter, data);
                case "local":
                    return LocalStorage.MakeRequest(method, table, key, filter, data);
            }
            return "";
        }

        public static string MakeRequest(HttpMethods method, string table, int key, string filter, string data = "")
        {
            return MakeRequest(method, table, key.ToString(), filter, data);
        }
    }
}
