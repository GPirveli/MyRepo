using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieManagement.Service.Abstractions;
using MovieManagement.Service.Models;
using MovieManagement.Web.Models;
using MovieManagement.Web.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _service;

        public SessionController(ISessionService service)
        {
            _service = service;
        }

        //[Route("{movieId}")]
        //[HttpGet]
        //public async Task<List<SessionDTO>> GetSessionsByMovie(int movieId)
        //{
        //    //var accId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    var sessions = await _service.GetSessionByMovie();
        //    return sessions.Adapt<List<SessionDTO>>();
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetByMovie(MovieDTO movie)
        //{
        //    var sessions = await _service.GetSessionByMovie(movie.Title);

        //    if (sessions == null)
        //        throw new Exception();

        //    return Ok(sessions.Adapt<List<SessionDTO>>());
        //}

        //[HttpPost]
        //[Route("Sell")]
        //public async Task<IActionResult> SellTickets(SellTicketsRequest tickets)
        //{
        //    await _service.SellTicketsAsync(tickets.Adapt<SoldTicketServiceModel>());
        //    return Ok();
        //}

        //[HttpPost]
        //[Route("Booked")]
        //public async Task<IActionResult> BookTickets(BookTicketsRequest tickets)
        //{
        //    await _service.BookTicketsAsync(tickets.Adapt<BookedTicketServiceModel>());
        //    return Ok();
        //}

        //[HttpPost]
        //[Route("Unbook")]
        //public async Task<IActionResult> UnbookTickets(int id)
        //{
        //    await _service.UnbookTicketsAsync(id);
        //    return Ok();
        //}

        //[HttpPost]
        //[Route("Book")]
        //public async Task<IActionResult> SellBookedTickets(int id)
        //{
        //    await _service.UnbookTicketsAsync(id);
        //    await _service.SellBookedTicketsAsync(id);
        //    return Ok();
        //}



    }
}
