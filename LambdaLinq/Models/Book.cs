using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LambdaLinq.Models
{
    public class Book
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Range(1,10,ErrorMessage ="between 1 and 10 only")]
        public int Edition { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Publication Date")]
        [DataType(DataType.Date)]
        public DateTime Publication { get; set; }
    }
}