using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Helpers;
using Microsoft.AspNetCore.Http;

namespace BookStore.Models
{
    public class BookModel
    {
        //[DataType(DataType.EmailAddress)]   
        //[Display(Name = "New Field")]
        //[EmailAddress]
        //public string MyField { get; set; }
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter title of the book")]
        //[MyCustomValidation("hello", ErrorMessage = "Custom error message")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter name of the Author")]
        public string Author { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public string Category { get; set; }
        [Display(Name = "Total Pages of Book")]
        [Required(ErrorMessage = "Please enter Total Pages of the book")]
        public int? TotalPages { get; set; }
        [Required(ErrorMessage = "Please choose language")]
        public int LanguageId { get; set; }
        public string Language { get; set; }
        [Display(Name = "Please add Image of the book")]
        [Required]
        public IFormFile ImageCover { get; set; }
        public string CoverImageUrl { get; set; }

    }
}
