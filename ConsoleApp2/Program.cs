using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order
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
            var json = new JavaScriptSerializer().Serialize(order);
            Debug.WriteLine(json);
            Console.WriteLine(json);
            Console.ReadLine();
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

}
