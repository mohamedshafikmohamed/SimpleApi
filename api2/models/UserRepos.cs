using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api2.models
{
    public interface UserRepos
    {
        public string Login(string Email,string Password);
        public void Register(User user);
        public void RemoveAccount(User user);
        public void EditUser(User user);
        public User GetUser(string id);
        public IEnumerable<User> GetUsers();
    }
}
