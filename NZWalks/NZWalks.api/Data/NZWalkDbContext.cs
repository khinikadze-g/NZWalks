using Microsoft.EntityFrameworkCore;
using NZWalks.api.models.domain;

namespace NZWalks.api.Data
{
    public class NZWalkDbContext : DbContext
    {
        public NZWalkDbContext(DbContextOptions <NZWalkDbContext> dbContextOptions) : base(dbContextOptions) 
        {
            
        }

        public DbSet <Difficulty> Difficulties { get; set; }
        public DbSet <Region> Regions { get; set; }
        public DbSet <Walks> Walks { get; set; }
        public DbSet <Image> Images { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulties = new List<Difficulty>()
            {
                new Difficulty
                {
                    Id = Guid.Parse("7c98793e-c040-464e-bd5a-712800f50b35"),
                    Name = "Easy"
                },
                new Difficulty
                {
                    Id = Guid.Parse("a98f1ddd-6ecb-49f1-b84e-a2eb9d17a460"),
                    Name = "Medium"
                },
                new Difficulty
                {
                    Id = Guid.Parse("1e38a9ec-9a56-4a51-b349-a20a4106dfb2"),
                    Name = "Hard"
                }


            };
           
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.Parse("f7248fc3-2585-4efb-8d1d-1c555f4087f6"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("14ceba71-4b51-4777-9b17-46602cf66153"),
                    Name = "Bay Of Plenty",
                    Code = "BOP",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("f077a22e-4248-4bf6-b564-c7cf4e250263"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = null
                },
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }

    }
}
