using AutoMapper;
using NZWalks.api.models.domain;

namespace NZWalks.api.Repositories
{
    public interface IWalkRepository
    {
        Task<Walks> CreateAsync(Walks walks);
        Task<List<Walks>>GetAllAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool IsAscending = true,
            int pageNumber = 1, int pageSize = 1000);
        Task<Walks?> GetByIdAsync(Guid id);
        Task<Walks?> UpdateAsync(Guid id, Walks walks);
        Task<Walks?> DeleteAsync(Guid id);
    };
}
