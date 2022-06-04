using MovieManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Service.Abstractions
{
    public interface ISoldTicketService
    {
        Task SellTicketsAsync(SoldTicketServiceModel request);
        Task SellBookedTicketsAsync(BookedTicketServiceModel tickets);
        Task SellBookedTicketsAsync(string accId, int sessionId);
    }
}
