using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    public class AuthorModel
    {
        [Required]
        [StringLength(20, ErrorMessage = "First name cannot be longer than 20 characters.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Last name cannot be longer than 20 characters."))]
        public string LastName { get; set; }
    }
}