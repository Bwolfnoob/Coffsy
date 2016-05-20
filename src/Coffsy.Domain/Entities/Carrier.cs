using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Coffsy.Domain.Entities
{
    public class Carrier : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string WebSite { get; set; }
        public Address Address { get; set; }
        public ICollection<Rating> Ratings { get; set; }

        private Carrier()
        { }

        public Carrier(string _name, string _email, string _phone, Address _address)
        {
            if (string.IsNullOrWhiteSpace(_name))
            {
                throw new Exception("O Nome não foi preenchido");
            }

            ValidaEmail(_email);
            ValidaPhone(_phone);

            if (_address == null)
            {
                throw new Exception("O Endereco não foi preenchido");
            }


            Name = _name;
            Phone = _phone;
            Address = _address;
        }

        private void ValidaPhone(string phone)
        {
            var regex = new Regex(@"^\(\d{2}\)\d{4}-\d{4}$");
            if (!regex.IsMatch(phone))
            {
                throw new Exception("O Telefone informado esta inválido");
            }
        }

        private void ValidaEmail(string email)
        {
            var regex = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            if (!regex.IsMatch(email))
            {
                throw new Exception("O Email informado esta inválido");
            }
        }
    }
}
