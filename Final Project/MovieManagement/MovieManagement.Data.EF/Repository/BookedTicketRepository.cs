using Microsoft.EntityFrameworkCore;
using MovieManagement.Data;
using MovieManagement.Domain;
using MovieManagement.Domain.POCO;
using MovieManagement.PersistanceDB.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Data.EF.Repository
{
    public class BookedTicketRepository : BaseRepository<BookedTicket>, IBookedTicketRepository
    {
        public BookedTicketRepository(MovieManagementContext context) : base(context)
        {

        }

        

        public async Task DeactivateAsync(int id)
        {
            var ticket = await GetAsync(id);
            ticket.IsActive = false;
            await _context.SaveChangesAsync();
        }

        public async Task DeactivateAsync(BookedTicket tickets)
        {
            var ticket = await GetAsync(tickets.Id);
            ticket.IsActive = false;
            await _context.SaveChangesAsync();
        }

        public async Task<List<BookedTicket>> GetActiveByAccIdAsync(string accId)
        {
            return await _dbSet.Where(x => x.IsActive && x.AccountId == accId).ToListAsync();
        }

        public async Task<List<BookedTicket>> GetByAccountIdAndSessionId(string accId, int sessionId)
        {
            return await _dbSet.Where(x => x.AccountId == accId && x.SessionId == sessionId && x.IsActive).ToListAsync();
        }
    }
}
