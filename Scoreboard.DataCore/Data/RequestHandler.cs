using Scoreboard.DataCore.Enums;

namespace Scoreboard.DataCore.Data
{
    public static class RequestHandler
    {
        private static readonly string dataLocation = Settings.Logic.GetSetting("dataLocation");

        public static string MakeRequest(HttpMethods method, ModelType table, string key, string filter, string data = "")
        {
            switch (dataLocation)
            {
                case "http":
                    return Rest.Rest.MakeRestRequest(method, table, key, filter, data);
                case "local":
                    return LocalStorage.LocalStorage.MakeRequest(method, table, key, filter, data);
                default:
                    break;
            }
            return "";
        }

        public static string MakeRequest(HttpMethods method, ModelType table, int key, string filter, string data = "")
        {
            return MakeRequest(method, table, key.ToString(), filter, data);
        }
    }
}
