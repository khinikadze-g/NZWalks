using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NZWalks.api.Data;
using NZWalks.api.models.domain;

namespace NZWalks.api.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NZWalkDbContext dbContext;

        public SQLRegionRepository(NZWalkDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Region> CreateAsync(Region region)
        {   
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
                
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var existing = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existing == null)
            {
                return null;
            }
            dbContext.Remove(existing);
            await dbContext.SaveChangesAsync();
            return existing;

        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null;
            }
            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.RegionImageUrl = region.RegionImageUrl;

            await dbContext.SaveChangesAsync();
            return existingRegion;
        }

    }
}
