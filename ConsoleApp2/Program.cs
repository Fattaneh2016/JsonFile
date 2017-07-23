using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Web;
using Newtonsoft.Json;

namespace ConsoleApp2
{
    class Program
    {

        static void Main(string[] args)
        {

            Helper.Addcart();

            //var result = Helper.GetTotalBeforeOrder();
            //Console.WriteLine(result.Result.Floristoneservicecharge);

            //var result = Helper.PlaceOrder();
            //Console.WriteLine(result.Result.OrderNo.ToString());
            //Console.ReadLine();


            //var result = Helper.GetShoppingCart(CartItem.CartSessionId);


            //Console.WriteLine((CartItem.CartSessionId));
            //Console.WriteLine(result.Result.Products.Count);
            //Console.WriteLine(result.Result.ProductCount);
            //Console.ReadLine();


           
            var resultOneProduct =  Helper.GetSingleProduct("F1-252");

            foreach (var cartitem in resultOneProduct.Result.Products)
            {


                Console.WriteLine(cartitem.Code);
                Console.WriteLine(cartitem.Description);
                Console.WriteLine(cartitem.Price);
            }
            Console.ReadLine();

        }

        }
    }



    public class Order

    {

        public int OrderNo { get; set; }

        public string Code { get; set; }
        public double Price { get; set; }
        public double OrderTotal { get; set; }
        public string Specialinstructions { get; set; }
        public string Cardmessage { get; set; }
        public string Deliverydate { get; set; }

        public Recipient Recipient { get; set; }
        //public Customer Customer { get; set; }
        //public Product Product { get; set; }
        //public CreditCard CreditCard { get; set; }

        public Error OrderErrors { get; set; }


    }

    public class Error
    {
        public List<string> Errors { get; set; }
    }

    public  class Product
    {

        [JsonProperty("CODE")]
        public string Code { get; set; }


        public string Small { get; set; }


        public double Price { get; set; }


        public string Description { get; set; }


        public string Dimension { get; set; }

        public string Large { get; set; }


        public string Service { get; set; }


        public string Name { get; set; }

    }

    public class Customer
    {

        public string Name { get; set; }


        public string Email { get; set; }


        public string Address1 { get; set; }



        public string Address2 { get; set; }


        public string City { get; set; }


        public string State { get; set; }
        public string Country { get; set; }


        public int Phone { get; set; }


        public int Zipcode { get; set; }


        public string Ip { get; set; }

    }


    public class CreditCard
    {

        public string Expmonth { get; set; }


        public int Expyear { get; set; }


        public long Ccnum { get; set; }


        public int Cvv2 { get; set; }


        public string Type { get; set; }

    }


    public class Recipient
    {

        public int Zipcode { get; set; }


        public int Phone { get; set; }

        public string Address2 { get; set; }


        public string State { get; set; }


        public string Address1 { get; set; }


        public string Name { get; set; }

        public string Country { get; set; }


        public string Institution { get; set; }


        public string City { get; set; }
    }


    public class GetTotal
    {

        //"https://www.floristone.com/api/rest/flowershop/gettotal?products=[{\"PRICE\":39.95,\"RECIPIENT\":{\"ZIPCODE\":\"11779\"},\"CODE\":\"F1-509\"}]";
        [JsonProperty("TAXTOTAL")]
        public double Taxtotal { get; set; }

        [JsonProperty("SUBTOTAL")]
        public double Subtotal { get; set; }

        [JsonProperty("ORDERTOTAL")]
        public double Ordertotal { get; set; }

        [JsonProperty("FLORISTONETAX")]
        public int Floristonetax { get; set; }

        [JsonProperty("ORDERNO")]
        public int Orderno { get; set; }

        [JsonProperty("FLORISTONESERVICECHARGE")]
        public double Floristoneservicecharge { get; set; }




        //"FLORISTONESERVICECHARGE": 14.99,
        //"SUBTOTAL": 39.95,
        //"FLORISTONETAX": 0,
        //"ORDERTOTAL": 54.94,
        //"ORDERNO": 0,
        //"MASTERSERVICECHARGE": 0,
        //"AFFILIATESERVICECHARGE": 0,
        //"TAXTOTAL": 0,
        //"DISCOUNT": 0

    }


    public class BeforeOrder
    {
        [JsonProperty("CODE")]
        public string Code { get; set; }


        [JsonProperty("PRICE")]
        public double Price { get; set; }


        [JsonProperty("ZIPCODE")]
        public double ZipCode { get; set; }

    }



    public class RECIPIENT
    {
        [JsonProperty("ZIPCODE")]
        public string Zipcode { get; set; }

        [JsonProperty("PHONE")]
        public int Phone { get; set; }

        [JsonProperty("ADDRESS2")]
        public string Address2 { get; set; }

        [JsonProperty("STATE")]
        public string State { get; set; }

        [JsonProperty("ADDRESS1")]
        public string Address1 { get; set; }

        [JsonProperty("NAME")]
        public string Name { get; set; }

        [JsonProperty("COUNTRY")]
        public string Country { get; set; }

        [JsonProperty("INSTITUTION")]
        public string Institution { get; set; }

        [JsonProperty("CITY")]
        public string City { get; set; }
    }

    public class RootObject
    {
        [JsonProperty("PRICE")]
        public double Price { get; set; }

        [JsonProperty("RECIPIENT")]
        public RECIPIENT Recipient { get; set; }

        [JsonProperty("CODE")]
        public string Code { get; set; }
    }


    public class AllProducts

    {
        [JsonProperty("TOTAL")]
        public int Total { get; set; }

        [JsonProperty("PRODUCTS")]
        public List<Product> Products { get; set; }

    }

    public class CartItem
    {
        public static string CartSessionId { get; set; }
        public static bool CartExist { get; set; }
        public static bool AddToCartVisible { get; set; }


        [JsonProperty("SESSIONID")]
        public string SessionId { get; set; }

        [JsonProperty("STATUS")]
        public string Status { get; set; }

        [JsonProperty("ACTION")]
        public string Action { get; set; }

        [JsonProperty("QUANTITY")]
        public int Quantity { get; set; }

        //the virtual keyword allows you to override the property in sub-classes       
        [JsonProperty("PRODUCTS")]
        public List<Product> Products { get; set; }


       

        [JsonProperty("PRODUCTCOUNT")]
        public int ProductCount { get; set; }

        [JsonProperty("CARTITEMS")]
        public List<string> CartItems { get; set; }

    }








