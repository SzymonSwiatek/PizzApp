using System.ComponentModel.DataAnnotations;

namespace PizzApp.Models
{
    public class Pizza
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
 

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }



        //public string? Source {
            private static string imgPath = "pizza.jpg";
            public string?  Source {
                get
                {
                    return imgPath;
                }
                set
                {
                    if (value == null) {
                    imgPath = "pizza.jpg";

                } else
                {
                    imgPath = value;
                }
                }
            }
        //}

        public Pizza(string name, string description, decimal price, string src )
        {
            Name = name;
            Description = description;  
            Price = price;  
            Source = src;
        }

        public Pizza()
        {

        }
    }
}
