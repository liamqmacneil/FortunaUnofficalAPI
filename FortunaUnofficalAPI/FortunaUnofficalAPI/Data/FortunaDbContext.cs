using System;
using FortunaUnofficialAPI.Models.Containers;
using FortunaUnofficialAPI.Models.General;
using FortunaUnofficialAPI.Models.SAF;
using Microsoft.EntityFrameworkCore;

namespace FortunaUnofficialAPI
{
    public class FortunaDbContext : DbContext
    {
        private static bool _created = false;

        public static bool skip = false;

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder) => optionbuilder.UseSqlite(@"Data Source=./Fortuna.db");

        public FortunaDbContext()
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }

        public DbSet<AttributeAltArt> AttributeAltArts { get; set; }
        public DbSet<AttributeCreator> AttributeCreator { get; set; }
        public DbSet<AttributesGeneric> AttributesGeneric { get; set; }
        public DbSet<AttributesSpecies> AttributesSpecies { get; set; }

        public DbSet<SpeciesContainer> SpeciesContainers { get; set; }
        public DbSet<FaunaContainer> FaunaContainers { get; set; }
        public DbSet<AiContainer> AiContainers { get; set; }
    }
}