using api2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api2.models
{
    public class IUserRepos : UserRepos
    {
        private readonly AppDbContext db;
        public IUserRepos(AppDbContext _db)
        {
            db = _db;
        }

        public void EditUser(User user)
        {
            db.Users.Update(user);
            db.SaveChanges();
        }

        public User GetUser(string id)
        {
            return db.Users.Find(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return db.Users.ToList();
        }

        public string Login(string Email, string Password)
        {
            var user=db.Users.Where(x => x.Email == Email && x.Password == Password).ToList();
               if(user.Count==1)
            {
                return user[0].Id;
            }
            else
            {
                return "";
            }
        }

        public void Register(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void RemoveAccount(User user)
        {
            db.Users.Remove(user);
            db.SaveChanges();
        }
    }
}
