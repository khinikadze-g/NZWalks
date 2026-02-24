using NZWalks.api.models.domain;

namespace NZWalks.api.Repositories
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image); 
    }
}
