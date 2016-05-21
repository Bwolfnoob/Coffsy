using System;

namespace Coffsy.Domain.Entities
{
    public class Address : Entity
    {
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public Carrier Carrier { get; set; }
        public string Obs { get; set; }

        private Address()
        { }

        public Address(string _street, string _district, string _city, double _longitude = 0, double _latitude = 0, string _obs = "")
        {
            if (string.IsNullOrWhiteSpace(_street))
            {
                throw new Exception("A Rua não foi preenchida");
            }
            if (string.IsNullOrWhiteSpace(_district))
            {
                throw new Exception("O Bairro não foi preenchido");
            }
            if (string.IsNullOrWhiteSpace(_city))
            {
                throw new Exception("A Cidade não foi preenchida");
            }
        }
    }
}