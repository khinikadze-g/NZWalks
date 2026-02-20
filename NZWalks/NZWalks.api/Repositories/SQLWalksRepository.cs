using Microsoft.EntityFrameworkCore;
using NZWalks.api.Data;
using NZWalks.api.models.domain;

namespace NZWalks.api.Repositories
{
    public class SQLWalksRepository : IWalkRepository
    {
        private readonly NZWalkDbContext dbContext;

        public SQLWalksRepository(NZWalkDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Walks> CreateAsync(Walks walks)
        {
            await dbContext.Walks.AddAsync(walks);
            await dbContext.SaveChangesAsync();
            return walks;
        }

        public async Task<Walks?> DeleteAsync(Guid id)
        {
            var existingWalk = await dbContext.Walks.FirstOrDefaultAsync(x => x.ID == id);
            if (existingWalk == null)
            {
                return null;
            }
            dbContext.Walks.Remove(existingWalk);
            await dbContext.SaveChangesAsync();
            return existingWalk;
        }

        public async Task<List<Walks>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool IsAscending = true, int pageNumber = 1, int pageSize = 1000)
        {
            var walks = dbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                { 
                    walks = walks.Where(x => x.Name.ToLower().Contains(filterQuery));
                }
            }
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = IsAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
                }
                else if (sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
                {
                    walks = IsAscending ? walks.OrderBy(x => x.LengthInKm) : walks.OrderByDescending(x => x.LengthInKm);
                }

            }
            var skipResult = (pageNumber - 1) * pageSize;
            return await walks.Skip(skipResult).Take(pageSize).ToListAsync();
            
            
            //return await dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();

        }

        public async Task<Walks> GetByIdAsync(Guid id)
        {
            return await dbContext.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.ID == id);

        }

        public async Task<Walks?> UpdateAsync(Guid id, Walks walks)
        {
            var existingWalk = await dbContext.Walks.FirstOrDefaultAsync(x => x.ID == id);
            if (existingWalk == null)
            {
                return null;
            }
            existingWalk.Name = walks.Name;
            existingWalk.Description = walks.Description;
            existingWalk.LengthInKm = walks.LengthInKm;
            existingWalk.WalkImageUrl = walks.WalkImageUrl;
            existingWalk.DifficultyId = walks.DifficultyId;
            existingWalk.RegionId = walks.RegionId;
            await dbContext.SaveChangesAsync();
            return existingWalk;
        }
    }
}
