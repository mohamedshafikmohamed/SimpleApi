using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api2.models
{
    public interface UserRepos
    {
        /*  public string Login(string Email,string Password);
          public void Register(User user);
          public void RemoveAccount(User user);
          public void EditUser(User user);
          public User GetUser(string id);
          public IEnumerable<User> GetUsers();*/


       
        public IdentityUser GetUser(string id);
        Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model);

        Task<UserManagerResponse> LoginUserAsync(LoginViewModel model);

        Task<UserManagerResponse> ConfirmEmailAsync(string userId, string token);

        Task<UserManagerResponse> ForgetPasswordAsync(string email);

        Task<UserManagerResponse> ResetPasswordAsync(ResetPasswordViewModel model);
        public IEnumerable<Project> SearchForProject(string Title, string Email);
    }
}
