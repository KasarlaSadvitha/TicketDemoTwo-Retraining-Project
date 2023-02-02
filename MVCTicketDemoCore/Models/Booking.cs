using System.ComponentModel.DataAnnotations;

namespace MVCTicketDemoCore.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }


        public int TotalTickets { get; set; }

        public double TotalCost { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public string MovieName { get; set; }


        public string UserName { get; set; }



        public virtual TBLMovieDetails MovieDetails { get; set; }
        public virtual TBLUserInfo User { get; set; }
    }
}
