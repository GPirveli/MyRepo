using Mapster;
using MovieManagement.Data;
using MovieManagement.Data.DTO;
using MovieManagement.Domain.POCO;
using MovieManagement.Service.Abstractions;
using MovieManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Service.Implementations
{
    public class SessionService : ISessionService
    {
        private ISessionRepository _sessionRepo;
        private IBookedTicketRepository _bookedRepo;
        private ISoldTicketService _soldTicketService;
        private IBookTicketsService _bookedTicketService;
        private IMovieRepository _movieRepo;

        public SessionService(ISessionRepository sessionRepo, ISoldTicketService soldTicketService, IBookTicketsService bookedTicketService, IMovieRepository movieRepo, IBookedTicketRepository bookedRepo)
        {
            _sessionRepo = sessionRepo;
            _soldTicketService = soldTicketService;
            _bookedTicketService = bookedTicketService;
            _movieRepo = movieRepo;
            _bookedRepo = bookedRepo;
        }

        public async Task<List<SessionServiceModel>> GetSessionByMovie(string movieTitle)
        {
            var movie = _movieRepo.GetAsync(movieTitle);
            var session = await _sessionRepo.GetAsyncByMovieId(movie.Id);

            if (session == null)
                throw new Exception();

            return session.Adapt<List<SessionServiceModel>>();
        }

        public async Task BookTicketsAsync(BookedTicketServiceModel tickets)
        {
            var session = await _sessionRepo.GetAsync(tickets.SessionId);

                await _sessionRepo.UpdateAsync(session);

                await _bookedTicketService.BookTicketsAsync(tickets);
        }

        public async Task SellTicketsAsync(SoldTicketServiceModel tickets)
        {
            var session = await _sessionRepo.GetAsync(tickets.SessionId);

                await _sessionRepo.UpdateAsync(session);

                await _soldTicketService.SellTicketsAsync(tickets);
        }

        public async Task UnbookTicketsAsync(int ticketId)
        {
            await _bookedTicketService.UnbookTicketsAsync(ticketId);
            var tickets = await _bookedRepo.GetAsync(ticketId);
            var sessionToUpdate = await _sessionRepo.GetAsync(tickets.SessionId);
            await _sessionRepo.UpdateAsync(sessionToUpdate);
        }

        public async Task SellBookedTicketsAsync(int ticketsId)
        {
            await _bookedTicketService.UnbookTicketsAsync(ticketsId);
            var newTickets = _bookedRepo.GetAsync(ticketsId);
            await _soldTicketService.SellTicketsAsync(newTickets.Adapt<SoldTicketServiceModel>());
        }

        public async Task CreateAsync(string movieTitle)
        {
            var movie = await _movieRepo.GetAsyncByTitle(movieTitle);
            var sessions = new List<Session>();
            int days = 7;
            int sessionInDay = 3;
            for (int i = 0; i < days; i++)
            {
                var time = DateTime.Today.AddHours(12).AddDays(i);

                for (int j = 0; j < sessionInDay; j++)
                {
                    var session = new Session()
                    {
                        MovieId = movie.Id,
                        StartTime = time
                    };
                    time = time.AddHours(3);
                    sessions.Add(session);
                }
            }

            foreach (var session in sessions)
            {
                await _sessionRepo.CreateAsync(session);
            }
        }
    }
}
