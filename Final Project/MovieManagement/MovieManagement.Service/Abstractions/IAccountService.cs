using MovieManagement.Domain.POCO;
using MovieManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Service.Abstractions
{
    public interface IAccountService
    {
        Task<string> GetIdByEmail(string email);
        //Task<AccountServiceModel> GetLoggedInAccAsync();
        Task<string> AuthenticateAsync(string username, string password);
        Task<bool> AdminAndModeratorLogIn(string email, string password);
        Task LogOutAsync(string accId);
        Task<bool> UserLogIn(string email, string password);
        Task<string> GetRoleAsync(string email);
        Task ActivateAccount(string id);
        Task<List<AccountServiceModel>> GetAllAsync();
        Task<AccountServiceModel> GetAsync(string id);
        Task RegisterAccountAsync(AccountServiceModel account, bool useJwt);
        Task ChangeRoleAsync(string id, string roleName);
        Task DeleteAsync(string id);
    }
}
