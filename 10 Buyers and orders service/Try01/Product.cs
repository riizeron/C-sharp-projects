using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Try01
{
    [DataContract]
    public class Product
    {
        [DataMember]
        int price;
        [DataMember]
        string name;
        [DataMember]
        public static List<Product> products = new List<Product>();
        public Product(string name, int price)
        {
            this.name = name;
            this.price = price;
            products.Add(this);
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
