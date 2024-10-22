using HasherMarketPlace.DBHelper.Entities;
using HasherMarketPlace.ModelHelper.DTO;

namespace HasherMarketPlace.BusinessService.Services.Interface
{
    public interface IMovieService
    {
        Task<List<MovieDto>> GetAllMovieNameAsync();
        Task<List<MovieMaster>> GetSpecificMovieDetailsAsync(List<int> movieIds);
        Task<List<MovieDto>> GetSpecificMovieDetailsDtoAsync(List<int> movieIds);
        Task<bool> AddToMovieAsync(AddMovieDto movieDto);
        Task<bool> UpdateMovieAsync(UpdateMovieDto movieDto);
        Task<bool> DeleteMovieAsync(int movieId);
    }
}
