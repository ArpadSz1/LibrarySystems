using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.App.Models
{
    public class Book
    {
        [Key]
        public int InventoryNumber { get; set; }

        [Required]
        [MinLength(1)]
        public string Title { get; set; } = string.Empty;


        [Required]
        [MinLength(1)]
        public string Author { get; set; } = string.Empty;


        [Required]
        [MinLength(1)]
        public string Publisher { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "YearPublished must be a positive integer number.")]
        public int YearPublished { get; set; }
    }
}
