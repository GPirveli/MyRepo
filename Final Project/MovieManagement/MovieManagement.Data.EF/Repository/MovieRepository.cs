using Microsoft.EntityFrameworkCore;
using MovieManagement.Domain.POCO;
using MovieManagement.PersistanceDB.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Data.EF.Repository
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieManagementContext context) : base(context)
        {

        }

        public async Task ChangeActiveStatusAsync(int movieId)
        {
            var movieToChange = await GetAsync(movieId);
            movieToChange.IsActive = !movieToChange.IsActive;
            await _context.SaveChangesAsync();
        }

        public async Task CreateInactive(Movie movie)
        {
            await CreateAsync(movie);
            movie.IsActive = false;
            await UpdateAsync(movie);
        }

        public async Task<List<Movie>> GetAllActiveAsync()
        {
            return await _dbSet.Where(x => x.IsActive).ToListAsync();
        }

        public async Task<Movie> GetAsyncByTitle(string title)
        {
            return await _dbSet.SingleOrDefaultAsync(x => x.Title == title);
        }
    }
}
