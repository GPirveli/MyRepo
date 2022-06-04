using MovieManagement.Data.DTO;
using MovieManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Service.Abstractions
{
    public interface ISessionService
    {
        Task CreateAsync(string movieTitle);
        Task SellTicketsAsync(SoldTicketServiceModel tickets);
        Task UnbookTicketsAsync(int ticketId);

        Task SellBookedTicketsAsync(int ticketsId);

        Task BookTicketsAsync(BookedTicketServiceModel tickets);
        Task<List<SessionServiceModel>> GetSessionByMovie(string movieTitle);
    }
}
