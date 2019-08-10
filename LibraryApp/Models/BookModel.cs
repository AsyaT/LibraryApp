using LibraryApp.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace LibraryApp.Models
{
    public class BookModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Title cannot be longer than 30 characters.")]
        public string Title { get; set; }

        //TODO: custom attribure that at least one author exists
        public IEnumerable<AuthorModel> Authors { get; set; }

        [Required]
        [Range(1, 10000)]
        public uint NumberOfPages { get; set; }

        [StringLength(30, ErrorMessage = "Publisher name cannot be longer than 20 characters.")]
        public string Publisher { get; set; }

        [Required]
        [YearMinimumRange(1800)]
        public int YearOfPublication { get; set; }

        [DataType(DataType.Upload)]
        public HttpPostedFileBase Image { get; set; } 
    }
}