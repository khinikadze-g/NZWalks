using AutoMapper;
using NZWalks.api.models.domain;
using NZWalks.api.models.DTO;
namespace NZWalks.api.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();
            CreateMap<UpdateRegionDto, Region>().ReverseMap();
            CreateMap<Walks, AddWalkRequestDto>().ReverseMap();
            CreateMap<Walks, WalksDto>().ReverseMap();
            CreateMap<Difficulty, DiffucultyDto>().ReverseMap();
            CreateMap<Walks, UpdateWalkDto>().ReverseMap();

        }

    }
}
