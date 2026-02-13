using Microsoft.EntityFrameworkCore;
using NZWalks.api.models.domain;

namespace NZWalks.api.Data
{
    public class NZWalkDbContext : DbContext
    {
        public NZWalkDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {
            
        }

        public DbSet <Difficulty> Difficulties { get; set; }
        public DbSet <Region> Regions { get; set; }
        public DbSet <Walks> Walks { get; set; }

    }
}
