using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp2
{
    public static class AuthenticateHelper
    {

        private static string _authorizationKey;
        private const string Apikey = "740594";
        private const string Apipassword = "yTrEHE";
        private const string GetProductUrl = "https://www.floristone.com/api/rest/flowershop/getproducts";

        public static async Task<HttpClient> GetClient()
        {
            var authData = $"{Apikey}:{Apipassword}";
            _authorizationKey = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

            var client = new HttpClient();
            if (String.IsNullOrEmpty(_authorizationKey))
            {
                _authorizationKey = await client.GetStringAsync(GetProductUrl + "login");
                _authorizationKey = JsonConvert.DeserializeObject<string>(_authorizationKey);
            }
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _authorizationKey);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }


    }
}
