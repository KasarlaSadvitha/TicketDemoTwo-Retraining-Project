using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketDemoCoreWebApi.Models
{
    public class TBLUserInfo
    {
        [Key]
        public int IdUs { get; set; }

        public string UserRole { get; set; }  //**************************


        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }    //***************************


        [DataType(DataType.PhoneNumber)]
        public string MobileNumber { get; set; }   //**********************



        [Display(Name = "Username")]
        [Required(ErrorMessage = "this field is required")]
        public string UsernameUs { get; set; }


        [Display(Name = "Password")]
        [Required(ErrorMessage = "this field is required")]
        [DataType(DataType.Password)]
        public string PasswordUs { get; set; }

        [Display(Name = "ReEnterPassword")]
        [Required(ErrorMessage = "this field is required")]
        [DataType(DataType.Password)]
        [NotMapped]
        [Compare("PasswordUs", ErrorMessage = "Confirm password doesn't match , type again !")]
        public string RePasswordUs { get; set; }


    }
}
