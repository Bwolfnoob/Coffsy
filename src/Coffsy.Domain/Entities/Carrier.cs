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
        public ICollection<Rate> Ratings { get; set; }

        private Carrier()
        { }

        public Carrier(string _name, string _email, string _phone, Address _address)
        {
            if (string.IsNullOrWhiteSpace(_name))
            {
                throw new Exception("O Nome não foi preenchido");
            }

            if (IsNotValidPhone(_phone))
            {
                throw new Exception("O Telefone informado esta inválido");
            }

            if (IsNotValidEmail(_email))
            {
                throw new Exception("O Email informado esta inválido");
            }

            if (_address == null)
            {
                throw new Exception("O Endereco não foi preenchido");
            }

            Name = _name;
            Phone = _phone;
            Address = _address;
        }

        private bool IsNotValidPhone(string phone)
        {
           var regex = new Regex(@"^\(\d{2}\)\d{4}-\d{4}$");
           return !regex.IsMatch(phone);
        }

        private bool IsNotValidEmail(string email)
        {
            var regex = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            return !regex.IsMatch(email);
        }
    }
}
