using LibraryApp.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace LibraryApp.Models
{
    public class BookModel
    {
        public BookModel()
        {
            Authors = new List<AuthorModel>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Title cannot be longer than 30 characters.")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [NotEmptyCollection]
        [NameisValid]
        [Display(Name = "Authors")]
        public IList<AuthorModel> Authors { get; set; }

        [Required]
        [Range(1, 10000)]
        [Display(Name = "Number of pages")]
        public uint NumberOfPages { get; set; }

        [StringLength(30, ErrorMessage = "Publisher name cannot be longer than 20 characters.")]
        [Display(Name = "Name of publisher")]
        public string Publisher { get; set; }

        [Required]
        [YearMinimumRange(1800)]
        [Display(Name = "Year of publication")]
        public int YearOfPublication { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Image")]
        public HttpPostedFileBase Image { get; set; } 
    }
}