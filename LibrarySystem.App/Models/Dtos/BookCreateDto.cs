using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.App.Models.Dtos
{
    public class BookCreateDto
    {

        [Required]
        public int InventoryNumber { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Author { get; set; } = string.Empty;

        [Required]
        public string Publisher { get; set; } = string.Empty;

        [Required]
        [Range(0, int.MaxValue)]
        public int YearPublished { get; set; }
    }
}