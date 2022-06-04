using MovieManagement.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Data
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        //Task LogInAsync(Account account);
        Task LogOutAsync(string accId);
        Task<string> GetIdByEmail(string email);
        Task<Account> GetLoggedInAccAsync();
        Task<string> GetRoleAsync(string email);
        Task ActivateAsync(string Id);
        Task CreateAccountAsync(Account account);
        Task<bool> AdminAndModeratorLogIn(string email, string password);
        Task<Account> GetFullAsync(string id);
        Task<bool> UserLogIn(string email, string password);
        Task<Account> GetByUsernameAndPasswordAsync(string username, string password);
        Task DeleteAccAsync(string id);
        Task<List<Account>> GetAllActiveAccs();
        Task ChangeRoleAsync(string id, string roleName);
        //Task<List<Account>> GetAllWithRolesAsync();
        Task<Account> GetNoTrackingAsync(string id);
        //Task ChangeRole()
    }
}
