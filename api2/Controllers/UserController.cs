using api2.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepos IUserrepo;
        //   [HttpGet("{id}")]
        public UserController(UserRepos _IUserrepo)
        {
            IUserrepo = _IUserrepo;
        }
        [HttpGet]
        public ActionResult<IEnumerable<product>> Getusers()
        {
            return Ok(IUserrepo.GetUsers());
        }
        [HttpGet("{Id}")]
        public ActionResult<product> GetUser(string id)
        {
            return Ok(IUserrepo.GetUser(id));
        }
        [HttpPost]
        public ActionResult<User> Register(User user)
        {
            IUserrepo.Register(user);
            return Ok();
        }
        [HttpPut]
        public ActionResult<User> EditUser(User user)
        {
            IUserrepo.EditUser(user);

            return Ok();
        }

        [HttpDelete("{Id}")]
        public ActionResult<User> RemoveAccount(string id)
        {
            IUserrepo.RemoveAccount(IUserrepo.GetUser(id));

            return Ok();
        }
    }
}
