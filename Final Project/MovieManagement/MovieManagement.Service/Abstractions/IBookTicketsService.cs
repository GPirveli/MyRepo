using MovieManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Service.Abstractions
{
    public interface IBookTicketsService
    {
        Task BookTicketsAsync(BookedTicketServiceModel tickets);
        Task UnbookTicketsAsync(string accId, int sessionId);
        Task UnbookTicketsAsync(int id);
        Task DeleteAsync(int id);
        Task<List<BookedTicketServiceModel>> GetByUserIdAsync(string accId);
    }
}
