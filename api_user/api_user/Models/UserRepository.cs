using System;
using System.Collections.Generic;

namespace api_user.Models
{
    public class UserRepository : IUserRepository
    {
        private List<User> users = new List<User>();
        private int _nextId = 1;

        public UserRepository()
        {
            Add(new User { Reason = "Cartao de credito", Value = 1.000M, Date = "01/05/2019" });
            Add(new User { Reason = "Cheque especial", Value = 1.000M, Date = "01/05/2019" });
            Add(new User { Reason = "Emprestimo", Value = 1.000M, Date = "01/05/2019" });
        }

        public User Add(User newUser)
        {
            if (newUser == null)
            {
                throw new ArgumentNullException("newUser");
            }
            newUser.Id = _nextId++;
            users.Add(newUser);
            return newUser;
        }

        public User Get(int id)
        {
            return users.Find(u => u.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return users;
        }

        public void Remove(int id)
        {
            users.RemoveAll(u => u.Id == id);
        }

        public bool Update(User updUser)
        {
            if (updUser == null)
            {
                throw new ArgumentNullException("newUser");
            }

            int index = users.FindIndex(u => u.Id == updUser.Id);

            if (index == -1)
            {
                return false;
            }
            users.RemoveAt(index);
            users.Add(updUser);
            return true;
        }
    }
}
