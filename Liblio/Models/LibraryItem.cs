using System;
using System.ComponentModel.DataAnnotations;

namespace Liblio.Models
{
    public class LibraryItem
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(255)]
        public string Author { get; set; }

        public int? Pages { get; set; }

        [Display(Name = "Runtime (minutes)")]
        public int? RunTimeMinutes { get; set; }

        [Required]
        public bool IsBorrowable { get; set; }

        public string Borrower { get; set; }

        public DateTime? BorrowDate { get; set; }

        [Required]
        public string Type { get; set; }
    }
}