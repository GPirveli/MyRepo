using Mapster;
using Microsoft.AspNetCore.Identity;
using MovieManagement.Data;
using MovieManagement.Domain.POCO;
using MovieManagement.Service.Abstractions;
using MovieManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Service.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IJWTService _jwtService;
        private readonly IAccountRepository _repo;

        public AccountService(IAccountRepository repo, IJWTService jwtService, UserManager<Account> userManager)
        {
            _repo = repo;
            _jwtService = jwtService;
        }

        public async Task ActivateAccount(string id)
        {
            await _repo.ActivateAsync(id);
        }

        public Task<bool> AdminAndModeratorLogIn(string email, string password)
        {
            return _repo.AdminAndModeratorLogIn(email, password);
        }

        public async Task<string> AuthenticateAsync(string username, string password)
        {
            var userEntity = await _repo.GetByUsernameAndPasswordAsync(username, password);

            if (userEntity == null)
                throw new Exception();

            return _jwtService.GenerateSecurityToken(userEntity.UserName, userEntity.Id);
        }

        public async Task ChangeRoleAsync(string id, string roleName)
        {
            await _repo.ChangeRoleAsync(id, roleName);
        }

        public async Task DeleteAsync(string id)
        {
            await _repo.DeleteAccAsync(id);
        }

        public async Task<List<AccountServiceModel>> GetAllAsync()
        {
            var accounts = await _repo.GetAllAsync();
            var adaptedAccounts = accounts.Adapt<List<AccountServiceModel>>();
            return adaptedAccounts;
        }

        public async Task<AccountServiceModel> GetAsync(string id)
        {
            var account = await _repo.GetAsync(id);
            return account.Adapt<AccountServiceModel>();
        }

        public async Task<string> GetIdByEmail(string email)
        {
            return await _repo.GetIdByEmail(email);
        }
        public async Task<string> GetRoleAsync(string email)
        {
            var role = await _repo.GetRoleAsync(email);
            return role;
        }

        public async Task LogOutAsync(string accId)
        {
            await _repo.LogOutAsync(accId);
        }

        public async Task RegisterAccountAsync(AccountServiceModel account, bool useJwt)
        {
            await _repo.CreateAccountAsync(account.Adapt<Account>());
            if (useJwt)
                await AuthenticateAsync(account.UserName, account.Password);
            else
            await _repo.UserLogIn(account.UserName, account.Password);
        }

        public async Task<bool> UserLogIn(string email, string password)
        {
            return await _repo.UserLogIn(email, password);
        }
    }
}
