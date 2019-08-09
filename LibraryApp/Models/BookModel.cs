using LibraryApp.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Title cannot be longer than 20 characters.")]
        public string Title { get; set; }

        //TODO: custom attribure that at least one author exists
        public IEnumerable<AuthorModel> Authors { get; set; }

        [Required]
        [Range(1, 10000)]
        public uint NumberOfPages { get; set; }

        [StringLength(30, ErrorMessage = "Publisher name cannot be longer than 20 characters.")]
        public string Publisher { get; set; }

        [DataType(DataType.Date)]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        [YearMinimumRange(1800)]
        public DateTime YearOfPublication { get; set; }

        public string Image { get; set; } // TODO: save image
    }
}