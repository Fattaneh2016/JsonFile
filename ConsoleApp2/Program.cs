using System;
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

          

            var result = Helper.GetTotalBeforeOrder();

            

            Console.WriteLine(result.Result.Floristoneservicecharge);

            Console.ReadLine();

            var order1 = new Order
            {
                Customer = new Customer
                {
                    Address1 = "45014 gardner drive",
                    Address2 = "",
                    City = "Alpharetta",
                    Country = "US",
                    Email = "fatameri@hotmail.com",
                    Name = "fattaneh",
                    Phone = 47025776,
                    State = "GA",
                    Zipcode = 30009,
                    Ip = "1,1,1,1"
                },

                Product = new Product
                {
                    Code = "F1-252"
                },

                Price = 5.0,
                Deliverydate = "2017-07-16",
                Cardmessage = "Hello API",
                Specialinstructions = "I love you",
                OrderTotal = 1230,
                Recipient = new Recipient
                {
                    Name = "Fati",
                    Address1 = "45014 gardner drive",
                    Address2 = "",
                    City = "Alpharetta",
                    Country = "US",
                    Institution = "freelancer",
                    Phone = 470257762,
                    State = "GA",
                    Zipcode = 30009
                },
                CreditCard = new CreditCard
                {
                    Ccnum = 1234567891234567,
                    Cvv2 = 123,
                    Expmonth = "09",
                    Expyear = 20,
                    Type = "Vi"
                }
            };

        }
    }


    public class Order

    {

        public Product Product { get; set; }



        public Customer Customer { get; set; }


        public Recipient Recipient { get; set; }


        public CreditCard CreditCard { get; set; }



        public double Price { get; set; }


        public string Cardmessage { get; set; }



        public string Deliverydate { get; set; }


        public string Code { get; set; }

        public double OrderTotal { get; set; }


        public string Specialinstructions { get; set; }

    }

    public class Product
    {

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
    public class EditListItemActionModel
    {

        public int Id { get; set; }
        public int State { get; set; }

        public string Prefix { get; set; }
        public string Index { get; set; }
        public string ParentId { get; set; }

        //Id = 1,
        //State = 26,
        //Prefix = "f",
        //Index = "oo",
        //ParentID = null
    }


    public class RECIPIENT
    {
        [JsonProperty("ZIPCODE")]
        public string Zipcode { get; set; }
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

}








