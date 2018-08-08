using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using FortunaUnofficialAPI.Models;

namespace FortunaUnofficialAPI.Data
{
    public class FortunaDbContext : DbContext
    {
        public DbSet<String> TestBe {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=fortuna.db");
        }
    }
}