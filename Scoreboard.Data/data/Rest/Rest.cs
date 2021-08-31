using System;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Scoreboard.Data.enums;

namespace Scoreboard.Data.data.Rest
{
    class Rest
    {
        private static readonly string baseUrl = ConfigurationManager.AppSettings["baseUrl"];

        public static string MakeRestRequest(HttpMethods method, string table, string key, string filter, string data = "")
        {
            //ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            string url = baseUrl;

            switch (method)
            {
                case HttpMethods.GET:
                case HttpMethods.DELETE:
                case HttpMethods.PUT:
                    if (!string.IsNullOrEmpty(filter))
                    {
                        url = Path.Combine(url, table);
                    }
                    else
                    {
                        url = Path.Combine(url, table, key);
                    }
                    break;
                case HttpMethods.POST:
                    url = Path.Combine(url, table);
                    break;
            }

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(url)
            };

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            string responseContent;
            HttpResponseMessage response = null;

            switch (method) {
                case HttpMethods.GET:
                    response = client.GetAsync(filter).Result;
                    break;
                case HttpMethods.DELETE:
                    response = client.DeleteAsync(filter).Result;
                    break;
                case HttpMethods.POST:
                    HttpContent _BodyPost = new StringContent(data);
                    response = client.PostAsync(url, _BodyPost).Result;
                    break;
                case HttpMethods.PUT:
                    HttpContent _BodyPut = new StringContent(data);
                    response = client.PutAsync(url, _BodyPut).Result;
                    break;
            }

            if (response == null)
            {
                return "";
            }

            if (response.IsSuccessStatusCode)
            {
                responseContent = response.Content.ReadAsStringAsync().Result ;             
            }
            else
            {
                responseContent = string.Concat("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            client.Dispose();
            return responseContent;
        }
    }
}
