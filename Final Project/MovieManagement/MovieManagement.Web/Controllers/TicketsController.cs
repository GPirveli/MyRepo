using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieManagement.Service.Abstractions;
using MovieManagement.Service.Models;
using MovieManagement.Web.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieManagement.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ISoldTicketService _soldTicketService;
        private readonly IBookTicketsService _bookTicketsService;
        public TicketsController(ISoldTicketService soldTicketService, IBookTicketsService bookTicketsService)
        {
            _soldTicketService = soldTicketService;
            _bookTicketsService = bookTicketsService;
        }

        [Route("Sell")]
        [HttpPost]
        //[HttpGet]
        public async Task SellTicket([FromBody]int sessionId)
        {
            var request = new SellTicketsRequest()
            {
                SessionId = sessionId,
                AccountId = User.FindFirstValue(ClaimTypes.NameIdentifier),
            };
            await _soldTicketService.SellTicketsAsync(request.Adapt<SoldTicketServiceModel>());
        }

        [Route("Book")]
        [HttpPost]
        public async Task BookTicket([FromBody] int sessionId)
        {
            var request = new BookTicketsRequest()
            {
                SessionId = sessionId,
                AccountId = User.FindFirstValue(ClaimTypes.NameIdentifier),
            };

            await _bookTicketsService.BookTicketsAsync(request.Adapt<BookedTicketServiceModel>());

        }

        [Route("Unbook")]
        [HttpPost]
        public async Task UnbookTicket([FromBody] int sessionId)
        {
            var accountId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _bookTicketsService.UnbookTicketsAsync(accountId, sessionId);
        }

        [Route("SellBooked")]
        [HttpPost]
        public async Task SellBookedTicket([FromBody] int sessionId)
        {
            var accountId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _soldTicketService.SellBookedTicketsAsync(accountId, sessionId);
        }
    }
}
