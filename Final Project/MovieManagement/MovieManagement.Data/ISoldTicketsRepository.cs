using MovieManagement.Data.DTO;
using MovieManagement.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Data
{
    public interface ISoldTicketsRepository : IBaseRepository<SoldTicket>
    {
        //Task SellTicketsAsync(SellTicketDTO request);
        Task<List<SoldTicket>> GetByAccountIdAndSessionId(string accId, int sessionId);
    }
}
