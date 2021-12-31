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
        public static void SeedDb(this ProfileContext dbContext)
        {
            if (!dbContext.Profiles.Any())
            {
                dbContext.Profiles.Add(new Profile
                {
                    Biography = "plant lover to the max",
                    ProfilePicture = "1.jpeg"
                });
                dbContext.Profiles.Add(new Profile
                {
                    Biography = "wokkels zijn lekker",
                    ProfilePicture = "2.jpeg"
                });
                dbContext.Profiles.Add(new Profile
                {
                    Biography = "johnny is on another level",
                    ProfilePicture = "3.jpeg"
                });

                dbContext.SaveChanges();
            }
        }
    }
}
