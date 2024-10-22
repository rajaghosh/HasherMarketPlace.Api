using HasherMarketPlace.DBHelper.Entities;
using HasherMarketPlace.ModelHelper.DTO;

namespace HasherMarketPlace.BusinessService.Services.Interface
{
    public interface IMovieListingService
    {
        Task<List<MovieListingDto>> GetAllMovieListingAsync();
        Task<List<MovieListing>> GetAllCoreMovieListingAsync();
        Task<MovieListing> GetSpecificMovieListingDetailsAsync(ListingSearch listingDto);
        Task<bool> AddToMovieListingAsync(AddMovieListingDto movieListingDto);
        Task<bool> UpdateMovieListingAsync(UpdateMovieListingDto movieListingDto);
        Task<bool> DeleteMovieListingAsync(int movieListingId);
    }
}
