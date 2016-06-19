using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CycloidServer.Models
{
    public class CycloidContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Device> Device { get; set; }
        public DbSet<Token> Token { get; set; }
    }
}