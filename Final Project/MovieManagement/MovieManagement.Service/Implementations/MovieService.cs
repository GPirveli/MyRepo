using MovieManagement.Data;
using MovieManagement.Service.Abstractions;
using MovieManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using System.Linq;
using MovieManagement.Domain.POCO;

namespace MovieManagement.Service.Implementations
{
    public class MovieService : IMovieService
    {
        private IMovieRepository _repo;
        private ISessionRepository _sessionRepo;
        private ISessionService _sessionService;
        private IBookedTicketRepository _bookedTicketsRepo;
        private ISoldTicketsRepository _soldTicketsRepo;

        public MovieService(IMovieRepository repo, ISessionRepository sessionRepo, ISessionService sessionService, IBookedTicketRepository bookedTicketsRepository, ISoldTicketsRepository soldTicketsRepo)
        {
            _repo = repo;
            _sessionRepo = sessionRepo;
            _sessionService = sessionService;
            _bookedTicketsRepo = bookedTicketsRepository;
            _soldTicketsRepo = soldTicketsRepo;
        }

        public async Task<List<MovieServiceModel>> GetAllAsync()
        {
            var result = await _repo.GetAllAsync();

            return result.Adapt<List<MovieServiceModel>>();
        }

        public async Task CreateAsync(MovieServiceModel movie)
        {
            var adaptedMovie = movie.Adapt<Movie>();
            await _repo.CreateAsync(adaptedMovie);
        }

        public async Task ChangeActiveStatusAsync(int movieId)
        {
            await _repo.ChangeActiveStatusAsync(movieId);
            var deactivatedMovie = await GetAsync(movieId);
            if (deactivatedMovie.IsActive)
                await _sessionService.CreateAsync(deactivatedMovie.Title);
            else
                await _sessionRepo.DeleteByMovieId(movieId);
        }

        public async Task CreateByModeratorAsync(MovieServiceModel movie)
        {
            await _repo.CreateInactive(movie.Adapt<Movie>());
        }

        public async Task<MovieServiceModel> GetAsync(int id)
        {
            var movie = await _repo.GetAsync(id);
            return movie.Adapt<MovieServiceModel>();
        }

        public async Task UpdateAsync(MovieServiceModel movie)
        {
            var movieToUpdate = movie.Adapt<Movie>();
            await _repo.UpdateAsync(movieToUpdate);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.RemoveAsync(id);
            await _sessionRepo.DeleteByMovieId(id);
        }

        public async Task<(MovieServiceModel, List<SessionServiceModel>)> GetMovieWithSessionsAsync(int movieId, string accId)
        {
            var movie = (await _repo.GetAsync(movieId)).Adapt<MovieServiceModel>();
            var sessions = (await _sessionRepo.GetAsyncByMovieId(movieId)).Adapt<List<SessionServiceModel>>();
            
            
            foreach (var session in sessions)
            {
                var usersBookedTicket = await _bookedTicketsRepo.GetByAccountIdAndSessionId(accId, session.Id);
                var usersBoughtTicket = await _soldTicketsRepo.GetByAccountIdAndSessionId(accId, session.Id);
                if (usersBookedTicket.Count > 0)
                {
                    session.IsBooked = true;
                }else if(usersBoughtTicket.Count > 0)
                {
                    session.IsBought = true;
                }
            }
           
            return (movie, sessions);
        }

        public async Task<List<MovieServiceModel>> GetAllActiveAsync()
        {
            var movies = await _repo.GetAllActiveAsync();
            return movies.Adapt<List<MovieServiceModel>>();
        }
    }
}
