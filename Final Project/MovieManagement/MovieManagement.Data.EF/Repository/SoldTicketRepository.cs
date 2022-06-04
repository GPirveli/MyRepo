using Microsoft.EntityFrameworkCore;
using MovieManagement.Data.DTO;
using MovieManagement.Domain.POCO;
using MovieManagement.PersistanceDB.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Data.EF.Repository
{
    public class SoldTicketRepository : BaseRepository<SoldTicket>, ISoldTicketsRepository
    {
        public SoldTicketRepository(MovieManagementContext context) : base(context)
        {

        }

        public async Task<List<SoldTicket>> GetByAccountIdAndSessionId(string accId, int sessionId)
        {
            return await _dbSet.Where(x => x.AccountId == accId && x.SessionId == sessionId).ToListAsync();
        }

        
    }
}
