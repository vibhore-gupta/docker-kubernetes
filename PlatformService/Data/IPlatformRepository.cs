using System.Collections.Generic;
using PlaformService.Models;

namespace PlatformService.Data
{
    public interface IPlatformRepository
    {
        bool SaveChanges();
        Platform GetPlatformById(int id);
        IEnumerable<Platform> GetAllPlatforms();
        void CreatePlatform(Platform platform);
    }
}
