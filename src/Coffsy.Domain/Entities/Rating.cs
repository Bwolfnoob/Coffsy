using System;

namespace Coffsy.Domain.Entities
{
    public class Rate : Entity
    {
        public int Point { get;private set; }
        public User User { get;private set; }
        private Rate()
        { }

        public Rate(int _rate, User _user)
        {
            if (_user == null)
            {
                throw new Exception("Usuário não informado");
            }

            Point = _rate;
            User = _user;
        }
    }
}