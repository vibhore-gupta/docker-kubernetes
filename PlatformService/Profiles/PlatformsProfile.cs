using AutoMapper;
using PlaformService.Models;
using PlatformService.Dtos;

namespace PlatformSerice.Profiles
{
    public class PlatformsProfile : Profile
    {
        public PlatformsProfile()
        {
            // source -> target
            CreateMap<Platform, PlatformReadDto>();
            CreateMap<PlatformCreateDto, Platform>();
        }
    }
}