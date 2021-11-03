using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Try01
{
    [DataContract]
    public class Client
    {
        [DataMember]
        string fio;
        [DataMember]
        string phone;
        [DataMember]
        string adress;
        [DataMember]
        string email;
        [DataMember]
        string password;
        [DataMember]
        public List<Order> orders = new List<Order>();
        [DataMember]
        public static List<string> emails = new List<string>();
        [DataMember]
        public static List<Client> clients = new List<Client>();

        public Client(string fio, string phone, string adress, string email, string password)
        {
            this.fio = fio;
            this.phone = phone;
            this.adress = adress;
            this.email = email;
            this.password = password;
            clients.Add(this);
        }
        public string Email
        {
            get { return email; }
        }
        public string Password
        {
            get { return password; }
        }
        public string FIO
        {
            get { return fio; }
        }
        public string Phone
        {
            get { return phone; }
        }

    }
}
