using Microsoft.EntityFrameworkCore;
using MovieManagement.Domain.POCO;
using MovieManagement.PersistanceDB.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace MovieManagement.Data.EF.Repository
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        private readonly UserManager<Account> _userManager;
        private readonly SignInManager<Account> _signInManager;
        public AccountRepository(MovieManagementContext context, UserManager<Account> userManager, SignInManager<Account> signInManager) : base(context)
        {
            _userManager = userManager;
            _signInManager =signInManager;
        }

        public async Task ActivateAsync(string id)
        {
            var account = await GetAsync(id);
            account.IsActive = true;
            await _context.SaveChangesAsync();
        }

       

        public async Task ChangeRoleAsync(string id, string newRoleName)
        {
            var account = await GetAsync(id);
            var currentRole = await _userManager.GetRolesAsync(account);
            await _userManager.RemoveFromRolesAsync(account, currentRole);
            await _userManager.AddToRoleAsync(account, newRoleName);
            account.Role = newRoleName;
            //await UpdateAsync(account);
            _context.SaveChanges();
        }

        public async Task CreateAccountAsync(Account account)
        {
            account.IsActive = true;
            account.Role = "RegisteredUser";
            await _userManager.CreateAsync(account, account.Password);
            await _userManager.AddToRoleAsync(account, "RegisteredUser");
        }

        public async Task DeleteAccAsync(string id)
        {
            var acc = await GetAsync(id);
            acc.IsActive = false;
            await _context.SaveChangesAsync();

        }

        public async Task<List<Account>> GetAllActiveAccs()
        {
            var allAccs = await GetAllAsync();
            return allAccs.Where(x => x.IsActive).ToList();
        }

        //public Task<List<Account>> GetAllWithRolesAsync()
        //{
        //    var accounts = 
        //}

        public async Task<Account> GetByUsernameAndPasswordAsync(string username, string password)
        {
            //if ((await _signInManager.PasswordSignInAsync(username, password, false, false)).Succeeded)
            //{
                return await Table.SingleOrDefaultAsync(x => x.UserName == username && x.Password == password);
            
            //}
        }

        public async Task<string> GetIdByEmail(string email)
        {
            return (await _dbSet.SingleOrDefaultAsync(x => x.UserName == email)).Id;
        }

        public Task<Account> GetLoggedInAccAsync()
        {
            throw new NotImplementedException();
        }

        //public Task<Account> GetLoggedInAccAsync()
        //{
        //    return _userManager.getUser
        //}

        public async Task<Account> GetNoTrackingAsync(string id)
        {
            return await _dbSet.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<string> GetRoleAsync(string email)
        {
            var account = await _dbSet.SingleOrDefaultAsync(x => x.UserName == email);
            return (await _userManager.GetRolesAsync(account)).FirstOrDefault();
        }
        public async Task<bool> AdminAndModeratorLogIn(string username, string password)
        {

            var canSignIn = (await _signInManager.PasswordSignInAsync(username, password, false, false)).Succeeded;
            var account = _dbSet.SingleOrDefault(x => x.UserName == username);
            var isAdminOrModerator = (await _userManager.IsInRoleAsync(account, "Admin")) || (await _userManager.IsInRoleAsync(account, "Moderator"));
            var result = canSignIn && isAdminOrModerator;
            //await _signInManager.SignInAsync(_dbSet.SingleOrDefault(x => x.UserName == email), isPersistent: false);
            //await _signInManager.SignInAsync(_dbSet.SingleOrDefault(x => x.UserName == email), false, ""); 
            //var test = await _userManager.IsInRoleAsync(_dbSet.SingleOrDefault(x => x.UserName == email), "Admin");

            //_signInManager.IsSignedIn();
            return result;

        }
        public async Task<bool> UserLogIn(string email, string password)
        {
            var canSignIn = (await _signInManager.PasswordSignInAsync(email, password, false, false)).Succeeded;
            return canSignIn;
        }

        public async Task<Account> GetFullAsync(string id)
        {
            return await _dbSet.Include("BookedTickets").AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task LogOutAsync(string accId)
        {
            await _signInManager.SignOutAsync();
        }



        //public Task LogInAsync(Account account)
        //{

        //}




        //public Task CreateAsync(Account acc)
        //{

        //}
    }
}
