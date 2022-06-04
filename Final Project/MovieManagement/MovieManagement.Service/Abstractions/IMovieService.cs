using MovieManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Service.Abstractions
{
    public interface IMovieService
    {
        Task<List<MovieServiceModel>> GetAllAsync();
        Task<List<MovieServiceModel>> GetAllActiveAsync();
        Task CreateAsync(MovieServiceModel movie);
        Task ChangeActiveStatusAsync(int movieId);
        Task CreateByModeratorAsync(MovieServiceModel movie);
        Task<MovieServiceModel> GetAsync(int id);
        Task UpdateAsync(MovieServiceModel movie);
        Task DeleteAsync(int id);
        Task<(MovieServiceModel, List<SessionServiceModel>)> GetMovieWithSessionsAsync(int movieId, string accId);
    }
}
