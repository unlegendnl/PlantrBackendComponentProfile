using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using authService.Context;
using authService.Models;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using Microsoft.AspNetCore.Identity;
using authService.Security;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace authService
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        private UserContext _userContext;

        public UserController(UserContext userContext)
        {
            _userContext = userContext;
        }

        // GET all
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IEnumerable<User> Get() // needs exeptions
        {
            //filter out passwords to garbage
            IEnumerable<User> users = _userContext.Users;
            foreach (User val in users)
            {
                val.Password = "bee movie";
            }

            return users;
        }

        // GET single
        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")] // needs exeptions
        public User Get(int id)
        {
            var user = _userContext.Users.FirstOrDefault(s => s.UserId == id);
            user.Password = "bee movie 2";
            return user;
        }

        // POST api/<UserController>
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public void Post([Microsoft.AspNetCore.Mvc.FromBody] User value) // needs exeptions
        {
            IEnumerable<User> users = _userContext.Users;
            foreach (User val in users)
            {
                //UserManager. 
                if(val.UserName == value.UserName) // no duplucate usernames
                {
                    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.UnprocessableEntity));
                }
            }
            value.Password = SecurePasswordHasher.Hash(value.Password);
            _userContext.Users.Add(value);
            _userContext.SaveChanges();
        }

        // PUT api/<UserController>/5
        [Microsoft.AspNetCore.Mvc.HttpPut("{id}")]
        public void Put(int id, [Microsoft.AspNetCore.Mvc.FromBody] User value)
        {
            var user = _userContext.Users.FirstOrDefault(s => s.UserId == id);
            if (user != null)
            {
                
                _userContext.Entry<User>(user).CurrentValues.SetValues(value);
                _userContext.SaveChanges();
            }
        }

        // DELETE api/<UserController>/5
        [Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]
        public void Delete(int id)
        {
        }







    }
}
