using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.App.Models.Dtos
{
    public class ReaderUpdateDto
    {

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        [Range(1900, int.MaxValue)]
        public int BirthYear { get; set; }
    }
}
