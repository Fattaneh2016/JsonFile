using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace ConsoleApp2
{
   public static class Helper
    {

        public static async Task<AllProducts> GetSingleProduct(string code)

        {

            try
            {
                var url = "https://www.floristone.com/api/rest/flowershop/getproducts?code=" + code;
                HttpClient client = await AuthenticateHelper.GetClient();
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    Debug.Assert(true);
                }

                var content = await response.Content.ReadAsStringAsync();

                var deserialized = JsonConvert.DeserializeObject<AllProducts>(content);
                return deserialized;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        public static void Addcart()

        {
            
                switch (CartItem.CartExist)
                {
                    case true:
                        var all = ShoppingCartItems("F1-252");
                        //await DisplayAlert("all.Status", all.Status.ToString(), "", "Ok");

                        break;
                    default:
                        CartItem.CartExist = false;
                        var resp =  AddNewCartItem();
                        CartItem.CartSessionId = resp.Result.SessionId;

                   
                        var allp = ShoppingCartItems("F1-252");
                        Console.WriteLine(allp.Status.ToString());

                    //await DisplayAlert("all.Status", allp.Status.ToString(), "", "Ok");

                    //await DisplayAlert("Add to cart", "Flower is added to cart", "Ok");
                    //await DisplayAlert("added ", resp.Status, "Ok", "Cancel");
                    CartItem.CartExist = true;
                        break;

                }
                //CartId.Text = CartItem.CartSessionId;
                //await Navigation.PushAsync( new MainTabPage());
            
        }


        public static async Task<CartItem> AddNewCartItem()
        {
            var url = "https://www.floristone.com/api/rest/shoppingcart";
            var client = await AuthenticateHelper.GetClient();
            var mycart = new CartItem();


            var response = await client.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(mycart),
                    Encoding.UTF8, "application/json"));
            return JsonConvert.DeserializeObject<CartItem>(await response.Content.ReadAsStringAsync());
        }

       

        public static async Task ShoppingCartItems(string productcode)
        {
            try
            {
                //https://www.floristone.com/api/rest/shoppingcart?sessionid"
                var client = await AuthenticateHelper.GetClient();
                //TODO: use Put to Add a cartitem
                var cartItem = new CartItem
                {
                    SessionId = CartItem.CartSessionId,
                    CartItems = new List<string>(new[] { productcode }),
                    Action = "add",
                    Quantity = 1
                };
                string url = "https://www.floristone.com/api/rest/shoppingcart?sessionid=" + CartItem.CartSessionId + "&productcode=" + productcode + "&action=add";
                var response = await client.PutAsync(url, new StringContent(
                    JsonConvert.SerializeObject(cartItem),
                    Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    Debug.Assert(true);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }

        }

        public static async Task<CartItem> GetShoppingCart(string sessionId)

        {
            try
            {
                HttpClient client = await AuthenticateHelper.GetClient();
                string url = "https://www.floristone.com/api/rest/shoppingcart?sessionid=" + sessionId;

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
                var deserialized = JsonConvert.DeserializeObject<CartItem>(content);
                return deserialized;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }


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


        public static async Task<Order> PlaceOrder()

        {
            try
            {
                var client = await AuthenticateHelper.GetClient();
                //TODO: use post to place order

                T[] InitializeArray<T>(int length) where T : new()
                {
                    T[] array = new T[length];
                    for (int i = 0; i < length; ++i)
                    {
                        array[i] = new T();
                    }

                    return array;
                }

                Order[] order1 = InitializeArray<Order>(1);

                order1[0] = new Order
                {                  
                    Code = "F1-509",
                    Price = 49.95,
                    Deliverydate = "2017-08-10",
                    Cardmessage = "This is a card message",
                    Specialinstructions = "",
                    
                    Recipient = new Recipient
                    {
                        Name = "Phil FloristOne",
                        Address1 = "123 Big St",
                        Address2 = "",
                        City = "Wilmington",
                        Country = "US",
                        Institution = "",
                        Phone = 1234567890,
                        State = "DE",
                        Zipcode = 11779
                    }
                    

                };

                
               var  customer = new Customer
                {
                    Address1 = "123 Big St",
                    Address2 = "",
                    City = "Wilmington",
                    Country = "US",
                    Email = "phil@floristone.com",
                    Name = "John Doe",
                    Phone = 1234567890,
                    State = "DE",
                    Zipcode = 11779,
                    Ip = "1,1,1,1"
                };

                var creditCard = new CreditCard
                {
                    Ccnum = 1234512345123455,
                    Cvv2 = 123,
                    Expmonth = "03",
                    Expyear = 18,
                    Type = "Vi"
                };


                var queryStringCustomer = JsonConvert.SerializeObject(customer);
                var queryStringCard = JsonConvert.SerializeObject(creditCard);
                var queryStringOrder1 = JsonConvert.SerializeObject(order1);

               Debug.Print(queryStringCustomer);
                Debug.Print(queryStringCard);
                Debug.Print(queryStringOrder1);

                var uriOrder = HttpUtility.UrlEncode(queryStringOrder1);
                var uriCustomer = HttpUtility.UrlEncode(queryStringCustomer);
                var uricard = HttpUtility.UrlEncode(queryStringCard);
                //Console.WriteLine(uri);
                //Console.ReadLine();

                var placeOrderUrl = "https://www.floristone.com/api/rest/flowershop/placeorder?products="+ uriOrder +"&customer=" + uriCustomer +"&ccinfo=" + uricard + "&OrderTotal=" + 64.94;

                var response = await client.PostAsync(placeOrderUrl,
                    new StringContent(JsonConvert.SerializeObject(order1),
                        Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    Debug.Assert(true);
                }
                return JsonConvert.DeserializeObject<Order>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.Source + e.HelpLink); 
                throw;
            }
        }
   }
}
