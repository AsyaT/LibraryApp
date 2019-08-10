using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    public class AuthorModel
    {
        [StringLength(20, ErrorMessage = "First name cannot be longer than 20 characters.")]
        public string FirstName { get; set; }

        [StringLength(20, ErrorMessage = "Last name cannot be longer than 20 characters.")]
        public string LastName { get; set; }
    }
}