using System.ComponentModel.DataAnnotations;

namespace TicketDemoCoreWebApi.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }


        public int TotalTickets { get; set; }

        public double TotalCost { get; set; }


        public DateTime Date { get; set; }

        public string MovieName { get; set; }


        public string UserName { get; set; }


    }
}
