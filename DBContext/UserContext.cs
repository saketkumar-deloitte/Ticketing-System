using System;
using System.Collections.Generic;
using System.Linq;
using Ticketing_System.Models;
using Microsoft.EntityFrameworkCore;

public class UserContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<Project> Projects { get; set; }

    public DbSet<Issue> Issues { get; set; }

    public UserContext(DbContextOptions options) : base(options)
    {

    }

}