using System;  
using System.Collections.Generic;   
using System.Linq;
using Ticketing_System.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseAPI;
public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public UserContext(DbContextOptions options):base(options)
        {
            
        }

    }