using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using authService.Context;
using authService.Models;

namespace authService.Context
{
    public static class Seed
    {
        public static void SeedDb(this UserContext dbContext)
        {
            if (!dbContext.Users.Any())
            {
                dbContext.Users.Add(new User
                {
                    UserName = "miguel",
                    Password = "jemoeder",
                    Admin = true,
                    Email = "msc@msc.com"

                    //uid auto generated
                });;
                dbContext.Users.Add(new User
                {
                    UserName = "johnny",
                    Password = "jemoeder",
                    Admin = false,
                    Email = "msc@msc.com"
                });
                dbContext.Users.Add(new User
                {
                    UserName = "hans",
                    Password = "jemoeder",
                    Admin = false,
                    Email = "msc@msc.com"
                });

                dbContext.SaveChanges();
            }
        }
    }
}
