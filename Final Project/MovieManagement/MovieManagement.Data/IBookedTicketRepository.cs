using MovieManagement.Data.DTO;
using MovieManagement.Domain;
using MovieManagement.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Data
{
    public interface IBookedTicketRepository : IBaseRepository<BookedTicket>
    {
        Task DeactivateAsync(int id);
        Task DeactivateAsync(BookedTicket tickets);
        Task<List<BookedTicket>> GetActiveByAccIdAsync(string accId);
        Task<List<BookedTicket>> GetByAccountIdAndSessionId(string accId, int sessionId);
    }
}
