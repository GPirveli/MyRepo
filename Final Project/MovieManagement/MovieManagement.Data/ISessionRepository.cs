using MovieManagement.Data.DTO;
using MovieManagement.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Data
{
    public interface ISessionRepository : IBaseRepository<Session>
    {
        Task ArchiveOldSessions();
        Task<List<Session>> GetAsyncByMovieId(int movieId);

        Task DeleteByMovieId(int id);

        //Task AddSessions(int movieId);
    }
}
