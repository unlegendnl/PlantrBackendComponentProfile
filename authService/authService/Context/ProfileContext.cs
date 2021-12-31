using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using authService.Models;

namespace authService.Context
{
    public class ProfileContext : DbContext
    {
        public ProfileContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Profile> Profiles { get; set; }
    }
}
