using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HasherMarketPlace.DBHelper.DatabaseContext;
using HasherMarketPlace.DBHelper.DatabaseContext.Repo;

namespace HasherMarketPlace.DBHelper
{
    public static class DependencyInjector
    {
        public static void RegisterDbHelperDependencies(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<MovieTicketDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MovieTicketDb")));

            services.AddScoped(typeof(IMovieTicketRepository<>), typeof(MovieTicketRepository<>));
        }        
    }
}
