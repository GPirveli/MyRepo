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
    public class SessionRepository : BaseRepository<Session>, ISessionRepository
    {
        public SessionRepository(MovieManagementContext context) : base(context)
        {

        }

        public async Task AddSessions(int movieId)
        {

        }

        public async Task ArchiveOldSessions()
        {
            var oldSessions = await _dbSet.Where(x => x.StartTime < DateTime.Now).ToListAsync();
            oldSessions.ForEach(x => x.IsActive = false);
            oldSessions.ForEach(async x => await CreateAsync(new Session()
            {
                MovieId = x.MovieId,
                StartTime = x.StartTime.AddDays(7),
                IsActive = true
            }));
            _context.SaveChanges();
        }

        public async Task DeleteByMovieId(int movieId)
        {
            var sessionsToDelete = await _dbSet.Where(x => x.MovieId == movieId && x.IsActive).ToListAsync();

            foreach (var session in sessionsToDelete)
            {
                await RemoveAsync(session.Id);
            }
        }

        public async Task<List<Session>> GetAsyncByMovieId(int movieId)
        {
            return await _dbSet.Where(x => x.MovieId == movieId && x.IsActive).ToListAsync();
        }


    }
}
