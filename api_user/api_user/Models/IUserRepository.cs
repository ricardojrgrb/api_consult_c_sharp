using System;
using System.Collections.Generic;

namespace api_user.Models
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User Get(int id);
        User Add(User newUser);
        void Remove(int id);
        bool Update(User updUser);
    }
}
