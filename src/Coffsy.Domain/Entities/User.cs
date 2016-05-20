using System;
using System.Text.RegularExpressions;

namespace Coffsy.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        private User()
        {

        }

        public User(string _name, string _password, string _email, string _passwordConf)
        {
            if (string.IsNullOrWhiteSpace(_name))
            {
                throw new Exception("O Nome não foi preenchido");
            }

            if (string.IsNullOrWhiteSpace(_password) || string.IsNullOrWhiteSpace(_passwordConf))
            {
                throw new Exception("O Senha não foi preenchido");
            }

            if (_password != _passwordConf)
            {
                throw new Exception("As senhas não são iguais");
            }

            ValidaEmail(_email);

            Name = _name;
            Password = _password;
            Email = _email;
        }

        private void ValidaEmail(string email)
        {
            var regex = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            if (!regex.IsMatch(email))
            {
                throw new Exception("O Email informado está inválido");
            }
        }
    }
}