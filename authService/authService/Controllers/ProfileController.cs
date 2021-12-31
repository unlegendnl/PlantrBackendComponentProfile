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
    public class ProfileController : ControllerBase
    {
        private ProfileContext _userContext;

        public ProfileController(ProfileContext userContext)
        {
            _userContext = userContext;
        }

        // GET all
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IEnumerable<Profile> Get() // needs exeptions
        {
            //filter out passwords to garbage
            IEnumerable<Profile> profiles = _userContext.Profiles;
            

            return profiles;
        }

        // GET single
        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")] // needs exeptions
        public Profile Get(int id)
        {
            var profile = _userContext.Profiles.FirstOrDefault(s => s.UserId == id);
            return profile;
        }

        // POST api/<UserController>
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public void Post([Microsoft.AspNetCore.Mvc.FromBody] Profile value) // needs exeptions
        {
            //add profile to user
            _userContext.Profiles.Add(value);
            _userContext.SaveChanges();
        }

        // PUT api/<UserController>/5
        [Microsoft.AspNetCore.Mvc.HttpPut("{id}")]
        public void Put(int id, [Microsoft.AspNetCore.Mvc.FromBody] Profile value)
        {
            var user = _userContext.Profiles.FirstOrDefault(s => s.UserId == id);
            if (user != null)
            {
                
                _userContext.Entry<Profile>(user).CurrentValues.SetValues(value);
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
