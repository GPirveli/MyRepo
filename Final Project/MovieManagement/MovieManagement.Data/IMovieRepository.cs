using MovieManagement.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Data
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        Task<List<Movie>> GetAllActiveAsync();
        Task<Movie> GetAsyncByTitle(string title);
        Task ChangeActiveStatusAsync(int movieId);
        Task CreateInactive(Movie movie);
    }
}
