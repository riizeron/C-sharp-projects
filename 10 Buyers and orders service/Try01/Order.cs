using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Try01
{
    /// <summary>
    /// Перечисление, относящееся к заказу.
    /// Отражает статус заказа.
    /// </summary>
    [Flags]
    public enum Status
    {
        None = 0,
        Proceed = 1,
        Paid = 2,
        Shipped = 4,
        Executed = 8
    }

    [DataContract]
    public class Order
    {
        static Random rnd = new Random();
        [DataMember]
        List<Product> products = new List<Product>();
        [DataMember]
        int price;
        [DataMember]
        int amount;
        [DataMember]
        int number;
        [DataMember]
        DateTime time;
        [DataMember]
        Status status;
        [DataMember]
        Client client;
        [DataMember]
        public static List<Order> orders = new List<Order>();

        public Order(Client client, List<Product> products)
        {
            this.client = client;
            this.time = DateTime.Now;
            this.products = products;
            this.price = PriceCalculating();
            this.status = Status.None;
            this.amount = products.Count;
            this.number = rnd.Next();
            client.orders.Add(this);
            orders.Add(this);
        }
        int PriceCalculating()
        {
            int price = 0;
            foreach (Product pr in products)
            {
                price += pr.Price;
            }
            return price;
        }
        public int Number
        {
            get { return number; }
        }
        public int Price
        {
            get { return price; }
        }
        public int Amount
        {
            get { return amount; }
        }
        public Client Client
        {
            get { return client; }
        }
        public Status Status
        {
            get { return status; }
            set { status = value; }
        }


    }
}
