using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Try01
{
    /// <summary>
    /// Тут, как и во всех остальных классах объектов, пояснять нечего, все примитивно.
    /// </summary>
    [DataContract]
    class Seller
    {
        [DataMember]
        string FIO;
        [DataMember]
        string phone;
        [DataMember]
        string adress;
        [DataMember]
        string email;
        [DataMember]
        string password;
        [DataMember]
        public static List<Seller> sellers = new List<Seller>();
        public Seller(string FIO, string phone, string adress, string email, string password)
        {
            this.FIO = FIO;
            this.phone = phone;
            this.adress = adress;
            this.email = email;
            this.password = password;
            sellers.Add(this);
        }
        public string Email
        {
            get { return email; }
        }
        public string Password
        {
            get { return password; }
        }
    }
}
