using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace ConsoleApp2
{
   public static class Helper
    {

       


        public static async Task<GetTotal>  GetTotalBeforeOrder()
        {
            var client = await AuthenticateHelper.GetClient();

            T[] InitializeArray<T>(int length) where T : new()
            {
                T[] array = new T[length];
                for (int i = 0; i < length; ++i)
                {
                    array[i] = new T();
                }

                return array;
            }

            RootObject[] order = InitializeArray<RootObject>(1);

            order[0] = new RootObject
            {
                Price = 49.95,
                Code = "F1-509",
                Recipient = new RECIPIENT
                {
                    Zipcode = "11779"
                }
            };

            //var url = "https://www.floristone.com/api/rest/flowershop/gettotal?products=[{\"PRICE\":39.95,\"RECIPIENT\":{\"ZIPCODE\":\"11779\"},\"CODE\":\"F1-509\"}]";
            var queryString = JsonConvert.SerializeObject(order);
            //Console.WriteLine(queryString);
            //Console.ReadLine();

            var uri=HttpUtility.UrlEncode(queryString);
            //Console.WriteLine(uri);
            //Console.ReadLine();

            //var queryString = "%5B%7B%22PRICE%22%3A39.95%2C%22RECIPIENT%22%3A%7B%22ZIPCODE%22%3A%2211779%22%7D%2C%22CODE%22%3A%22F1-509%22%7D%5D";
            var url = "https://www.floristone.com/api/rest/flowershop/gettotal?products=" +uri;

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                Debug.Assert(true);
            }
            var content = await response.Content.ReadAsStringAsync();
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }
            var deserialized = JsonConvert.DeserializeObject<GetTotal>(content);

            return deserialized;
        }

    }
}
