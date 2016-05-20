using System;

namespace Coffsy.Domain.Entities
{
    public class Rating : Entity
    {
        public int Rate { get; set; }
        public User User { get; set; }
        private Rating()
        { }

        public Rating(int _rate, User _user)
        {
            if (_user == null)
            {
                throw new Exception("Usuário não informado");
            }

            Rate = _rate;
            User = _user;
        }


    }
}