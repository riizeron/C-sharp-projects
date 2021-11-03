using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace First
{
    [DataContract]
    public class Product
    {
        [DataMember]
        public static List<Product> products = new List<Product>();
        [DataMember]
        string name;
        [DataMember]
        string code;

        public Product(string name, string code, int amount, double price, Section parent)
        {
            Parent = parent;
            Name = name;
            Code = code;
            Amount = amount;
            Price = price;
            Parent.Products.Add(this);
            products.Add(this);
            Path = Parent.Path;
            // Сразу проверяем на необходимость занести продукт в csv файл.
            Form1.CsvCreation();
        }
        [DataMember]
        public Section Parent { set; get; }
        [DataMember]
        public double Price { set; get; }
        [DataMember]
        public string Path { get; set; }
        [DataMember]
        public int Amount { get; set; }
        [DataMember]
        public string Code
        {
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Артикул не может быть пустым!");
                }
                foreach (Product pr in Parent.Products)
                {
                    if (value == pr.code)
                    {
                        throw new ArgumentException("Товар с таким артикулом уже существуетв этом разделе!");
                    }
                }
                code = value;
            }
            get
            {
                return code;
            }
        }
        [DataMember]
        public string Name
        {
            set
            {
                if(value.Length==0)
                {
                    throw new ArgumentException("Имя не может быть пустым!");
                }
                foreach (Product pr in Parent.Products)
                {
                    if (value == pr.name)
                    {
                        throw new ArgumentException("Товар с таким именем уже существует в этом разделе!");
                    }
                }
                name = value;
            }
            get
            {
                return name;
            }
        }
    }
}
