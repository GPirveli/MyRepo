using Mapster;
using MovieManagement.Data;
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
    public class SoldTicketService : ISoldTicketService
    {
        private ISoldTicketsRepository _repo;
        private IBookTicketsService _bookedService;

        public SoldTicketService(ISoldTicketsRepository repo, IBookTicketsService bookedService)
        {
            _repo = repo;
            _bookedService = bookedService;
        }

        public async Task SellTicketsAsync(SoldTicketServiceModel tickets)
        {
            await _repo.CreateAsync(tickets.Adapt<SoldTicket>());
        }

        public async Task SellBookedTicketsAsync(BookedTicketServiceModel tickets)
        {
            var soldTickets = new SoldTicketServiceModel()
            {
                AccountId = tickets.AccountId,
                SessionId = tickets.SessionId
            };
            var soldTicketsTest = tickets.Adapt<SoldTicketService>();

            await _repo.CreateAsync(soldTickets.Adapt<SoldTicket>());
            await _bookedService.UnbookTicketsAsync(tickets.Id);
        }

        public async Task SellBookedTicketsAsync(string accId, int sessionId)
        {
            var soldTicket = new SoldTicket()
            {
                AccountId = accId,
                SessionId = sessionId
            };
            await _repo.CreateAsync(soldTicket);
            await _bookedService.UnbookTicketsAsync(accId, sessionId);
        }
    }
}
