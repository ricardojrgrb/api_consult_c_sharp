using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using api_user.Models;

namespace api_user.Controllers
{
    public class UsersController : ApiController
    {
        static readonly IUserRepository userRepository = new UserRepository();

        public IEnumerable<User> GetAllUsers()
        {
            return userRepository.GetAll();
        }

        public User GetUser(int id)
        {
            User user = userRepository.Get(id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return user;
        }

        public HttpResponseMessage PostUser(User user)
        {
            user = userRepository.Add(user);
            var response = Request.CreateResponse<User>(HttpStatusCode.Created, user);
            string uri = Url.Link("DefaultApi", new { id = user.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutUser(int id, User user)
        {
            user.Id = id;
            if (!userRepository.Update(user))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteUser(int id)
        {
            User user = userRepository.Get(id);

            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            userRepository.Remove(id);
        }
    }
}
