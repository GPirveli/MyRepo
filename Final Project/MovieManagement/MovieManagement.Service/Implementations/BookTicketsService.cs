using Mapster;
using MovieManagement.Data;
using MovieManagement.Domain;
using MovieManagement.Domain.POCO;
using MovieManagement.Service.Abstractions;
using MovieManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Service.Implementations
{
    public class BookTicketsService : IBookTicketsService
    {
        private IBookedTicketRepository _repo;
        private ISessionRepository _sessionRepo;

        public BookTicketsService(IBookedTicketRepository repo, ISessionRepository sessionRepo)
        {
            _repo = repo;
            _sessionRepo = sessionRepo;
        }

        public async Task BookTicketsAsync(BookedTicketServiceModel ticket)
        {
            var session = await _sessionRepo.GetAsync(ticket.SessionId);
            if(DateTime.Now.AddHours(1) < session.StartTime)
                await _repo.CreateAsync(ticket.Adapt<BookedTicket>());
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.RemoveAsync(id);
        }

        public async Task<List<BookedTicketServiceModel>> GetByUserIdAsync(string accId)
        {
            var tickets = await _repo.GetActiveByAccIdAsync(accId);
            return tickets.Adapt<List<BookedTicketServiceModel>>();
        }
        public async Task UnbookTicketsAsync(int id)
        {
            var ticketsToDeactivate = await _repo.GetAsync(id);
            await _repo.DeactivateAsync(ticketsToDeactivate);
        }

        public async Task UnbookTicketsAsync(string accId, int sessionId)
        {
            var ticketsToDeactivate = await _repo.GetByAccountIdAndSessionId(accId, sessionId);
            foreach (var ticket in ticketsToDeactivate)
            {
                await _repo.DeactivateAsync(ticket.Id);
            }
        }
    }
}
