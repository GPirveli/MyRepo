using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieManagement.Admin.Models;
using MovieManagement.Admin.Models.Requests;
using MovieManagement.Domain.POCO;
using MovieManagement.Service.Abstractions;
using MovieManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Admin.Controllers
{
    
    [Authorize(Roles = "Admin,Moderator")]
    public class AdminController : Controller
    {
        private readonly IAccountService _accService;
        private readonly IMovieService _movieService;
        private readonly ISessionService _sessionService;
        private readonly IBookTicketsService _bookedTicketService;

        public AdminController(IAccountService accService, IMovieService movieService, ISessionService sessionService, IBookTicketsService bookedTicketService)
        {
            _accService = accService;
            _movieService = movieService;
            _sessionService = sessionService;
            _bookedTicketService = bookedTicketService;
        }

        [HttpGet]
        public async Task<IActionResult> ListAccounts()
        {
            var accountViews = (await _accService.GetAllAsync()).Adapt<List<AccountViewModel>>();
            return View(accountViews);
        }

        [HttpGet]
        public async Task<IActionResult> ListMovies()
        {
            var movieViews = (await _movieService.GetAllAsync()).Adapt<List<MovieViewModel>>();
            return View(movieViews);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CreateMovie()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateMovie(CreateMovieRequest request)
        {
            await _movieService.CreateAsync(request.Adapt<MovieServiceModel>());
            await _sessionService.CreateAsync(request.Title);

            return RedirectToAction("ListMovies");
        }

        [Authorize(Roles = "Moderator")]
        public IActionResult CreateMovieByModerator()
        {
            return View();
        }

        [Authorize(Roles = "Moderator")]
        [HttpPost]
        public async Task<IActionResult> CreateMovieByModerator(CreateMovieRequest request)
        {
            await _movieService.CreateByModeratorAsync(request.Adapt<MovieServiceModel>());
            return RedirectToAction("CreateMovieByModerator");
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeActiveStatus(int movieId)
        {
            await _movieService.ChangeActiveStatusAsync(movieId);
            return RedirectToAction("ListMovies");
        }

        [HttpGet]
        public async Task<IActionResult> EditMovie(int movieId)
        {
            var movie = await _movieService.GetAsync(movieId);
            var movieEdit = movie.Adapt<EditMovieRequest>();
            return View(movieEdit);
        }

        [HttpPost]
        public async Task<IActionResult> EditMovie(EditMovieRequest request)
        {
            var movie = request.Adapt<MovieServiceModel>();
            await _movieService.UpdateAsync(movie);
            return RedirectToAction("ListMovies");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeRole(string accId, string roleName)
        {
            await _accService.ChangeRoleAsync(accId, roleName);
            return RedirectToAction("ListAccounts");
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> DeleteAccount(string accId)
        {

            await _accService.DeleteAsync(accId);

            return RedirectToAction("ListAccounts");
        }

        public async Task<IActionResult> DeleteMovie(int movieId)
        {
            await _movieService.DeleteAsync(movieId);
            return RedirectToAction("ListMovies");
        }
        
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> ActivateAccount(string accId)
        {
            await _accService.ActivateAccount(accId);
            return RedirectToAction("ListAccounts");
        }

        
        public async Task<IActionResult> GetBookedTicketsByUser(string accId)
        {
            var tickets = (await _bookedTicketService.GetByUserIdAsync(accId)).Adapt<List<BookedTicketViewModel>>();
            return View(tickets);
        }

        public async Task<IActionResult> DeleteBookedTicket(int ticketId, string accId)
        {
            await _bookedTicketService.DeleteAsync(ticketId);
            return RedirectToAction("GetBookedTicketsByUser", "Admin", new { accId });
        }
    }
}
