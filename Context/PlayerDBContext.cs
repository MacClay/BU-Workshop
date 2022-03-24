using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetRPG.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetRPG.Context
{
    public class PlayerDBContext : DbContext
    {
        public PlayerDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Player> players {get; set;}
    }
}