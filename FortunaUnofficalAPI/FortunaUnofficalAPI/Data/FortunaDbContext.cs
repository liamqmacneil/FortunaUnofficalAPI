using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using FortunaUnofficalAPI.Models;

namespace FortunaUnofficalAPI.Data
{
    public class FortunaDbContext : DbContext
    {
        public DbSet<String> SpeciesUrls {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=fortuna.db");
        }
    }
}