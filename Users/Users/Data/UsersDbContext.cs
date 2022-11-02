using System;
using Microsoft.EntityFrameworkCore;
using Users.Models;

namespace Users.Data
{
    public class UsersDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
        }
    }
}

