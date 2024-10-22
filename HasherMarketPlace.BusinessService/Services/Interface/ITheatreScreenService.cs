using HasherMarketPlace.DBHelper.Entities;
using HasherMarketPlace.ModelHelper.DTO;

namespace HasherMarketPlace.BusinessService.Services.Interface
{
    public interface ITheatreScreenService
    {
        Task<List<TheatreScreenDto>> GetAllTheatreScreenAsync();
        Task<List<TheatreScreen>> GetAllCoreTheatreScreenAsync();
        Task<List<TheatreScreenTotalDto>> GetSpecificTheatreScreenDetailsAsync(List<int> theatreScreenIds);
        Task<bool> AddToTheatreScreenAsync(AddTheatreScreenDto theatreScreenDto);
        Task<bool> UpdateTheatreScreenAsync(UpdateTheatreScreenDto theatreScreenDto);
        Task<bool> DeleteTheatreScreenAsync(int theatreScreenId);
    }
}
