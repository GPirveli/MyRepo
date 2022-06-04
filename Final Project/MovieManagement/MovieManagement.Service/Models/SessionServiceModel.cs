using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Service.Models
{
    public class SessionServiceModel
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int RoomId { get; set; }
        public DateTime StartTime { get; set; }
        public int TicketsLeft { get; set; }
        public bool IsBooked { get; set; }
        public bool IsBought { get; set; }
    }
}
