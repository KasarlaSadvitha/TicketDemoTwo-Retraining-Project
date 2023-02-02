using System.ComponentModel.DataAnnotations;

namespace TicketDemoCoreWebApi.Models
{
    public class TBLMovieDetails
    {

        [Key]
        public int MovieId { get; set; }

        [Required]
        [StringLength(100)]
        public string MovieName { get; set; }

        [Required]
        [StringLength(100)]
        public string Genre { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [StringLength(100)]
        public string Language { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public int Duration { get; set; }

        public string Director { get; set; }

        public string PosterUrl { get; set; }




    }
}
